using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Common.Repositories;
using FitLibrary.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.DataAccess.Repositories
{
    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly FitLibraryContext _context;

        public TrainingPlanRepository(FitLibraryContext context)
        {
            _context = context;
        }

        public async Task<ICollection<TrainingPlanDb>> GetAllTrainingPlansAsync()
        {
            return await _context.TrainingPlans
                .Include(tp => tp.Creator)
                .ToListAsync();
        }

        public async Task<TrainingPlanDb> GetTrainingPlanByIdAsync(int id)
        {
            return await _context.TrainingPlans
                .Include(tp => tp.Creator)
                .Include(tp => tp.Exercises)
                .FirstOrDefaultAsync(plan => plan.Id == id);
        }

        public async Task<int> CreateTrainingPlanAsync(TrainingPlanDb plan)
        {
            await _context.TrainingPlans.AddAsync(plan);
            var isCreated = await SaveChangesAsync();
            return isCreated ? plan.Id : 0;
        }

        public async Task<int> UpdateTrainingPlanAsync(TrainingPlanDb plan)
        {
            _context.TrainingPlans.Update(plan);
            var isUpdated = await SaveChangesAsync();
            return isUpdated ? plan.Id : 0;
        }

        public async Task<int> DeleteTrainingPlanByIdAsync(int id)
        {
            var plan = await _context.TrainingPlans.FirstOrDefaultAsync(plan => plan.Id == id);

            if (plan != null)
            {
                _context.TrainingPlans.Remove(plan);
                var isDeleted = await SaveChangesAsync();

                if (isDeleted)
                {
                    return plan.Id;
                }
            }

            return 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
