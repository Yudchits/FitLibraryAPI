using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using System.Threading.Tasks;

namespace FitLibrary.DataAccess.Common.Repositories
{
    public interface IAuthRepository
    {
        Task<Result<UserDb>> RegisterAsync(UserDb user, string password);
        Task<Result<UserDb>> LoginAsync(UserDb user, string password);
    }
}