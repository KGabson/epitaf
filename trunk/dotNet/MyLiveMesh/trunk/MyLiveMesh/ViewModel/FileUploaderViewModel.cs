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
using Liquid.Components;

namespace MyLiveMesh.ViewModel
{
    public class FileUploaderViewModel : ViewModelBase
    {
        public Uploader uploader;

        public FileUploaderViewModel()
        {
            Commands.FileUploaderCommand.selectFoldersButton.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(selectFoldersButton_Executed);
            uploader = new Uploader("http://localhost/MyLiveMesh/FileUploadService.svc");
        }

        public void selectFoldersButton_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
//            dialog.Filter = "Image files (*.gif;*.jpg;*.png)|*.gif;*.jpg;*.png";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == true)
            {
                Debug.WriteLine("files to upload " + dialog.Files.ToString());
                uploader.UploadFiles(dialog.Files, "/", true);
                if (uploader.WebserviceMethod != null)
                {
                    Debug.WriteLine("vla les methodes du webservice : " + uploader.WebserviceMethod);
                }
            }
        }
    }
}
