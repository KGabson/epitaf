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
        MyWindowsMediaPlayer.ViewModel.TreeViewViewModel viewModel;

        public TreeView()
        {
            viewModel = new MyWindowsMediaPlayer.ViewModel.TreeViewViewModel();
            
            InitializeComponent();
            this.viewModel.PropertyChanged += this.updateTreeView;
            //treeViewViewModelBindingSource.Add(this.viewModel);
            this.treeView1.Nodes.Add(viewModel.MainNode);
        }

        public void updateTreeView(Object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add(viewModel.MainNode);
        }

    }
}
