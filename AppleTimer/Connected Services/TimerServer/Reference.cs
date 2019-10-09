﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppleTimer.TimerServer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TimerServer.ITimerServer")]
    public interface ITimerServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/GetAllUsers", ReplyAction="http://tempuri.org/ITimerServer/GetAllUsersResponse")]
        DbModels.Models.User[] GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/GetAllUsers", ReplyAction="http://tempuri.org/ITimerServer/GetAllUsersResponse")]
        System.Threading.Tasks.Task<DbModels.Models.User[]> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddUser", ReplyAction="http://tempuri.org/ITimerServer/AddUserResponse")]
        void AddUser(DbModels.Models.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITimerServer/AddUser", ReplyAction="http://tempuri.org/ITimerServer/AddUserResponse")]
        System.Threading.Tasks.Task AddUserAsync(DbModels.Models.User user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITimerServerChannel : AppleTimer.TimerServer.ITimerServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TimerServerClient : System.ServiceModel.ClientBase<AppleTimer.TimerServer.ITimerServer>, AppleTimer.TimerServer.ITimerServer {
        
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
        
        public DbModels.Models.User[] GetAllUsers() {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<DbModels.Models.User[]> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
        
        public void AddUser(DbModels.Models.User user) {
            base.Channel.AddUser(user);
        }
        
        public System.Threading.Tasks.Task AddUserAsync(DbModels.Models.User user) {
            return base.Channel.AddUserAsync(user);
        }
    }
}
