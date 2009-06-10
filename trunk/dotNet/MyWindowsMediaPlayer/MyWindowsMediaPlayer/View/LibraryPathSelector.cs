using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using MyWindowsMediaPlayer.Model;

namespace MyWindowsMediaPlayer.View
{
    public partial class LibraryPathSelector : UserControl
    {
        private MyWindowsMediaPlayer.ViewModel.LibraryPathSelectorViewModel viewModel;

        public LibraryPathSelector()
        {
            viewModel = new MyWindowsMediaPlayer.ViewModel.LibraryPathSelectorViewModel();
            InitializeComponent();
            textBoxToMediaPath.Add(DirectoryReader.getInstance());
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            try
            {
                this.folderBrowserDialog1.ShowDialog(this);
                DirectoryReader.getInstance().MediaPath = folderBrowserDialog1.SelectedPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
