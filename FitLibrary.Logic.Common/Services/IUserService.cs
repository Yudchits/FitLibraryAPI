using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.Logic.Common.Models;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Common.Services
{
    public interface IUserService
    {
        Task<Result<UserBLL>> CreateAsync(UserBLL user);
        Task<Result<UserBLL>> CheckPasswordAsync(UserBLL user);
    }
}