using appleTimer.DbProject;
using DbModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace DbProject
{
	public static class EntityWrapper
	{
		public static List<Record> GetUserRecords(User user)
		{
			using (var context = new TimerContext())
			{
				return context.Records.Where(o => o.UserId == user.Id).ToList();
			}
		}

		public static List<Group> GetUserGroups(User user)
		{
			using (var context = new TimerContext())
			{
				return context.Groups.Where(o => o.UserId == user.Id).ToList();
			}
		}

		public static void AddRecord(Record record)
		{
			using (var context = new TimerContext())
			{
				context.Records.Add(record);
				context.SaveChanges();
			}
		}
	}
}
