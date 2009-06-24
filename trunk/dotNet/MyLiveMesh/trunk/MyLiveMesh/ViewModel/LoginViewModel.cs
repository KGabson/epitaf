﻿using System;
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
    public class LoginViewModel : ViewModelBase
    {
        #region Construction
        //private AccountServiceReference.AccountServiceClient authSrv = new MyLiveMesh.AccountServiceReference.AccountServiceClient();
        public LoginViewModel()
        {
            Commands.LoginCommands.AuthCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(AuthCommand_Executed);
            //Commands.LoginCommands.CreateAccountCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(CreateAccountCommand_Executed);
        }
        #endregion

        #region Bindable fields
        public String Login { get; set; }
        public String Password { get; set; }

        private String errorMsg;
        public String ErrorMsg 
        {
            get
            {
                return errorMsg;
            }
            set
            {
                errorMsg = value;
                InvokePropertyChanged("ErrorMsg");
            }
        }
        #endregion

        #region Command management
        void AuthCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            if (Password.Length == 0 || Login.Length == 0)
            {
                ErrorMsg = "Some fields are missing";
                return;
            }
            ErrorMsg = "Please wait...";
            Services.Services.AuthService.AuthentifyAsync(Login, Password);
        }

        //void CreateAccountCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        //{
        //    Debug.WriteLine("OK tu vas creer un compte");
        //}
        #endregion
    }
}