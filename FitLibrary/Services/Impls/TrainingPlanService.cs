using AutoMapper;
using FitLibrary.DTOs;
using FitLibrary.Models;
using FitLibrary.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitLibrary.Services.Impls
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

        public async Task<ICollection<TrainingPlanDTO>> GetAllTrainingPlansAsync()
        {
            return await _repository.GetAllTrainingPlansAsync()
                .ContinueWith(result => _mapper.Map<ICollection<TrainingPlanDTO>>(result.Result));
        }

        public async Task<TrainingPlanDTO> GetTrainingPlanByIdAsync(int id)
        {
            return await _repository.GetTrainingPlanByIdAsync(id)
                .ContinueWith(result => _mapper.Map<TrainingPlanDTO>(result.Result));
        }

        public async Task<int> CreateTrainingPlanAsync(TrainingPlanDTO plan)
        {
            var planMapped = _mapper.Map<TrainingPlan>(plan);
            return await _repository.CreateTrainingPlanAsync(planMapped);
        }

        public async Task<int> UpdateTrainingPlanAsync(TrainingPlanDTO plan)
        {
            var planMapped = _mapper.Map<TrainingPlan>(plan);
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
