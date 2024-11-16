using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FitLibrary.DataAccess.Contexts
{
    public class FitLibraryContext : DbContext
    {
        public DbSet<TrainingPlanDb> TrainingPlans { get; set; }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<RoleDb> Roles { get; set; }
        public DbSet<UserRoleDb> UserRoles { get; set; }

        public FitLibraryContext(DbContextOptions<FitLibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingPlanConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}