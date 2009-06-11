namespace MyWindowsMediaPlayer.View
{
    partial class PlayerControlView
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
            this.btnStop = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.progressBar = new MyWindowsMediaPlayer.View.MovieProgressBar();
            this.currentTrackLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(246, 38);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(165, 38);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.AutoEllipsis = true;
            this.btnPlay.Location = new System.Drawing.Point(3, 38);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(84, 38);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.AccessibleName = "";
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.BackColor = System.Drawing.SystemColors.ControlText;
            this.progressBar.Location = new System.Drawing.Point(3, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Position = 65;
            this.progressBar.Size = new System.Drawing.Size(397, 17);
            this.progressBar.TabIndex = 4;
            // 
            // currentTrackLabel
            // 
            this.currentTrackLabel.AutoSize = true;
            this.currentTrackLabel.Location = new System.Drawing.Point(3, 20);
            this.currentTrackLabel.Name = "currentTrackLabel";
            this.currentTrackLabel.Size = new System.Drawing.Size(70, 13);
            this.currentTrackLabel.TabIndex = 5;
            this.currentTrackLabel.Text = "current_track";
            // 
            // PlayerControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.currentTrackLabel);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.progressBar);
            this.Name = "PlayerControlView";
            this.Size = new System.Drawing.Size(400, 64);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MovieProgressBar progressBar;
        public System.Windows.Forms.Button btnStop;
        public System.Windows.Forms.Button btnNext;
        public System.Windows.Forms.Button btnPlay;
        public System.Windows.Forms.Button btnPrevious;
        public System.Windows.Forms.Label currentTrackLabel;
    }
}
