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

namespace MyLiveMesh.ViewModel
{
    public class DesktopViewModel : ViewModelBase
    {
        private List<FileViewModel> files;
        private ExplorerViewModel explorer;
        private List<ExplorerViewModel> explorers;

        public DesktopViewModel()
        {
            files = new List<FileViewModel>();
            explorers = new List<ExplorerViewModel>();
            //explorers.Add(new ExplorerViewModel());
            FileViewModel but = new FileViewModel();
            but.Title = "My Files";
            files.Add(but);
            files.Add(new FileViewModel());
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

        public ExplorerViewModel Explorer
        {
            get { return explorer; }

            set
            {
                explorer = value;
                InvokePropertyChanged("Explorer");
            }
        }
                                       
        public List<ExplorerViewModel> Explorers
        {
            get { return explorers; }
            set
            {
                explorers = value;
                InvokePropertyChanged("Explorers");
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
    }
}
