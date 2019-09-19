using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using AppleTimer.Views.Windows;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Data;

namespace AppleTimer.ViewModels
{
	class MainViewModel : BaseViewModel
	{
		private string _time;

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

		private Timer _timer = null;
		private TimerCallback _cb;
		private bool _isPause = false;

		public MainViewModel()
		{
			_cb = new TimerCallback(ChangeText);
			Time = TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm\:ss");
			ViewSource.Source = Records;

			StationManager.RefreshRecords += () =>
			{
				StationManager.CurRecord.Duration = seconds;
				Records.Add(StationManager.CurRecord);
				ViewSource.View.Refresh();
			};
		}

		public int seconds = 0;

		private RelayCommand<object> _startCommand;

		private RelayCommand<object> _stopCommand;

		private RelayCommand<object> _pauseCommand;

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
				return _stopCommand ?? (_stopCommand = new RelayCommand<object>(
					 o =>
					 {
						 _isPause = false;
						 _timer.Dispose();
						 _timer = null;
						 StationManager.ShowTaskWindow();
						 AddRecordWindowView win = new AddRecordWindowView();
						 win.ShowDialog();
						 seconds = -1;
						 ChangeText(o);
					 }, o => _timer != null));
			}
		}

		public RelayCommand<object> Pause
		{
			get
			{
				return _pauseCommand ?? (_pauseCommand = new RelayCommand<object>(
					 o =>
					 {
						 _timer.Change(Timeout.Infinite, Timeout.Infinite);
						 _isPause = true;
					 }, o => _timer != null && !_isPause));
			}
		}

		private void StartImplementation()
		{
			if (_isPause)
			{
				_timer.Change(0, 1000);
				_isPause = false;
			}
			else
			{
				_timer = new Timer(_cb, null, 0, 1000);
			}

		}

		/// <summary>
		/// Изменение лейбы каждую секунду
		/// </summary>
		/// <param name="obj"></param>
		private void ChangeText(object obj)
		{
			Time = TimeSpan.FromSeconds(++seconds).ToString(@"hh\:mm\:ss");
		}
	}
}
