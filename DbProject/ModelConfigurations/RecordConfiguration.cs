using DbModels.Models;
using System.Data.Entity.ModelConfiguration;

namespace DbProject.ModelConfigurations
{
	class RecordConfiguration : EntityTypeConfiguration<Record>
	{
		public RecordConfiguration()
		{
			ToTable("record");
			HasKey(record => record.Id);
			Property(record => record.Id).HasColumnName("id").IsRequired();
			Property(record => record.StartTime).HasColumnName("start_time").IsRequired();
			Property(record => record.EndTime).HasColumnName("endTime");
			Property(record => record.Comment).HasColumnName("comment");
			Property(record => record.Duration).HasColumnName("duration");
		}
	}
}
