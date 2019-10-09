using DbModels.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace TimerServerInterface
{
	[ServiceContract]
	public interface ITimerServer
	{
        #region UserMethods

        [OperationContract]
        bool UserExists(string username);

        [OperationContract]
        User GetUserByUsername(string username);

        [OperationContract]
        User GetUserByGuid(Guid guid);

        [OperationContract]
        void AddUser(User user);
        #endregion

	}
}
