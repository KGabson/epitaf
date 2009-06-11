using MyWindowsMediaPlayer.View;
namespace MyWindowsMediaPlayer
{
    partial class MainWindow
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.treeView1 = new MyWindowsMediaPlayer.View.TreeView();
            this.playerView1 = new MyWindowsMediaPlayer.View.PlayerView();
            this.libraryPathSelector1 = new MyWindowsMediaPlayer.View.LibraryPathSelector();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.libraryPathSelector1);
            this.topPanel.Location = new System.Drawing.Point(13, 13);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(785, 85);
            this.topPanel.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.treeView1.Location = new System.Drawing.Point(13, 105);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(201, 456);
            this.treeView1.TabIndex = 3;
            // 
            // playerView1
            // 
            this.playerView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.playerView1.Location = new System.Drawing.Point(220, 105);
            this.playerView1.Name = "playerView1";
            this.playerView1.Size = new System.Drawing.Size(763, 456);
            this.playerView1.TabIndex = 2;
            // 
            // libraryPathSelector1
            // 
            this.libraryPathSelector1.Location = new System.Drawing.Point(3, 48);
            this.libraryPathSelector1.Name = "libraryPathSelector1";
            this.libraryPathSelector1.Size = new System.Drawing.Size(316, 34);
            this.libraryPathSelector1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 573);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.playerView1);
            this.Controls.Add(this.topPanel);
            this.Name = "MainWindow";
            this.Text = "MyWindowsMediaPlayer";
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private LibraryPathSelector libraryPathSelector1;
        //private MediaViewer mediaViewer1;
        //private TreeView treeView2;
        private PlayerView playerView1;
        private TreeView treeView1;
    }
}

