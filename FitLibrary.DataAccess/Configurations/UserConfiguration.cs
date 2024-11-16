using FitLibrary.DataAccess.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitLibrary.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDb>
    {
        public void Configure(EntityTypeBuilder<UserDb> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedNever();

            builder.Property(u => u.FirstName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(u => u.MiddleName)
                .HasMaxLength(64);

            builder.Property(u => u.LastName)
                .HasMaxLength(64)
                .IsRequired();
            
            builder.Property(u => u.Email)
                .HasMaxLength(254)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(256)
                .IsRequired();

            builder
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserRoleDb>
                (
                    l => l.HasOne<RoleDb>(ur => ur.Role).WithMany().HasForeignKey(u => u.RoleId),
                    r => r.HasOne<UserDb>(ur => ur.User).WithMany().HasForeignKey(ur => ur.UserId)
                );  
        }
    }
}