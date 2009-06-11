using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyWindowsMediaPlayer.View;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace MyWindowsMediaPlayer.ViewModel
{
    class MovieProgressBarViewModel : IViewModel
    {
        private Point position;
        public Point Position {
            get { return position; }
            set
            {
                if (value.X > this.view.Width)
                    throw new Exception("Invalid position: maximum allowed value is " + this.view.Width);
                position = value;
                this.view.timeCursor.Location = new Point(value.X, this.view.timeCursor.Location.Y);
            }
        }

        public double TotalDuration { get; set; }

        
        private MovieProgressBar view;

        public MovieProgressBarViewModel(MovieProgressBar view)
        {
            this.view = view;
            init();
        }

        void init()
        {
            TotalDuration = 50;
            Position = new Point(0, 0);
        }

        public void updatePosition(double current_position_in_total_duration)
        {
            if (this.TotalDuration == 0)
                return;
            if (current_position_in_total_duration > TotalDuration)
                throw new Exception("Invalid position: total duration is " + TotalDuration);
            this.Position = new Point((int)(current_position_in_total_duration * this.view.Width / TotalDuration), this.view.timeCursor.Location.Y);
            //TO RECODE !!
            //this.Position = (int)(current_position * this.view.Width / TotalDuration);
        }

        public double getClickedPosition(int x)
        {
            return (x * TotalDuration / this.view.Width);
        }

        #region Bindable functions

        public void movieProgressBar_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hop => " + (e as MouseEventArgs).X);
            Position = new Point((e as MouseEventArgs).X, this.view.timeCursor.Location.Y);
        }
        #endregion

    }
}
