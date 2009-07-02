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

namespace MyLiveMesh.View
{
    public partial class MediaPlayerPopup : UserControl
    {
        public MediaPlayerPopup()
        {
            InitializeComponent();
            this.itemViewerPopup.Show();
            //this.MediaPlayer.MediaElement.Source = ;
        }

        private void itemViewerPopup_Closed(object sender, Liquid.DialogEventArgs e)
        {
            this.MediaPlayer.MediaElement.Stop();
        }
    }
}
