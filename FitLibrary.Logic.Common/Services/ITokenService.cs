using FitLibrary.Logic.Common.Models;
using System.Collections.Generic;

namespace FitLibrary.Logic.Common.Services
{
    public interface ITokenService
    {
        string GenerateToken(UserBLL user, IList<string> roles);
    }
}