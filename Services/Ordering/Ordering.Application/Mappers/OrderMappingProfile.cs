using AutoMapper;
using EventBus.Messages.Events;
using Ordering.Application.Commands;
using Ordering.Application.Handlers;
using Ordering.Application.Responses;
using Ordering.Core.Entities;

namespace Ordering.Application.Mappers
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommandv2>().ReverseMap();
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
            CreateMap<CheckoutOrderCommandv2, BasketCheckoutEventv2>().ReverseMap();
        }
    }
}
