using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using AppleTimer.Views.Windows;
using System.Collections.Generic;
using System.Windows.Data;

namespace AppleTimer.ViewModels
{
	class RecordControlViewModel : BaseViewModel
	{

		private Record _record { get; set; }
		public Record CurrentRecord
		{
			get { return _record; }
			set
			{
				_record = value;
				OnPropertyChanged();
			}
		}
		public List<Group> Groups { get; set; }

		public CollectionViewSource ViewSource { get; set; } = new CollectionViewSource();

		public RecordControlViewModel()
		{
			Groups = StationManager.Groups;
			ViewSource.Source = Groups;

			if (StationManager.IsWindow)
			{
				CurrentRecord = StationManager.CurRecord;
			}
			else
			{
				StationManager.IsWindow = true;
				CurrentRecord = new Record();

				StationManager.ShowWindow += () =>
				{
					StationManager.CurRecord = CurrentRecord;
				};

				StationManager.CleanRecords += () =>
				{
					CurrentRecord = new Record();
				};
			}
		}

		private RelayCommand<object> _addGroupCommand;


		public RelayCommand<object> AddGroup
		{
			get
			{
				return _addGroupCommand ?? (_addGroupCommand = new RelayCommand<object>(
					 o => AddGroupImplementation()));
			}
		}

		private void AddGroupImplementation()
		{
			StationManager.CurGroup = new Group();
			AddGroupWindowView win = new AddGroupWindowView();
			win.ShowDialog();
			Groups.Add(StationManager.CurGroup);
			ViewSource.View.Refresh();
		}

	}
}

