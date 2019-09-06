using System.Windows.Controls;
using AppleTimer.Tools.Navigation;
using AppleTimer.ViewModels;

namespace AppleTimer.Views
{
    /// <summary>
    /// Interaction logic for LoginControlView.xaml
    /// </summary>
    public partial class LoginControlView : UserControl, INavigatable
    {
        public LoginControlView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
