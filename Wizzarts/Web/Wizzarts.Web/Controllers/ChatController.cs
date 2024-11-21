﻿namespace Wizzarts.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Wizzarts.Data;
    using Wizzarts.Data.Models;
    using Wizzarts.Data.Models.Enums;
    using Wizzarts.Services.Data;
    using Wizzarts.Web.ViewModels.Chat;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ChatController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IChatService chatService;
        private readonly UserManager<ApplicationUser> userManager;

        public ChatController(
            ApplicationDbContext dbContext,
            IChatService chatService,
            UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.chatService = chatService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MessageViewModel viewModel)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);
                var message = new ChatMessage
                {
                    ChatId = viewModel.ChatId,
                    Text = viewModel.Text,
                    Name = user.UserName,
                    Timestamp = DateTime.Now,
                };
                _ = this.dbContext.ChatMessages.AddAsync(message);
                await this.dbContext.SaveChangesAsync();
                return this.Ok();
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            try
            {
                var chat = new Chat
                {
                    Name = name,
                    Type = ChatType.Event,

                };
                var user = await this.userManager.GetUserAsync(this.User);
                chat.Users.Add(new ChatUser
                {
                    UserId = user.Id,
                });

                this.dbContext.Chats.Add(chat);

                await this.dbContext.SaveChangesAsync();

                return this.Ok();
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> JoinRoom(int id)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);
                var chatUser = new ChatUser
                {
                    ChatId = id,
                    UserId = user.Id,
                };

                this.dbContext.ChatUsers.Add(chatUser);

                await this.dbContext.SaveChangesAsync();
                return this.Ok();
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        public IActionResult ById(int id)
        {
            var view = this.chatService.GetById<SingleChatViewModel>(id);
            view.ChatId = id;
            view.ChatRooms = this.chatService.GetAllChatRooms<SingleChatViewModel>();
            view.Messages = this.chatService.GetAllChatMessagesInChatRoom<DbChatMessagesInListViewModel>(id);

            return this.View(view);
        }
    }
}