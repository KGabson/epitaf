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
        private ObservableCollection<Node> dirList;
        private string      rootPath;
        private Visibility  visibility;
        private bool        isEnabled = false;
        private string      newFolderName;
        public Node         selectedNode;
        public Dialog       newFolderPopup;
        public string       userId;

        public ExplorerViewModel()
        {
            dirList = new ObservableCollection<Node>();
            newFolderName = "New Folder";
            userId = "0";
            dirList.Add(new Node("/ClientDocs/" + userId, "My Files", false, "../Data/folder.png", "../Data/folderOpen.png"));
            
            //Command
            Commands.ExplorerCommands.AddFolderCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(AddFolderCommand_Executed);

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

        public string NewFolderName
        {
            get { return newFolderName; }
            set
            {
                newFolderName= value;
                InvokePropertyChanged("NewFolderName");
            }
        }

        public void AddFolderCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            newFolderPopup.Show();
        }

        public void createDirectory(string dirname)
        {
            if (selectedNode != null)
            {
                Services.Services.UserDirectory.CreateDirectoryOnServerAsync(selectedNode.ID + "/" + dirname);
                selectedNode.Nodes.Add(CreateNewNodeFromSelectedNode(dirname));
            }
        }

        private Node CreateNewNodeFromSelectedNode(string nodeTitle)
        {
            return new Node(selectedNode.ID + "/" + nodeTitle, nodeTitle, false, "../Data/folder.png", "../Data/folderOpen.png");
        }
    }
}
