using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Utils
{
    public class RoleInitializer
    {
        public static async Task InitializeRoles(IServiceProvider serviceProvider)
        {
            var roleService = serviceProvider.GetRequiredService<IRoleService>();

            var roles = new List<RoleBLL>
            {
                new RoleBLL
                {
                    Name = UserRoles.TRAINEE
                },
                new RoleBLL
                {
                    Name = UserRoles.COACH
                },
                new RoleBLL
                {
                    Name = UserRoles.ADMIN
                }
            };

            foreach (var role in roles)
            {
                if (await roleService.GetByNameAsync(role.Name) == null)
                {
                    await roleService.CreateAsync(role);
                }
            }
        }
    }
}