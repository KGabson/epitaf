using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MyWindowsMediaPlayer.Model;

namespace MyWindowsMediaPlayer.ViewModel
{
    class TreeViewViewModel
    {
        //ATTRIBUTS
        private MyWindowsMediaPlayer.Model.DirectoryReader model;
        public TreeNode mainNode { get; set; }

        public TreeViewViewModel()
        {
            model = DirectoryReader.getInstance();
            model.MediaPath = "I:/Ma musique/Pink Floyd";
            this.mainNode = initNode(this.model.MediaPath);
            this.getNodes(this.mainNode);
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

    }
}