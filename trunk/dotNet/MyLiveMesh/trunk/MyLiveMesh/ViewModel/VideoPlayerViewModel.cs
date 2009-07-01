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

namespace MyLiveMesh.ViewModel
{
    public class VideoPlayerViewModel : ViewModelBase
    {
        //private bool isEnabled = false;
        //private UIElement.Visibility visibility = new Visibility();

        private String btnPlayPauseText;

        public VideoPlayerViewModel()
        {
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
    }
}
