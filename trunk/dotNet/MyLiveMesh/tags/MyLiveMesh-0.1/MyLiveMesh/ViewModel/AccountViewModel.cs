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
using MyLiveMesh.Commanding;
using System.Diagnostics;
using MyLiveMesh.View;
using MyLiveMesh.DBServiceReference;
using System.Security.Cryptography;
using Shared;

namespace MyLiveMesh.ViewModel
{
    public class AccountViewModel
    {
        #region Fields
        public String Login { get; set; }
        public String Password { get; set; }

        private LoginView loginView;
        private Page currentPage;
        private DBServiceReference.DBServiceClient srv;
        #endregion

        #region Constructor
        public AccountViewModel()
        {
            currentPage = App.Current.RootVisual as Page;
            Debug.WriteLine(currentPage.currentMainView.GetType());
            if (currentPage.currentMainView.GetType() == Type.GetType("MyLiveMesh.View.LoginView"))
                loginView = currentPage.currentMainView as LoginView;

            srv = new MyLiveMesh.DBServiceReference.DBServiceClient();
            srv.AuthentifyCompleted += new EventHandler<MyLiveMesh.DBServiceReference.AuthentifyCompletedEventArgs>(srv_AuthentifyCompleted);
        }
        #endregion

        #region Commands
        RelayCommand authentifyCommand;
        public RelayCommand AuthentifyCommand
        {
            get
            {
                if (authentifyCommand == null)
                {
                    authentifyCommand = new RelayCommand(
                        () => this.Authentify(),
                        () => true
                    );
                }
                return authentifyCommand;
            }
        }

        public void Authentify()
        {
            if (loginView == null)
                throw new Exception("No LoginView has been initialized, so could not find password field");
            //String password = loginView.passwordBox.Password;
            Password = loginView.passwordBox.Password;
            srv.AuthentifyAsync(Login, Password);
            Debug.WriteLine("Login: " + Login + ", Password: " + Password);

        }

        public void srv_AuthentifyCompleted(object sender, EventArgs e)
        {
            AuthentifyCompletedEventArgs args = e as AuthentifyCompletedEventArgs;
            Debug.WriteLine(args.Result.ToString());
        }
        #endregion


    }
}
