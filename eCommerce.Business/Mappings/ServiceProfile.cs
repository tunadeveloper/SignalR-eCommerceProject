using AutoMapper;
using eCommerce.DTO.DTOs.ServiceDTOs;
using eCommerce.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business.Mappings
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, CreateServiceDTO>().ReverseMap();
            CreateMap<Service, UpdateServiceDTO>().ReverseMap();
            CreateMap<Service, ResultServiceDTO>().ReverseMap();
        }
    }
}
