using System;
using System.ServiceModel;
using DbModels.Models;
using TimerServerInterface;

namespace Interface
{
    public class TimerServerWrapper
    {
        private const string _timerEndpointName = "BasicHttpBinding_ITimerServer";

        public static bool UserExists(string username, string password)
        {
            using (var myChannelFactory = new ChannelFactory<ITimerServer>("BasicHttpBinding_ITimerServer"))
            {
                ITimerServer client = myChannelFactory.CreateChannel();
                return client.UserExists(username, password);
            }
        }

        public static User GetUser(string username, string password)
        {
            using (var myChannelFactory = new ChannelFactory<ITimerServer>(_timerEndpointName))
            {
                ITimerServer client = myChannelFactory.CreateChannel();
                return client.GetUser(username, password);
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
