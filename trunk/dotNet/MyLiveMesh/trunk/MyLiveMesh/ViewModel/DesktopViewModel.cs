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

namespace MyLiveMesh.ViewModel
{
    public class DesktopViewModel : ViewModelBase
    {
        private List<FileViewModel> files;

        public DesktopViewModel()
        {
            files = new List<FileViewModel>();
            FileViewModel but = new FileViewModel();
            but.Title = "Le directory!";
            files.Add(but);
            files.Add(new FileViewModel());
            files.Add(new FileViewModel());
            files.Add(new FileViewModel());
            files.Add(new FileViewModel());
            InvokePropertyChanged("Files");
            Commands.DesktopCommands.FileCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(FileCommand_Executed);
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

        public void test(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Ca serait trop rebeeeeeel");
        }

        public void FileCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            ListBox list = (ListBox)e.Source;
            FileViewModel selectedFile = (FileViewModel)list.SelectedItem;
            Debug.WriteLine("youpi mon con !!!!!" + selectedFile.Title);
        }
    }
}
