using System;
using System.Collections.Generic;
using AppleTimer.Server.TimerServerInterface;
using DbModels.Models;
using TimerServerInterface;

namespace WcfService1
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class TimerService : ITimerServer
	{
		private TimerServerImpl _service = new TimerServerImpl();
		public void AddUser(User user)
		{
			_service.AddUser(user);
		}

		public IEnumerable<User> GetAllUsers()
		{
			return _service.GetAllUsers();
		}
	}
}
