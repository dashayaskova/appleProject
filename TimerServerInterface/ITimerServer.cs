using DbModels.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace TimerServerInterface
{
	[ServiceContract]
	public interface ITimerServer
	{
		[OperationContract]
		IEnumerable<User> GetAllUsers();

		[OperationContract]
		void AddUser(User user);

	}
}
