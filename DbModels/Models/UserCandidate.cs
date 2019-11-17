using System;
using System.Runtime.Serialization;


namespace DbModels.Models
{
    [DataContract(IsReference = true)]
    public class UserCandidate
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
        [DataMember]
        private string surname;

        public Guid Id { get => _id; set => _id = value; }
        public String Username { get => _username; set => _username = value; }
        public String Name { get => _name; set => _name = value; }
        public String Surname { get => surname; set => surname = value; }
        public String Email { get => _email; set => _email = value; }
        public String Password { get => _password; set => _password = value; }

    }
}
