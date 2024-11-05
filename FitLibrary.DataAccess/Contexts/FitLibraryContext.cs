using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitLibrary.DataAccess.Contexts
{
    public class FitLibraryContext : DbContext
    {
        public DbSet<TrainingPlanDb> TrainingPlans { get; set; }

        public FitLibraryContext(DbContextOptions<FitLibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingPlanConfiguration());
        }
    }
}
