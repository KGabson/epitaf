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
            mediaPath = "F:/Musique";
        }

        public string[] getListMusicForPath(string path)
        {
            List<FileInfo> files = new List<FileInfo>();
            List<string> listPath = new List<string>();

            files.AddRange(new DirectoryInfo(path).GetFiles("*.mp3"));
            files.AddRange(new DirectoryInfo(path).GetFiles("*.wma"));
            files.AddRange(new DirectoryInfo(path).GetFiles("*.ogg"));
            foreach (FileInfo file in files)
            {
                listPath.Add(file.FullName);
            }
            return listPath.ToArray();
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
