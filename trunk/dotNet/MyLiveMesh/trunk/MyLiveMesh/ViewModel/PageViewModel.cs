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
using System.Diagnostics;

namespace MyLiveMesh.ViewModel
{
    public class PageViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        private ViewModelBase desktopViewModel;
        private ViewModelBase accountViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                InvokePropertyChanged("CurrentViewModel");
            }
        }

        public PageViewModel()
        {
            accountViewModel = new AccountViewModel();
            desktopViewModel = new DesktopViewModel();
            Services.Services.AuthService.AuthentifyCompleted += new EventHandler<MyLiveMesh.AccountServiceReference.AuthentifyCompletedEventArgs>(AuthService_AuthentifyCompleted);
            currentViewModel = accountViewModel;
        }

        void AuthService_AuthentifyCompleted(object sender, MyLiveMesh.AccountServiceReference.AuthentifyCompletedEventArgs e)
        {
            //Debug.WriteLine("===> " + e.Result);
        }
    }
}
