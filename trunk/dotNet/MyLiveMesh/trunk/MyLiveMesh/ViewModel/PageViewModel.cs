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

namespace MyLiveMesh.ViewModel
{
    public class PageViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                InvokePropertyChanged("CurrentViewModel");
            }
        }

        private AccountViewModel accountViewModel;

        public PageViewModel()
        {
            accountViewModel = new AccountViewModel();
            currentViewModel = accountViewModel;
        }
    }
}
