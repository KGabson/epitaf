using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyWindowsMediaPlayer.Model
{
    class DirectoryReader : MyWindowsMediaPlayer.ViewModel.IViewModel
    {
        //ATTRIBUTS
        private string mediaPath;
        public string MediaPath 
        {
            get
            {
                return mediaPath;
            }

            set
            {
              mediaPath = value;
              this.onPropertyChanged("mediaPath");
            }
        }
        private static DirectoryReader instance = null;
        
        public static DirectoryReader getInstance()
        {
            if (instance == null)
                instance = new DirectoryReader();
            return instance;
        } 
            

        private DirectoryReader()
        {
            mediaPath = "I:/Ma musique";
        }

        public string[] getDirs(string path)
        {
            DirectoryInfo[] dirs = new DirectoryInfo(path).GetDirectories();
            List<string> paths = new List<string>();

            foreach (DirectoryInfo di in dirs)
            {
                paths.Add(di.FullName);
            }
            return paths.ToArray();
        }
    }
}
