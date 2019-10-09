using DbModels.Models;
using System.Collections.Generic;
using System.Linq;
using TimerServerInterface;
using Tools;

namespace AppleTimer.Server.TimerServerInterface
{
	public class TimerServerImpl : ITimerServer
	{
		public void AddUser(User user)
		{
			using (var dbProvider = ProviderFactory.CreateNewDBProvider())
			{
				dbProvider.Add(user);
			}
		}

		public IEnumerable<User> GetAllUsers()
		{
			using (var dbProvider = ProviderFactory.CreateNewDBProvider())
			{
				return dbProvider.SelectAll<User>().ToList();
			}
		}
	}
}
