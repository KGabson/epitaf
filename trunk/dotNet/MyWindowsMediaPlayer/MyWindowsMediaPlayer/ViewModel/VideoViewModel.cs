using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.AudioVideoPlayback;
using MyWindowsMediaPlayer.View;
using System.Windows.Forms;
using System.Drawing;

namespace MyWindowsMediaPlayer.ViewModel
{
    class VideoViewModel : IViewModel
    {
        string currentPlayedFile;
        
        Video player;
        VideoView view;

        bool fullScreen = false;

        public VideoViewModel(VideoView view)
        {
            currentPlayedFile = "F:/Films/Soul Eater (En cours)/[K`N`T]_Soul_Eater_21_vostfr_Upload_by_Jyg!.avi";
            this.player = null;
            this.view = view;
            init();
        }

        private void init()
        {
            this.view.control.progressBar.Position = 0;
            //this.view.screen.Width = 200;
            //this.view.screen.Height = 100;
        }

        #region Action Handlers
        private void initPlayer(string file_to_read)
        {
            Size s = this.view.screen.Size;
            this.player = new Video(file_to_read);
            this.player.Owner = this.view.screen;
            this.player.Owner.Size = s;
            this.view.control.progressBar.Position = 0;
        }

        public void playAction(object sender, EventArgs e)
        {
            Console.WriteLine("Playing [" + this.currentPlayedFile + "]");
            if (this.currentPlayedFile == null)
                return;
            if (this.player == null)
                this.initPlayer(this.currentPlayedFile);
            this.player.Play();
            this.view.refreshTimer.Start();
        }

        void Owner_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine("DoubleClick");
        }

        public void stopAction(object sender, EventArgs e)
        {
            if (this.player == null)
                return;
            this.player.Stop();
            this.player.Dispose();
            this.player = null;
            this.view.refreshTimer.Stop();
            this.view.control.progressBar.Position = 0;
        }

        public void refreshProgress(object sender, EventArgs e)
        {
            int cursor_position = (int)(this.player.CurrentPosition * this.view.control.progressBar.Width / this.player.Duration);
            //this.view.control.progressBar.timeCursor.Location = new Point(cursor_position, this.view.control.progressBar.timeCursor.Location.Y);
            this.view.control.progressBar.Position = (int)(this.player.CurrentPosition * this.view.control.progressBar.Width / this.player.Duration);
        }

        public void setVideoPosition(object sender, EventArgs e)
        {
            if (this.player == null)
                return;
            MouseEventArgs args = (e as MouseEventArgs);
            double movie_position = args.X * this.player.Duration / (sender as MovieProgressBar).Width;
            this.player.CurrentPosition = movie_position;
        }
        #endregion
    }
}
