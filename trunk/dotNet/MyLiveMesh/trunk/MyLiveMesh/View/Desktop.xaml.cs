using System;
using System.Collections.Generic;
using System.Windows;
using System.Net;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Liquid;

namespace MyLiveMesh.View
{
	public partial class Desktop : UserControl
	{
		public Desktop()
		{
			// Required to initialize variables
			InitializeComponent();
            this.viewerPopup.Show();
            //Dialog test = new Dialog();
            //test.Show();
            //this.LayoutRoot.Children.Add(test);
            //test.Show();
		}
	}
}