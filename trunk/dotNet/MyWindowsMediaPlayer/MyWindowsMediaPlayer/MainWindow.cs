using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyWindowsMediaPlayer.ViewModel;

namespace MyWindowsMediaPlayer
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {

            InitializeComponent();
            //this.treeView2.treeView1.AfterSelect += this.update;
        }

        private void update(object sender, TreeViewEventArgs e)
        {
        }

    }
}
