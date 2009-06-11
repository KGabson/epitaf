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
    public partial class PlayerView : UserControl
    {
        private PlayerViewModel viewModel;

        public PlayerView()
        {
            InitializeComponent();
            viewModel = new PlayerViewModel(this);
            bind();
        }

        private void bind()
        {
            this.control.btnPlay.Click += new EventHandler(this.viewModel.playAction);
            this.control.btnStop.Click += new EventHandler(this.viewModel.stopAction);
            this.btnMusicMode.Click += new EventHandler(this.viewModel.setMusicModeAction);
            this.btnVideoMode.Click += new EventHandler(this.viewModel.setVideoModeAction);
            this.control.progressBar.Click += new EventHandler(this.viewModel.setCurrentPositionAction);
            this.refreshTimer.Tick += new EventHandler(this.viewModel.updatePositionAction);
            this.paylistView1.DoubleClick += new EventHandler(this.viewModel.playDoubleClickPlaylistAction);
        }
    }
}
