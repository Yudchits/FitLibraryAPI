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
        private readonly UserManager<UserDb> _userManager;
        private readonly IMapper _mapper;

        public RoleService(UserManager<UserDb> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> AddToRoleAsync(UserBLL user, string role)
        {
            var userDb = _mapper.Map<UserDb>(user);
            var result = await _userManager.AddToRoleAsync(userDb, role);
            return result.Succeeded;
        }

        public async Task<bool> RemoveFromRoleAsync(UserBLL user, string role)
        {
            var userDb = _mapper.Map<UserDb>(user);
            var result = await _userManager.RemoveFromRoleAsync(userDb, role);
            return result.Succeeded;
        }

        public async Task<IList<string>> GetUserRolesAsync(UserBLL user)
        {
            var userDb = _mapper.Map<UserDb>(user);
            var roles = await _userManager.GetRolesAsync(userDb);
            return roles;
        }
    }
}
