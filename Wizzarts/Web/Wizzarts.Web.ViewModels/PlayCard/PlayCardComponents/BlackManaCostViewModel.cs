﻿namespace Wizzarts.Web.ViewModels.PlayCard.PlayCardComponents
{
    using Wizzarts.Data.Models;
    using Wizzarts.Services.Mapping;

    public class BlackManaCostViewModel : IMapFrom<BlackMana>
    {
        public int Id { get; set; }

        public int Cost { get; set; }

        public string ColorName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}