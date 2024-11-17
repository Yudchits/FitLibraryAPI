using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using System;
using System.Threading.Tasks;

namespace FitLibrary.DataAccess.Common.Repositories
{
    public interface IUserRepository
    {
        Task<UserDb> GetById(Guid id);
        Task<UserDb> GetByEmail(string email);
        Task<Result<UserDb>> CreateAsync(UserDb user);
        Task<Result<UserDb>> UpdateAsync(UserDb user);
        Task<Result<UserDb>> DeleteAsync(UserDb user);
        Task<bool> SaveChangesAsync();
    }
}