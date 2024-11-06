using AutoMapper;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.Logic.Common.Models;

namespace FitLibrary.Logic.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserBLL, UserDb>();
            CreateMap<UserDb, UserBLL>();
        }
    }
}