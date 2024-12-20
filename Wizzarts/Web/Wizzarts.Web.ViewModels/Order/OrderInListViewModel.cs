﻿namespace Wizzarts.Web.ViewModels.Order
{
    using System;

    using AutoMapper;
    using Wizzarts.Data.Models;
    using Wizzarts.Services.Mapping;
    using Wizzarts.Web.ViewModels.Home;
    using Wizzarts.Web.ViewModels.PlayCard;

    public class OrderInListViewModel : IndexAuthenticationViewModel, IMapFrom<Order>, IHaveCustomMappings, ISingleCardViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string DeckImageUrl { get; set; } = string.Empty;

        public string RecipientId { get; set; } = string.Empty;

        public int DeckId { get; set; }

        public string ShippingAddress { get; set; } = string.Empty;

        public DateTime? EstimatedDeliveryDate { get; set; }

        public string OrderStatus { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order, OrderInListViewModel>()
               .ForMember(x => x.OrderStatus, opt =>
                   opt.MapFrom(x =>
                      x.OrderStatus.Name));
        }
    }
}
