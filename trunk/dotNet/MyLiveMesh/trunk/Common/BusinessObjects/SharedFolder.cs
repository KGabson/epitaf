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

namespace Common.BusinessObjects
{
    public class SharedFolder
    {
        public String RootPath { get; set; }
        public String FolderName { get; set; }
        public UserInfo Owner { get; set; }
        public bool IsOwner { get; set; }
    }
}
