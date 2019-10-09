using DbModels.Models;
using Interface;

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
