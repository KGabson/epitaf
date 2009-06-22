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
using System.Collections.Generic;
using System.Diagnostics;

namespace MyLiveMesh.ViewModel
{
    public class DesktopViewModel : ViewModelBase
    {
        private List<String> icones;

        public DesktopViewModel()
        {
            Icones = new List<String>();
            String but = "mais putain";
            Icones.Add(but);
            Icones.Add("tamere elle suce");
            Icones.Add("mais putain");
            Icones.Add("c quoi ce bordel");
            Icones.Add("jean naipleinlcul");
            InvokePropertyChanged("Icones");           
        }

        public List<String> Icones
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
