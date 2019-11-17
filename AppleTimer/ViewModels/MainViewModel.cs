﻿using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using AppleTimer.Views.Windows;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Data;
using AppleTimer.Tools.Navigation;
using System.Threading.Tasks;
using System.Linq;
using AppleTimer.TimerService;

namespace AppleTimer.ViewModels
{
	class MainViewModel : BaseViewModel
	{

        #region Fields

        private string _time;
        private Timer _timer = null;
        private TimerCallback _cb;
        private bool _isPause = false;
        private long _seconds = 0;

        private RelayCommand<object> _startCommand;
        private RelayCommand<object> _stopCommand;
        private RelayCommand<object> _pauseCommand;
        private RelayCommand<object> _logoutCommand;


        #endregion

        #region Properties

        public List<Record> Records { get; set; } = StationManager.Records;

		public CollectionViewSource ViewSource { get; set; } = new CollectionViewSource();

		public string Time
		{
			get { return _time; }
			set
			{
				_time = value;
				OnPropertyChanged();
			}
		}

        public RelayCommand<object> Start
        {
            get
            {
                return _startCommand ?? (_startCommand = new RelayCommand<object>(
                     o => StartImplementation(), o => _timer == null || _isPause));
            }
        }

        public RelayCommand<object> Stop
        {
            get
            {
                return _stopCommand ?? (_stopCommand = new RelayCommand<object>(EndImplementation, o => _timer != null));
            }
        }

        /*public RelayCommand<object> Pause
        {
            get
            {
                return _pauseCommand ?? (_pauseCommand = new RelayCommand<object>(PauseImplementation, o => _timer != null && !_isPause));
            }
        }*/

        public RelayCommand<object> LogoutCommand
        {
            get
            {
                return _logoutCommand ?? (_logoutCommand = new RelayCommand<object>(DoLogout));
            }
        }

        #endregion

        public MainViewModel()
		{
			_seconds = (StationManager.CurRecord.StartTime != DateTime.MinValue) 
				? (long)(DateTime.Now - StationManager.CurRecord.StartTime).TotalSeconds : 0;
			
			_cb = new TimerCallback(ChangeText);
			Time = TimeSpan.FromSeconds(_seconds).ToString(@"hh\:mm\:ss");
			ViewSource.Source = StationManager.CurrentUser.Records;

			if (StationManager.CurRecord.StartTime != DateTime.MinValue)
			{
				_timer = new Timer(_cb, null, 0, 1000);
			}

			StationManager.RefreshRecords += () =>
			{
                using (var serv = new TimerServerClient())
                {
                    StationManager.CurrentUser.Records = serv.GetUserRecords(StationManager.CurrentUser).ToList();
                    ViewSource.Source = StationManager.CurrentUser.Records;
                    ViewSource.View.Refresh();
                }
			};
		}

        private void StartImplementation()
		{
			StationManager.CurRecord.StartTime = DateTime.Now;
			StationManager.SubmitUpdateRecord(StationManager.CurRecord, new string[] { "StartTime"});

			_timer = new Timer(_cb, null, 0, 1000);
		}

      /*  private void PauseImplementation(object obj)
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _isPause = true;
            StationManager.CurRecord.AddEndTime(DateTime.Now);
            SubmitUpdateRecord(StationManager.CurRecord, new string[] { "EndTime", "Duration" });
        }*/

        private void EndImplementation(object obj)
        {
            _isPause = false;
            _timer.Dispose();
            _timer = null;
            AddRecordWindowView win = new AddRecordWindowView();
            bool? succ = win.ShowDialog();
            if (succ != false)
            {
                StationManager.CurRecord.AddEndTime(DateTime.Now);
                StationManager.SubmitUpdateRecord(StationManager.CurRecord, new [] { "Comment", "Group", "GroupId", "EndTime", "Duration" });
            }
            _seconds = -1;
            ChangeText(obj);
            StationManager.CleanRecord();
            StationManager.RefreshRecordsList();
            StationManager.CurRecord = new Record(StationManager.CurrentUser);

        }

		private async void SubmitNewRecord(Record record)
        {
            await Task.Run(() =>
            {
                using (var serv = new TimerService.TimerServerClient(StationManager.EndpointName))
                {
                    serv.AddRecord(record);
                }
            }
            );
        }


        /// <summary>
        /// Изменение лейбы каждую секунду
        /// </summary>
        /// <param name="obj"></param>
        private void ChangeText(object obj)
		{
			Time = TimeSpan.FromSeconds(++_seconds).ToString(@"hh\:mm\:ss");
		}

        private void DoLogout(object obj)
        {
            StationManager.CurrentUser = null;

            NavigationManager.Instance.Navigate(ViewType.LoginView);
        }
	}
}
