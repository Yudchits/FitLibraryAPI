using FitLibrary.Contexts;
using FitLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.Repositories.Impls
{
    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly FitLibraryContext _context;

        public TrainingPlanRepository(FitLibraryContext context)
        {
            _context = context;
        }

        public async Task<ICollection<TrainingPlan>> GetAllTrainingPlansAsync()
        {
            return await _context.TrainingPlans.ToListAsync();
        }

        public async Task<TrainingPlan> GetTrainingPlanByIdAsync(int id)
        {
            return await _context.TrainingPlans.FirstOrDefaultAsync(plan => plan.Id == id);
        }

        public async Task<int> CreateTrainingPlanAsync(TrainingPlan plan)
        {
            await _context.TrainingPlans.AddAsync(plan);
            var isCreated = await SaveChangesAsync();
            return isCreated ? plan.Id : 0;
        }

        public async Task<int> UpdateTrainingPlanAsync(TrainingPlan plan)
        {
            _context.TrainingPlans.Update(plan);
            var isUpdated = await SaveChangesAsync();
            return isUpdated ? plan.Id : 0;
        }

        public async Task<int> DeleteTrainingPlanAsync(TrainingPlan plan)
        {
            _context.TrainingPlans.Remove(plan);
            var isDeleted = await SaveChangesAsync();
            return isDeleted ? plan.Id : 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
