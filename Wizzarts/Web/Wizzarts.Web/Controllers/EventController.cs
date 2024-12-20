﻿namespace Wizzarts.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Wizzarts.Common;
    using Wizzarts.Data.Models;
    using Wizzarts.Services.Data;
    using Wizzarts.Web.Infrastructure.Extensions;
    using Wizzarts.Web.ViewModels.Event;
    using Wizzarts.Web.ViewModels.TagHelper;

    using static Wizzarts.Common.GlobalConstants;
    using static Wizzarts.Common.HardCodedConstants;

    public class EventController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEventService eventService;
        private readonly IStoreService storeService;
        private readonly IWebHostEnvironment environment;

        public EventController(
            UserManager<ApplicationUser> userManager,
            IEventService eventService,
            IStoreService storeService,
            IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.eventService = eventService;
            this.storeService = storeService;
            this.environment = environment;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(int id = 1)
        {
            const int ItemsPerPage = 4;
            var viewModel = new EventListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Count = await this.eventService.GetCount(),
                Events = await this.eventService.GetAllPagination<EventInListViewModel>(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        // location of user only events, those are not visible on the main page
        public async Task<IActionResult> ByUser()
        {
            var viewModel = new EventListViewModel
            {
                Events = await this.eventService.GetAllEventsByUsers<EventInListViewModel>(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> ById(int id, string information, int pageId = 1)
        {
            var newEvent = await this.eventService.GetById<SingleEventViewModel>(id);
            if (newEvent == null || information != newEvent.GetEventTitle())
            {
                return this.BadRequest();
            }

            newEvent.EventComponents = await this.eventService.GetAllEventComponents<EventComponentsInListViewModel>(id);
            newEvent.EventId = id;
            return this.View(newEvent);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateEventViewModel
            {
                Events = await this.eventService.GetAllEventsByUserId<EventInListViewModel>(this.User.GetId(), 1, 3),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventViewModel input)
        {
            this.ModelState.Remove("UserName");
            this.ModelState.Remove("Password");

            if (await this.eventService.EventTitleExist(input.Title))
            {
                this.ModelState.AddModelError(nameof(input.Title), "Event title exist.");
            }

            if (!this.ModelState.IsValid)
            {
                input.Events = await this.eventService.GetAllEventsByUserId<EventInListViewModel>(this.User.GetId(), 1, 3);
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var currentRole = await this.userManager.GetRolesAsync(user);
            bool isContentCreator = false;

            if (currentRole.Contains(PremiumRoleName) || currentRole.Contains(ArtistRoleName))
            {
                isContentCreator = true;
            }

            try
            {
                await this.eventService.CreateAsync(input, this.User.GetId(), $"{this.environment.WebRootPath}/images", isContentCreator);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.Events = await this.eventService.GetAllEventsByUserId<EventInListViewModel>(this.User.GetId(), 1, 3);
                return this.View(input);
            }

            this.TempData["Message"] = "Event added successfully.";

            return this.RedirectToAction("Create", "Event");
        }

        // this will allow customer to edit the event and add additional content
        public async Task<IActionResult> My(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var newEvent = await this.eventService.GetById<MyEventSettingsViewModel>(id);
            newEvent.EventComponents = await this.eventService.GetAllEventComponents<EventComponentsInListViewModel>(id);
            newEvent.Events = await this.eventService.GetAllEventsByUserId<EventInListViewModel>(this.User.GetId(), 1, 3);
            newEvent.EventId = id;
            newEvent.CreatorAvatar = user.AvatarUrl;
            newEvent.OwnerBrowsing = false;
            bool isOwner = await this.eventService.HasUserWithIdAsync(newEvent.EventId, this.User.GetId());
            if (isOwner)
            {
                newEvent.OwnerBrowsing = true;
            }

            return this.View(newEvent);
        }

        [HttpPost]
        public async Task<IActionResult> My(MyEventSettingsViewModel input)
        {
            this.ModelState.Remove("UserName");
            this.ModelState.Remove("Password");
            var user = await this.userManager.GetUserAsync(this.User);
            var newEvent = await this.eventService.GetById<MyEventSettingsViewModel>(input.EventId);

            if (!this.ModelState.IsValid)
            {
                newEvent.EventComponents = await this.eventService.GetAllEventComponents<EventComponentsInListViewModel>(input.EventId);
                newEvent.Events = await this.eventService.GetAllEventsByUserId<EventInListViewModel>(this.User.GetId(), 1, 3);
                newEvent.EventId = input.EventId;
                newEvent.CreatorAvatar = user.AvatarUrl;
                newEvent.OwnerBrowsing = false;
                bool isOwner = await this.eventService.HasUserWithIdAsync(newEvent.EventId, this.User.GetId());
                if (isOwner)
                {
                    newEvent.OwnerBrowsing = true;
                }

                return this.View(newEvent);
            }

            try
            {
                await this.eventService.AddComponentAsync(input, this.User.GetId(), $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                newEvent.EventComponents = await this.eventService.GetAllEventComponents<EventComponentsInListViewModel>(input.EventId);
                newEvent.Events = await this.eventService.GetAllEventsByUserId<EventInListViewModel>(this.User.GetId(), 1, 3);
                newEvent.EventId = input.EventId;
                newEvent.CreatorAvatar = user.AvatarUrl;
                newEvent.OwnerBrowsing = false;
                bool isOwner = await this.eventService.HasUserWithIdAsync(newEvent.EventId, this.User.GetId());
                if (isOwner)
                {
                    newEvent.OwnerBrowsing = true;
                }

                return this.View(input);
            }

            this.TempData["Message"] = "Event added successfully.";

            return this.RedirectToAction(nameof(this.My), new { id = input.EventId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var inputModel = await this.eventService.GetById<EditEventViewModel>(id);

            if (inputModel != null)
            {
                inputModel.EventComponents = await this.eventService.GetAllEventComponents<EventComponentsInListViewModel>(id);
                return this.View(inputModel);
            }
            else
            {
                return this.NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEventViewModel inputModel, int id)
        {
            this.ModelState.Remove("UserName");
            this.ModelState.Remove("Password");
            if (!this.ModelState.IsValid)
            {
                inputModel.EventComponents = await this.eventService.GetAllEventComponents<EventComponentsInListViewModel>(id);
                return this.View(inputModel);
            }

            if (await this.eventService.EventExist(id) == false)
            {
                return this.BadRequest();
            }

            if (await this.eventService.HasUserWithIdAsync(id, this.User.GetId()) == false
                && this.User.IsAdmin() == false)
            {
                return this.Unauthorized();
            }

            await this.eventService.UpdateAsync(inputModel, id);
            return this.RedirectToAction(nameof(this.My), new { id });
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> ApproveEvent(int id)
        {
            var userId = await this.eventService.ApproveEvent(id);
            if (userId != null)
            {
                return this.RedirectToAction("ById", "Member", new { id = $"{userId}", Area = "Administration" });
            }
            else
            {
                return this.RedirectToAction("All", "Member", new { Area = "Administration" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await this.eventService.EventExist(id) == false)
            {
                return this.BadRequest();
            }

            if (await this.eventService.HasUserWithIdAsync(id, this.User.GetId()) == false
                && this.User.IsAdmin() == false)
            {
                return this.Unauthorized();
            }

            await this.eventService.DeleteAsync(id);

            return this.RedirectToAction("MyData", "User");
        }

        // delete is used for removing the event, remove is used fo removing event content
        public async Task<IActionResult> Remove(int id)
        {
            if (await this.eventService.EventComponentExist(id) == false)
            {
                return this.BadRequest();
            }

            var currentEventComponent = await this.eventService.GetEventComponentById<EventComponentsInListViewModel>(id);
            var eventId = currentEventComponent.EventId;
            if (await this.eventService.HasUserWithIdAsync(currentEventComponent.EventId, this.User.GetId()) == false
                && this.User.IsAdmin() == false)
            {
                return this.Unauthorized();
            }

            await this.eventService.DeleteComponentAsync(id);

            return this.RedirectToAction(nameof(this.Edit), new { id = eventId });
        }

        // this will turn the event visible on the event page
        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Promote(int id)
        {
            var userId = await this.eventService.PromoteEvent(id);
            if (userId != null)
            {
                return this.RedirectToAction("ById", "Member", new { id = $"{userId}", Area = "Administration" });
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}
