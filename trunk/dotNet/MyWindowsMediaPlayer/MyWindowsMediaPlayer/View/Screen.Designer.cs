namespace MyWindowsMediaPlayer.View
{
    partial class Screen
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
            this.videoContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // videoContainer
            // 
            this.videoContainer.Location = new System.Drawing.Point(0, 0);
            this.videoContainer.Name = "videoContainer";
            this.videoContainer.Size = new System.Drawing.Size(345, 292);
            this.videoContainer.TabIndex = 0;
            this.videoContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.videoContainer);
            this.Name = "Screen";
            this.Size = new System.Drawing.Size(345, 292);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel videoContainer;
    }
}
