using AppleTimer.Models;
using System.Data.Entity.ModelConfiguration;

namespace DbProject.ModelConfigurations
{
	class UserConfiguration : EntityTypeConfiguration<User>
	{
		public UserConfiguration()
		{
			ToTable("user");
			HasKey(user => user.Username);
			Property(user => user.Username).HasColumnName("username").IsRequired();
			Property(user => user.Email).HasColumnName("email").IsRequired();
			Property(user => user.Name).HasColumnName("name").IsRequired();
			Property(user => user.Password).HasColumnName("password").IsRequired();
			Property(user => user.Surname).HasColumnName("surname");
		}
	}
}
