using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TrainCrew;

namespace ntncCrewHud
{
    public partial class Form1 : Form
    {
        bool InGame = false;

        // Determines whether to show the stopbar
        bool NearStation = false;

        Process TcProcess = null;
        IntPtr TcWindowHandle = IntPtr.Zero;
        Rectangle TcWindowBounds;

        List<Station> DiagramStations = null;
        Station NextStation = null;

        StationInfo[] TatehamaLineInfo;

        readonly string TcName = "TrainCrew";
        readonly string StaErrorName = "－－－－－";

        int TimerLongTicks = 0;

        Bitmap BmBar;
        int BarWidth = 20;
        int PixelsPerMeter = 75;
        int CenterLineThickness = 4;
        int MarkerThickness = 3;
        float MaxDistance = 20;

        Bitmap BmPlatform;
        int CellWidth = 20;
        int CellThickness = 1;

        Color Blue1 = Color.FromArgb(192, 224, 248);
        Color Blue2 = Color.FromArgb(112, 160, 208);
        Color Blue3 = Color.FromArgb(56, 80, 128);
        Color Orange = Color.FromArgb(255, 168, 0);

        Font PlatformGuideFont = new Font("Yu Gothic", 12, FontStyle.Bold);

        SolidBrush SbBlue1;
        SolidBrush SbBlue2;
        SolidBrush SbBlue3;
        SolidBrush SbOrange;
        SolidBrush SbWhite;

        public Form1()
        {
            InitializeComponent();
            
            timerLong.Start();

            TatehamaLineInfo = new StationInfo[] { Tatehama, Komano, Kawarazaki, KaiganKoen, Nijigahama,
                Tsuzaki, Hamazono, Hagoromobashi, Araigawa, ShinNozaki,
                Enohara, EnoharaSignal, Daidoji, Fujie, Mizukoshi,
                Takamizawa, Hinomori, Okumineguchi, NishiAkayama, Akayamacho };

            BmBar = new Bitmap(BarWidth, this.Height);

            pictureBoxPlatform.Width = CellWidth * 6;
            BmPlatform = new Bitmap(pictureBoxPlatform.Width, pictureBoxPlatform.Height);

            SbBlue1 = new SolidBrush(Blue1);
            SbBlue2 = new SolidBrush(Blue2);
            SbBlue3 = new SolidBrush(Blue3);
            SbOrange = new SolidBrush(Orange);
            SbWhite = new SolidBrush(Color.White);

            TrainCrewInput.Init();
        }

        // This is run roughly every frame when the overlay is active
        private void timerFrame_Tick(object sender, EventArgs e)
        {
            TrainState trainState = TrainCrewInput.GetTrainState();

            btnTimeNow.Text = trainState.NowTime.ToString(@"hh\:mm\:ss");
            btnTimeNow.Refresh();

            btnDistance.Text = $"{Math.Max(0, trainState.nextUIDistance / 1000) :F1} km";

            // Appears when the station object starts blinking
            if (NearStation)
            {
                Graphics gb = Graphics.FromImage(BmBar);
                gb.Clear(this.TransparencyKey);

                // Actual stopbar background
                int stopbarTop = this.Height / 2 - 3 * PixelsPerMeter;
                gb.FillRectangle(SbBlue3, new Rectangle(0, stopbarTop, BarWidth, PixelsPerMeter));
                gb.FillRectangle(SbBlue3, new Rectangle(0, stopbarTop + 5 * PixelsPerMeter, BarWidth, PixelsPerMeter));
                gb.FillRectangle(SbBlue2, new Rectangle(0, stopbarTop + PixelsPerMeter, BarWidth, 4 * PixelsPerMeter));
                gb.FillRectangle(SbBlue1, new Rectangle(0, stopbarTop + 2 * PixelsPerMeter, BarWidth, 2 * PixelsPerMeter));
                gb.FillRectangle(SbWhite, new Rectangle(0, stopbarTop + 3 * PixelsPerMeter - CenterLineThickness / 2, BarWidth, CenterLineThickness));

                // Only draw the marker when very close
                if (trainState.nextStaDistance < MaxDistance)
                {
                    int markerCenterY = (int)(this.Height / 2 - trainState.nextStaDistance * PixelsPerMeter);

                    Point[] poly = new Point[]
                    {
                        new Point(BarWidth / 2, markerCenterY - BarWidth / 2),
                        new Point(BarWidth, markerCenterY),
                        new Point(BarWidth / 2, markerCenterY + BarWidth / 2),
                        new Point(0, markerCenterY)
                    };
                    gb.FillPolygon(SbOrange, poly);

                    Point[] poly2 = new Point[]
                    {
                        new Point(BarWidth / 2, markerCenterY - BarWidth / 2 + MarkerThickness),
                        new Point(BarWidth - MarkerThickness, markerCenterY),
                        new Point(BarWidth / 2, markerCenterY + BarWidth / 2 - MarkerThickness),
                        new Point(MarkerThickness, markerCenterY)
                    };
                    gb.FillPolygon(SbWhite, poly2);
                }

                pictureBoxBar.Image = BmBar;
                gb.Dispose();

                pictureBoxBar.Visible = true;
            }
            else
            {
                pictureBoxBar.Visible = false;
            }
            pictureBoxBar.Refresh();
        }

