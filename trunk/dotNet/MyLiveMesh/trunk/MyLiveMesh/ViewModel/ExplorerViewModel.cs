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
        private string              rootPath;
        private Visibility          visibility;
        private bool                isEnabled = false;
        private string              newFolderName;
        public Node                 selectedNode;
        public Dialog               newFolderPopup;
		public Dialog               shareFolderPopup;
        public string               userId;
        public string               serverRootPath;
        public Node                 expandedNode;
        public ItemViewer           itemViewer = new ItemViewer();


        public ExplorerViewModel()
        {
            dirList = new ObservableCollection<Node>();
            userId = (((App.Current.RootVisual as Page).DataContext as PageViewModel).CurrentViewModel as DesktopViewModel).userInfo.Id.ToString();
            userId = (userId == "") ? "0" : userId;
            serverRootPath = "/ClientDocs/" + userId + "/";
            newFolderName = "New Folder";
            selectedNode = new Node(serverRootPath, "My Files", true, "../Data/folder.png", "../Data/folderOpen.png");
            expandedNode = selectedNode;
            updateDirListFromServer(serverRootPath);            
            dirList.Add(selectedNode);
        
            //Command
            Commands.ExplorerCommands.AddFolderCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(AddFolderCommand_Executed);
            Commands.ExplorerCommands.ShareFolderCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(ShareFolderCommand_Executed);
            //Delegate
            Services.Services.UserDirectory.getDirectoryTreeFromPathCompleted += new EventHandler<MyLiveMesh.UserDirectoryServiceReference.getDirectoryTreeFromPathCompletedEventArgs>(UserDirectory_getDirectoryTreeFromPathCompleted);
            Services.Services.UserDirectory.getFilesFromPathCompleted += new EventHandler<MyLiveMesh.UserDirectoryServiceReference.getFilesFromPathCompletedEventArgs>(UserDirectory_getFilesFromPathCompleted);
        
        }

        #region Attributs

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
#endregion

        #region Commands

        public void AddFolderCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            newFolderPopup.Show();
        }

        void ShareFolderCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            shareFolderPopup.Show();
        }

        #endregion

        #region ToolsFunctions
        public void createDirectory(string dirname)
        {
            if (selectedNode != null)
            {
                Node newNode = CreateNewNodeFromSelectedNode(dirname);
                string newFolderId = selectedNode.ID + "/" + dirname;
                if (!selectedNode.Nodes.Contains(newNode))
                {
                    Services.Services.UserDirectory.CreateDirectoryOnServerAsync(selectedNode.ID + "/" + dirname);
                    if (selectedNode.IndexOfChild(newNode.ID) == -1)
                    {
                        selectedNode.Nodes.Add(newNode);
                    }
                }
            }
        }

        private FileItem CreateItem(string type, string filename, string desc)
        {
            return new FileItem() { Icon = "../Data/Large/" + type.Substring(1) + ".png", Text = filename, OtherText = desc };
        }

        private Node CreateNewNodeFromSelectedNode(string nodeTitle)
        {
            return new Node(selectedNode.ID + "/" + nodeTitle, nodeTitle, false, "../Data/folder.png", "../Data/folderOpen.png");
        }

        public void updateDirListFromServer(string path)
        {
            Services.Services.UserDirectory.getDirectoryTreeFromPathAsync(path);
        }

        public void fillItemsFromServerPath()
        {
            if (selectedNode.ID != null)
            {
                Services.Services.UserDirectory.getFilesFromPathAsync(selectedNode.ID);
            }
        }
        #endregion

        #region Delegate
        void UserDirectory_getDirectoryTreeFromPathCompleted(object sender, MyLiveMesh.UserDirectoryServiceReference.getDirectoryTreeFromPathCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                int nb = 0;
                List<String> dirlist = new List<string>(e.Result as ObservableCollection<string>);
                if (dirlist.Count > 1 && selectedNode.ID == dirlist[0])
                {
                    selectedNode.HasChildren = true;
                    foreach (string dirname in dirlist)
                    {
                        if (nb != 0)
                        {
                            Node newnode = CreateNewNodeFromSelectedNode(dirname);
                            selectedNode.Nodes.Add(newnode);
                        }
                        nb++;
                    }
                }
            }
        }

        void UserDirectory_getFilesFromPathCompleted(object sender, MyLiveMesh.UserDirectoryServiceReference.getFilesFromPathCompletedEventArgs e)
        {
            ObservableCollection<ObservableCollection<string>> files = new ObservableCollection<ObservableCollection<string>>();
            List<ItemViewerItem> items = new List<ItemViewerItem>();
            
            files = e.Result;
            itemViewer.Clear();
            foreach (ObservableCollection<string> fileinfo in files)
            {
                Debug.WriteLine("ben c quoi l'extension ? : " + fileinfo[1]);
                items.Add(CreateItem(fileinfo[1], fileinfo[0], fileinfo[2]));
            }
            itemViewer.Add(items);
        }
        #endregion

    }
}
