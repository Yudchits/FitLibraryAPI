using AutoMapper;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;

        public RoleService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<bool> AddToRoleAsync(UserBLL user, string role)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetUserRolesAsync(UserBLL user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveFromRoleAsync(UserBLL user, string role)
        {
            throw new System.NotImplementedException();
        }
    }
}
