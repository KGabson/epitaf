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
    public class ShareFolderViewModel : ViewModelBase
    {
        private String shareLogin;
        private bool isOwner;
        private String errorMsg;
        private String errorMsgColor;

        private ExplorerViewModel expViewModel;

        public ShareFolderViewModel(ExplorerViewModel expViewModel)
        {
            Commands.ExplorerCommands.SubmitSharingCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(SubmitSharingCommand_Executed);
            Services.Services.UserDirectory.ShareFolderCompleted += new EventHandler<MyLiveMesh.UserDirectoryServiceReference.ShareFolderCompletedEventArgs>(UserDirectory_ShareFolderCompleted);
            this.expViewModel = expViewModel;
            errorMsgColor = Tools.Colors.Green;
        }

        public void Reset()
        {
            ShareLogin = "";
            IsOwner = false;
            ErrorMsgColor = Tools.Colors.Green;
            ErrorMsg = "";
        }

        void UserDirectory_ShareFolderCompleted(object sender, MyLiveMesh.UserDirectoryServiceReference.ShareFolderCompletedEventArgs e)
        {
            if (!e.Result.Success)
            {
                ErrorMsgColor = Tools.Colors.Red;
                ErrorMsg = e.Result.ErrorMsg;
                return;
            }
            ErrorMsgColor = Tools.Colors.Green;
            ErrorMsg = "This folder is now shared with " + shareLogin;
        }

        void SubmitSharingCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            if (shareLogin == null || shareLogin.Trim().Length == 0)
                return;
            UserInfo uInfo = (((App.Current.RootVisual as Page).DataContext as PageViewModel).CurrentViewModel as DesktopViewModel).userInfo;
            ErrorMsgColor = Tools.Colors.Green;
            ErrorMsg = "Please wait...";
            Services.Services.UserDirectory.ShareFolderAsync(uInfo.Id, shareLogin, expViewModel.selectedNode.ID, isOwner);
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

        public String ErrorMsgColor
        {
            get { return errorMsgColor; }
            set
            {
                errorMsgColor = value;
                InvokePropertyChanged("ErrorMsgColor");
            }
        }
        #endregion
    }
}
