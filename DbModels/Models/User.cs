using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DbModels.Models
{
	[DataContract]
	public class User : IDBModel
	{
		[DataMember]
		private Guid _id;
		[DataMember]
		private string _username;
		[DataMember]
		private string _name;
		[DataMember]
		private string _email;
		[DataMember]
		private string _password;
		[IgnoreDataMember]
		private List<Group> _groups;
		[IgnoreDataMember]
		private List<Record> _records;

		public Guid Id { get => _id; set => _id = value; }
		public String Username { get => _username; set => _username = value; }
		public String Name { get => _name; set => _name = value; }
		public String Surname { get; set; }
		public String Email { get => _email; set => _email = value; }
		public String Password { get => _password; set => _password = value; }

		public List<Group> Groups { get => _groups; set => _groups = value; }
		public List<Record> Records { get => _records; set => _records = value; }

        public User()
        {

        }

        public User(string username, string email, string password)
        {
            _id = Guid.NewGuid();
            _email = email;
            _username = username;
            _password = password;
        }
    }
}
