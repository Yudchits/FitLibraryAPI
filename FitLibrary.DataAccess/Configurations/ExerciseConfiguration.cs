using FitLibrary.DataAccess.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitLibrary.DataAccess.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<ExerciseDb>
    {
        public void Configure(EntityTypeBuilder<ExerciseDb> builder)
        {
            builder.ToTable("Exercises");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ExerciseName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(e => e.Time)
                .HasMaxLength(64);

            builder.Property(e => e.Weight)
                .HasPrecision(10, 2);

            builder.Property(e => e.RestPeriod)
                .HasMaxLength(64)
                .IsRequired();

        }
    }
}
