using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using AppleTimer.Tools.Managers;
using AppleTimer.Tools.Navigation;
using AppleTimer.ViewModels;

namespace AppleTimer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

 
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            Width = 400;
            Height = 550;
            NavigationManager.Instance.Navigate(ViewType.LoginView);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
