﻿namespace MagicCardsmith.Web.ViewModels.SearchCard
{
    using MagicCardsmith.Data.Models;
    using MagicCardsmith.Services.Mapping;

    public class CardByTypeListViewModel : IMapFrom<CardType>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}