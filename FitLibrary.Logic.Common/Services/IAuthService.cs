using FitLibrary.Logic.Common.Models;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Common.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(UserBLL user);
        Task LoginAsync(UserBLL user);
    }
}