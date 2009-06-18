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

namespace MyLiveMesh.View
{
	public partial class LoginView : UserControl
	{
		public LoginView()
		{
			// Required to initialize variables
			InitializeComponent();
            /**
             * Utilisation EXCEPTIONNELLE du gestionnaire d'evenement Loaded
             * pour pouvoir récupérer la valeur du champ password dans la vue
             * depuis le ViewModel, car ce type de champ n'est pas bindable
             * (il ne contient pas de DependencyProperty pour des raisons de
             * securite).
             **/
            this.Loaded += new RoutedEventHandler(LoginView_Loaded);
		}

        void LoginView_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new AccountViewModel();
            //DBServiceReference.DBServiceClient srv = new MyLiveMesh.DBServiceReference.DBServiceClient();
            //srv.AuthentifyCompleted += new EventHandler<MyLiveMesh.DBServiceReference.AuthentifyCompletedEventArgs>(srv_AuthentifyCompleted);
            //srv.AuthentifyAsync();
        }
	}
}