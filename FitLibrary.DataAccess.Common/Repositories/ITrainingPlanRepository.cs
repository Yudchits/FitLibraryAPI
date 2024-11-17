using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.DataAccess.Common.Repositories
{
    public interface ITrainingPlanRepository
    {
        Task<ICollection<TrainingPlanDb>> GetAllAsync();
        Task<TrainingPlanDb> GetByIdAsync(int id);
        Task<Result<int>> CreateAsync(TrainingPlanDb plan);
        Task<Result<int>> UpdateAsync(TrainingPlanDb plan);
        Task<Result<int>> DeleteAsync(TrainingPlanDb plan);
        Task<bool> SaveChangesAsync();
    }
}
