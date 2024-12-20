﻿using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.Logic.Common.Models;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Common.Services
{
    public interface IRoleService
    {
        Task<Result<RoleBLL>> CreateAsync(RoleBLL role);
        Task<RoleBLL> GetByNameAsync(string name);
    }
}