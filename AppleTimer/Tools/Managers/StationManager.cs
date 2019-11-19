﻿using AppleTimer.TimerService;
using DbModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AppleTimer.Tools.Managers
{
	static class StationManager
	{
        public static string EndpointName = "TimerServerWCF";

        public static Window MainWindow = null;
        public static bool IsWindow { get; set; } = false;
        public static User CurrentUser { get; set; }
		public static Group CurGroup { get; set; }
		public static Record CurRecord { get; set; }
		public static List<Record> Records { get; set; }
		public static List<Group> Groups { get; set; }

		public delegate void MyRefresh();

		public static event MyRefresh RefreshRecords;

		public static event MyRefresh CleanRecords;

		public static event MyRefresh DeleteInfo;

		public static void RefreshRecordsList()
		{
			RefreshRecords?.Invoke();
		}

		public static void CleanRecord()
		{
			CleanRecords?.Invoke();
		}

		public static void DeleteUserInfo()
		{
            DeleteInfo?.Invoke();
		}

        public static void SubmitUpdateRecord(Record record, string[] updateFields)
        {

                using (var serv = new TimerService.TimerServerClient(StationManager.EndpointName))
                {
                    serv.UpdateRecord(record, updateFields);
                }
        }
		public static Record GetUnfinishedRecord(User user)
		{
			using (var serv = new TimerService.TimerServerClient(StationManager.EndpointName))
			{
				var record = serv.GetUserRecords(user).Where(r => r.EndTime == null).FirstOrDefault();
				return record;
			}
		}

		public static void DeleteRecord(Guid guid)
		{
			using (var serv = new TimerServerClient())
			{
				serv.DeleteRecords(new Guid[] { guid });
			}
		}
	}
}
