using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace DbModels.Models
{
    public class Group
    {
        #region Fields

        private Color _color;

        #endregion

        #region Properties

		public List<Record> Records { get; set; }
        public Guid Id { get; set; }
        public User User { get; set; }

		public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ColorString { get; set; }

        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                ColorString = value.ToString();
            }
        }
        public Group()
        {
        }
        
        #endregion


        public Group(string color, string name)
        {
            Name = name;
            ColorString = color;
        }
    }
}