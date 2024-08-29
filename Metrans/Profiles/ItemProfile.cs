using AutoMapper;
using DAL.Models;
using Metrans.SerializerObjects;

namespace Metrans.Profiles
{
    internal class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<OrderItem, Item>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(opt => opt.Id))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(opt => opt.OrderId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(opt => opt.ProductName))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(opt => opt.Quantity))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(opt => opt.TotalPrice))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(opt => opt.UnitPrice));
        }
    }
}
