using FitLibrary.Logic.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Common.Services
{
    public interface IRoleService
    {
        Task<bool> AddToRoleAsync(UserBLL user, string role);
        Task<bool> RemoveFromRoleAsync(UserBLL user, string role);
        Task<IList<string>> GetUserRolesAsync(UserBLL user);
    }
}