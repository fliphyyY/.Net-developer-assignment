using AutoMapper;
using DAL.Models;
using Metrans.SerializerObjects;

namespace Metrans.Profiles
{
    internal class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderObject, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderHeader.Id))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.OrderHeader.CustomerId))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderHeader.OrderDate))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.OrderFooter.TotalAmount))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.OrderFooter.Status));
        }
    }
}
