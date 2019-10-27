﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppleTimer.TimerService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TimerService.ITimerServer")]
    public interface ITimerServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/UserExists", ReplyAction="http://tempuri.org/ITimerServer/UserExistsResponse")]
        bool UserExists(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/UserExists", ReplyAction="http://tempuri.org/ITimerServer/UserExistsResponse")]
        System.Threading.Tasks.Task<bool> UserExistsAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/GetUser", ReplyAction="http://tempuri.org/ITimerServer/GetUserResponse")]
        DbModels.Models.User GetUser(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/GetUser", ReplyAction="http://tempuri.org/ITimerServer/GetUserResponse")]
        System.Threading.Tasks.Task<DbModels.Models.User> GetUserAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddUser", ReplyAction="http://tempuri.org/ITimerServer/AddUserResponse")]
        void AddUser(DbModels.Models.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddUser", ReplyAction="http://tempuri.org/ITimerServer/AddUserResponse")]
        System.Threading.Tasks.Task AddUserAsync(DbModels.Models.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/UpdateUser", ReplyAction="http://tempuri.org/ITimerServer/UpdateUserResponse")]
        void UpdateUser(DbModels.Models.User user, string[] update_fields);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/UpdateUser", ReplyAction="http://tempuri.org/ITimerServer/UpdateUserResponse")]
        System.Threading.Tasks.Task UpdateUserAsync(DbModels.Models.User user, string[] update_fields);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/GetUserRecords", ReplyAction="http://tempuri.org/ITimerServer/GetUserRecordsResponse")]
        DbModels.Models.Record[] GetUserRecords(DbModels.Models.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/GetUserRecords", ReplyAction="http://tempuri.org/ITimerServer/GetUserRecordsResponse")]
        System.Threading.Tasks.Task<DbModels.Models.Record[]> GetUserRecordsAsync(DbModels.Models.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddRecord", ReplyAction="http://tempuri.org/ITimerServer/AddRecordResponse")]
        void AddRecord(DbModels.Models.Record record);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddRecord", ReplyAction="http://tempuri.org/ITimerServer/AddRecordResponse")]
        System.Threading.Tasks.Task AddRecordAsync(DbModels.Models.Record record);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddRecords", ReplyAction="http://tempuri.org/ITimerServer/AddRecordsResponse")]
        void AddRecords(DbModels.Models.Record[] records);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddRecords", ReplyAction="http://tempuri.org/ITimerServer/AddRecordsResponse")]
        System.Threading.Tasks.Task AddRecordsAsync(DbModels.Models.Record[] records);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/DeleteRecords", ReplyAction="http://tempuri.org/ITimerServer/DeleteRecordsResponse")]
        void DeleteRecords(System.Guid[] recordIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/DeleteRecords", ReplyAction="http://tempuri.org/ITimerServer/DeleteRecordsResponse")]
        System.Threading.Tasks.Task DeleteRecordsAsync(System.Guid[] recordIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/UpdateRecord", ReplyAction="http://tempuri.org/ITimerServer/UpdateRecordResponse")]
        void UpdateRecord(DbModels.Models.Record record, string[] updateFields);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/UpdateRecord", ReplyAction="http://tempuri.org/ITimerServer/UpdateRecordResponse")]
        System.Threading.Tasks.Task UpdateRecordAsync(DbModels.Models.Record record, string[] updateFields);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/GetUserGroups", ReplyAction="http://tempuri.org/ITimerServer/GetUserGroupsResponse")]
        DbModels.Models.Group[] GetUserGroups(DbModels.Models.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/GetUserGroups", ReplyAction="http://tempuri.org/ITimerServer/GetUserGroupsResponse")]
        System.Threading.Tasks.Task<DbModels.Models.Group[]> GetUserGroupsAsync(DbModels.Models.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddGroup", ReplyAction="http://tempuri.org/ITimerServer/AddGroupResponse")]
        void AddGroup(DbModels.Models.Group group);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddGroup", ReplyAction="http://tempuri.org/ITimerServer/AddGroupResponse")]
        System.Threading.Tasks.Task AddGroupAsync(DbModels.Models.Group group);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddGroups", ReplyAction="http://tempuri.org/ITimerServer/AddGroupsResponse")]
        void AddGroups(DbModels.Models.Group[] groups);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddGroups", ReplyAction="http://tempuri.org/ITimerServer/AddGroupsResponse")]
        System.Threading.Tasks.Task AddGroupsAsync(DbModels.Models.Group[] groups);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/DeleteGroups", ReplyAction="http://tempuri.org/ITimerServer/DeleteGroupsResponse")]
        void DeleteGroups(System.Guid[] group_ids);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/DeleteGroups", ReplyAction="http://tempuri.org/ITimerServer/DeleteGroupsResponse")]
        System.Threading.Tasks.Task DeleteGroupsAsync(System.Guid[] group_ids);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/UpdateGroup", ReplyAction="http://tempuri.org/ITimerServer/UpdateGroupResponse")]
        void UpdateGroup(DbModels.Models.Group group, string[] update_fields);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/UpdateGroup", ReplyAction="http://tempuri.org/ITimerServer/UpdateGroupResponse")]
        System.Threading.Tasks.Task UpdateGroupAsync(DbModels.Models.Group group, string[] update_fields);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITimerServerChannel : AppleTimer.TimerService.ITimerServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TimerServerClient : System.ServiceModel.ClientBase<AppleTimer.TimerService.ITimerServer>, AppleTimer.TimerService.ITimerServer {
        
        public TimerServerClient() {
        }
        
        public TimerServerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TimerServerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TimerServerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TimerServerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool UserExists(string username, string password) {
            return base.Channel.UserExists(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> UserExistsAsync(string username, string password) {
            return base.Channel.UserExistsAsync(username, password);
        }
        
        public DbModels.Models.User GetUser(string username, string password) {
            return base.Channel.GetUser(username, password);
        }
        
        public System.Threading.Tasks.Task<DbModels.Models.User> GetUserAsync(string username, string password) {
            return base.Channel.GetUserAsync(username, password);
        }
        
        public void AddUser(DbModels.Models.User user) {
            base.Channel.AddUser(user);
        }
        
        public System.Threading.Tasks.Task AddUserAsync(DbModels.Models.User user) {
            return base.Channel.AddUserAsync(user);
        }
        
        public void UpdateUser(DbModels.Models.User user, string[] update_fields) {
            base.Channel.UpdateUser(user, update_fields);
        }
        
        public System.Threading.Tasks.Task UpdateUserAsync(DbModels.Models.User user, string[] update_fields) {
            return base.Channel.UpdateUserAsync(user, update_fields);
        }
        
        public DbModels.Models.Record[] GetUserRecords(DbModels.Models.User user) {
            return base.Channel.GetUserRecords(user);
        }
        
        public System.Threading.Tasks.Task<DbModels.Models.Record[]> GetUserRecordsAsync(DbModels.Models.User user) {
            return base.Channel.GetUserRecordsAsync(user);
        }
        
        public void AddRecord(DbModels.Models.Record record) {
            base.Channel.AddRecord(record);
        }
        
        public System.Threading.Tasks.Task AddRecordAsync(DbModels.Models.Record record) {
            return base.Channel.AddRecordAsync(record);
        }
        
        public void AddRecords(DbModels.Models.Record[] records) {
            base.Channel.AddRecords(records);
        }
        
        public System.Threading.Tasks.Task AddRecordsAsync(DbModels.Models.Record[] records) {
            return base.Channel.AddRecordsAsync(records);
        }
        
        public void DeleteRecords(System.Guid[] recordIds) {
            base.Channel.DeleteRecords(recordIds);
        }
        
        public System.Threading.Tasks.Task DeleteRecordsAsync(System.Guid[] recordIds) {
            return base.Channel.DeleteRecordsAsync(recordIds);
        }
        
        public void UpdateRecord(DbModels.Models.Record record, string[] updateFields) {
            base.Channel.UpdateRecord(record, updateFields);
        }
        
        public System.Threading.Tasks.Task UpdateRecordAsync(DbModels.Models.Record record, string[] updateFields) {
            return base.Channel.UpdateRecordAsync(record, updateFields);
        }
        
        public DbModels.Models.Group[] GetUserGroups(DbModels.Models.User user) {
            return base.Channel.GetUserGroups(user);
        }
        
        public System.Threading.Tasks.Task<DbModels.Models.Group[]> GetUserGroupsAsync(DbModels.Models.User user) {
            return base.Channel.GetUserGroupsAsync(user);
        }
        
        public void AddGroup(DbModels.Models.Group group) {
            base.Channel.AddGroup(group);
        }
        
        public System.Threading.Tasks.Task AddGroupAsync(DbModels.Models.Group group) {
            return base.Channel.AddGroupAsync(group);
        }
        
        public void AddGroups(DbModels.Models.Group[] groups) {
            base.Channel.AddGroups(groups);
        }
        
        public System.Threading.Tasks.Task AddGroupsAsync(DbModels.Models.Group[] groups) {
            return base.Channel.AddGroupsAsync(groups);
        }
        
        public void DeleteGroups(System.Guid[] group_ids) {
            base.Channel.DeleteGroups(group_ids);
        }
        
        public System.Threading.Tasks.Task DeleteGroupsAsync(System.Guid[] group_ids) {
            return base.Channel.DeleteGroupsAsync(group_ids);
        }
        
        public void UpdateGroup(DbModels.Models.Group group, string[] update_fields) {
            base.Channel.UpdateGroup(group, update_fields);
        }
        
        public System.Threading.Tasks.Task UpdateGroupAsync(DbModels.Models.Group group, string[] update_fields) {
            return base.Channel.UpdateGroupAsync(group, update_fields);
        }
    }
}