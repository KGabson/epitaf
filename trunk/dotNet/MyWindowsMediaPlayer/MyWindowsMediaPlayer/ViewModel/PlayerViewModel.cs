using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWindowsMediaPlayer.View;
using Microsoft.DirectX.AudioVideoPlayback;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace MyWindowsMediaPlayer.ViewModel
{
    class PlayerViewModel
    {
        private PlayerView view;
        private string currentMode = "music";

        private Audio mplayer = null;
        private Video vplayer = null;

        private bool pause = false;
        private bool playing = false;

        private int currentTrackIndex = 0;
        private string playingIn = "";

        private string currentPlayedFile;
        public string CurrentPlayedFile
        {
            get { return currentPlayedFile; }
            set
            {
                Stop();
                currentPlayedFile = value;
            }
        }

        public PlayerViewModel(PlayerView view)
        {
            this.view = view;
            this.currentPlayedFile = "F:/Musique/F.F.- Album - 2004/03. Take Me Out.mp3";
            this.view.control.progressBar.Position = 0;
        }

        public void playVideo(string filename)
        {
            if (this.vplayer == null)
                this.initVideoPlayer(filename);
            this.vplayer.Play();
            this.vplayer.Ending += new EventHandler(this.nextAction);
        }

        public void playMusic(string filename)
        {
            if (this.mplayer == null)
                this.initMusicPlayer(filename);
            this.mplayer.Play();
            this.mplayer.Ending += new EventHandler(this.nextAction);
        }

        private void initVideoPlayer(string filename)
        {
            Size s = this.view.screen.Size;
            this.vplayer = new Video(filename);
            this.vplayer.Owner = this.view.screen;
            this.vplayer.Owner.Size = s;
            this.view.control.progressBar.Position = 0;
        }

        private void initMusicPlayer(string filename)
        {
            Size s = this.view.screen.Size;
            this.mplayer = new Audio(filename);
            this.view.control.progressBar.Position = 0;
        }

        public void Play(string filename)
        {
            if (!this.playing || this.pause)
            {
                if (this.currentPlayedFile == "")
                    return;
                if (this.currentMode == "music")
                    this.playMusic(filename);
                else
                    this.playVideo(filename);

                this.view.control.btnPlay.Text = "Pause";
                this.currentPlayedFile = filename;
                this.playing = true;
                this.pause = false;
                
            }
            else if (this.playing)
            {
                Pause();
                this.view.control.btnPlay.Text = "Play";
                this.pause = true;
            }
        }

        private void Play()
        {
            if (this.currentPlayedFile == "")
                return;
            Play(this.currentPlayedFile);
        }

        private void Stop()
        {
            if (this.currentMode == "video" && this.vplayer != null)
            {
                this.vplayer.Stop();
                this.vplayer.Dispose();
                this.vplayer = null;
            }
            else if (this.mplayer != null)
            {
                this.mplayer.Stop();
                this.mplayer.Dispose();
                this.mplayer = null;
            }
            this.pause = false;
            this.playing = false;
            this.view.control.progressBar.Position = 0;
            this.view.control.btnPlay.Text = "Play";
        }

        private void Pause()
        {
            if (this.currentMode == "video")
                this.vplayer.Pause();
            else
                this.mplayer.Pause();
        }

        private void Next()
        {
            DataRowCollection list = null;
            int column_index = 0;

            if (PlaylistViewModel.getInstance().mediaList.Rows.Count > 0)
            {
                list = PlaylistViewModel.getInstance().mediaList.Rows;
                currentTrackIndex = (this.playingIn == "media_explorer") ? 0 : currentTrackIndex;
                column_index = 3;
                playingIn = "playlist";
            }
            else if (MediaViewerViewModel.getInstance().mediasInfo.Rows.Count > 0)
            {
                list = MediaViewerViewModel.getInstance().mediasInfo.Rows;
                currentTrackIndex = (this.playingIn == "playlist") ? 0 : currentTrackIndex;
                column_index = 4;
                playingIn = "media_explorer";
            }
            if (list == null)
                return;
            //if (list.Count < currentTrackIndex)
                //Play(list[currentTrackIndex]);
            //MediaViewerViewModel.getInstance().mediasInfo.Rows.Count;
        }

        private void emptyCurrentTrackInfo()
        {
            //this.
        }

        private void setCurrentTrackInfo(string file, string total_time)
        {
            this.view.control.currentTrackLabel.Text = "Current Track: " + file + " - " + total_time;
        }

        #region Handlers
        public void playAction(object sender, EventArgs e)
        {
            Play();
        }

        public void pauseAction(object sender, EventArgs e)
        {
            Pause();
        }

        public void stopAction(object sender, EventArgs e)
        {
            Stop();
        }

        public void nextAction(object sender, EventArgs e)
        {

        }

        public void previousAction(object sender, EventArgs e)
        {

        }

        public void setCurrentPositionAction(object sender, EventArgs e)
        {
            
            MouseEventArgs args = (e as MouseEventArgs);
            double play_position;

            if (!this.playing)
                return;
            if (this.currentMode == "video")
            {
                play_position = args.X * this.vplayer.Duration / (sender as MovieProgressBar).Width;
                if (this.vplayer == null)
                    return;
                this.vplayer.CurrentPosition = play_position;
            }
            else
            {
                play_position = args.X * this.mplayer.Duration / (sender as MovieProgressBar).Width;
                if (this.mplayer == null)
                    return;
                this.mplayer.CurrentPosition = play_position;
            }
            this.view.control.progressBar.Position = args.X;
        }

        public void updatePositionAction(object sender, EventArgs e)
        {
            int cursor_position;
            if (this.currentMode == "video")
            {
                cursor_position = (int)(this.vplayer.CurrentPosition * this.view.control.progressBar.Width / this.vplayer.Duration);
                this.view.control.progressBar.Position = (int)(this.vplayer.CurrentPosition * this.view.control.progressBar.Width / this.vplayer.Duration);
            }
            else
            {
                cursor_position = (int)(this.vplayer.CurrentPosition * this.view.control.progressBar.Width / this.vplayer.Duration);
                this.view.control.progressBar.Position = (int)(this.mplayer.CurrentPosition * this.view.control.progressBar.Width / this.mplayer.Duration);
            }
        }

        public void setMusicModeAction(object sender, EventArgs e)
        {
            if (this.currentMode == "music")
                return;
            Stop();
            this.currentMode = "music";
            this.currentPlayedFile = "F:/Musique/F.F.- Album - 2004/03. Take Me Out.mp3";
        }

        public void setVideoModeAction(object sender, EventArgs e)
        {
            if (this.currentMode == "video")
                return;
            Stop();
            this.currentMode = "video";
            this.currentPlayedFile = "F:/Films/Soul Eater (En cours)/[K`N`T]_Soul_Eater_21_vostfr_Upload_by_Jyg!.avi";
        }

        public void playDoubleClickPlaylistAction(object sender, EventArgs e)
        {
            DataGridViewCellEventArgs args = (e as DataGridViewCellEventArgs);
            int x = args.ColumnIndex;
            int y = args.RowIndex;
            Console.WriteLine("==> Clicked element: " + PlaylistViewModel.getInstance().mediaList.Rows[y].Field<string>(3));
        }
        #endregion

    }
}
