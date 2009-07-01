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
using Liquid.Components;
using System.Diagnostics;

namespace MyLiveMesh.ViewModel
{
    public class ProgressDialogViewModel : ViewModelBase
    {
        private bool    isEnabled = false;
        private string  popupTitle;
        private string  itemsCopied;
        private string  progressText;

        public Uploader uploader = new Uploader("http://localhost:54164/Services/FileUp.asmx");
        private Liquid.ProgressBarPlus progress;

        public ProgressDialogViewModel()
        {
            progress = new Liquid.ProgressBarPlus();
            uploader.UploadProgressChange += new UploadEventHandler(uploader_UploadProgressChange);
            uploader.UploadFinished += new UploadEventHandler(uploader_UploadFinished);
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                InvokePropertyChanged("IsEnabled");
            }
        }

        public string PopupTitle
        {
            get { return popupTitle; }
            set
            {
                popupTitle = value;
                InvokePropertyChanged("PopupTitle");
            }
        }

        public string ItemsCopied
        {
            get { return itemsCopied; }
            set
            {
                itemsCopied = value;
                InvokePropertyChanged("ItemsCopied");
            }
        }

        public string ProgressText
        {
            get { return progressText; }
            set
            {
                progressText = value;
                InvokePropertyChanged("ProgressText");
            }
        }

        public Liquid.ProgressBarPlus Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                InvokePropertyChanged("Progress");
            }
        }

        void uploader_UploadProgressChange(object sender, UploadEventArgs e)
        {
            int itemsUploaded = uploader.ItemsUploaded + 1;

            if (itemsUploaded > uploader.ItemsTotal)
                itemsUploaded = uploader.ItemsTotal;
            ProgressText = "Uploading " + e.Text + "...";
            ItemsCopied = "Copying file " + itemsUploaded.ToString() + " of " + uploader.ItemsTotal.ToString();
            Progress.Text = "Uploading " + Math.Round(e.Progress) + "% (" + e.Text + ")";
            Progress.Complete = e.Progress;
        }

        void uploader_UploadFinished(object sender, UploadEventArgs e)
        {
            progress.Text = "Complete.";
            progress.Complete = e.Progress;
        }
    }
}
