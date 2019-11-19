using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using AppleTimer.Views.Windows;
using System.Windows.Data;
using System.Linq;
using System;

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

        public string RecordComment
        {
            get
            {
                return CurrentRecord.Comment;
            }
            set
			{
                CurrentRecord.Comment = value;
                StationManager.SubmitUpdateRecord(CurrentRecord, new string[] { "Comment" });
            }
        }

        public Group RecordGroup
        {
            get
            {
                return CurrentRecord.Group;
            }
            set
            {
                CurrentRecord.Group = value;
                StationManager.SubmitUpdateRecord(CurrentRecord, new string[] { "Group", "GroupId" });
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

            StationManager.CleanRecords += () =>
            {
                Record rec = new Record(StationManager.CurrentUser);
                rec.Id = Guid.NewGuid();
                CurrentRecord = StationManager.CurRecord = rec;
                OnPropertyChanged("RecordComment");
                OnPropertyChanged("RecordGroup");
            };
        }

		private void AddGroupImplementation()
		{
			StationManager.CurGroup = new Group();
			AddGroupWindowView win = new AddGroupWindowView();
			bool? res= win.ShowDialog();
			if (res == true)
			{
				ViewSource.View.Refresh();
			}
		}


    }
}

