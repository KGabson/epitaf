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
        private MyWindowsMediaPlayer.ViewModel.MainViewModel viewModel;

        public MainWindow()
        {
            viewModel = new MainViewModel();

            InitializeComponent();
            this.treeView1.treeView1.AfterSelect += this.update;
        }

        private void update(object sender, TreeViewEventArgs e)
        {
        }

    }
}
