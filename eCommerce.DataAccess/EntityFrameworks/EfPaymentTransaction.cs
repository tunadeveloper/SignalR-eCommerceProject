using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.Concretes;
using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;

namespace eCommerce.DataAccess.EntityFrameworks
{
    public class EfPaymentTransaction : Repository<PaymentTransaction>, IPaymentTransaction
    {
        public EfPaymentTransaction(ECommerceContext context) : base(context)
        {
        }
    }
}

