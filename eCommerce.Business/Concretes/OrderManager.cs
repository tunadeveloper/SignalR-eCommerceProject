using eCommerce.Business.Abstracts;
using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.UnitOfWorks;
using eCommerce.Entity.Entities;
using System.Linq.Expressions;

namespace eCommerce.Business.Concretes
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IOrder _repository;

        public OrderManager(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.Orders;
        }

        public async Task<List<Order>> GetListBL(params Expression<Func<Order, object>>[] includes)
            => await _repository.GetList(includes);

        public async Task<Order> GetByIdAsyncBL(int id, params Expression<Func<Order, object>>[] includes)
            => await _repository.GetByIdAsync(id, includes);

        public async Task<List<Order>> GetListByFilterAsyncBL(Expression<Func<Order, bool>> filter, params Expression<Func<Order, object>>[] includes)
            => await _repository.GetListByFilterAsync(filter, includes);

        public async Task<List<Order>> GetPagedAsyncBL(int page, int pageSize, params Expression<Func<Order, object>>[] includes)
            => await _repository.GetPagedAsync(page, pageSize, includes);

        public async Task<List<Order>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task InsertAsyncBL(Order entity)
        {
            await _repository.InsertAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsyncBL(Order entity)
        {
            await _repository.UpdateAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsyncBL(Order entity)
        {
            // Order detaylarıyla birlikte silinir.
            await _repository.DeleteWithOrderDetailsAsync(entity.Id);
        }

        public async Task DeleteWithOrderDetailsAsyncBL(int orderId)
        {
            await _repository.DeleteWithOrderDetailsAsync(orderId);
        }

        public async Task<int> GetCountAsyncBL()
            => await _repository.GetCountAsync();
    }
}

