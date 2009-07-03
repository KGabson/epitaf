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
using System.ServiceModel.Syndication;
using System.Collections.Generic;
using System.Diagnostics;
using MyLiveMesh.View;
using Liquid.Components;
using Common.BusinessObjects;
using Liquid;
using System.Collections.ObjectModel;

namespace MyLiveMesh.ViewModel
{
    public class DesktopViewModel : ViewModelBase
    {
        private ExplorerViewModel explorer;
        private FileUploaderViewModel fileUploader = new FileUploaderViewModel();
        private List<FileViewModel> files = new List<FileViewModel>();
        public ObservableCollection<SharedFolder> MySharedFolders = new ObservableCollection<SharedFolder>();
        private ProgressDialogViewModel progressDialog = new ProgressDialogViewModel();
        private VideoPlayerViewModel mediaPlayer = new VideoPlayerViewModel();
        public UserInfo userInfo;

        public DesktopViewModel(UserInfo _user)
        {
            //Init attributs
            userInfo = _user;

            //Commands bindings
            Commands.DesktopCommands.FileCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(FileCommand_Executed);
            Commands.DesktopCommands.FileUploaderCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(FileUploaderCommand_Executed);
            //Events Handler
            this.progressDialog.uploader.UploadFinished += new UploadEventHandler(uploader_UploadFinished);
        }


        #region Fields
        public List<FileViewModel> Files
        {
            get { return files; }

            set 
            { 
                files = value;
                InvokePropertyChanged("Files");
            }
        }

        public ExplorerViewModel Explorer
        {
            get { return explorer; }

            set
            {
                explorer = value;
                InvokePropertyChanged("Explorer");
            }
        }

        public FileUploaderViewModel FileUploader
        {
            get { return fileUploader; }
            set 
            {
                fileUploader = value;
                InvokePropertyChanged("FileUploader");
            }
        }

        public ProgressDialogViewModel ProgressDialog
        {
            get { return progressDialog; }
            set
            {
                progressDialog = value;
                InvokePropertyChanged("ProgressDialog");
            }
        }

        public VideoPlayerViewModel MediaPlayer
        {
            get { return mediaPlayer; }
            set
            {
                mediaPlayer = value;
                InvokePropertyChanged("MediaPlayer");
            }
        }

        #endregion

        #region Commands
        public void FileCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            FileViewModel selectedFile = (FileViewModel)(((ListBox)e.Source).SelectedItem as File).DataContext;
            
            if (selectedFile != null)
            {
                Debug.WriteLine(selectedFile.Title + " clicked");
                if (explorer == null)
                {
                    explorer = new ExplorerViewModel(selectedFile.Path);
                }
                else if (selectedFile.Path != explorer.DirList[0].Title)
                {
                    Debug.WriteLine("nouveau explorer " + selectedFile.Path);
                    explorer.updateWithPath(selectedFile.Path, selectedFile.Title, selectedFile.IsOwner);
                    explorer.IsEnabled = false;

                }
                explorer.IsEnabled = true;
                InvokePropertyChanged("Explorer");
            }
        }

        public void FileUploaderCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            if (ProgressDialog.IsEnabled == false)
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Multiselect = true;
                if (dialog.ShowDialog() == true)
                {
                    progressDialog.Progress.Complete = 0;
                    progressDialog.Progress.Text = "0 %";
                    Debug.WriteLine("files to upload " + dialog.Files.ToString());
                    progressDialog.uploader.UploadFiles(dialog.Files, this.explorer.selectedNode.ID + "/", true);
                    progressDialog.IsEnabled = true;
                }
            }
        }
        #endregion

        void uploader_UploadFinished(object sender, UploadEventArgs e)
        {
            this.progressDialog.IsEnabled = false;
            this.explorer.fillItemsFromServerPath();
        }

    }
}
