using System.ComponentModel;

namespace MyLiveMesh.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected void InvokePropertyChanged(string PropertyName)
        {
            var e = new PropertyChangedEventArgs(PropertyName);
            PropertyChangedEventHandler Handler = PropertyChanged;
            if (Handler != null) Handler(this, e);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
