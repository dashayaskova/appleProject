using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using AppleTimer.Views.Windows;
using System.Windows.Data;
using System;
using System.Linq;

namespace AppleTimer.ViewModels
{
	class RecordControlViewModel : BaseViewModel
	{

        #region Fields

        private Record _record { get; set; }
        private RelayCommand<object> _addGroupCommand;

        #endregion

        #region Props

        public Record CurrentRecord
		{
			get { return StationManager.CurRecord; }
			set
			{
				StationManager.CurRecord = value;
				OnPropertyChanged();
			}
		}

		public CollectionViewSource ViewSource { get; set; } = new CollectionViewSource();

        public RelayCommand<object> AddGroup
        {
            get
            {
                return _addGroupCommand ?? (_addGroupCommand = new RelayCommand<object>(
                     o => AddGroupImplementation()));
            }
        }

        #endregion

        public RecordControlViewModel()
		{
			ViewSource.Source = StationManager.CurrentUser.Groups;
			
			if (!StationManager.IsWindow)
			{
				var records = GetNotFinishedRecords(StationManager.CurrentUser);

				if(records.Length == 0)
				{
					StationManager.CurRecord = new Record(StationManager.CurrentUser);
				}
				else
				{
					var rec = records.FirstOrDefault();
					rec.User = StationManager.CurrentUser;
					StationManager.CurRecord = rec;
				}

				StationManager.IsWindow = true;

				StationManager.CleanRecords += () =>
				{
					CurrentRecord = StationManager.CurRecord = new Record(StationManager.CurrentUser);
				};
			}

		}

		private Record[] GetNotFinishedRecords(User user)
		{
			using (var serv = new TimerService.TimerServerClient(StationManager.EndpointName))
			{
				return serv.GetUserRecords(user).Where(r => r.EndTime == null).ToArray();
			}
		}

		private void AddGroupImplementation()
		{
			StationManager.CurGroup = new Group();
			AddGroupWindowView win = new AddGroupWindowView();
			win.ShowDialog();
			ViewSource.View.Refresh();
		}


	}
}

