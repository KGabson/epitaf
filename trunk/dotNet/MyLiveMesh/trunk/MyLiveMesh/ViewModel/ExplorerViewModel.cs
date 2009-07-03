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
        private ObservableCollection<Node> dirList = new ObservableCollection<Node>();
        private Visibility          visibility;
        private bool                isEnabled = false;
        private string              newFolderName = "New Folder";
        public Node                 selectedNode;
        public Dialog               newFolderPopup;
		public Dialog               shareFolderPopup;
        public string               userId;
        public string               serverRootPath;
        public ItemViewer           itemViewer = new ItemViewer();
        public DesktopViewModel     parentDestop;
        public List<string>         handleExtension = new List<string>();
        public Tree                 fileTree;

        public ExplorerViewModel()
        {
            init();
        }

        public ExplorerViewModel(string _rootPath)
        {
            serverRootPath = _rootPath;
            init();
        }

        #region Attributs

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

        void DeleteFolderCommand_Executed(object sender, SLExtensions.Input.ExecutedEventArgs e)
        {
            if (this.itemViewer.Selected != null)
            {
                Debug.WriteLine("Selected item: " + selectedNode.ID + "/" + this.itemViewer.Selected.Name);
                Services.Services.UserDirectory.deletePathAsync(selectedNode.ID + "/" + this.itemViewer.Selected.Text);
            }
        }

        #endregion

        #region ToolsFunctions
        private void init()
        {
            parentDestop = (((App.Current.RootVisual as Page).DataContext as PageViewModel).CurrentViewModel as DesktopViewModel);
            Visibility = Visibility.Visible;
            //userId = (parentDestop.userInfo.Id.ToString() == "") ? "0" : userId;
            //serverRootPath = rootPath + userId;           
            if (serverRootPath != null)
            {
                selectedNode = new Node(serverRootPath, "My Files", true, "../Data/folder.png", "../Data/folderOpen.png");
                updateDirListFromServer(serverRootPath);
                dirList.Add(selectedNode);
            }
            handleExtension.Add("wmv");
            handleExtension.Add("wma");
            handleExtension.Add("mp3");

            //Command
            Commands.ExplorerCommands.AddFolderCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(AddFolderCommand_Executed);
            Commands.ExplorerCommands.ShareFolderCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(ShareFolderCommand_Executed);
            Commands.ExplorerCommands.DeleteFolderCommand.Executed += new EventHandler<SLExtensions.Input.ExecutedEventArgs>(DeleteFolderCommand_Executed);
            //Delegate
            Services.Services.UserDirectory.getDirectoryTreeFromPathCompleted += new EventHandler<MyLiveMesh.UserDirectoryServiceReference.getDirectoryTreeFromPathCompletedEventArgs>(UserDirectory_getDirectoryTreeFromPathCompleted);
            Services.Services.UserDirectory.getFilesFromPathCompleted += new EventHandler<MyLiveMesh.UserDirectoryServiceReference.getFilesFromPathCompletedEventArgs>(UserDirectory_getFilesFromPathCompleted);
            Services.Services.UserDirectory.deletePathCompleted += new EventHandler<MyLiveMesh.UserDirectoryServiceReference.deletePathCompletedEventArgs>(UserDirectory_deletePathCompleted);
        }
    
        public void updateWithPath(string newPath, string rootTitle, bool isOwner)
        {
            serverRootPath = newPath;
            DirList.Clear();
            selectedNode = new Node(newPath, rootTitle, true, "../Data/folder.png", "../Data/folderOpen.png");
            DirList.Add(selectedNode);
            itemViewer.Clear();
            updateDirListFromServer(newPath);
            if (!isOwner)
            {
                Visibility = Visibility.Collapsed;
            }
            else
            {
                Visibility = Visibility.Visible;
            }
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

        public void launchFile(string filename)
        {
            Debug.WriteLine("Launching File: " + this.selectedNode.ID + "/" + filename);
            String file = filename;
            int pos = file.LastIndexOf('.');
            if (pos > 0)
            {
                parentDestop.MediaPlayer.setMediaSource(this.selectedNode.ID + "/" + filename);
                if (handleExtension.Contains(filename.Substring(pos + 1)))
                    parentDestop.MediaPlayer.popup.Show();
                else
                    System.Windows.Browser.HtmlPage.Window.Navigate(parentDestop.MediaPlayer.media.Source, "_blank");
            }
            else
            {
                Node clickedNode = selectedNode.GetChild(this.selectedNode.ID + "/" + filename);
                if (clickedNode != null)
                {
                    selectedNode.Expand();
                    selectedNode = clickedNode;
                    this.fileTree.SetSelected(selectedNode);
                    this.fillItemsFromServerPath();
                }
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
                if (dirlist.Count > 0)
                {
                    Debug.WriteLine("le selected Node " + selectedNode.ID + " == " + dirlist[0]);
                    if (dirlist.Count > 1 && selectedNode.ID == dirlist[0])
                    {
                        selectedNode.HasChildren = true;
                        foreach (string dirname in dirlist)
                        {
                            if (nb != 0)
                            {
                                Debug.WriteLine("je add " + dirname);
                                Node newnode = CreateNewNodeFromSelectedNode(dirname);
                                selectedNode.Nodes.Add(newnode);
                            }
                            nb++;
                        }
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
                items.Add(CreateItem(fileinfo[1], fileinfo[0], fileinfo[2]));
            }
            itemViewer.Add(items);
        }

        void UserDirectory_deletePathCompleted(object sender, MyLiveMesh.UserDirectoryServiceReference.deletePathCompletedEventArgs e)
        {
            if (e.Result == true)
            {
                this.fillItemsFromServerPath();
                this.updateDirListFromServer(selectedNode.ID);
            }
        }
        #endregion

    }
}
