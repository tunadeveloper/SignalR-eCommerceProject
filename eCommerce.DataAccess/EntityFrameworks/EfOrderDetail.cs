using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.Concretes;
using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;

namespace eCommerce.DataAccess.EntityFrameworks
{
    public class EfOrderDetail : Repository<OrderDetail>, IOrderDetail
    {
        public EfOrderDetail(ECommerceContext context) : base(context)
        {
        }
    }
}

