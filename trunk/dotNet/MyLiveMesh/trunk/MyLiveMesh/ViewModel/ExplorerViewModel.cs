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
using System.IO;

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
        public string       serverRootPath;
        public Node         expandedNode;

        public ExplorerViewModel()
        {
            dirList = new ObservableCollection<Node>();
            userId = "0";
            serverRootPath = "/ClientDocs/" + userId + "/";
            newFolderName = "New Folder";
            selectedNode = new Node(serverRootPath, "My Files", true, "../Data/folder.png", "../Data/folderOpen.png");
            expandedNode = selectedNode;
            Debug.WriteLine(serverRootPath);
            updateDirListFromServer(serverRootPath);            
            dirList.Add(selectedNode);
            
            //Command
            Commands.ExplorerCommands.AddFolderCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(AddFolderCommand_Executed);
            Services.Services.UserDirectory.getDirectoryTreeFromPathCompleted += new EventHandler<MyLiveMesh.UserDirectoryServiceReference.getDirectoryTreeFromPathCompletedEventArgs>(UserDirectory_getDirectoryTreeFromPathCompleted);
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
                Node newNode = CreateNewNodeFromSelectedNode(dirname);
                string newFolderId = selectedNode.ID + "/" + dirname;
                if (!selectedNode.Nodes.Contains(newNode))
                {
                    Services.Services.UserDirectory.CreateDirectoryOnServerAsync(selectedNode.ID + "/" + dirname);
                    selectedNode.Nodes.Add(newNode);
                }
            }
        }

        private Node CreateNewNodeFromSelectedNode(string nodeTitle)
        {
            return new Node(selectedNode.ID + "/" + nodeTitle, nodeTitle, false, "../Data/folder.png", "../Data/folderOpen.png");
        }

        public void updateDirListFromServer(string path)
        {
            Services.Services.UserDirectory.getDirectoryTreeFromPathAsync(path);
        }

        void UserDirectory_getDirectoryTreeFromPathCompleted(object sender, MyLiveMesh.UserDirectoryServiceReference.getDirectoryTreeFromPathCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                List<String> dirlist = new List<string>(e.Result as ObservableCollection<string>);
                if (dirlist.Count > 0)
                    selectedNode.HasChildren = true;
                foreach (string dirname in dirlist)
                {
                    Node newnode = CreateNewNodeFromSelectedNode(dirname);
                    Debug.WriteLine("new node = " + newnode.ID);
                    selectedNode.Nodes.Add(newnode);
                }
            }
        }
    }
}
