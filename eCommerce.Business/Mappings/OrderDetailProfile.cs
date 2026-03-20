using AutoMapper;
using eCommerce.DTO.DTOs.OrderDetailDTOs;
using eCommerce.Entity.Entities;

namespace eCommerce.Business.Mappings
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, CreateOrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, ResultOrderDetailDTO>()
                .ForMember(x => x.OrderNumber, y => y.MapFrom(z => z.Order.OrderNumber))
                .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Product.ProductName));
        }
    }
}

