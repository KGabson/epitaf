using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel.Syndication;

namespace MyLiveMesh.ViewModel
{
    public class DesktopViewModel : ViewModelBase
    {
        private SyndicationFeed icones;

        public DesktopViewModel()
        {
        }

        public SyndicationFeed Icones
        {
            get
            {
                return icones;
            }

            set
            {
                icones = value;
                InvokePropertyChanged("Icones");
            }
        }
    }
}
