﻿using KitapSatisApp.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitapSatisApp.Persistence.Auth
{
	public class AuthConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.Id);
			builder.Property(u => u.Id).ValueGeneratedOnAdd();
			builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
			builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(100);	
			builder.Property(u => u.Email).IsRequired().HasMaxLength(100);	

		}
	}
}
