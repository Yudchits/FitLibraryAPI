using AutoMapper;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.Logic.Common.Models;

namespace FitLibrary.Logic.Mappings
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<ExerciseDb, ExerciseBLL>();
            CreateMap<ExerciseBLL, ExerciseDb>();
        }
    }
}