﻿namespace Wizzarts.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MagicCardsmith.Web.ViewModels.Card;
    using MagicCardsmith.Web.ViewModels.Event;
    using MagicCardsmith.Web.ViewModels.Expansion;
    using MagicCardsmith.Web.ViewModels.Stores;
    using Wizzarts.Web.ViewModels.Art;
    using Wizzarts.Web.ViewModels.Article;
    using Wizzarts.Web.ViewModels.WizzartsMember;

    public class IndexAuthenticationViewModel : PagingViewModel
    {
        [Required]
        public string UserName { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<ArticleInListViewModel> Articles { get; set; }

        public IEnumerable<ArtInListViewModel> Arts { get; set; }

        public IEnumerable<WizzartsTeamInListViewModel> Artists { get; set; }

        public IEnumerable<CardInListViewModel> Cards { get; set; }

        public IEnumerable<EventInListViewModel> Events { get; set; }

        public IEnumerable<StoresInListViewModel> Stores { get; set; }

        public IEnumerable<ExpansionInListViewModel> GameExpansions { get; set; }
    }
}
