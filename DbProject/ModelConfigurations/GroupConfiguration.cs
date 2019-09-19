using DbModels.Models;
using System.Data.Entity.ModelConfiguration;

namespace DbProject.ModelConfigurations
{
	class GroupConfiguration : EntityTypeConfiguration<Group>
	{
		public GroupConfiguration()
		{
			ToTable("group");
			HasKey(group => group.Id);
			Property(group => group.Id).HasColumnName("id").IsRequired();
			Property(group => group.Name).HasColumnName("name").IsRequired();
			Property(group => group.ColorString).HasColumnName("color_name").IsRequired();
			
		}
	}
}
