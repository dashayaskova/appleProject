using System;
using System.Windows.Media;

namespace AppleTimer.Models
{
	public class Record
	{
		public User User { get; set; }
		public DateTime StartTime { get; set; }
		public long Duration { get; set; }
		public DateTime EndTime { get; set; }
		public string Comment { get; set; }
		public Group Group { get; set; }
	}
}
