using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.Logic.Common.Models;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Common.Services
{
    public interface IAuthService
    {
        Task<Result<UserBLL>> RegisterAsync(UserBLL user, string password);
        Task<Result<UserBLL>> LoginAsync(UserBLL user, string password);
    }
}