using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;
using System.Threading.Tasks;

namespace eCommerce.DataAccess.Abstracts
{
    public interface IOrder : IRepository<Order>
    {
        Task DeleteWithOrderDetailsAsync(int orderId);
    }
}

