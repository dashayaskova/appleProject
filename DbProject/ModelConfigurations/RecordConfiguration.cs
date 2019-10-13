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
			Property(record => record.StartTime).HasColumnName("start_time").IsRequired().HasColumnType("datetime2");
			Property(record => record.EndTime).HasColumnName("endTime").IsOptional().HasColumnType("datetime2");
			Property(record => record.Comment).HasColumnName("comment").IsOptional();
			Property(record => record.Duration).HasColumnName("duration").IsOptional();
		}
	}
}
