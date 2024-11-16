using FitLibrary.DataAccess.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitLibrary.DataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleDb>
    {
        public void Configure(EntityTypeBuilder<RoleDb> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Name)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}