using AppleTimer.Tools.Navigation;
using AppleTimer.ViewModels;
using System.Windows.Controls;

namespace AppleTimer.Views
{
	/// <summary>
	/// Interaction logic for MainView.xaml
	/// </summary>
	public partial class MainView : UserControl, INavigatable
	{
		public MainView()
		{
			InitializeComponent();
			DataContext = new MainViewModel();


		}
	}
}
