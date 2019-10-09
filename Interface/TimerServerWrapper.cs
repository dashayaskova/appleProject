using System;
using System.ServiceModel;
using DbModels.Models;
using TimerServerInterface;

namespace Interface
{
    public class TimerServerWrapper
    {
        private const string _timerEndpointName = "BasicHttpBinding_ITimerServer";

        public static bool UserExists(string login)
        {
            using (var myChannelFactory = new ChannelFactory<ITimerServer>("BasicHttpBinding_ITimerServer"))
            {
                ITimerServer client = myChannelFactory.CreateChannel();
                return client.UserExists(login);
            }
        }

        public static User GetUserByUsername(string username)
        {
            using (var myChannelFactory = new ChannelFactory<ITimerServer>(_timerEndpointName))
            {
                ITimerServer client = myChannelFactory.CreateChannel();
                return client.GetUserByUsername(username);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var myChannelFactory = new ChannelFactory<ITimerServer>(_timerEndpointName))
            {
                ITimerServer client = myChannelFactory.CreateChannel();
                return client.GetUserByGuid(guid);
            }
        }

        public static void AddUser(User user)
        {
            using (var myChannelFactory = new ChannelFactory<ITimerServer>(_timerEndpointName))
            {
                ITimerServer client = myChannelFactory.CreateChannel();
                client.AddUser(user);
            }
        }
    }
}
