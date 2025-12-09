using AutoMapper;
using Discount.Core;
using Discount.Grpc.Protos;

namespace Discount.Application.Mappers
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile() 
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
