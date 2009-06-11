using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyWindowsMediaPlayer.ViewModel;

namespace MyWindowsMediaPlayer.View
{
    public partial class MediaViewer : UserControl
    {
        public MyWindowsMediaPlayer.ViewModel.MediaViewerViewModel viewModel;

        public MediaViewer()
        {
            this.viewModel = MyWindowsMediaPlayer.ViewModel.MediaViewerViewModel.getInstance();
            InitializeComponent();
            this.dataGridView1.DataSource = this.viewModel.mediasInfo;
            this.dataGridView1.CellContentClick += PlaylistViewModel.getInstance().addToPlaylist;
        }
    }
}
