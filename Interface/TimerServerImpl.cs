using appleTimer.DbProject;
using DbModels.Models;
using DbProject;
using System;
using System.Collections.Generic;
using System.Linq;
using TimerServerInterface;
using Tools;

namespace AppleTimer.Server.TimerServerInterface
{
	public class TimerServerImpl : ITimerServer
	{
        public bool UserExists(string username, string password)
        {
            return EntityWrapper.UserExists(username, password);
        }

        public User GetUser(string username, string password)
        {
            return EntityWrapper.GetUser(username, password);
        }

        public User GetUserByGuid(Guid guid)
        {
            return EntityWrapper.GetUserByGuid(guid);
        }

        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

    }
}
