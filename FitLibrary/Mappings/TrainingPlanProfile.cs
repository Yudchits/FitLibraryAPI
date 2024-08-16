using AutoMapper;
using FitLibrary.DTOs;
using FitLibrary.Models;

namespace FitLibrary.Mappings
{
    public class TrainingPlanProfile : Profile
    {
        public TrainingPlanProfile()
        {
            CreateMap<TrainingPlan, TrainingPlanDTO>();
            CreateMap<TrainingPlanDTO, TrainingPlan>();
        }
    }
}
