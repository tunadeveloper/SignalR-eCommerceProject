using AutoMapper;
using eCommerce.DTO.DTOs.ContactDTOs;
using eCommerce.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business.Mappings
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
        }
    }
}
