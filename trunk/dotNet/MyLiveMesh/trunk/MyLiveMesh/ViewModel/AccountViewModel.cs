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

namespace MyLiveMesh.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        private AccountServiceReference.AccountServiceClient authSrv = new MyLiveMesh.AccountServiceReference.AccountServiceClient();
        public AccountViewModel()
        {
            Commands.LoginCommands.AuthCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(AuthCommand_Executed);
        }

        void AuthCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
        }
    }
}
