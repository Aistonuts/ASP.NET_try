﻿namespace Wizzarts.Web.Areas.Administration.Models.Event
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;
    using Wizzarts.Web.ViewModels.Deck;
    using Wizzarts.Web.ViewModels.Home;
    using Wizzarts.Web.ViewModels.TagHelper;

    using static Wizzarts.Common.DataConstants;
    using static Wizzarts.Common.MessageConstants;

    public class BaseEventViewModel
    {
        public const int StatusId = 3;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(EventTitleMaxLength, MinimumLength = EventTitleMinLength, ErrorMessage = LengthMessage)]
        [Comment("Event Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength, ErrorMessage = LengthMessage)]
        [Comment("Event Description")]
        public string EventDescription { get; set; } = string.Empty;

        public int EventStatusId { get; set; } = StatusId;

        public string ActionId { get; set; } = string.Empty;

        public string ControllerId { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public IEnumerable<SingleTagHelpControllerViewModel> TagHelpControllers { get; set; }

        public IEnumerable<SingleTagHelperActionViewModel> TagHelperActions { get; set; }

        public IEnumerable<EventCategoryInListViewModel> EventCategories { get; set; }

        public IEnumerable<EventComponentsInListViewModel> EventComponents { get; set; }

        public IEnumerable<EventInListViewModel> Events { get; set; }

    }
}