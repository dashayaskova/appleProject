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

        #region UserMethods
        public bool UserExists(string username, string password)
        {
            return _service.UserExists(username, password);
        }

        public User GetUser(string username, string password)
        {
            return _service.GetUser(username, password);
        }

        public void AddUser(UserCandidate user)
        {
            _service.AddUser(user);
        }

        public void UpdateUser(User user, string[] update_fields)
        {
            _service.UpdateUser(user, update_fields);
        }

        #endregion

        #region RecordMethods
        public List<Record> GetUserRecords(User user)
        {
            return _service.GetUserRecords(user);
        }

        public void AddRecord(Record record)
        {
            _service.AddRecord(record);
        }

        public void AddRecords(List<Record> records)
        {
            _service.AddRecords(records);
        }

        public void DeleteRecords(List<Guid> recordIds)
        {
            _service.DeleteRecords(recordIds);
        }
        
        public void UpdateRecord(Record record, string[] updateFields)
        {
            _service.UpdateRecord(record, updateFields);
        }

        #endregion

        #region GroupMethods
        public List<Group> GetUserGroups(User user)
        {
            return _service.GetUserGroups(user);
        }

        public void AddGroup(Group group)
        {
            _service.AddGroup(group);
        }

        public void AddGroups(List<Group> groups)
        {
            _service.AddGroups(groups);
        }

        public void DeleteGroups(List<Guid> groupIds)
        {
            _service.DeleteGroups(groupIds);
        }

        public void UpdateGroup(Group group, string[] updateFields)
        {
            _service.UpdateGroup(group, updateFields);
        }

        #endregion
    }
}
