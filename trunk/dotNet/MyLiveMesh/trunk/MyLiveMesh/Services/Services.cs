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

namespace MyLiveMesh.Services
{
    public static class Services
    {
        public static AccountServiceReference.AccountServiceClient AuthService { get; set; }
        public static FileUploaderServiceReference.FileUploaderServiceClient FileUpService { get; set; }

        static Services()
        {
            AuthService = new MyLiveMesh.AccountServiceReference.AccountServiceClient();
            FileUpService = new MyLiveMesh.FileUploaderServiceReference.FileUploaderServiceClient();
        }
    }
}
