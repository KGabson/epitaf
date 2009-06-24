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
        private ViewModelBase loginViewModel;
        private ViewModelBase createAccountViewModel;

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
            loginViewModel = new LoginViewModel();
            desktopViewModel = new DesktopViewModel();
            createAccountViewModel = new CreateAccountViewModel();

            Services.Services.AuthService.AuthentifyCompleted += new EventHandler<MyLiveMesh.AccountServiceReference.AuthentifyCompletedEventArgs>(AuthService_AuthentifyCompleted);
            Services.Services.AuthService.CreateAccountCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(AuthService_CreateAccountCompleted);

            Commands.LoginCommands.CreateAccountCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(CreateAccountCommand_Executed);
            currentViewModel = loginViewModel;
        }

        void AuthService_CreateAccountCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            (loginViewModel as LoginViewModel).ErrorMsg = "Account created successfully";
            CurrentViewModel = loginViewModel;
        }

        void CreateAccountCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            Debug.WriteLine("Create Account !!!");
            CurrentViewModel = createAccountViewModel;
        }

        void AuthService_AuthentifyCompleted(object sender, MyLiveMesh.AccountServiceReference.AuthentifyCompletedEventArgs e)
        {
            if (e.Result == false)
            {
                (loginViewModel as LoginViewModel).ErrorMsg = "Wrong login or password";
                return;
            }
            CurrentViewModel = desktopViewModel;
        }
    }
}
