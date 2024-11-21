﻿namespace Wizzarts.Web.Controllers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Wizzarts.Data.Models;
    using Wizzarts.Services.Data;
    using Wizzarts.Services.Messaging;
    using Wizzarts.Web.Extensions;
    using Wizzarts.Web.ViewModels.Deck;
    using Wizzarts.Web.ViewModels.Event;
    using Wizzarts.Web.ViewModels.Order;
    using Wizzarts.Web.ViewModels.PlayCard;
    using Wizzarts.Web.ViewModels.WizzartsMember;

    public class OrderController : Controller
    {
        private readonly IPlayCardService cardService;
        private readonly IArticleService articleService;
        private readonly IEventService eventService;
        private readonly IPlayCardComponentsService playCardComponentsService;
        private readonly IStoreService storeService;
        private readonly IDeckService deckService;
        private readonly IOrderService orderService;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;
        private readonly IEmailSender emailSender;

        public OrderController(
              IPlayCardService cardService,
              IArticleService articleService,
              IEventService eventService,
              IPlayCardComponentsService playCardComponentsService,
              IStoreService storeService,
              IDeckService deckService,
              IOrderService orderService,
              IUserService userService,
              UserManager<ApplicationUser> userManager,
              IWebHostEnvironment environment,
              IEmailSender emailSender)
        {
            this.cardService = cardService;
            this.articleService = articleService;
            this.eventService = eventService;
            this.playCardComponentsService = playCardComponentsService;
            this.storeService = storeService;
            this.deckService = deckService;
            this.orderService = orderService;
            this.userService = userService;
            this.userManager = userManager;
            this.environment = environment;
            this.emailSender = emailSender;
        }

        public IActionResult All()
        {
            var viewModel = new OrderListViewModel
            {
                Orders = this.orderService.GetAll<OrderInListViewModel>(),
                Events = this.eventService.GetAll<EventInListViewModel>(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> ById(int id)
        {
            var order = await this.orderService.GetById<OrderInListViewModel>(id);
            order.Cards = this.orderService.GetAllCardsInOrderId<CardInListViewModel>(id);
            order.Decks = this.deckService.GetAll<DeckInListViewModel>();
            return this.View(order);
        }

        public IActionResult My()
        {
            var viewModel = new OrderListViewModel
            {
                Orders = this.orderService.GetAllOrdersByUserId<OrderInListViewModel>(this.User.Id()),
                Decks = this.deckService.GetAll<DeckInListViewModel>(),
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Pause(int id)
        {
            var order = await this.orderService.GetById<OrderInListViewModel>(id);
            if (order != null)
            {
               await this.orderService.PauseOrder(id);
            }

            return this.RedirectToAction("All", "Order");
        }

        public async Task<IActionResult> Ship(int id)
        {
            var order = await this.orderService.GetById<OrderInListViewModel>(id);
            if (order != null)
            {
               await this.orderService.ShipOrder(id);
            }

            return this.RedirectToAction("All", "Order");
        }

        public async Task<IActionResult> Ready(int id)
        {
            var order = await this.orderService.GetById<OrderInListViewModel>(id);
            if (order != null)
            {
                await this.orderService.ReadyOrder(id);
            }

            return this.RedirectToAction("All", "Order");
        }

        [HttpPost]
        public async Task<IActionResult> SendToEmail(int id)
        {
            var order = await this.orderService.GetById<OrderInListViewModel>(id);
            var html = new StringBuilder();
            var user = this.userService.GetById<SingleMemberViewModel>(order.RecipientId);
            var uid = Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
            html.AppendLine($"<h1>{order.Title}</h1>");
            html.AppendLine($"<h3>{order.OrderStatus}</h3>");
            html.AppendLine($"<h3>Confirmation key : {uid}</h3>");
            html.AppendLine($"<h3>To secure the dispatch of your deck and your place at the event, provide us with the confirmation key by mail, chat or phone.</h3>");
            html.AppendLine($"<img src=\"{order.DeckImageUrl}\" />");
            await this.emailSender.SendEmailAsync("drawgoon@aol.com", "Wizzarts", user.Email, order.Title, html.ToString());
            return this.RedirectToAction(nameof(this.ById), new { id });
        }
    }
}