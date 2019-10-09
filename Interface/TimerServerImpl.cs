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
        public bool UserExists(string username)
        {
            return EntityWrapper.UserExists(username);
        }

        public User GetUserByUsername(string username)
        {
            return EntityWrapper.GetUserByUsername(username);
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
