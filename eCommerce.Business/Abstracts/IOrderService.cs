using eCommerce.Business.Repositories;
using eCommerce.Entity.Entities;
using System.Threading.Tasks;

namespace eCommerce.Business.Abstracts
{
    public interface IOrderService : IRepositoryService<Order>
    {
        Task DeleteWithOrderDetailsAsyncBL(int orderId);
    }
}

