﻿namespace Wizzarts.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    public class WizzartsTeamRoleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.UserRoles.Any())
            {
                return;
            }

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = "c3233260-ea67-47fe-a8f0-7785bb31c136",
                UserId = "2b346dc6-5bd7-4e64-8396-15a064aa27a7",
            });

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = "7932748b-a6a7-480d-b8d7-a689b6e29221",
                UserId = "5823bbf1-993c-416b-9bf1-c358fedf38a6",
            });

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = "7932748b-a6a7-480d-b8d7-a689b6e29221",
                UserId = "0ac1e577-c7ff-4aa3-83c3-e5acac9de281",
            });

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = "7932748b-a6a7-480d-b8d7-a689b6e29221",
                UserId = "2b346dc6-5bd7-4e64-8396-15a064aa27a7",
            });

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = "7932748b-a6a7-480d-b8d7-a689b6e29221",
                UserId = "f6f94be8-49e0-4a28-9e7f-797c40e7e169",
            });

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = "7932748b-a6a7-480d-b8d7-a689b6e29221",
                UserId = "b4accad4-e878-4de3-a317-665d0a43fbd3",
            });

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = "7932748b-a6a7-480d-b8d7-a689b6e29221",
                UserId = "ad8dada2-c947-4ad3-aaa1-e530f13d21c1",
            });

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = "7932748b-a6a7-480d-b8d7-a689b6e29221",
                UserId = "799d728e-0c16-4e4a-81b3-48a113a88cf1",
            });

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = "7932748b-a6a7-480d-b8d7-a689b6e29221",
                UserId = "eb49ba9d-5030-42b6-8aef-c93506943fde",
            });

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = "7932748b-a6a7-480d-b8d7-a689b6e29221",
                UserId = "2738e787-5d57-4bc7-b0d2-287242f04695",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
