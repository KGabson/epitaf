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
        private bool begin = true;

		public Desktop()
		{
			// Required to initialize variables
			InitializeComponent();
            updateTimer.Interval = TimeSpan.FromSeconds(5);
            updateTimer.Tick += new EventHandler(updateTimer_Tick);
            this.Loaded += new RoutedEventHandler(Desktop_Loaded);
            Services.Services.UserDirectory.GetSharedFoldersCompleted += new EventHandler<MyLiveMesh.UserDirectoryServiceReference.GetSharedFoldersCompletedEventArgs>(UserDirectory_GetSharedFoldersCompleted);
        }

        void updateTimer_Tick(object sender, EventArgs e)
        {
            UserInfo uInfo = (this.DataContext as DesktopViewModel).userInfo;
            Services.Services.UserDirectory.GetSharedFoldersAsync(uInfo.Id);
        }

        void Desktop_Loaded(object sender, RoutedEventArgs e)
        {
            UserInfo uInfo = (this.DataContext as DesktopViewModel).userInfo;
            Services.Services.UserDirectory.GetSharedFoldersAsync(uInfo.Id);
        }

        #region Web Services Handlers
        void UserDirectory_GetSharedFoldersCompleted(object sender, MyLiveMesh.UserDirectoryServiceReference.GetSharedFoldersCompletedEventArgs e)
        {
            UserInfo uInfo = (this.DataContext as DesktopViewModel).userInfo;
            List<File> itemList = new List<File>();
            File f;
            bool contains = false;

            if (begin)
            {
                f = new File();
                f.DataContext = new FileViewModel("My Files", "dir", "/ClientDocs/" + uInfo.Id, uInfo);
                itemList.Add(f);
            }
            else
            {
                foreach (File existing_file in FolderList.Items)
                {
                    itemList.Add(existing_file);
                }
            }
            foreach (SharedFolder folder in e.Result)
            {
                contains = false;
                foreach (SharedFolder exiting_folder in (DataContext as DesktopViewModel).MySharedFolders)
                {
                    if (exiting_folder.Equals(folder))
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    f = new File();
                    f.DataContext = new FileViewModel(folder);
                    itemList.Add(f);
                }
                //FolderList.ItemsSource
            }
            FolderList.ItemsSource = itemList;
            (DataContext as DesktopViewModel).MySharedFolders = e.Result;
            if (begin)
            {
                updateTimer.Start();
                begin = false;
            }
        }
        #endregion
	}
}