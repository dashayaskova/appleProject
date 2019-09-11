using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

        private void OnAnyPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PBpass1.Password != PBpass2.Password)
            {
                PBpass2.Background = Brushes.LightCoral;
                BtnSave1.IsEnabled = false;
            }
            else
            {
                PBpass2.Background = Brushes.LightGreen;
                BtnSave1.IsEnabled = true;
            }
        }
    }
}
