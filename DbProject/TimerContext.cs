using AppleTimer.Models;
using DbProject.Migrations;
using DbProject.ModelConfigurations;
using System.Data.Entity;

namespace DbProject
{
	class TimerContext:DbContext
	{
		public TimerContext() : base("DB")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<TimerContext, Configuration>());
		}

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new UserConfiguration());
		}
	}
}
