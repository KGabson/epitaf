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
    public partial class PaylistView : UserControl
    {
        public PlaylistViewModel viewModel;

        public PaylistView()
        {
            viewModel = PlaylistViewModel.getInstance();
            InitializeComponent();
            this.dataGridView1.DataSource = this.viewModel.mediaList;
        }
    }
}
