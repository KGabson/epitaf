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
using System.ComponentModel;

namespace MyLiveMesh.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected void InvokePropertyChanged(string PropertyName)
        {
            var e = new PropertyChangedEventArgs(PropertyName);
            PropertyChangedEventHandler Handler = PropertyChanged;
            if (Handler != null) 
                Handler(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
