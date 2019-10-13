using DbModels.Models;
using DbProject.Migrations;
using DbProject.ModelConfigurations;
using System;
using System.Data.Entity;

namespace appleTimer.DbProject
{
	public class TimerContext:DbContext
	{
        public TimerContext() : base("DB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TimerContext, Configuration>());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
		public DbSet<Record> Records { get; set; }
		public DbSet<Group> Groups { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new UserConfiguration());
			modelBuilder.Configurations.Add(new RecordConfiguration());
			modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Entity<Record>()
                .HasOptional<Group>(record => record.Group)
                .WithMany(group => group.Records)
                .HasForeignKey<Guid?>(record => record.GroupId)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Group>()
            //    .HasMany<Record>(group => group.Records)
            //    .WithOptional(record => record.GroupId)

            modelBuilder.Entity<Record>()
				.HasRequired<User>(record => record.User)
				.WithMany(user => user.Records)
				.HasForeignKey<Guid>(record => record.UserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Group>()
				.HasRequired<User>(group => group.User)
				.WithMany(user => user.Groups)
				.HasForeignKey<Guid>(group => group.UserId)
				.WillCascadeOnDelete(false);
				
		}
	}
}
