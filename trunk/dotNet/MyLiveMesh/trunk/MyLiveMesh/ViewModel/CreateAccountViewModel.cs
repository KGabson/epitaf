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
using System.Reflection;
using System.Text.RegularExpressions;

namespace MyLiveMesh.ViewModel
{
    public class CreateAccountViewModel : ViewModelBase
    {
        #region Construction
        public CreateAccountViewModel()
        {
            Commands.LoginCommands.SubmitCreateAccountCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(SubmitCreateAccountCommand_Executed);
        }
        #endregion

        #region Bindable Fields
        public String Login { get; set; }

        private String loginError;
        public String LoginError
        {
            get
            {
                return loginError;
            }
            set
            {
                loginError = value;
                InvokePropertyChanged("LoginError");
            }
        }

        public String Password { get; set; }

        private String passwordError;
        public String PasswordError
        {
            get
            {
                return passwordError;
            }
            set
            {
                passwordError = value;
                InvokePropertyChanged("PasswordError");
            }
        }

        public String PasswordConfirmation { get; set; }

        private String passwordConfirmationError;
        public String PasswordConfirmationError
        {
            get
            {
                return passwordConfirmationError;
            }
            set
            {
                passwordConfirmationError = value;
                InvokePropertyChanged("PasswordConfirmationError");
            }
        }

        public String Email { get; set; }

        private String emailError;
        public String EmailError
        {
            get
            {
                return emailError;
            }
            set
            {
                emailError = value;
                InvokePropertyChanged("EmailError");
            }
        }
        #endregion

        #region Commands management
        bool checkField(String prop_name)
        {
            PropertyInfo pInfo = this.GetType().GetProperty(prop_name);
            String value = (String)pInfo.GetValue(this, null);
            String prop_error_name = prop_name + "Error";
            PropertyInfo pErrorInfo = this.GetType().GetProperty(prop_error_name);
            bool error = true;

            if (value == null)
                error = false;
            else
            {
                if (value.Trim().Length == 0)
                    error = false;
            }
            if (error == false)
            {
                pErrorInfo.SetValue(this, "Mandatory field", null);
                return false;
            }
            pErrorInfo.SetValue(this, "", null);
            pInfo.SetValue(this, value.Trim(), null);
            return true;
        }

        bool checkPasswordMatch()
        {
            if (Password != PasswordConfirmation)
            {
                PasswordConfirmationError = "Password verification mismatch";
                return false;
            }
            return true;
        }

        bool checkEmail()
        
        {
            if (!Regex.Match(Email, "^[a-z0-9.-_]+@[a-z0-9.-_]{2,}\\.[a-z]{2,6}$").Success)
            {
                EmailError = "Invalid Email Address";
                return false;
            }
            return true;
        }

        bool validationProcess()
        {
            bool ok = false;

            ok = checkField("Login");
            if (checkField("Password"))
            {
                if (checkField("PasswordConfirmation"))
                {
                    if (checkPasswordMatch() && ok)
                        ok = true;
                    else
                        ok = false;
                }
                else
                    ok = false;
            }
            else
                ok = false;
            if (checkField("Email"))
            {
                if (checkEmail() && ok)
                    ok = true;
                else
                    ok = false;
            }
            else
                ok = false;
            return ok;
        }

        void SubmitCreateAccountCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            if (!validationProcess())
                return;
            Services.Services.AuthService.CreateAccountAsync(Login, Password, Email);
        }
        #endregion
    }
}
