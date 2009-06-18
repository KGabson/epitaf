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

namespace MyLiveMesh
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            Debug.WriteLine("Hello !");
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("====> " + App.Current.RootVisual.ToString());
        }
    }
}
