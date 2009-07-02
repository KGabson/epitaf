using System;
using System.Collections.Generic;
using System.Windows;
using System.Net;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Liquid;
using MyLiveMesh.ViewModel;
using Common.BusinessObjects;
using System.Windows.Threading;

namespace MyLiveMesh.View
{
	public partial class Desktop : UserControl
	{
        private DispatcherTimer updateTimer = new DispatcherTimer();

		public Desktop()
		{
			// Required to initialize variables
			InitializeComponent();
            updateTimer.Interval = TimeSpan.FromSeconds(30);
            updateTimer.Tick += new EventHandler(updateTimer_Tick);
            this.Loaded += new RoutedEventHandler(Desktop_Loaded);
        }

        void updateTimer_Tick(object sender, EventArgs e)
        {
            
        }

        void Desktop_Loaded(object sender, RoutedEventArgs e)
        {
            UserInfo uInfo = (this.DataContext as DesktopViewModel).userInfo;
            Services.Services.UserDirectory.GetSharedFoldersAsync(uInfo.Id);
            Services.Services.UserDirectory.GetSharedFoldersCompleted += new EventHandler<MyLiveMesh.UserDirectoryServiceReference.GetSharedFoldersCompletedEventArgs>(UserDirectory_GetSharedFoldersCompleted);
        }

        #region Web Services Handlers
        void UserDirectory_GetSharedFoldersCompleted(object sender, MyLiveMesh.UserDirectoryServiceReference.GetSharedFoldersCompletedEventArgs e)
        {
            List<File> itemList = new List<File>();

            File f = new File();
            f.DataContext = new FileViewModel("My Files", "dir", "ClientDocs");
            itemList.Add(f);

            foreach (SharedFolder folder in e.Result)
            {
                f = new File();
                f.DataContext = new FileViewModel(folder.FolderName, "dir", folder.RootPath);
                itemList.Add(f);
                //FolderList.ItemsSource
            }
            FolderList.ItemsSource = itemList;
            (DataContext as DesktopViewModel).MySharedFolders = e.Result;
            updateTimer.Start();
        }
        #endregion
	}
}