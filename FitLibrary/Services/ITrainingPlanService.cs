using FitLibrary.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.Services
{
    public interface ITrainingPlanService
    {
        Task<ICollection<TrainingPlanDTO>> GetAllTrainingPlansAsync();
        Task<TrainingPlanDTO> GetTrainingPlanByIdAsync(int id);
        Task<int> CreateTrainingPlanAsync(TrainingPlanDTO plan);
        Task<int> UpdateTrainingPlanAsync(TrainingPlanDTO plan);
        Task<int> DeleteTrainingPlanByIdAsync(int id);
        Task<bool> TrainingPlanIdExistsAsync(int id);
    }
}
