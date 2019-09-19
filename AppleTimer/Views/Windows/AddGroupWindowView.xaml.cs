using AppleTimer.ViewModels.Windows;
using System.Windows;

namespace AppleTimer.Views.Windows
{
	/// <summary>
	/// Interaction logic for AddGroupWindowView.xaml
	/// </summary>
	public partial class AddGroupWindowView : Window
	{
		public AddGroupWindowView()
		{
			InitializeComponent();
			DataContext = new AddGroupWindowViewModel();
		}
	}
}
