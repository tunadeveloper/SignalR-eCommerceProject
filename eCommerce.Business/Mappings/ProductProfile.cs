using AutoMapper;
using eCommerce.DTO.DTOs.ProductDTOs;
using eCommerce.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductDTO>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName));
        }
    }
}
