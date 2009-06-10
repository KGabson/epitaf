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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.treeView1 = new MyWindowsMediaPlayer.View.TreeView();
            this.topPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.playerControlView1 = new MyWindowsMediaPlayer.View.PlayerControlView();
            this.libraryPathSelector1 = new MyWindowsMediaPlayer.View.LibraryPathSelector();
            this.leftPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.treeView1);
            this.leftPanel.Location = new System.Drawing.Point(13, 104);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 457);
            this.leftPanel.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.treeView1.Location = new System.Drawing.Point(0, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(197, 457);
            this.treeView1.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.libraryPathSelector1);
            this.topPanel.Location = new System.Drawing.Point(13, 13);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(767, 85);
            this.topPanel.TabIndex = 1;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.playerControlView1);
            this.rightPanel.Location = new System.Drawing.Point(220, 107);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(559, 454);
            this.rightPanel.TabIndex = 2;
            // 
            // playerControlView1
            // 
            this.playerControlView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.playerControlView1.Location = new System.Drawing.Point(3, 384);
            this.playerControlView1.Name = "playerControlView1";
            this.playerControlView1.Size = new System.Drawing.Size(553, 70);
            this.playerControlView1.TabIndex = 0;
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
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.leftPanel);
            this.Name = "MainWindow";
            this.Text = "MyWindowsMediaPlayer";
            this.leftPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel rightPanel;
        private MyWindowsMediaPlayer.View.PlayerControlView playerControlView1;
        private TreeView treeView1;
        private LibraryPathSelector libraryPathSelector1;
    }
}

