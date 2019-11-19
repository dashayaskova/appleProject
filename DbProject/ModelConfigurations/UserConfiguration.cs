﻿using DbModels.Models;
using System.Data.Entity.ModelConfiguration;

namespace DbProject.ModelConfigurations
{
	class UserConfiguration : EntityTypeConfiguration<User>
	{
		public UserConfiguration()
		{
			ToTable("user");
			HasKey(user => user.Id);
			Property(user => user.Id).HasColumnName("id").IsRequired();
			Property(user => user.Username).HasMaxLength(100).HasColumnName("username").IsRequired();
			Property(user => user.Email).HasMaxLength(100).HasColumnName("email").IsRequired();
			Property(user => user.Name).HasColumnName("name").IsRequired();
			Property(user => user.Password).HasColumnName("password").IsRequired();
			Property(user => user.Surname).HasColumnName("surname");
		}
	}
}
