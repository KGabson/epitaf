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

namespace MyLiveMesh.ViewModel
{
    public class FileViewModel : ViewModelBase
    {
        private string imageUrl;
        private string title;
        private string path;
        private string type;

        public FileViewModel()
        {
            type = "dir";
            imageUrl = "../Data/directory.png";
            path = "";
            title = "Default Directory";
        }

        public FileViewModel(string _type)
        {
            this.type = _type;
        }

        public string ImageUrl
        {
            get { return imageUrl; }
            set 
            {
                imageUrl = value;
                InvokePropertyChanged("ImageUrl");
            }
        }

        public string Title
        {
            get { return title; }
            set 
            { 
                title = value;
                InvokePropertyChanged("Title");
            }
        }

        public string Path
        {
            get { return path; }
            set 
            { 
                path = value;
                InvokePropertyChanged("Path");
            }
        }
    }
}
