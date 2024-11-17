using AutoMapper;
using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.DataAccess.Common.Models;
using FitLibrary.DataAccess.Common.Repositories;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<RoleBLL>> CreateAsync(RoleBLL role)
        {
            var roleDb = _mapper.Map<RoleDb>(role);
            var createResult = await _repository.CreateAsync(roleDb);
            if (!createResult.Success)
            {
                return Result<RoleBLL>.Fail(createResult.Message);
            }

            var roleBLL = _mapper.Map<RoleBLL>(roleDb);
            return Result<RoleBLL>.Ok(roleBLL);
        }

        public async Task<RoleBLL> GetByNameAsync(string name)
        {
            return await _repository
                .GetByNameAsync(name)
                .ContinueWith(result => _mapper.Map<RoleBLL>(result.Result));
        }
    }
}
