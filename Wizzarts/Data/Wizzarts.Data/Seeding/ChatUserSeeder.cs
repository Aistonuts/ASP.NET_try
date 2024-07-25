﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizzarts.Data.Models.Enums;
using Wizzarts.Data.Models;

namespace Wizzarts.Data.Seeding
{
    public class ChatUserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ChatUsers.Any())
            {
                return;
            }

            await dbContext.ChatUsers.AddAsync(new ChatUser
            {
               UserId = "2738e787-5d57-4bc7-b0d2-287242f04695",
               ChatId = 1,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
