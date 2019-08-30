using SSE662_Proj1.ViewModels;
using SSE662_Proj1.Views;

namespace SSE662_Proj1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AbstractWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Model = new MainViewModel();
            Model.View = this;
        }
    }
}