        // This is run at a longer interval
        private void timerLong_Tick(object sender, EventArgs e)
        {
            TimerLongTicks++;

            GameState gameState = TrainCrewInput.gameState;
            TrainState trainState = TrainCrewInput.GetTrainState();

            if (TcWindowHandle == IntPtr.Zero)
            {
                // Find the game process
                Process[] allProcesses = Process.GetProcesses();
                foreach (Process p in allProcesses)
                {
                    if (p.ProcessName.Contains(TcName))
                    {
                        TcProcess = p;
                        break;
                    }
                }

                if (TcProcess != null)
                {
                    // Get the window after the process was found
                    TcWindowHandle = TcProcess.MainWindowHandle;
                }
            }

            if (TcProcess == null || TcProcess.HasExited)
            {
                TcProcess = null;
                TcWindowHandle = IntPtr.Zero;
            }
            else
            {
            // Try to get window bounds
            bool getRectSuccess = Window.GetWindowBounds(TcWindowHandle, out TcWindowBounds);

                if (getRectSuccess)
                {
                    // Check if the game window corresponds exactly to a screen ==> assume fullscreen
                    bool fullscreen = false;
                    foreach (Screen s in Screen.AllScreens)
                    {
                        if (s.Bounds == TcWindowBounds)
                        {
                            fullscreen = true;
                        }
                    }

                    
                    if (fullscreen)
                    {
                        this.Bounds = TcWindowBounds;
                    }
                    else
                    {
                        // Perform corrections if not in fullscreen
                        this.Location = new Point(TcWindowBounds.Left, TcWindowBounds.Top + SystemInformation.CaptionHeight);
                        this.Size = new Size(TcWindowBounds.Width, TcWindowBounds.Height - SystemInformation.CaptionHeight);
                    }
                    
                }
            }

            if (InGame)
            {
                if (DiagramStations == null || DiagramStations.Count == 0)
                {
                    TrainCrewInput.RequestStaData();
                    DiagramStations = trainState.stationList;
                }

                if (gameState.gameScreen == GameScreen.MainGame || gameState.gameScreen == GameScreen.MainGame_Pause)
                {
                    // Still in game
                    // Update low-frequency info elements

                    if (DiagramStations.Count > trainState.nowStaIndex)
                    {
                        NextStation = DiagramStations[trainState.nowStaIndex];
                    }

                    // Look ahead to choose the next displayed station
                    Station dispStation = null;
                    StationInfo dispStationInfo = null;
                    for (int i = trainState.nowStaIndex; i < DiagramStations.Count; i++)
                    {
                        Station s = DiagramStations[i];
                        StationInfo si = GetStationInfo(s.Name, TatehamaLineInfo);

                        // Select this station to show
                        // If the station requires stopping, it will be selected even if there is no StationInfo entry for it
                        // since a dummy StationInfo with TimeChecked will be used
                        if (s.stopType == StopType.StopForPassenger || s.stopType == StopType.StopForOperation || si.TimeChecked)
                        {
                            dispStation = s;
                            dispStationInfo = si;
                            break;
                        }
                    }

                    // Apply station name text
                    if (dispStation == null)
                    {
                        btnStationName.Text = StaErrorName;
                    }
                    else if (dispStation.Name.Length > 5)
                    {
                        // Apply special shortened names
                        if (dispStation.Name == "江ノ原信号場")
                        {
                            btnStationName.Text = "江ノ原信号";
                        }
                        else
                        {
                            btnStationName.Text = StaErrorName;
                        }
                    }
                    else
                    {
                        btnStationName.Text = dispStation.Name;
                    }
                    // END apply station name text

                    // Apply style according to the next action
                    if (NextStation == null || dispStation.stopType == StopType.Passing)
                    {
                        btnStationName.ForeColor = Blue1;
                        btnStationName.BackColor = Blue3;
                        btnPlatform.ForeColor = Blue1;
                        btnPlatform.BackColor = Blue3;

                        labelTrack.ForeColor = Blue3;
                        labelTrack.BackColor = Blue1;

                        SetSimpleElementColors(Blue3, Blue1);

                        NearStation = false;
                    }
                    else // stopping at displayed station
                    {
                        if (NextStation.stopType != StopType.Passing)
                        {
                            // Stop at the next station
                            btnPlatform.ForeColor = Orange;
                            btnPlatform.BackColor = Color.White;
                            labelTrack.ForeColor = Color.White;
                            labelTrack.BackColor = Orange;

                            SetSimpleElementColors(Color.White, Orange);

                            if (trainState.nextStaDistance > 700)
                            {
                                btnStationName.ForeColor = Orange;
                                btnStationName.BackColor = Color.White;

                                NearStation = false;
                            }
                            else
                            {
                                // Approaching, within 700m

                                if ((trainState.ATS_State != "無表示" || trainState.nextStaDistance < 300) && TimerLongTicks % 2 == 0)
                                {
                                    btnStationName.ForeColor = Color.White;
                                    btnStationName.BackColor = Orange;

                                    NearStation = true;
                                }
                                else
                                {
                                    btnStationName.ForeColor = Orange;
                                    btnStationName.BackColor = Color.White;
                                }
                            }
                        }
                        else
                        {
                            // Pass the next station, but stop at the displayed station
                            // btnStationName.ForeColor = Blue1;
                            // btnStationName.BackColor = Blue3;
                        }
                    }
                    // END apply style according to the next action

                    // Set borders to same color as text
                    btnStationName.FlatAppearance.BorderColor = btnStationName.ForeColor;
                    btnPlatform.FlatAppearance.BorderColor = btnPlatform.ForeColor;

                    // Prevent visual effects of mouse interaction, since buttons are used for text boxes
                    Button[] SetBgButtons = { btnPlatform, btnDistance, btnStationName, btnTimeNow, btnArv, btnDep };
                    foreach (Button b in SetBgButtons)
                    {
                        b.FlatAppearance.MouseOverBackColor = b.BackColor;
                    }

                    // Identify stop marker positions
                    int[] stopMarkers = new int[] { 0, 0, 0, 0, 0, 0 };
                    TrainDirection dir;
                    int track = 0;

                    if (dispStation != null)
                    {
                        string stopName = dispStation.StopPosName;
                        char dir_c = stopName[stopName.LastIndexOfAny(new char[] { '上', '下' })];
                        dir = dir_c == '上' ? TrainDirection.East : TrainDirection.West;

                        int track_c_index = stopName.LastIndexOfAny(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' });
                        if (track_c_index >= 1)
                        {
                            // Track number was found
                            track = int.Parse(stopName[track_c_index].ToString());

                            // Look back once more to see if it is a double digit track (only found in depots)
                            bool two_digit = char.IsDigit(stopName[track_c_index - 1]);
                            if (two_digit)
                            {
                                track += 10 * int.Parse(stopName[track_c_index - 1].ToString());
                            }
                        }
                        else
                        {
                            // No track number for simple stations in the Tatehama suburban area
                            // Assume track numbers
                            track = (dir == TrainDirection.West ? 1 : 2);
                        }

                        if (dispStationInfo != null && dispStation.stopType != StopType.Passing)
                        {
                            stopMarkers = GetStopMarkers(dispStationInfo, track, dir);
                        }
                    }

                    // Calculate stop position
                    bool[] carCells = { false, false, false, false, false, false };
                    int foremost = 0;
                    int rearmost = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        if (stopMarkers[i] >= trainState.CarStates.Count)
                        {
                            // Front of the train stops at this cell
                            foremost = i;
                            rearmost = i - trainState.CarStates.Count + 1;
                            // Don't look further forward
                            break;
                        }
                    }
                    if (foremost == 0 && rearmost == 0)
                    {
                        // Undefined stop point, leave empty
                    }
                    else
                    {
                        for (int c = rearmost; c <= foremost; c++)
                        {
                            carCells[c] = true;
                        }
                    }

                    // Draw the platform guide image
                    Color guideForeColor = btnPlatform.ForeColor;
                    Color guideBackColor = btnPlatform.BackColor;
                    SolidBrush sbFore = new SolidBrush(guideForeColor);
                    SolidBrush sbBack = new SolidBrush(guideBackColor);

                    Graphics gp = Graphics.FromImage(BmPlatform);

                    for (int i = 0; i < carCells.Length; i++)
                    {
                        gp.FillRectangle(sbFore, i * CellWidth, 0, CellWidth, BmPlatform.Height);
                        gp.FillRectangle(sbBack, i * CellWidth + CellThickness, CellThickness,
                            CellWidth - 2 * CellThickness, BmPlatform.Height - 2 * CellThickness);

                        // Number in the cell
                        string num = (stopMarkers[i] >= 2 && stopMarkers[i] <= 6 ? stopMarkers[i].ToString() : "");

                        if (carCells[i])
                        {
                            // Car occupies this cell
                            gp.FillRectangle(sbFore, i * CellWidth + 3 * CellThickness, 3 * CellThickness,
                                CellWidth - 6 * CellThickness, BmPlatform.Height - 6 * CellThickness);
                            gp.DrawString(num, PlatformGuideFont, sbBack, i * CellWidth + 2, 6);
                        }
                        else
                        {
                            // Car does not occupy this cell
                            
                            gp.DrawString(num, PlatformGuideFont, sbFore, i * CellWidth + 2, 6);
                        }
                    }

                    pictureBoxPlatform.Image = BmPlatform;
                    gp.Dispose();
                    // END draw the platform guide image

                    // Update the scheduled action and track number display
                    if (dispStation == null)
                    {
                        labelArv.Text = "停";
                        btnArv.Text = "--:--:--";

                        labelDep.Text = "発";
                        btnDep.Text = "--:--:--";

                        labelTrack.Text = "";
                    }
                    else if (dispStation.stopType == StopType.Passing)
                    {
                        labelArv.Text = "";
                        btnArv.Text = "▼          ";

                        labelDep.Text = "通";
                        btnDep.Text = dispStation.DepTime.ToString(@"hh\:mm\:ss");

                        labelTrack.Text = GetCircledNum(track);
                    }
                    else
                    {
                        labelArv.Text = "停";

                        if (dispStationInfo != null && !dispStationInfo.TimeChecked)
                        {
                            btnArv.Text = "";
                        }
                        else
                        {
                            btnArv.Text = dispStation.ArvTime.ToString(@"hh\:mm\:ss");
                        }

                        labelDep.Text = "発";
                        btnDep.Text = dispStation.DepTime.ToString(@"hh\:mm\:ss");

                        if (dispStation.stopType == StopType.StopForPassenger)
                        {
                            labelTrack.Text = GetCircledNum(track) + GetTriangle(dispStation.doorDir);
                        }
                        else
                        {
                            labelTrack.Text = GetCircledNum(track);
                        }
                        
                    }
                    // END update the scheduled action and track number display
                }
                else
                {
                    // No longer in game
                    InGame = false;

                    timerFrame.Stop();
                    DiagramStations = null;
                    NextStation = null;

                    // Hide elements?
                    // todo
                }
            }
            else
            {
                if (gameState.gameScreen == GameScreen.MainGame || gameState.gameScreen == GameScreen.MainGame_Pause)
                {
                    InGame = true;

                    timerFrame.Start();
                }
            }

            this.Refresh();
        }

        private void SetSimpleElementColors(Color fg, Color bg)
        {
            Control[] affectedControls = new Control[] { labelDebug, btnDistance,
                btnTimeNow, btnArv, btnDep, labelTimeNow, labelArv, labelDep };

            foreach (Control c in affectedControls)
            {
                c.ForeColor = fg;
                c.BackColor = bg;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            BmBar = new Bitmap(BarWidth, this.Height);
            pictureBoxBar.Height = this.Height;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TrainCrewInput.Dispose();
        }
    }
}
