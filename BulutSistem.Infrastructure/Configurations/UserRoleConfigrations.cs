﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BulutSistem.Domain.Models;


namespace BulutSistem.Infrastructure.Configurations
{
    internal sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");
            builder.HasKey(p => new { p.AppUserId, p.AppRoleId });
        }
    }
}
