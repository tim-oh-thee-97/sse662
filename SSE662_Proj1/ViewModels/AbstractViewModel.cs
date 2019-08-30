using SSE662_Proj1.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace SSE662_Proj1.ViewModels
{
    public abstract class AbstractViewModel : INotifyPropertyChanged
    {
        //Require that a View be related to the ViewModel
        AbstractWindow _view;
        [XmlIgnore]
        public virtual AbstractWindow View
        {
            get => _view;
            set
            {
                if (value != null && _view != value) //if it's a new view, hook it up
                {
                    SetValue(ref _view, value);
                    SubscribeToLifecycleEvents();
                    //TODO: Evaluate for odd cases, e.g. setting View to null or another View object after initial set  
                }
            }
        }

        //A handy convenience method for reference types to set their values and notify property changes.
        //We need the ref keyword so that non-reference types will still update their backing property's value.
        protected void SetValue<T>(ref T variable, T value, [CallerMemberName] string propertyName = "")
        {
            variable = value;
            OnPropertyChanged(propertyName);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region View Lifecycle Event Handlers

        void SubscribeToLifecycleEvents()
        {
            _view.Activated += View_Activated;
            _view.Loaded += View_Loaded;
            _view.ContentRendered += View_ContentRendered;
            _view.Deactivated += View_Deactivated;
            _view.Unloaded += View_Unloaded;
            _view.Closing += View_Closing;
        }

        void UnsubscribeToLifecycleEvents()
        {
            _view.Activated -= View_Activated;
            _view.Loaded -= View_Loaded;
            _view.ContentRendered -= View_ContentRendered;
            _view.Deactivated -= View_Deactivated;
            _view.Unloaded -= View_Unloaded;
            _view.Closing -= View_Closing;
        }

        public virtual void View_ContentRendered(object sender, System.EventArgs e)
        {
            //Do nothing, unless overridden
        }

        public virtual void View_Closing(object sender, CancelEventArgs e)
        {
            //Do nothing, unless overridden
        }

        public virtual void View_Activated(object sender, System.EventArgs e)
        {
            //Do nothing, unless overridden
        }

        public virtual void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Do nothing, unless overridden
        }

        public virtual void View_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Do nothing, unless overridden
        }

        public virtual void View_Deactivated(object sender, System.EventArgs e)
        {
            //Do nothing, unless overridden
        }

        #endregion
    }
}
