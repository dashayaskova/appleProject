using appleTimer.DbProject;
using DbModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DbProject
{
	public static class EntityWrapper
	{

        #region UserMethods

        public static bool UserExists(string username, string password)
        {
            using (var context = new TimerContext())
            {
                return context.Users.Any(u => u.Username == username && u.Password == password);
            }
        }

        public static User GetUser(string username, string password)
        {
            using (var context = new TimerContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }
        }

        public static void UpdateUser(User user, string[] update_fields)
        {
            using (var context = new TimerContext())
            {
                User n_user = context.Users.FirstOrDefault(u => u.Id == user.Id);
                foreach (string p in update_fields)
                {
                    switch (p) {
                        case "Username":
                            n_user.Username = user.Username;
                            break;
                        case "Name":
                            n_user.Name = user.Name;
                            break;
                        case "Surname":
                            n_user.Surname = user.Surname;
                            break;
                        case "Email":
                            n_user.Email = user.Email;
                            break;
                        case "Password":
                            n_user.Password = user.Password;
                            break;
                    }
                }
                context.SaveChanges();
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var context = new TimerContext())
            {
                return context.Users.FirstOrDefault(u => u.Id == guid);
            }
        }

        public static void AddUser(User user)
        {
            using (var context = new TimerContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        #endregion

        #region RecordMethods

        public static List<Record> GetUserRecords(Guid userId)
        {
            using (var context = new TimerContext())
            {
                var a =  context.Records.Include(r => r.Group).Where(o => o.UserId == userId).ToList();
                
                return a;
            }
        }
        
        public static void AddRecord(Record record)
        {
            using (var context = new TimerContext())
            {
                context.Users.Attach(record.User);

				if (record.Group != null)
				{
					context.Groups.Attach(record.Group);
				}
				
				context.Records.Add(record);
                context.SaveChanges();
            }
        }

        public static void AddRecords(List<Record> records)
        {
            using (var context = new TimerContext())
            {
                context.Records.AddRange(records);
                context.SaveChanges();
            }
        }

        public static void DeleteRecords(List<Guid> record_ids)
        {
            using (var context = new TimerContext())
            {
                var toDelete = context.Records.Where(r => record_ids.Contains(r.Id));
                context.Records.RemoveRange(toDelete);
                context.SaveChanges();
            }
        }

        public static void UpdateRecord(Record record, string[] update_fields)
        {
            using (var context = new TimerContext())
            {
                //context.Users.Attach(record.User);
                context.Groups.Attach(record.Group);
                Record nRecord = context.Records.FirstOrDefault(r => r.Id == record.Id);
                foreach (string p in update_fields)
                {
                    switch (p)
                    {
                        case "StartTime":
                            nRecord.StartTime = record.StartTime;
                            break;
                        case "Duration":
                            nRecord.Duration = record.Duration;
                            break;
                        case "EndTime":
                            nRecord.EndTime = record.EndTime;
                            break;
                        case "Comment":
                            nRecord.Comment = record.Comment;
                            break;
                        case "Group":
                            nRecord.Group = record.Group;
                            nRecord.GroupId = record.GroupId;
                            break;
                    }
                }
                context.SaveChanges();
            }
        }
        
        #endregion

        #region GroupMethods

        public static List<Group> GetUserGroups(Guid userId)
        {
            using (var context = new TimerContext())
            {
                return context.Groups.Where(o => o.UserId == userId).ToList();
            }
        }
        
        public static void AddGroup(Group group)
        {
            using (var context = new TimerContext())
            {
                context.Users.Attach(group.User);
                context.Groups.Add(group);
				context.SaveChanges();
				context.Entry(group).State = System.Data.Entity.EntityState.Unchanged;
			}
        }

        public static void AddGroups(List<Group> groups)
        {
            using (var context = new TimerContext())
            {
                context.Groups.AddRange(groups);
                context.SaveChanges();
            }
        }

        public static void DeleteGroups(List<Guid> groupIds)
        {
            using (var context = new TimerContext())
            {
                var toDelete = context.Groups.Where(r => groupIds.Contains(r.Id));
                context.Groups.RemoveRange(toDelete);
                context.SaveChanges();
            }
        }

        public static void UpdateGroup(Group group, string[] update_fields)
        {
            using (var context = new TimerContext())
            {
                context.Users.Attach(group.User);
                Group nGroup = context.Groups.FirstOrDefault(r => r.Id == group.Id);
                foreach (string p in update_fields)
                {
                    switch (p)
                    {
                        case "Name":
                            nGroup.Name = group.Name;
                            break;
                        case "ColorString":
                            nGroup.ColorString = group.ColorString;
                            break;
                    }
                }
                context.SaveChanges();
            }
        }
        #endregion


    }
}
