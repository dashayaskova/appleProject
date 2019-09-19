using System;
using System.Windows.Media;

namespace AppleTimer.Models
{
    public class Group
    {
        #region Fields

        private Color _color;

        #endregion

        #region Properties
        public Guid Id { get; set; }
        public User User { get; set; }
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