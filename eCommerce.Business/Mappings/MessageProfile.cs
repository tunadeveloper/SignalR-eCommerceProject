using AutoMapper;
using eCommerce.DTO.DTOs.MessageDTOs;
using eCommerce.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business.Mappings
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();
            CreateMap<Message, ResultMessageDTO>().ReverseMap();
        }
    }
}
