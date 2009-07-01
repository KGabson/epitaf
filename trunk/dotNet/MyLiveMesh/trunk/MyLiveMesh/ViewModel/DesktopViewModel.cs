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

namespace MyLiveMesh.ViewModel
{
    public class DesktopViewModel : ViewModelBase
    {
        private ExplorerViewModel explorer;
        private FileUploaderViewModel fileUploader = new FileUploaderViewModel();
        private List<FileViewModel> files = new List<FileViewModel>();
        private ProgressDialogViewModel progressDialog = new ProgressDialogViewModel();


        public DesktopViewModel()
        {
            //Init attributs
            files.Add(new FileViewModel("My Files", "dir", "ClientDocs"));

            //Commands bindings
            Commands.DesktopCommands.FileCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(FileCommand_Executed);
            Commands.DesktopCommands.FileUploaderCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(FileUploaderCommand_Executed);
            //Events Handler
            this.progressDialog.uploader.UploadFinished += new UploadEventHandler(uploader_UploadFinished);
        }

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
        
        public void FileCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            FileViewModel selectedFile = (FileViewModel)((ListBox)e.Source).SelectedItem;

            Debug.WriteLine(selectedFile.Title + " clicked");
            if (explorer == null)
                explorer = new ExplorerViewModel();
            explorer.IsEnabled = true;
            InvokePropertyChanged("Explorer");
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
                    progressDialog.uploader.UploadFiles(dialog.Files, "/ClientDocs/", true);
                    progressDialog.IsEnabled = true;
                }
            }
        }

        void uploader_UploadFinished(object sender, UploadEventArgs e)
        {
            this.progressDialog.IsEnabled = false;
        }

    }
}
