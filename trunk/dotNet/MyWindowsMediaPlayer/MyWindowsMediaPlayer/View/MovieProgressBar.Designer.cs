﻿namespace MyWindowsMediaPlayer.View
{
    partial class MovieProgressBar
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
            this.timeCursor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timeCursor
            // 
            this.timeCursor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.timeCursor.Location = new System.Drawing.Point(167, 0);
            this.timeCursor.Name = "timeCursor";
            this.timeCursor.Size = new System.Drawing.Size(13, 17);
            this.timeCursor.TabIndex = 0;
            // 
            // MovieProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.timeCursor);
            this.Name = "MovieProgressBar";
            this.Size = new System.Drawing.Size(251, 17);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel timeCursor;
    }
}
