using FitLibrary.DataAccess.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.DataAccess.Common.Repositories
{
    public interface ITrainingPlanRepository
    {
        Task<ICollection<TrainingPlanDb>> GetAllTrainingPlansAsync();
        Task<TrainingPlanDb> GetTrainingPlanByIdAsync(int id);
        Task<int> CreateTrainingPlanAsync(TrainingPlanDb plan);
        Task<int> UpdateTrainingPlanAsync(TrainingPlanDb plan);
        Task<int> DeleteTrainingPlanByIdAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
