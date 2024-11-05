using FitLibrary.DataAccess.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitLibrary.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDb>
    {
        public void Configure(EntityTypeBuilder<UserDb> builder)
        {
            builder.ToTable("Users")
                .HasNoKey();

            builder.Property(u => u.Name)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
