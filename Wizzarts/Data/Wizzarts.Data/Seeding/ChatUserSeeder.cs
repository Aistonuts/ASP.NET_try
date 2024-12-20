﻿namespace Wizzarts.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Wizzarts.Data.Models;

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

            await dbContext.ChatUsers.AddAsync(new ChatUser
            {
                UserId = "2738e787-5d57-4bc7-b0d2-287242f04695",
                ChatId = 2,
            });

            await dbContext.ChatUsers.AddAsync(new ChatUser
            {
                UserId = "2738e787-5d57-4bc7-b0d2-287242f04695",
                ChatId = 3,
            });

            await dbContext.ChatUsers.AddAsync(new ChatUser
            {
                UserId = "2738e787-5d57-4bc7-b0d2-287242f04695",
                ChatId = 4,
            });

            await dbContext.ChatUsers.AddAsync(new ChatUser
            {
                UserId = "2738e787-5d57-4bc7-b0d2-287242f04695",
                ChatId = 5,
            });

            await dbContext.ChatUsers.AddAsync(new ChatUser
            {
                UserId = "2738e787-5d57-4bc7-b0d2-287242f04695",
                ChatId = 6,
            });

            await dbContext.ChatUsers.AddAsync(new ChatUser
            {
                UserId = "2738e787-5d57-4bc7-b0d2-287242f04695",
                ChatId = 7,
            });

            await dbContext.ChatUsers.AddAsync(new ChatUser
            {
                UserId = "2738e787-5d57-4bc7-b0d2-287242f04695",
                ChatId = 8,
            });

            await dbContext.ChatUsers.AddAsync(new ChatUser
            {
                UserId = "2738e787-5d57-4bc7-b0d2-287242f04695",
                ChatId = 9,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
