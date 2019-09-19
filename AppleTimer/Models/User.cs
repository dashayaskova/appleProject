using System;
using System.Collections.Generic;

namespace AppleTimer.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public String Username { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

        public List<Group> Groups { get; set; }
        public List<Record> Records { get; set; }
    }
}
