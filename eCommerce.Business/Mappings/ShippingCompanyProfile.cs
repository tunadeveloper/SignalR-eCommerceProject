using AutoMapper;
using eCommerce.DTO.DTOs.ShippingCompanyDTOs;
using eCommerce.Entity.Entities;

namespace eCommerce.Business.Mappings
{
    public class ShippingCompanyProfile : Profile
    {
        public ShippingCompanyProfile()
        {
            CreateMap<ShippingCompany, CreateShippingCompanyDTO>().ReverseMap();
            CreateMap<ShippingCompany, UpdateShippingCompanyDTO>().ReverseMap();
            CreateMap<ShippingCompany, ResultShippingCompanyDTO>();
        }
    }
}

