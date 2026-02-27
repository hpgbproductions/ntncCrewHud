using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntncCrewHud
{
    enum TrainDirection { East, West };

    class StationInfo
    {
        public string JapaneseName;

        /// <summary>
        /// Whether the stopping or passing time is measured.
        /// </summary>
        public bool TimeChecked;

        /// <summary>
        /// Stop markers that westbound trains see
        /// </summary>
        public int[,] WestMarkers;

        /// <summary>
        /// Stop markers that eastbound trains see
        /// </summary>
        public int[,] EastMarkers;

        public StationInfo(string name_ja, bool time_check, int[,] stops_west, int[,] stops_east)
        {
            JapaneseName = name_ja;
            TimeChecked = time_check;
            WestMarkers = stops_west;
            EastMarkers = stops_east;
        }
    }

    partial class Form1
    {
        StationInfo GetStationInfo(string name, StationInfo[] stations)
        {
            foreach (StationInfo s in stations)
            {
                if (name == s.JapaneseName)
                {
                    return s;
                }
            }
            return null;
        }

        int[] GetStopMarkers(StationInfo stationInfo, int trackNum, TrainDirection dir)
        {
            int[] output = { 0, 0, 0, 0, 0, 0 };

            if (stationInfo == null)
            {
                return output;
            }

            int[,] stopInfo = (dir == TrainDirection.West ? stationInfo.WestMarkers : stationInfo.EastMarkers);
            
            for (int i = 0; i < 6; i++)
            {
                output[i] = stopInfo[trackNum - 1, i];
            }
            return output;
        }

        string GetCircledNum(int n)
        {
            if (n == 0)
            {
                return char.ConvertFromUtf32(0x24EA);
            }
            else if (n >= 1 && n <= 20)
            {
                return char.ConvertFromUtf32(0x2460 + (n - 1));
            }
            else if (n <= 35)
            {
                return char.ConvertFromUtf32(0x3251 + (n - 21));
            }
            else if (n <= 50)
            {
                return char.ConvertFromUtf32(0x32B1 + (n - 36));
            }
            else
            {
                throw new ArgumentOutOfRangeException("Encircled character for the number " + n + " does not exist.");
            }
        }

        string GetTriangle(TrainCrew.DoorDir dir)
        {
            if (dir == TrainCrew.DoorDir.LeftSide)
            {
                return "◀";
            }
            else
            {
                return "▶";
            }
        }

        /*
        StationInfo DummyStationInfo = new StationInfo("", true,
            new int[,] { { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 } },
            new int[,] { { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 } });
        */

        StationInfo Tatehama = new StationInfo("館浜", true,
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } },
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } });

        StationInfo Komano = new StationInfo("駒野", true,
            new int[,] { { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 2, 6 }, { 0, 0, 0, 0, 2, 6 } },
            new int[,] { { 0, 0, 3, 4, 5, 6 }, { 0, 0, 3, 0, 4, 6 }, { 0, 0, 3, 0, 4, 6 } });

        StationInfo Kawarazaki = new StationInfo("河原崎", false,
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } },
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } });

        StationInfo KaiganKoen = new StationInfo("海岸公園", false,
            new int[,] { { 0, 0, 0, 0, 4, 6 }, { 0, 0, 0, 0, 4, 6 } },
            new int[,] { { 0, 0, 0, 0, 4, 6 }, { 0, 0, 0, 0, 4, 6 } });

        StationInfo Nijigahama = new StationInfo("虹ケ浜", false,
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } },
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } });

        StationInfo Tsuzaki = new StationInfo("津崎", true,
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } },
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } });

        StationInfo Hamazono = new StationInfo("浜園", true,
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } },
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } });

        StationInfo Hagoromobashi = new StationInfo("羽衣橋", false,
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } },
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } });

        StationInfo Araigawa = new StationInfo("新井川", false,
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } },
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } });

        StationInfo ShinNozaki = new StationInfo("新野崎", true,
            new int[,] { { 0, 0, 2, 4, 5, 6 }, { 0, 0, 2, 4, 5, 6 }, { 0, 0, 2, 4, 5, 6 }, { 0, 0, 2, 4, 5, 6 } },
            new int[,] { { 0, 0, 2, 4, 5, 6 }, { 0, 0, 2, 4, 5, 6 }, { 0, 0, 2, 4, 5, 6 }, { 0, 0, 2, 4, 5, 6 } });

        StationInfo Enohara = new StationInfo("江ノ原", false,
            new int[,] { { 0, 0, 0, 0, 4, 6 }, { 0, 0, 0, 0, 4, 6 } },
            new int[,] { { 0, 0, 0, 0, 4, 6 }, { 0, 0, 0, 0, 4, 6 } });

        StationInfo EnoharaSignal = new StationInfo("江ノ原信号場", true,
            new int[,] { { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 } },
            new int[,] { { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 } });

        StationInfo Daidoji = new StationInfo("大道寺", true,
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } },
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } });

        StationInfo Fujie = new StationInfo("藤江", true,
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } },
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } });

        StationInfo Mizukoshi = new StationInfo("水越", true,
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } },
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } });

        StationInfo Takamizawa = new StationInfo("高見沢", true,
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } },
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } });

        StationInfo Hinomori = new StationInfo("日野森", true,
            new int[,] { { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 4, 6 } },
            new int[,] { { 0, 0, 0, 2, 3, 6 }, { 0, 0, 0, 4, 5, 6 }, { 0, 0, 0, 4, 5, 6 } });

        StationInfo Okumineguchi = new StationInfo("奥峯口", false,
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } },
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } });

        StationInfo NishiAkayama = new StationInfo("西赤山", true,
            new int[,] { { 0, 2, 3, 4, 5, 6 }, { 0, 2, 3, 4, 5, 6 } },
            new int[,] { { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } });

        StationInfo Akayamacho = new StationInfo("赤山町", true,
            new int[,] { { 0, 0, 0, 2, 4, 6 }, { 0, 0, 0, 0, 0, 6 }, { 0, 0, 0, 0, 0, 6 } },
            new int[,] { { 0, 0, 0, 2, 4, 6 }, { 0, 0, 0, 0, 0, 0 }, { 0, 2, 3, 4, 5, 6 } });
    }
}
