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
using MyLiveMesh.View;

namespace MyLiveMesh
{
    public partial class Page : UserControl
    {
        public UserControl currentMainView { get; private set; }

        public Page()
        {
            InitializeComponent();
            currentMainView = null;
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadView(new LoginView());
        }

        public void loadView(UserControl view)
        {
            if (currentMainView != null)
            {
                this.RootContent.Children.Remove(currentMainView);
            }
            this.RootContent.Children.Add(view);
            currentMainView = view;
        }

    }
}
