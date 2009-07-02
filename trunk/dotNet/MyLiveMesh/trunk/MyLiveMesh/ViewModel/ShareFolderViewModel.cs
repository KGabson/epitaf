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
    public class ShareFolderViewModel : ViewModelBase
    {
        private String shareLogin;
        private bool isOwner;
        private String errorMsg;

        private ExplorerViewModel expViewModel;

        public ShareFolderViewModel(ExplorerViewModel expViewModel)
        {
            Commands.ExplorerCommands.SubmitSharingCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(SubmitSharingCommand_Executed);
            this.expViewModel = expViewModel;
        }

        void SubmitSharingCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            Debug.WriteLine(this.expViewModel.ToString());
            if (shareLogin == null || shareLogin.Trim().Length == 0)
                return;
        }

        #region Fields
        public String ShareLogin
        {
            get { return shareLogin; }
            set
            {
                shareLogin = value;
                InvokePropertyChanged("ShareLogin");
            }
        }

        public bool IsOwner
        {
            get { return isOwner; }
            set
            {
                isOwner = value;
                InvokePropertyChanged("ShareLogin");
            }
        }

        public String ErrorMsg
        {
            get { return errorMsg; }
            set
            {
                errorMsg = value;
                InvokePropertyChanged("ErrorMsg");
            }
        }
        #endregion
    }
}
