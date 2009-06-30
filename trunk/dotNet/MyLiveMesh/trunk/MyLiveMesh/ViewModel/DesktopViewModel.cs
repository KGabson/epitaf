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
        private List<FileViewModel> files;
        private ExplorerViewModel explorer;
        private FileUploaderViewModel fileUploader;
        public Uploader uploader;


        public DesktopViewModel()
        {
            files = new List<FileViewModel>();
            FileViewModel but = new FileViewModel();
            uploader = new Uploader("http://localhost:54164/Services/FileUp.asmx");
            but.Title = "My Files";
            files.Add(but);
            files.Add(new FileViewModel());
            Commands.DesktopCommands.FileCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(FileCommand_Executed);
            Commands.DesktopCommands.FileUploaderCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(FileUploaderCommand_Executed);
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

        public void FileCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            FileViewModel selectedFile = (FileViewModel)((ListBox)e.Source).SelectedItem;
            Debug.WriteLine(selectedFile.Title + " clicked et aussi => " + sender.GetType());
            if (explorer == null)
            {
                ExplorerViewModel ex = new ExplorerViewModel();
                ex.RootPath = selectedFile.Title;
                explorer = ex;
            }
            explorer.IsEnabled = true;
            InvokePropertyChanged("Explorer");
        }

        public void FileUploaderCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
//          this.fileUploader = new FileUploaderViewModel();
//          InvokePropertyChanged("FileUploader");
            OpenFileDialog dialog = new OpenFileDialog();
//          dialog.Filter = "Image files (*.gif;*.jpg;*.png)|*.gif;*.jpg;*.png";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == true)
            {
                Debug.WriteLine("files to upload " + dialog.Files.ToString());
                uploader.UploadFiles(dialog.Files, "/ClientDocs/", true);
                if (uploader.WebserviceMethod != null)
                {
                    Debug.WriteLine("vla les methodes du webservice : " + uploader.WebserviceMethod);
                }
            } 
        }
    }
}
