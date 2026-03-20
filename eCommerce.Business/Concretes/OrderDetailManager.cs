using eCommerce.Business.Abstracts;
using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.UnitOfWorks;
using eCommerce.Entity.Entities;
using System.Linq.Expressions;

namespace eCommerce.Business.Concretes
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IOrderDetail _repository;

        public OrderDetailManager(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.OrderDetails;
        }

        public async Task<List<OrderDetail>> GetListBL(params Expression<Func<OrderDetail, object>>[] includes)
            => await _repository.GetList(includes);

        public async Task<OrderDetail> GetByIdAsyncBL(int id, params Expression<Func<OrderDetail, object>>[] includes)
            => await _repository.GetByIdAsync(id, includes);

        public async Task<List<OrderDetail>> GetListByFilterAsyncBL(Expression<Func<OrderDetail, bool>> filter, params Expression<Func<OrderDetail, object>>[] includes)
            => await _repository.GetListByFilterAsync(filter, includes);

        public async Task<List<OrderDetail>> GetPagedAsyncBL(int page, int pageSize, params Expression<Func<OrderDetail, object>>[] includes)
            => await _repository.GetPagedAsync(page, pageSize, includes);

        public async Task<List<OrderDetail>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task InsertAsyncBL(OrderDetail entity)
        {
            await _repository.InsertAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsyncBL(OrderDetail entity)
        {
            await _repository.UpdateAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsyncBL(OrderDetail entity)
        {
            await _repository.DeleteAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task<int> GetCountAsyncBL()
            => await _repository.GetCountAsync();
    }
}

