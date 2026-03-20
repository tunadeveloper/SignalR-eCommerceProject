using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.Concretes;
using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;

namespace eCommerce.DataAccess.EntityFrameworks
{
    public class EfShippingCompany : Repository<ShippingCompany>, IShippingCompany
    {
        public EfShippingCompany(ECommerceContext context) : base(context)
        {
        }
    }
}

