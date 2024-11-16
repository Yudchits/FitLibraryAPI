using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Common.Repositories;
using FitLibrary.DataAccess.Contexts;
using System;
using System.Threading.Tasks;

namespace FitLibrary.DataAccess.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FitLibraryContext _context;

        public AuthRepository(FitLibraryContext context)
        {
            _context = context;
        }

        public Task<Result<UserDb>> LoginAsync(UserDb user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Result<UserDb>> RegisterAsync(UserDb user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
