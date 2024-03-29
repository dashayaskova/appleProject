﻿using System;
using System.Runtime.Serialization;

namespace DbModels.Models
{
    public class Record : IDBModel
	{
		[DataMember]
		private Guid _id;
		[DataMember]
		private User _user;
		[DataMember]
		private Guid _userId;
		[DataMember]
		private DateTime _startTime;
		[DataMember]
		private long _duration;
		[DataMember]
		private DateTime? _endTime;
		[DataMember]
		private string _comment;
		[DataMember]
		private Group _group;
        [DataMember]
        private Guid? _groupId;

		public Guid Id { get => _id; set => _id = value; }
		public User User { get => _user; set => _user = value; }
		public Guid UserId { get => _userId; set => _userId = value; }
		public DateTime StartTime { get => _startTime; set => _startTime = value; }
		public long Duration { get => _duration; set => _duration = value; }
		public string DurationFormat { get => TimeSpan.FromSeconds(Duration).ToString(@"hh\:mm\:ss"); }
		public DateTime? EndTime { get => _endTime; set => _endTime = value; }
		public string Comment { get => _comment; set => _comment = value; }
		public Group Group
		{
			get { return _group; }
			set
			{
				_group = value;
				GroupId = value?.Id;
			}
		}
		public Guid? GroupId { get => _groupId; set => _groupId = value; }

        public Record()
        {

        }

        public Record(User user, DateTime start)
        {
            Id = Guid.NewGuid();
            User = user;
            UserId = user.Id;
            StartTime = start;
        }

		public Record(User user)
		{
			Id = Guid.NewGuid();
			User = user;
			UserId = user.Id;
		}

		public void AddEndTime(DateTime dt)
        {
            EndTime = dt;
            Duration = (long)(EndTime - StartTime)?.TotalSeconds;
        }
	}
}
