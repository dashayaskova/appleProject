using System.Windows.Media;

namespace AppleTimer.Models
{
	public class Group
	{
		private Color _color;
		public string Name { get; set; }

		public string ColorString
		{
			get; set;
		}

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

		public Group(string color, string name)
		{
			Name = name;
			ColorString = color;
		}

	}
}
