using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Common.Repositories;
using FitLibrary.DataAccess.Contexts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace FitLibrary.DataAccess.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FitLibraryContext _context;
        private readonly UserManager<UserDb> _userManager;

        public AuthRepository(FitLibraryContext context, UserManager<UserDb> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Result<UserDb>> RegisterAsync(UserDb user, string password)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var userByEmail = await _userManager.FindByEmailAsync(user.Email);

                    if (userByEmail != null)
                    {
                        throw new ArgumentException("Пользователь с указанной почтой уже существует");
                    }

                    var result = await _userManager.CreateAsync(user, password);
                    
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException("Не удалось создать аккаунт. Попробуйте позже");
                    }

                    var addedToRoleResult = await _userManager.AddToRoleAsync(user, UserRoles.TRAINEE);

                    if (!addedToRoleResult.Succeeded)
                    {
                        throw new InvalidOperationException("Не удалось назначить роль. Попробуйте позже");
                    }

                    await transaction.CommitAsync();
                    return Result<UserDb>.Ok(user);
                }
                catch (Exception exception)
                {
                    await transaction.RollbackAsync();
                    return Result<UserDb>.Fail(exception.Message);
                }
            }
        }

        public async Task<Result<UserDb>> LoginAsync(UserDb user, string password)
        {
            try
            {
                var userByEmail = await _userManager.FindByEmailAsync(user.Email);

                if (userByEmail == null)
                {
                    throw new ArgumentException("Пользователь с указанной почтой не существует");
                }

                bool isPasswordCorrect = await _userManager.CheckPasswordAsync(userByEmail, password);

                if (!isPasswordCorrect)
                {
                    throw new ArgumentException("Неверный пароль");
                }

                return Result<UserDb>.Ok(userByEmail);
            }
            catch (Exception exception)
            {
                return Result<UserDb>.Fail(exception.Message);
            }
        }
    }
}
