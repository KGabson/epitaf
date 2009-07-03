using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Threading;
using System.Net;

namespace MyLiveMesh.View
{
	public partial class MediaPlayer : UserControl
	{
        private bool isPlaying = true;
        private DispatcherTimer timer = new DispatcherTimer();

		public MediaPlayer()
		{
			// Required to initialize variables
			InitializeComponent();

            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            this.MediaElement.MediaOpened += new RoutedEventHandler(MediaElement_MediaOpened);
            this.Slider.MouseLeftButtonDown += new MouseButtonEventHandler(Slider_MouseLeftButtonDown);
            this.Slider.MouseLeftButtonUp += new MouseButtonEventHandler(Slider_MouseLeftButtonUp);
            this.Loaded += new RoutedEventHandler(MediaPlayer_Loaded);
        }

        public void Stop()
        {
            MediaElement.Stop();
            isPlaying = false;
            timer.Stop();
            btnPlayPause.Content = "Play";
            Slider.Value = 0;
        }

        #region Handlers
        void MediaPlayer_Loaded(object sender, RoutedEventArgs e)
        {
            this.btnPlayPause.Content = "Pause";
            isPlaying = true;
        }

        void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            btnPlayPause.Content = "Pause";
            isPlaying = true;
            timer.Start();
            Slider.Maximum = this.MediaElement.NaturalDuration.TimeSpan.TotalSeconds;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (!isPlaying)
                return;
            if (MediaElement.Position.TotalSeconds == 0.0)
                return;
            Slider.Value = MediaElement.Position.TotalSeconds;
            //Debug.WriteLine("==> " + this.MediaElement.Position.TotalSeconds + ", " + Slider.Maximum);
        }

        private void btnPlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                MediaElement.Pause();
                timer.Stop();
                isPlaying = false;
                btnPlayPause.Content = "Play";
            }
            else
            {
                MediaElement.Play();
                timer.Start();
                isPlaying = true;
                btnPlayPause.Content = "Pause";
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            Stop();
        }

        private void Slider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("ok");
        }

        private void Slider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("ok");
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }
        #endregion
    }
}