using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MyWindowsMediaPlayer.Model;

namespace MyWindowsMediaPlayer.ViewModel
{
    public class TreeViewViewModel : IViewModel
    {
        //ATTRIBUTS
        private static TreeViewViewModel instance = null;
        private MyWindowsMediaPlayer.Model.DirectoryReader model;
        private TreeNode mainNode;

        public static TreeViewViewModel getInstance()
        {
            if (instance == null)
            {
                instance = new TreeViewViewModel();
            }
            return instance;
        }

        private TreeViewViewModel()
        {
            model = DirectoryReader.getInstance();
            this.fillViewWithModel();
            model.PropertyChanged += this.updateView;
        }

        public TreeNode MainNode
        {
            get
            {
                return this.mainNode;
            }
            set
            {
                this.mainNode = value;
                this.onPropertyChanged("MainNode");
            }
        }

        public void fillViewWithModel()
        {
            this.MainNode = initNode(this.model.MediaPath);
            this.getNodes(this.MainNode);
        }

        public void updateView(object sender, EventArgs e)
        {
            this.fillViewWithModel();
        }

        public TreeNode initNode(string path)
        {
            TreeNode node = new TreeNode();

            node.Text = Path.GetFileName(path);
            node.Name = path;
            return node;
        }

        public TreeNode getNodes(TreeNode node)
        {
            string[] dirs = model.getDirs(node.Name);

            if (dirs.Length > 0)
                foreach (string dir in dirs)
                {
                    Console.WriteLine("Adding directory: " + dir);
                    node.Nodes.Add(getNodes(this.initNode(dir)));
                }
            return node;
        }

        public void updateMediaViewer(Object sender, TreeViewEventArgs e)
        {
            MediaViewerViewModel.getInstance().updateList(sender, e);
        }
    }
}