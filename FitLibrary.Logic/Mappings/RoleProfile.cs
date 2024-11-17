using AutoMapper;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.Logic.Common.Models;

namespace FitLibrary.Logic.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleBLL, RoleDb>();
            CreateMap<RoleDb, RoleBLL>();
        }
    }
}