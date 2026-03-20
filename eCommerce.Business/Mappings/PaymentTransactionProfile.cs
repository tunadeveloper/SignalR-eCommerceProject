using AutoMapper;
using eCommerce.DTO.DTOs.PaymentTransactionDTOs;
using eCommerce.Entity.Entities;

namespace eCommerce.Business.Mappings
{
    public class PaymentTransactionProfile : Profile
    {
        public PaymentTransactionProfile()
        {
            CreateMap<PaymentTransaction, CreatePaymentTransactionDTO>().ReverseMap();
            CreateMap<PaymentTransaction, UpdatePaymentTransactionDTO>().ReverseMap();
            CreateMap<PaymentTransaction, ResultPaymentTransactionDTO>()
                .ForMember(x => x.CustomerName, y => y.MapFrom(z => z.Order.CustomerName));
        }
    }
}

