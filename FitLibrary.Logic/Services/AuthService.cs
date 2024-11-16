using AutoMapper;
using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Common.Repositories;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<UserBLL>> LoginAsync(UserBLL user, string password)
        {
            var userDb = _mapper.Map<UserDb>(user);
            var result = await _repository.LoginAsync(userDb, password);

            var userMapped = _mapper.Map<UserBLL>(result.Data);
            if (result.Success)
            {
                return Result<UserBLL>.Ok(userMapped);
            }
            else
            {
                return Result<UserBLL>.Fail(result.Message);
            }
        }

        public async Task<Result<UserBLL>> RegisterAsync(UserBLL user, string password)
        {
            var userDb = new UserDb
            {
                //UserName = user.UserName,
                //Email = user.Email
            };

            var result = await _repository.RegisterAsync(userDb, password);

            var userMapped = _mapper.Map<UserBLL>(result.Data);
            if (result.Success)
            {
                return Result<UserBLL>.Ok(userMapped);
            }
            else
            {
                return Result<UserBLL>.Fail(result.Message);
            }
        }
    }
}