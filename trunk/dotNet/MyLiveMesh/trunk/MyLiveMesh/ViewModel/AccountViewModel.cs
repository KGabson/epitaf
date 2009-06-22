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
using MyLiveMesh.Commands;
using System.Diagnostics;

namespace MyLiveMesh.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        #region Construction
        //private AccountServiceReference.AccountServiceClient authSrv = new MyLiveMesh.AccountServiceReference.AccountServiceClient();
        public AccountViewModel()
        {
            Commands.LoginCommands.AuthCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(AuthCommand_Executed);
        }
        #endregion

        #region Bindable fields
        public String Login { get; set; }
        public String Password { get; set; }
        public String ErrorMsg { get; set; }
        #endregion

        #region Command management
        void AuthCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            if (Password.Length == 0 || Login.Length == 0)
            {
                ErrorMsg = "Some fields are missing";
                return;
            }
            Debug.WriteLine("==> " + Login + ", " + Password);
            Services.Services.AuthService.AuthentifyAsync(Login, Password);
            //authSrv.AuthentifyAsync(Login, Password);
            //authSrv.AuthentifyCompleted += new EventHandler<MyLiveMesh.AccountServiceReference.AuthentifyCompletedEventArgs>(authSrv_AuthentifyCompleted);
        }

        void authSrv_AuthentifyCompleted(object sender, MyLiveMesh.AccountServiceReference.AuthentifyCompletedEventArgs e)
        {
            Debug.WriteLine(e.Result.ToString());
        }
        #endregion
    }
}
