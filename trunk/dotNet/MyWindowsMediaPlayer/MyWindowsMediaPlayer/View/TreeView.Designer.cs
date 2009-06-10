namespace MyWindowsMediaPlayer.View
{
    partial class TreeView
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeViewViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeViewViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.treeViewViewModelBindingSource, "mainNode", true));
            this.treeView1.DataBindings.Add(new System.Windows.Forms.Binding("ImeMode", this.treeViewViewModelBindingSource, "mainNode", true));
            this.treeView1.DataBindings.Add(new System.Windows.Forms.Binding("TabIndex", this.treeViewViewModelBindingSource, "mainNode", true));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(228, 439);
            this.treeView1.TabIndex = 0;
            // 
            // treeViewViewModelBindingSource
            // 
            this.treeViewViewModelBindingSource.DataSource = typeof(MyWindowsMediaPlayer.ViewModel.TreeViewViewModel);
            // 
            // TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.treeView1);
            this.Name = "TreeView";
            this.Size = new System.Drawing.Size(229, 442);
            ((System.ComponentModel.ISupportInitialize)(this.treeViewViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.BindingSource treeViewViewModelBindingSource;
    }
}
