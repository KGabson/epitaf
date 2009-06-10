using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyWindowsMediaPlayer.View
{
    public partial class MovieProgressBar : UserControl
    {

        private int position;

        public MovieProgressBar()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            TotalDuration = 0;
            Position = 0;
        }

        public int test { get; set; }

        public int Position
        {
            get { return position; }
            set
            {
                if (value > TotalDuration)
                    throw new Exception("Invalid position: total duration is " + TotalDuration);
                position = value;
                this.panel1.Location = new Point(value - this.panel1.Width / 2, this.panel1.Location.Y);
            }
        }

        public double TotalDuration;

        public void updatePosition(int current_position)
        {
            if (this.TotalDuration == 0)
                return;
            if (current_position > TotalDuration)
                throw new Exception("Invalid position: total duration is " + TotalDuration);
            this.Position = (int)(current_position * this.Width / TotalDuration);
        }

        public double getClickedPosition(int x)
        {
            return (x * TotalDuration / this.Width);
        }
    }
}

