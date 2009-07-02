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
using Common.BusinessObjects;

namespace MyLiveMesh.ViewModel
{
    public class FileViewModel : ViewModelBase
    {
        private string imageUrl;
        private string title;
        private string path;
        private string type;
        private string ownerName;
        private bool isOwner;

        public FileViewModel()
        {
            type = "dir";
            imageUrl = "../Data/directory.png";
            path = "";
            title = "Default Directory";
        }

        public FileViewModel(string _title, string _type, string _path, UserInfo _owner_info, bool _is_owner)
        {
            init(_title, _type, _path, _owner_info, _is_owner);
        }

        public FileViewModel(SharedFolder folder)
        {
            init(folder.FolderName, "shared", folder.RootPath, folder.Owner, folder.IsOwner);
        }

        void init(string _title, string _type, string _path, UserInfo _owner_info, bool _is_owner)
        {
            this.title = _title;
            this.path = _path;
            this.type = _type;
            this.isOwner = _is_owner;
            if (type == "dir")
                imageUrl = "../Data/directory.png";
            else if (type == "shared")
                imageUrl = "../Data/shared_directory.png";
            ownerName = "@" + _owner_info.Login;
        }

        public bool Equals(SharedFolder folder)
        {
            return (title == folder.FolderName 
                && path == folder.RootPath
                && type == "shared");
        }

        #region Fields
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

        public string OwnerName
        {
            get { return ownerName; }
            set
            {
                ownerName = value;
                InvokePropertyChanged("OwnerName");
            }
        }

        public bool IsOwner
        {
            get { return isOwner; }
            set
            {
                isOwner = value;
                InvokePropertyChanged("IsOwner");
            }
        }
        #endregion

        public UserInfo OwnerInfo { get; set; }
    }
}
