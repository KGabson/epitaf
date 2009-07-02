using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Liquid;
using System.Diagnostics;
using MyLiveMesh.ViewModel;
using System.Collections.Generic;

namespace MyLiveMesh.View
{
	public partial class Explorer : UserControl
	{
		public Explorer() 
		{
			// Required to initialize variables
			InitializeComponent();

            this.itemViewerPopup.Show();
            //Events Controls
            this.itemViewerPopup.Closed += new DialogEventHandler(itemViewerPopup_Closed);
            this.itemViewerPopup.IsEnabledChanged += new DependencyPropertyChangedEventHandler(itemViewerPopup_IsEnabledChanged);
            this.newFolder.Closed += new DialogEventHandler(newFolder_Closed);
            this.Loaded += new RoutedEventHandler(Explorer_Loaded);
            this.fileItems.DoubleClick += new ItemViewerEventHandler(fileItems_DoubleClick);
        }

        void newFolder_Closed(object sender, DialogEventArgs e)
        {
            if (e.Cancel == false)
                (this.DataContext as ExplorerViewModel).createDirectory(this.folderName.Text);
        }

        void Explorer_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                this.fileTree.Nodes = ((ExplorerViewModel)this.DataContext).DirList;
                this.fileTree.OnApplyTemplate();
                (this.DataContext as ExplorerViewModel).newFolderPopup = this.newFolder;
                this.ShareDirectoryControl.DataContext = new ShareFolderViewModel(this.DataContext as ExplorerViewModel);
                (this.DataContext as ExplorerViewModel).shareFolderPopup = this.shareFolderPopup;
                (this.DataContext as ExplorerViewModel).itemViewer = this.fileItems;
            }
            
       }

        //Events
        void itemViewerPopup_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                this.itemViewerPopup.Show();
            }
        }

        void itemViewerPopup_Closed(object sender, DialogEventArgs e)
        {
            this.itemViewerPopup.IsEnabled = false;
        }

        private void fileTree_NodeClick(object sender, TreeEventArgs e)
        {
            Node n = (Node)sender;
            (this.DataContext as ExplorerViewModel).selectedNode = n;
            if (n.HasChildren == false)
                (this.DataContext as ExplorerViewModel).updateDirListFromServer(n.ID);
            (this.DataContext as ExplorerViewModel).fillItemsFromServerPath();

            //fileItems.Clear();
            //fileItems.Add((this.DataContext as ExplorerViewModel).items);
        }

        void fileItems_DoubleClick(object sender, ItemViewerEventArgs e)
        {
            Debug.WriteLine("nihaaahoué " + sender.GetType());
            Debug.WriteLine("title  " + e.Title);
        }


        private FileItem CreateItem(string type, string filename, string desc)
        {
            return new FileItem() { Icon = "../Data/Large/" + type + ".png", Text = filename, OtherText = desc };
        }

        private void fileTree_NodeExpanded(object sender, TreeEventArgs e)
        {
             Node result = ((Node)sender);

             if (result.ID != null)
             {
                 //(this.DataContext as ExplorerViewModel).expandedNode = result;
                 //(this.DataContext as ExplorerViewModel).updateDirListFromServer(result.ID);
             }
        }
            

	}
}