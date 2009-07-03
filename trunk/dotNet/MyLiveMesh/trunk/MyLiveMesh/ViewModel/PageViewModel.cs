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
using Common.BusinessObjects;

namespace MyLiveMesh.ViewModel
{
    public class PageViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        private ViewModelBase desktopViewModel;
        private ViewModelBase loginViewModel;
        private ViewModelBase createAccountViewModel;
        private ViewModelBase videoPlayerViewModel;

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
            createAccountViewModel = new CreateAccountViewModel();
            videoPlayerViewModel = new VideoPlayerViewModel();

            Services.Services.AuthService.AuthentifyCompleted += new EventHandler<MyLiveMesh.AccountServiceReference.AuthentifyCompletedEventArgs>(AuthService_AuthentifyCompleted);
            Services.Services.AuthService.CreateAccountCompleted += new EventHandler<MyLiveMesh.AccountServiceReference.CreateAccountCompletedEventArgs>(AuthService_CreateAccountCompleted);

            Commands.LoginCommands.CreateAccountCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(CreateAccountCommand_Executed);
            Commands.LoginCommands.BackToLoginCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(BackToLoginCommand_Executed);
            currentViewModel = loginViewModel;
        }

        void AuthService_CreateAccountCompleted(object sender, MyLiveMesh.AccountServiceReference.CreateAccountCompletedEventArgs e)
        {
            if (!e.Result.Success)
            {
                (createAccountViewModel as CreateAccountViewModel).ErrorMsg = e.Result.ErrorMsg;
                return;
            }
            (loginViewModel as LoginViewModel).ErrorMsg = "Account created successfully";
            CurrentViewModel = loginViewModel;
        }

        void CreateAccountCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            CurrentViewModel = createAccountViewModel;
        }

        void BackToLoginCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            CurrentViewModel = loginViewModel;
        }


        void AuthService_AuthentifyCompleted(object sender, MyLiveMesh.AccountServiceReference.AuthentifyCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                (loginViewModel as LoginViewModel).ErrorMsg = "Wrong login or password";
                return;
            }
            Debug.WriteLine((e.Result as UserInfo).Email);
            desktopViewModel = new DesktopViewModel((e.Result as UserInfo));
            CurrentViewModel = desktopViewModel;
        }
    }
}
