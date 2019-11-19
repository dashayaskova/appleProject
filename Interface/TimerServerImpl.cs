using DbModels.Models;
using DbProject;
using Interface.Tools;
using System;
using System.Collections.Generic;
using TimerServerInterface;

namespace AppleTimer.Server.TimerServerInterface
{
	public class TimerServerImpl : ITimerServer
	{
		#region UserMethods
		public bool IsUserUnique(string username, string email)
		{
			return EntityWrapper.IsUserUnique(username, email);
		}

		public bool UserExists(string username, string password)
        {
            string hash = CryptoManager.TransformPassword(password);
            return EntityWrapper.UserExists(username, hash);
        }

        public User GetUser(string username, string password)
        {
            string hash = CryptoManager.TransformPassword(password);
            return EntityWrapper.GetUser(username, hash);
        }

        public void AddUser(UserCandidate userCandidate)
        {
            User user = new User();
            user.Id = userCandidate.Id;
            user.Name = userCandidate.Name;
            user.Username = userCandidate.Username;
            user.Surname = userCandidate.Surname;
            user.Email = userCandidate.Email;
            user.Password = CryptoManager.TransformPassword(userCandidate.Password);
            EntityWrapper.AddUser(user);
        }

        public void UpdateUser(User user, string[] update_fields)
        {
            EntityWrapper.UpdateUser(user, update_fields);
        }

        #endregion

        #region RecordMethods
        public List<Record> GetUserRecords(User user)
        {
            return EntityWrapper.GetUserRecords(user.Id);
        }

        public void AddRecord(Record record)
        {
            EntityWrapper.AddRecord(record);
        }

        public void AddRecords(List<Record> records)
        {
            EntityWrapper.AddRecords(records);
        }

        public void DeleteRecords(List<Guid> record_ids)
        {
            EntityWrapper.DeleteRecords(record_ids);
        }

        public void UpdateRecord(Record record, string[] update_fields)
        {
            EntityWrapper.UpdateRecord(record, update_fields);
        }

        #endregion

        #region GroupMethods
        public List<Group> GetUserGroups(User user)
        {
            return EntityWrapper.GetUserGroups(user.Id);
        }

        public void AddGroup(Group group)
        {
            EntityWrapper.AddGroup(group);
        }

        public void AddGroups(List<Group> groups)
        {
            EntityWrapper.AddGroups(groups);
        }

        public void DeleteGroups(List<Guid> group_ids)
        {
            EntityWrapper.DeleteGroups(group_ids);
        }

        public void UpdateGroup(Group group, string[] update_fields)
        {
            EntityWrapper.UpdateGroup(group, update_fields);
        }

        #endregion
    }
}
