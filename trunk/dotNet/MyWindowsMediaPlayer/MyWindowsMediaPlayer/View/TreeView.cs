using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyWindowsMediaPlayer.ViewModel;

namespace MyWindowsMediaPlayer.View
{
    public partial class TreeView : UserControl
    {
        public MyWindowsMediaPlayer.ViewModel.TreeViewViewModel viewModel;

        public TreeView()
        {
            viewModel = MyWindowsMediaPlayer.ViewModel.TreeViewViewModel.getInstance();
         
            InitializeComponent();
            this.viewModel.PropertyChanged += this.updateTreeView;
            //treeViewViewModelBindingSource.Add(this.viewModel);
            this.treeView1.Nodes.Add(viewModel.MainNode);
            this.treeView1.AfterSelect += this.viewModel.updateMediaViewer;
        }

        public void updateTreeView(Object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add(viewModel.MainNode);
        }

    }
}
