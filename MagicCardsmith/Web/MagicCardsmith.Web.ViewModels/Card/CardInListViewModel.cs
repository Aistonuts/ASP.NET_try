﻿namespace MagicCardsmith.Web.ViewModels.Card
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;
    using MagicCardsmith.Data.Models;
    using MagicCardsmith.Services.Mapping;
    using MagicCardsmith.Web.ViewModels.Art;

    public class CardInListViewModel : IMapFrom<Card>, IHaveCustomMappings, ISingleCardViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CardRemoteUrl { get; set; }

        public string CardExpansion { get; set; }

        public string CardTypeId { get; set; }

        public string AbilitiesAndFlavor { get; set; }

        public bool ApprovedByAdmin { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Card, CardInListViewModel>()
         .ForMember(x => x.CardRemoteUrl, opt =>
          opt.MapFrom(x => x.CardRemoteUrl));

            configuration.CreateMap<Card, CardInListViewModel>()
         .ForMember(x => x.CardExpansion, opt =>
          opt.MapFrom(x => x.GameExpansionId));
        }
    }
}
