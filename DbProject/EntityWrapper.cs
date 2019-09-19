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
	}
}
