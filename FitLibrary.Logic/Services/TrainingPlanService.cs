using AutoMapper;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Common.Repositories;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Services
{
    public class TrainingPlanService : ITrainingPlanService
    {
        private readonly ITrainingPlanRepository _repository;
        private readonly IMapper _mapper;

        public TrainingPlanService(ITrainingPlanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<TrainingPlanFullBLL>> GetAllTrainingPlansAsync()
        {
            return await _repository.GetAllTrainingPlansAsync()
                .ContinueWith(result => _mapper.Map<ICollection<TrainingPlanFullBLL>>(result.Result));
        }

        public async Task<TrainingPlanFullBLL> GetTrainingPlanByIdAsync(int id)
        {
            return await _repository.GetTrainingPlanByIdAsync(id)
                .ContinueWith(result => _mapper.Map<TrainingPlanFullBLL>(result.Result));
        }

        public async Task<int> CreateTrainingPlanAsync(TrainingPlanShortBLL plan)
        {
            var planMapped = _mapper.Map<TrainingPlanDb>(plan);
            return await _repository.CreateTrainingPlanAsync(planMapped);
        }

        public async Task<int> UpdateTrainingPlanAsync(TrainingPlanShortBLL plan)
        {
            var planMapped = _mapper.Map<TrainingPlanDb>(plan);
            return await _repository.UpdateTrainingPlanAsync(planMapped);
        }

        public async Task<int> DeleteTrainingPlanByIdAsync(int id)
        {
            return await _repository.DeleteTrainingPlanByIdAsync(id);
        }

        public async Task<bool> TrainingPlanIdExistsAsync(int id)
        {
            var plans = await _repository.GetAllTrainingPlansAsync();
            return plans.Any(plan => plan.Id == id);
        }
    }
}
