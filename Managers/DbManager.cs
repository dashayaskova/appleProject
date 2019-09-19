using DbModels.Models;
using DbProject;
using System.Collections.Generic;

namespace Managers
{
    public class DbManager
    {
		public static List<Record> GetUserRecords(User user)
		{
			return EntityWrapper.GetUserRecords(user);
		}
	}
}
