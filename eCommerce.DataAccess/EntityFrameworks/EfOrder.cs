using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.Concretes;
using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.DataAccess.EntityFrameworks
{
    public class EfOrder : Repository<Order>, IOrder
    {
        private readonly ECommerceContext _context;

        public EfOrder(ECommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteWithOrderDetailsAsync(int orderId)
        {
            var order = await _context.Set<Order>().FirstOrDefaultAsync(x => x.Id == orderId);
            if (order == null) return;

            var orderDetails = await _context.Set<OrderDetail>()
                .Where(x => x.OrderId == orderId)
                .ToListAsync();

            if (orderDetails.Count > 0)
                _context.Set<OrderDetail>().RemoveRange(orderDetails);

            _context.Set<Order>().Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}

