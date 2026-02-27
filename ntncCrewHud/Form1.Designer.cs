
namespace ntncCrewHud
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStationName = new System.Windows.Forms.Button();
            this.timerFrame = new System.Windows.Forms.Timer(this.components);
            this.timerLong = new System.Windows.Forms.Timer(this.components);
            this.btnTimeNow = new System.Windows.Forms.Button();
            this.btnDep = new System.Windows.Forms.Button();
            this.labelTimeNow = new System.Windows.Forms.Label();
            this.labelDep = new System.Windows.Forms.Label();
            this.labelArv = new System.Windows.Forms.Label();
            this.btnArv = new System.Windows.Forms.Button();
            this.labelDebug = new System.Windows.Forms.Label();
            this.btnPlatform = new System.Windows.Forms.Button();
            this.pictureBoxPlatform = new System.Windows.Forms.PictureBox();
            this.labelTrack = new System.Windows.Forms.Label();
            this.pictureBoxBar = new System.Windows.Forms.PictureBox();
            this.btnDistance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStationName
            // 
            this.btnStationName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStationName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.btnStationName.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.btnStationName.FlatAppearance.BorderSize = 2;
            this.btnStationName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.btnStationName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.btnStationName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStationName.Font = new System.Drawing.Font("Yu Gothic Medium", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStationName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.btnStationName.Location = new System.Drawing.Point(570, 30);
            this.btnStationName.Name = "btnStationName";
            this.btnStationName.Size = new System.Drawing.Size(200, 50);
            this.btnStationName.TabIndex = 0;
            this.btnStationName.UseMnemonic = false;
            this.btnStationName.UseVisualStyleBackColor = false;
            // 
            // timerFrame
            // 
            this.timerFrame.Interval = 30;
            this.timerFrame.Tick += new System.EventHandler(this.timerFrame_Tick);
            // 
            // timerLong
            // 
            this.timerLong.Interval = 500;
            this.timerLong.Tick += new System.EventHandler(this.timerLong_Tick);
            // 
            // btnTimeNow
            // 
            this.btnTimeNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.btnTimeNow.FlatAppearance.BorderSize = 0;
            this.btnTimeNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimeNow.Font = new System.Drawing.Font("Yu Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.btnTimeNow.Location = new System.Drawing.Point(30, 86);
            this.btnTimeNow.Name = "btnTimeNow";
            this.btnTimeNow.Size = new System.Drawing.Size(110, 25);
            this.btnTimeNow.TabIndex = 1;
            this.btnTimeNow.Text = "--:--:--";
            this.btnTimeNow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimeNow.UseVisualStyleBackColor = false;
            // 
            // btnDep
            // 
            this.btnDep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.btnDep.FlatAppearance.BorderSize = 0;
            this.btnDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDep.Font = new System.Drawing.Font("Yu Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.btnDep.Location = new System.Drawing.Point(660, 115);
            this.btnDep.Name = "btnDep";
            this.btnDep.Size = new System.Drawing.Size(110, 25);
            this.btnDep.TabIndex = 2;
            this.btnDep.Text = "--:--:--";
            this.btnDep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDep.UseVisualStyleBackColor = false;
            // 
            // labelTimeNow
            // 
            this.labelTimeNow.AutoSize = true;
            this.labelTimeNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.labelTimeNow.Font = new System.Drawing.Font("Yu Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.labelTimeNow.Location = new System.Drawing.Point(33, 90);
            this.labelTimeNow.Name = "labelTimeNow";
            this.labelTimeNow.Size = new System.Drawing.Size(24, 19);
            this.labelTimeNow.TabIndex = 3;
            this.labelTimeNow.Text = "時";
            // 
            // labelDep
            // 
            this.labelDep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDep.AutoSize = true;
            this.labelDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.labelDep.Font = new System.Drawing.Font("Yu Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.labelDep.Location = new System.Drawing.Point(663, 119);
            this.labelDep.Name = "labelDep";
            this.labelDep.Size = new System.Drawing.Size(24, 19);
            this.labelDep.TabIndex = 4;
            this.labelDep.Text = "発";
            // 
            // labelArv
            // 
            this.labelArv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelArv.AutoSize = true;
            this.labelArv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.labelArv.Font = new System.Drawing.Font("Yu Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.labelArv.Location = new System.Drawing.Point(663, 90);
            this.labelArv.Name = "labelArv";
            this.labelArv.Size = new System.Drawing.Size(24, 19);
            this.labelArv.TabIndex = 6;
            this.labelArv.Text = "停";
            // 
            // btnArv
            // 
            this.btnArv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.btnArv.FlatAppearance.BorderSize = 0;
            this.btnArv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArv.Font = new System.Drawing.Font("Yu Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.btnArv.Location = new System.Drawing.Point(660, 86);
            this.btnArv.Name = "btnArv";
            this.btnArv.Size = new System.Drawing.Size(110, 25);
            this.btnArv.TabIndex = 5;
            this.btnArv.Text = "--:--:--";
            this.btnArv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArv.UseVisualStyleBackColor = false;
            // 
            // labelDebug
            // 
            this.labelDebug.AutoSize = true;
            this.labelDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.labelDebug.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDebug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.labelDebug.Location = new System.Drawing.Point(145, 89);
            this.labelDebug.Name = "labelDebug";
            this.labelDebug.Size = new System.Drawing.Size(85, 20);
            this.labelDebug.TabIndex = 7;
            this.labelDebug.Text = "Debug Text";
            this.labelDebug.Visible = false;
            // 
            // btnPlatform
            // 
            this.btnPlatform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.btnPlatform.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.btnPlatform.FlatAppearance.BorderSize = 2;
            this.btnPlatform.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.btnPlatform.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.btnPlatform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlatform.Font = new System.Drawing.Font("Yu Gothic Medium", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlatform.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.btnPlatform.Location = new System.Drawing.Point(30, 30);
            this.btnPlatform.Name = "btnPlatform";
            this.btnPlatform.Size = new System.Drawing.Size(180, 50);
            this.btnPlatform.TabIndex = 8;
            this.btnPlatform.UseMnemonic = false;
            this.btnPlatform.UseVisualStyleBackColor = false;
            // 
            // pictureBoxPlatform
            // 
            this.pictureBoxPlatform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.pictureBoxPlatform.Location = new System.Drawing.Point(75, 40);
            this.pictureBoxPlatform.Name = "pictureBoxPlatform";
            this.pictureBoxPlatform.Size = new System.Drawing.Size(120, 30);
            this.pictureBoxPlatform.TabIndex = 10;
            this.pictureBoxPlatform.TabStop = false;
            // 
            // labelTrack
            // 
            this.labelTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.labelTrack.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.labelTrack.Location = new System.Drawing.Point(30, 30);
            this.labelTrack.Name = "labelTrack";
            this.labelTrack.Padding = new System.Windows.Forms.Padding(7, 5, 5, 0);
            this.labelTrack.Size = new System.Drawing.Size(30, 50);
            this.labelTrack.TabIndex = 11;
            this.labelTrack.Text = "①◀";
            this.labelTrack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxBar
            // 
            this.pictureBoxBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBar.Location = new System.Drawing.Point(780, 0);
            this.pictureBoxBar.Name = "pictureBoxBar";
            this.pictureBoxBar.Size = new System.Drawing.Size(20, 600);
            this.pictureBoxBar.TabIndex = 12;
            this.pictureBoxBar.TabStop = false;
            // 
            // btnDistance
            // 
            this.btnDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.btnDistance.FlatAppearance.BorderSize = 0;
            this.btnDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDistance.Font = new System.Drawing.Font("Yu Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(80)))), ((int)(((byte)(128)))));
            this.btnDistance.Location = new System.Drawing.Point(30, 115);
            this.btnDistance.Name = "btnDistance";
            this.btnDistance.Size = new System.Drawing.Size(70, 25);
            this.btnDistance.TabIndex = 13;
            this.btnDistance.Text = "0.0 km";
            this.btnDistance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDistance.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnDistance);
            this.Controls.Add(this.pictureBoxBar);
            this.Controls.Add(this.labelTrack);
            this.Controls.Add(this.pictureBoxPlatform);
            this.Controls.Add(this.btnPlatform);
            this.Controls.Add(this.labelDebug);
            this.Controls.Add(this.labelArv);
            this.Controls.Add(this.btnArv);
            this.Controls.Add(this.labelDep);
            this.Controls.Add(this.labelTimeNow);
            this.Controls.Add(this.btnDep);
            this.Controls.Add(this.btnTimeNow);
            this.Controls.Add(this.btnStationName);
            this.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.8D;
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlatform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStationName;
        private System.Windows.Forms.Timer timerFrame;
        private System.Windows.Forms.Timer timerLong;
        private System.Windows.Forms.Button btnTimeNow;
        private System.Windows.Forms.Button btnDep;
        private System.Windows.Forms.Label labelTimeNow;
        private System.Windows.Forms.Label labelDep;
        private System.Windows.Forms.Label labelArv;
        private System.Windows.Forms.Button btnArv;
        private System.Windows.Forms.Label labelDebug;
        private System.Windows.Forms.Button btnPlatform;
        private System.Windows.Forms.PictureBox pictureBoxPlatform;
        private System.Windows.Forms.Label labelTrack;
        private System.Windows.Forms.PictureBox pictureBoxBar;
        private System.Windows.Forms.Button btnDistance;
    }
}

