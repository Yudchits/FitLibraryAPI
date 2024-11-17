using AutoMapper;
using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Common.Repositories;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Services
{
    public class TrainingPlanService : ITrainingPlanService
    {
        private readonly ITrainingPlanRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public TrainingPlanService(ITrainingPlanRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ICollection<TrainingPlanShortBLL>> GetAllAsync()
        {
            return await _repository.GetAllAsync()
                .ContinueWith(result => _mapper.Map<ICollection<TrainingPlanShortBLL>>(result.Result));
        }

        public async Task<TrainingPlanFullBLL> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id)
                .ContinueWith(result => _mapper.Map<TrainingPlanFullBLL>(result.Result));
        }

        public async Task<Result<int>> CreateAsync(TrainingPlanFullBLL plan)
        {
            if (plan.Photo == null || plan.Photo.Trim() == string.Empty)
            {
                plan.Photo = _configuration["DEFAULT_PHOTO_URL"];
            }

            var planMapped = _mapper.Map<TrainingPlanDb>(plan);
            return await _repository.CreateAsync(planMapped);
        }

        public async Task<Result<int>> UpdateAsync(TrainingPlanFullBLL plan)
        {
            if (plan.Photo == null || plan.Photo.Trim() == string.Empty)
            {
                plan.Photo = _configuration["DEFAULT_PHOTO_URL"];
            }

            var planMapped = _mapper.Map<TrainingPlanDb>(plan);
            return await _repository.UpdateAsync(planMapped);
        }

        public async Task<Result<int>> DeleteByIdAsync(int id)
        {
            var plan = await _repository.GetByIdAsync(id);

            if (plan == null)
            {
                return Result<int>.Fail("План с указанным id не существует");
            }

            return await _repository.DeleteAsync(plan);
        }
    }
}
