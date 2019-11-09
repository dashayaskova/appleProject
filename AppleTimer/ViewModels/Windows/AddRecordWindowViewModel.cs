using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using System;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;

namespace AppleTimer.ViewModels.Windows
{
	class AddRecordWindowViewModel
	{

		public Record Record { get; set; } = StationManager.CurRecord;

		#region Commands

		private ICommand _saveCommand;
		private ICommand _cancelCommand;

		#endregion

		public ICommand CancelCommand
		{
			get { return _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w => w?.Close())); }
		}

		public ICommand SaveCommand
		{
			get
			{
				return _saveCommand ?? (_saveCommand = new RelayCommand<Window>(SaveImplementation, CanExecuteCommand));
			}
		}

		private bool CanExecuteCommand(Object o)
		{
			return !String.IsNullOrEmpty(Record.Comment) && Record.Group != null;
		}

		private void SaveImplementation(Window win)
		{
            SubmitRecord(StationManager.CurRecord);
            StationManager.CurrentUser.Records.Add(StationManager.CurRecord);
			StationManager.RefreshRecordsList();
			win?.Close();
		}

        private async void SubmitRecord(Record record)
        {
            await Task.Run(() =>
            {
                using (var serv = new TimerService.TimerServerClient(StationManager.EndpointName))
                {
                    if (record.Group?.Id == Guid.Empty)
                    {
                        serv.AddGroup(record.Group);
                    }
                    if (record.Id == Guid.Empty)
                    {
                        serv.AddRecord(record);
                    }
                    else
                    {
                        serv.UpdateRecord(record, new string[] { "EndTime", "Duration", "GroupId", "Comment"});
                    }
                }
            }
            );
        }
    }
}
