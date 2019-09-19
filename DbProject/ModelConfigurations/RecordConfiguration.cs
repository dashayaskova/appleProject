using AppleTimer.Models;
using System.Data.Entity.ModelConfiguration;

namespace DbProject.ModelConfigurations
{
	class RecordConfiguration : EntityTypeConfiguration<Record>
	{
		public RecordConfiguration()
		{
			ToTable("user");
			HasKey(record => record.StartTime);
			Property(record => record.StartTime).HasColumnName("username").IsRequired();
		}
	}
}
