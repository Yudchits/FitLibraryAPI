using FitLibrary.DataAccess.Common.Helpers;
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

        public async Task<ICollection<TrainingPlanDb>> GetAllAsync()
        {
            return await _context.TrainingPlans
                .Include(tp => tp.Creator)
                .ToListAsync();
        }

        public async Task<TrainingPlanDb> GetByIdAsync(int id)
        {
            return await _context.TrainingPlans
                .Include(tp => tp.Creator)
                .Include(tp => tp.Exercises)
                .FirstOrDefaultAsync(plan => plan.Id == id);
        }

        public async Task<Result<int>> CreateAsync(TrainingPlanDb plan)
        {
            _context.TrainingPlans.Add(plan);
            var isCreated = await SaveChangesAsync();
            if (!isCreated)
            {
                return Result<int>.Fail("Не удалось создать план тренировок");
            }

            return Result<int>.Ok(plan.Id);
        }

        public async Task<Result<int>> UpdateAsync(TrainingPlanDb plan)
        {
            _context.TrainingPlans.Update(plan);
            var isUpdated = await SaveChangesAsync();
            if (!isUpdated)
            {
                return Result<int>.Fail("Не удалось обновить план тренировок");
            }

            return Result<int>.Ok(plan.Id);
        }

        public async Task<Result<int>> DeleteAsync(TrainingPlanDb plan)
        {
            _context.TrainingPlans.Remove(plan);
            var isDeleted = await SaveChangesAsync();
            if (!isDeleted)
            {
                return Result<int>.Fail("Не удалось удалить план тренировок");
            }

            return Result<int>.Ok(plan.Id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
