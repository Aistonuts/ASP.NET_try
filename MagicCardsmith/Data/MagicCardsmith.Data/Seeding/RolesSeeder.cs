﻿namespace MagicCardsmith.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MagicCardsmith.Common;
    using MagicCardsmith.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRoleAsync(roleManager, GlobalConstants.AdministratorRoleName, GlobalConstants.AdministratorRoleGuid);
            await SeedRoleAsync(roleManager, GlobalConstants.UserRoleName, GlobalConstants.UserRoleGuid);
            await SeedRoleAsync(roleManager, GlobalConstants.ArtistRoleName, GlobalConstants.ArtistRoleGuid);
            await SeedRoleAsync(roleManager, GlobalConstants.StoreOwnerRoleName, GlobalConstants.StoreOwnerRoleGuid);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName, string id)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole
                {
                Id = id,
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                });

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
