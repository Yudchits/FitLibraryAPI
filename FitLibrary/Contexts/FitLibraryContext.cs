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
    }
}
