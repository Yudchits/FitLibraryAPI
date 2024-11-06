using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserDb> _userManager;

        public AuthService(UserManager<UserDb> userManager)
        {
            _userManager = userManager;
        }

        public async Task RegisterAsync(UserBLL user)
        {
            var userDb = new UserDb
            {
                UserName = user.UserName,
                Email = user.Email
            };

            var createResult = await _userManager.CreateAsync(userDb, user.Password);

            if (!createResult.Succeeded)
            {
                throw new InvalidOperationException(string.Join(", ", createResult.Errors.Select(e => e.Description)));
            }

            await _userManager.AddToRoleAsync(userDb, UserRoles.TRAINEE);
        }

        public async Task LoginAsync(UserBLL userBLL)
        {
            var user = await _userManager.FindByEmailAsync(userBLL.Email);

            if (user == null)
            {
                throw new ArgumentException("There is no user with such email");
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, userBLL.Password);

            if (!isPasswordCorrect)
            {
                throw new ArgumentException("Incorrect password");
            }
        }
    }
}