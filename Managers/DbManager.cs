using DbModels.Models;
using Interface;

namespace Managers
{
    public class DBManager
    {
        public static bool UserExists(string username, string password)
        {
            return TimerServerWrapper.UserExists(username, password);
        }

        public static User GetUserByUsername(string username, string password)
        {
            return TimerServerWrapper.GetUser(username, password);
        }

        public static void AddUser(User user)
        {
            TimerServerWrapper.AddUser(user);
        }
    }
}
