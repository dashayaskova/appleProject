using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using System;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using AppleTimer.TimerService;

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
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w =>
                {
                    using (var serv = new TimerServerClient())
                    {
                        serv.DeleteRecords(new Guid[] { StationManager.CurRecord.Id });
                    }
                    w.DialogResult = false;
                    w?.Close();
                }));
            }
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
            StationManager.SubmitUpdateRecord(StationManager.CurRecord, new [] { "EndTime", "Duration", "GroupId", "Comment"});
            if (!StationManager.CurrentUser.Records.Contains(StationManager.CurRecord))
            {
                StationManager.CurrentUser.Records.Add(StationManager.CurRecord);
            }
            StationManager.RefreshRecordsList();
            win.DialogResult = true;
			win?.Close();
		}

    }
}
