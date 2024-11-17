using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Common.Repositories;
using FitLibrary.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FitLibrary.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly FitLibraryContext _context;

        public RoleRepository(FitLibraryContext context)
        {
            _context = context;
        }

        public async Task<Result<RoleDb>> CreateAsync(RoleDb role)
        {
            _context.Roles.Add(role);

            var isCreated = await SaveChangesAsync();
            if (!isCreated)
            {
                return Result<RoleDb>.Fail("Не удалось создать роль");
            }

            return Result<RoleDb>.Ok(role);
        }

        public async Task<RoleDb> GetByNameAsync(string name)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
        }

        public async Task<bool> SaveChangesAsync()
        {
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
