using AutoMapper;
using eCommerce.DTO.DTOs.PromotionDTOs;
using eCommerce.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business.Mappings
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<Promotion, CreatePromotionDTO>().ReverseMap();
            CreateMap<Promotion, UpdatePromotionDTO>().ReverseMap();
            CreateMap<Promotion, ResultPromotionDTO>().ReverseMap();
        }
    }
}
