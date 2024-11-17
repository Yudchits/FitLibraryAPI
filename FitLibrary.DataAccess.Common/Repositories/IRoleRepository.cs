using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using System.Threading.Tasks;

namespace FitLibrary.DataAccess.Common.Repositories
{
    public interface IRoleRepository
    {
        Task<Result<RoleDb>> CreateAsync(RoleDb role);
        Task<RoleDb> GetByNameAsync(string name);
        Task<bool> SaveChangesAsync();
    }
}
