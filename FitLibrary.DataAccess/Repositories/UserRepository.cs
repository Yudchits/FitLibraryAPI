using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Common.Repositories;
using FitLibrary.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FitLibrary.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FitLibraryContext _context;

        public UserRepository(FitLibraryContext context)
        {
            _context = context;
        }

        public async Task<UserDb> GetById(Guid id)
        {
            return await _context.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u =>  u.Id == id);
        }

        public async Task<UserDb> GetByEmail(string email)
        {
            return await _context.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Result<UserDb>> CreateAsync(UserDb user)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Users.Add(user);
                    var isCreated = await SaveChangesAsync();
                    if (!isCreated)
                    {
                        throw new InvalidOperationException("Не удалось создать профиль");
                    }

                    var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == UserRoles.TRAINEE);
                    if (role == null)
                    {
                        throw new ArgumentException("Отсутствует пользовательская роль. Обратитесь к модератору");
                    }

                    var userRole = new UserRoleDb
                    {
                        UserId = user.Id,
                        RoleId = role.Id
                    };
                    _context.UserRoles.Add(userRole);
                    var isUserRoleCreated = await SaveChangesAsync();
                    if (!isUserRoleCreated)
                    {
                        throw new InvalidOperationException("Не удалось назначить роль");
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
        public async Task<Result<UserDb>> UpdateAsync(UserDb user)
        {
            _context.Users.Update(user);
            var isUpdated = await SaveChangesAsync();
            if (!isUpdated)
            {
                return Result<UserDb>.Fail("Не удалось обновить профиль");
            }

            return Result<UserDb>.Ok(user);
        }

        public async Task<Result<UserDb>> DeleteAsync(UserDb user)
        {
            _context.Users.Remove(user);
            var isDeleted = await SaveChangesAsync();
            if (!isDeleted)
            {
                return Result<UserDb>.Fail("Не удалось удалить профиль");
            }

            return Result<UserDb>.Ok(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}