using AutoMapper;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.Logic.Common.Models;

namespace FitLibrary.Logic.Mappings
{
    public class TrainingPlanProfile : Profile
    {
        public TrainingPlanProfile()
        {
            CreateMap<TrainingPlanDb, TrainingPlanShortBLL>();
            CreateMap<TrainingPlanShortBLL, TrainingPlanDb>();

            CreateMap<TrainingPlanDb, TrainingPlanFullBLL>();
            CreateMap<TrainingPlanFullBLL, TrainingPlanDb>();
        }
    }
}
