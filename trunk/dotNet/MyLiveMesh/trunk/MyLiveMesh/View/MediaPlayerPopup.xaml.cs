using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Diagnostics;
using MyLiveMesh.ViewModel;

namespace MyLiveMesh.View
{
    public partial class MediaPlayerPopup : UserControl
    {
        public MediaPlayerPopup()
        {
            InitializeComponent();
            //this.itemViewerPopup.Show();
            Debug.WriteLine("mediaPlayerPopup ctor");
            this.Loaded += new RoutedEventHandler(MediaPlayerPopup_Loaded);
            this.MediaPlayer.MediaElement.MediaFailed += new EventHandler<ExceptionRoutedEventArgs>(MediaElement_MediaFailed);
        }

        void MediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            this.itemViewerPopup.Close();
        }

        void MediaPlayerPopup_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                (DataContext as VideoPlayerViewModel).popup = this.itemViewerPopup;
                (DataContext as VideoPlayerViewModel).media = this.MediaPlayer.MediaElement;
            }
        }

        private void itemViewerPopup_Closed(object sender, Liquid.DialogEventArgs e)
        {
            this.MediaPlayer.Stop();
        }
    }
}
