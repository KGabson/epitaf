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
using System.Collections.Generic;
using System.Diagnostics;
using Liquid;
using System.Collections.ObjectModel;

namespace MyLiveMesh.ViewModel
{
    public class ExplorerViewModel : ViewModelBase
    {
        private string      rootPath;
        private Visibility  visibility;
        private bool        isEnabled;
        private ObservableCollection<Node>  dirList;

        public ExplorerViewModel()
        {
            //visibility = System.Windows.Visibility.Visible;
            IsEnabled = true;
            dirList = new ObservableCollection<Node>();
            dirList.Add(new Node("1", "first node", true, "../Data/folder.png", "../Data/folderOpen.png"));
            dirList.Add(new Node("2", "Second node", false, "../Data/folder.png", "../Data/folderOpen.png"));
            dirList.Add(new Node("3", "Third node", false, "../Data/folder.png", "../Data/folderOpen.png"));
        }

        public string RootPath
        {
            get { return rootPath; }
            set
            {
                rootPath = value;
                InvokePropertyChanged("RootPath");
            }
        }

        public System.Windows.Visibility Visibility
        {
            get { return visibility; }
            set
            {
                visibility = value;
                InvokePropertyChanged("Visibility");
            }
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                InvokePropertyChanged("IsEnabled");
            }
        }

        public ObservableCollection<Node> DirList
        {
            get { return dirList; }
            set
            {
                dirList = value;
                InvokePropertyChanged("DirList");
            }
        }
    }
}
