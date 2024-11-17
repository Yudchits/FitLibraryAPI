using AutoMapper;
using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Common.Repositories;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Isopoh.Cryptography.Argon2;
using System;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<UserBLL>> CheckPasswordAsync(UserBLL user)
        {
            var userByEmail = await _repository.GetByEmail(user.Email);

            if (userByEmail == null)
            {
                return Result<UserBLL>.Fail("Пользователь с указанной почтой не существует");
            }

            if (!Argon2.Verify(userByEmail.Password, user.Password))
            {
                return Result<UserBLL>.Fail("Неверный пароль");
            }

            var userBLL = _mapper.Map<UserBLL>(userByEmail);
            return Result<UserBLL>.Ok(userBLL);
        }

        public async Task<Result<UserBLL>> CreateAsync(UserBLL user)
        {
            var userDb = _mapper.Map<UserDb>(user);

            string passwordHash = Argon2.Hash(user.Password);
            if (string.IsNullOrEmpty(passwordHash) || passwordHash == user.Password)
            {
                return Result<UserBLL>.Fail("Не удалось захэшировать пароль");
            }
            userDb.Id = Guid.NewGuid();
            userDb.Password = passwordHash;

            var createResult = await _repository.CreateAsync(userDb);
            if (!createResult.Success)
            {
                return Result<UserBLL>.Fail(createResult.Message);
            }

            var userBLL = _mapper.Map<UserBLL>(createResult.Data);
            return Result<UserBLL>.Ok(userBLL);
        }
    }
}