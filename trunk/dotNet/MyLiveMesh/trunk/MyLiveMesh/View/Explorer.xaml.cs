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

            this.itemViewerPopup.Show(); //to del and manage the display only with IsEnabled
            //Events Controls
            this.itemViewerPopup.Closed += new DialogEventHandler(itemViewerPopup_Closed);
            this.itemViewerPopup.IsEnabledChanged += new DependencyPropertyChangedEventHandler(itemViewerPopup_IsEnabledChanged);
            this.Loaded += new RoutedEventHandler(Explorer_Loaded);
        }

        void Explorer_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                this.fileTree.Nodes = ((ExplorerViewModel)this.DataContext).DirList;
                this.fileTree.OnApplyTemplate();
            }
            else
            {
                Debug.WriteLine("la non plus le datacontext il est pas init");
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
            Debug.WriteLine("je close la fenetre");
            Debug.WriteLine("visibility = " + this.itemViewerPopup.Visibility);
            this.itemViewerPopup.IsEnabled = false;
        }

        private void fileTree_NodeClick(object sender, TreeEventArgs e)
        {
            Node n = (Node)sender;
            List<ItemViewerItem> toAdd = new List<ItemViewerItem>();
            fileItems.Clear();
            if (n.ID == "1")
            {
                toAdd.Add(CreateItem("xls", "tableur.xls", "456.3KB"));
                toAdd.Add(CreateItem("xls", "facture.xls", "456.3KB"));
            }
            else if (n.ID == "2")
            {
                toAdd.Add(CreateItem("avi", "Joseph a la montagne.avi", "700.0MB"));
                toAdd.Add(CreateItem("mp4", "Freakazoid.mp4", "548.6MB"));
            }
            fileItems.Add(toAdd);
        }

        private FileItem CreateItem(string type, string filename, string desc)
        {
            return new FileItem() { Icon = "../Data/Large/" + type + ".png", Text = filename, OtherText = desc };
        }

	}
}