using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MyLiveMesh.ViewModel;
using System.Diagnostics;
using Liquid.Components;

namespace MyLiveMesh.View
{
	public partial class ProgressDialog : UserControl
	{
		public ProgressDialog()
		{
			// Required to initialize variables
			InitializeComponent();

            this.progressPopup.IsEnabledChanged += new DependencyPropertyChangedEventHandler(progressPopup_IsEnabledChanged);
            this.progressPopup.Closed += new Liquid.DialogEventHandler(progressPopup_Closed);
            this.Loaded += new RoutedEventHandler(ProgressDialog_Loaded);
        }

        void ProgressDialog_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
                (this.DataContext as ProgressDialogViewModel).Progress = this.progressBar;
        }

        void progressPopup_Closed(object sender, Liquid.DialogEventArgs e)
        {
            this.progressPopup.IsEnabled = false;
            (this.DataContext as ProgressDialogViewModel).uploader.Abort();
        }

        void progressPopup_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
                this.progressPopup.Show();
            else
                this.progressPopup.Close();
        }

	}
}