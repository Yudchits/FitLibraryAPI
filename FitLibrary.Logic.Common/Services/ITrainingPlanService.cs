using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.Logic.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Common.Services
{
    public interface ITrainingPlanService
    {
        Task<ICollection<TrainingPlanShortBLL>> GetAllAsync();
        Task<TrainingPlanFullBLL> GetByIdAsync(int id);
        Task<Result<int>> CreateAsync(TrainingPlanFullBLL plan);
        Task<Result<int>> UpdateAsync(TrainingPlanFullBLL plan);
        Task<Result<int>> DeleteByIdAsync(int id);
    }
}
