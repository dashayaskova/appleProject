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
        bool UserExists(string username, string password);

        [OperationContract]
        User GetUser(string username, string password);

        [OperationContract]
        void AddUser(UserCandidate user);

        [OperationContract]
        void UpdateUser(User user, string[] update_fields);

        #endregion

        #region RecordMethods
        [OperationContract]
        List<Record> GetUserRecords(User user);

        [OperationContract]
        void AddRecord(Record record);

        [OperationContract]
        void AddRecords(List<Record> records);

        [OperationContract]
        void DeleteRecords(List<Guid> recordIds);

        [OperationContract]
        void UpdateRecord(Record record, string[] updateFields);

        #endregion

        #region GroupMethods

        [OperationContract]
        List<Group> GetUserGroups(User user);
        
        [OperationContract]
        void AddGroup(Group group);

        [OperationContract]
        void AddGroups(List<Group> groups);

        [OperationContract]
        void DeleteGroups(List<Guid> group_ids);

        [OperationContract]
        void UpdateGroup(Group group, string[] update_fields);

        #endregion
    }
}
