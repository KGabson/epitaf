namespace MyWindowsMediaPlayer.View
{
    partial class PlayerView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnMusicMode = new System.Windows.Forms.Button();
            this.btnVideoMode = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.paylistView1 = new MyWindowsMediaPlayer.View.PaylistView();
            this.mediaViewer1 = new MyWindowsMediaPlayer.View.MediaViewer();
            this.screen = new MyWindowsMediaPlayer.View.Screen();
            this.control = new MyWindowsMediaPlayer.View.PlayerControlView();
            this.SuspendLayout();
            // 
            // btnMusicMode
            // 
            this.btnMusicMode.Location = new System.Drawing.Point(4, 4);
            this.btnMusicMode.Name = "btnMusicMode";
            this.btnMusicMode.Size = new System.Drawing.Size(75, 23);
            this.btnMusicMode.TabIndex = 0;
            this.btnMusicMode.Text = "Music";
            this.btnMusicMode.UseVisualStyleBackColor = true;
            // 
            // btnVideoMode
            // 
            this.btnVideoMode.Location = new System.Drawing.Point(85, 4);
            this.btnVideoMode.Name = "btnVideoMode";
            this.btnVideoMode.Size = new System.Drawing.Size(75, 23);
            this.btnVideoMode.TabIndex = 1;
            this.btnVideoMode.Text = "Video";
            this.btnVideoMode.UseVisualStyleBackColor = true;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 1000;
            // 
            // paylistView1
            // 
            this.paylistView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paylistView1.Location = new System.Drawing.Point(272, 195);
            this.paylistView1.Name = "paylistView1";
            this.paylistView1.Size = new System.Drawing.Size(308, 116);
            this.paylistView1.TabIndex = 6;
            // 
            // mediaViewer1
            // 
            this.mediaViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaViewer1.Location = new System.Drawing.Point(272, 32);
            this.mediaViewer1.Name = "mediaViewer1";
            this.mediaViewer1.Size = new System.Drawing.Size(308, 157);
            this.mediaViewer1.TabIndex = 5;
            // 
            // screen
            // 
            this.screen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.screen.BackColor = System.Drawing.Color.DimGray;
            this.screen.Location = new System.Drawing.Point(4, 32);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(262, 279);
            this.screen.TabIndex = 4;
            // 
            // control
            // 
            this.control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.control.Location = new System.Drawing.Point(4, 317);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(577, 64);
            this.control.TabIndex = 3;
            // 
            // PlayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.paylistView1);
            this.Controls.Add(this.mediaViewer1);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.control);
            this.Controls.Add(this.btnVideoMode);
            this.Controls.Add(this.btnMusicMode);
            this.Name = "PlayerView";
            this.Size = new System.Drawing.Size(584, 384);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMusicMode;
        private System.Windows.Forms.Button btnVideoMode;
        public Screen screen;
        public PlayerControlView control;
        public System.Windows.Forms.Timer refreshTimer;
        public MediaViewer mediaViewer1;
        public PaylistView paylistView1;

    }
}
