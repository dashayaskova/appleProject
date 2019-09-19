using AppleTimer.ViewModels.Windows;
using System.Windows;

namespace AppleTimer.Views.Windows
{
	/// <summary>
	/// Interaction logic for AddRecordWindowView.xaml
	/// </summary>
	public partial class AddRecordWindowView : Window
	{
		public AddRecordWindowView()
		{
			InitializeComponent();
			DataContext = new AddRecordWindowViewModel();
		}
	}
}
