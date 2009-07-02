using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Diagnostics;
using MyLiveMesh.View;
using Liquid;

namespace MyLiveMesh.ViewModel
{
    public class VideoPlayerViewModel : ViewModelBase
    {
        private String btnPlayPauseText;
        public Dialog  popup;
        public MediaElement media;

        public VideoPlayerViewModel()
        {
            Debug.WriteLine("VideoPlayerViewModel ctor");
            btnPlayPauseText = "Play";
            //Commands.FileCommands.PlayVideoCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(PlayVideoCommand_Executed);
        }

        void PlayVideoCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            //(e.Source as VideoPlayer).VideoElement.Play();
        }

        public String BtnPlayPauseText
        {
            get { return btnPlayPauseText; }
            set
            {
                btnPlayPauseText = value;
                InvokePropertyChanged("BtnPlayPauseText");
            }
        }

        public Uri MediaSource
        {
            get { return this.media.Source; }
            set
            {
                this.media.Source = new Uri("http://localhost:" + Application.Current.Host.Source.Port + value);
            }
        }

        public void setMediaSource(string uri)
        {
            this.media.Source = new Uri("http://localhost:" + Application.Current.Host.Source.Port + uri);
            Debug.WriteLine("source settter a : " + this.media.Source);
        }
    }
}
