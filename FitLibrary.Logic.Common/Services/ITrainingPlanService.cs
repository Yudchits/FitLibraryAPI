using FitLibrary.Logic.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Common.Services
{
    public interface ITrainingPlanService
    {
        Task<ICollection<TrainingPlanShortBLL>> GetAllTrainingPlansAsync();
        Task<TrainingPlanFullBLL> GetTrainingPlanByIdAsync(int id);
        Task<int> CreateTrainingPlanAsync(TrainingPlanFullBLL plan);
        Task<int> UpdateTrainingPlanAsync(TrainingPlanFullBLL plan);
        Task<int> DeleteTrainingPlanByIdAsync(int id);
        Task<bool> TrainingPlanIdExistsAsync(int id);
    }
}
