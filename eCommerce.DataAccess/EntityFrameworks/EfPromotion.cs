using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.Concretes;
using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataAccess.EntityFrameworks
{
    public class EfPromotion:Repository<Promotion>, IPromotion
    {
        public EfPromotion(ECommerceContext context) : base(context)
        {
            
        }
    }
}
