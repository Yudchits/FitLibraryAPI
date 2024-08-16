using FitLibrary.Configurations;
using FitLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FitLibrary.Contexts
{
    public class FitLibraryContext : DbContext
    {
        public DbSet<TrainingPlan> TrainingPlans { get; set; }

        public FitLibraryContext(DbContextOptions<FitLibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingPlanConfiguration());
        }
    }
}
