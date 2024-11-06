using FitLibrary.Logic.Common.Models;

namespace FitLibrary.Logic.Common.Services
{
    public interface ITokenService
    {
        string GenerateToken(UserBLL user);
    }
}