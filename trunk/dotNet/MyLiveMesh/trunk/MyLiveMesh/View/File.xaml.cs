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

namespace MyLiveMesh.View
{
	public partial class File : UserControl
	{
		public File()
		{
			// Required to initialize variables
			InitializeComponent();
            Debug.WriteLine("File ctor");
 		}
	}
}