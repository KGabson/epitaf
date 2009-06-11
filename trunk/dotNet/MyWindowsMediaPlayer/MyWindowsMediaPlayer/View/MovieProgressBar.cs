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
    public partial class MovieProgressBar : UserControl
    {

        public MovieProgressBar()
        {
            InitializeComponent();
        }

        public int Position {
            get { return this.timeCursor.Location.X; }
            set { this.timeCursor.Location = new Point(value - this.timeCursor.Width / 2, this.timeCursor.Location.Y); }
        }
    }
}

