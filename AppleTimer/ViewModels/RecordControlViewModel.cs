using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using AppleTimer.Views.Windows;
using System.Windows.Data;

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
			get { return _record; }
			set
			{
				_record = value;
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

			if (StationManager.IsWindow)
			{
				CurrentRecord = StationManager.CurRecord;
			}
			else
			{
				StationManager.IsWindow = true;
				StationManager.CleanRecords += () =>
				{
                    CurrentRecord = null;
				};
			}
		}

		private void AddGroupImplementation()
		{
			StationManager.CurGroup = new Group();
			AddGroupWindowView win = new AddGroupWindowView();
			win.ShowDialog();
			StationManager.CurrentUser.Groups.Add(StationManager.CurGroup);
			ViewSource.View.Refresh();
		}

	}
}

