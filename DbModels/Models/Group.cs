using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace DbModels.Models
{
    public class Group : IDBModel
    {
        #region Fields
        [IgnoreDataMember]
        private Color _color;
        [IgnoreDataMember]
        private List<Record> records;
        
        [DataMember]
        private Guid id;
        [DataMember]
        private User user;
        [DataMember]
        private Guid userId;
        [DataMember]
        private string name;
        [DataMember]
        private string colorString;

        #endregion

        #region Properties
        public List<Record> Records { get => records; set => records = value; }
        public Guid Id { get => id; set => id = value; }
        public User User { get => user; set => user = value; }
        public Guid UserId { get => userId; set => userId = value; }
        public string Name { get => name; set => name = value; }
        public string ColorString { get => colorString; set => colorString = value; }

        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                ColorString = value.ToString();
            }
        }

        #endregion

        public Group()
        {
        }

        public Group(User user)
        {
            Id = Guid.NewGuid();
            User = user;
            UserId = user.Id;
        }

    }
}