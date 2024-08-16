using FitLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitLibrary.Configurations
{
    public class TrainingPlanConfiguration : IEntityTypeConfiguration<TrainingPlan>
    {
        public void Configure(EntityTypeBuilder<TrainingPlan> builder)
        {
            builder.ToTable("TrainingPlans");

            builder.HasKey(tp => tp.Id);

            builder.Property(tp => tp.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(tp => tp.Sport)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasOne(tp => tp.Creator)
                .WithMany(c => c.TrainingPlans)
                .HasForeignKey(tp => tp.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(tp => tp.Exercises)
                .WithOne(e => e.TrainingPlan)
                .HasForeignKey(e => e.TrainingPlanId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
