using DbModels.Models;
using System.Collections.Generic;

namespace AppleTimer.Tools.Managers
{
	static class StationManager
	{
		public static bool IsWindow { get; set; } = false;
		public static Group CurGroup { get; set; }
		public static Record CurRecord { get; set; } = new Record();
		public static List<Record> Records { get; set; }
		public static List<Group> Groups { get; set; }

		public delegate void MyRefresh();

		public static event MyRefresh RefreshRecords;

		public static event MyRefresh CleanRecords;

		public static event MyRefresh ShowWindow;

		public static void RefreshRecordsList()
		{
			RefreshRecords?.Invoke();
		}

		public static void CleanRecord()
		{
			CleanRecords?.Invoke();
		}

		public static void ShowTaskWindow()
		{
			ShowWindow?.Invoke();
		}
	}
}
