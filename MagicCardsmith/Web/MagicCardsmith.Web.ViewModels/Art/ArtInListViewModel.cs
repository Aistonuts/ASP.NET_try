﻿namespace MagicCardsmith.Web.ViewModels.Art
{
    using AutoMapper;
    using MagicCardsmith.Data.Models;
    using MagicCardsmith.Services.Mapping;

    public class ArtInListViewModel : IMapFrom<Art>, IHaveCustomMappings, ISingleArtViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ArtistName { get; set; }

        public bool ApprovedByAdmin { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Art, ArtInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                       x.RemoteImageUrl))
                .ForMember(x => x.ArtistName, opt =>
                   opt.MapFrom(x =>
                       x.Artist.Nickname));
        }
    }
}