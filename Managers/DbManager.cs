using DbModels.Models;
using DbProject;
using Interface;
using System.Collections.Generic;

namespace Managers
{
    public class DBManager
    {
        public static bool UserExists(string login)
        {
            return TimerServerWrapper.UserExists(login);
        }

        public static User GetUserByUsername(string username)
        {
            return TimerServerWrapper.GetUserByUsername(username);
        }

        public static void AddUser(User user)
        {
            TimerServerWrapper.AddUser(user);
        }
    }
}
