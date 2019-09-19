using AppleTimer.ViewModels;
using System.Windows.Controls;


namespace AppleTimer.Views
{
	/// <summary>
	/// Interaction logic for RecordControlView.xaml
	/// </summary>
	public partial class RecordControlView : UserControl
	{
		public RecordControlView()
		{
			InitializeComponent();
			DataContext = new RecordControlViewModel();
		}
	}
}
