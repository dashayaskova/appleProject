using System.Windows.Controls;
using AppleTimer.Tools.Navigation;
using AppleTimer.ViewModels;

namespace AppleTimer.Views
{
    /// <summary>
    /// Interaction logic for SignUpControlView.xaml
    /// </summary>
    public partial class SignUpControlView : UserControl, INavigatable
    {
        public SignUpControlView()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }
    }
}
