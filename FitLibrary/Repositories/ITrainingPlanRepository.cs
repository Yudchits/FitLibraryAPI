using FitLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.Repositories
{
    public interface ITrainingPlanRepository
    {
        Task<ICollection<TrainingPlan>> GetAllTrainingPlansAsync();
        Task<TrainingPlan> GetTrainingPlanByIdAsync(int id);
        Task<int> CreateTrainingPlanAsync(TrainingPlan plan);
        Task<int> UpdateTrainingPlanAsync(TrainingPlan plan);
        Task<int> DeleteTrainingPlanAsync(TrainingPlan plan);
        Task<bool> SaveChangesAsync();
    }
}
