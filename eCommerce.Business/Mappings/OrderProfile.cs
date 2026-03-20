using AutoMapper;
using eCommerce.DTO.DTOs.OrderDTOs;
using eCommerce.Entity.Entities;

namespace eCommerce.Business.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();
            CreateMap<Order, ResultOrderDTO>();
        }
    }
}

