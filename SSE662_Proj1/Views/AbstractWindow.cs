using SSE662_Proj1.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace SSE662_Proj1.Views
{
    /// <summary>
    /// Interaction logic for AbstractWindow.xaml
    /// </summary>
    public abstract class AbstractWindow : Window
    {
        public AbstractViewModel Model { get; set; }

        public AbstractWindow()
        {

        }

        protected override void OnClosed(EventArgs e)
        {
            Activated -= Model.View_Activated;
            Loaded -= Model.View_Loaded;
            ContentRendered -= Model.View_ContentRendered;
            Deactivated -= Model.View_Deactivated;
            Unloaded -= Model.View_Unloaded;
            Closing -= Model.View_Closing;

            base.OnClosed(e);
        }

    }
}