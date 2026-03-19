using eCommerce.Business.Abstracts;
using eCommerce.DataAccess.Repositories;
using eCommerce.DataAccess.UnitOfWorks;
using eCommerce.Entity.Entities;
using System.Linq.Expressions;

namespace eCommerce.Business.Concretes
{
    public class PromotionManager : IPromotionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Promotion> _repository;

        public PromotionManager(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.Promotion;
        }

        public async Task<List<Promotion>> GetListBL(params Expression<Func<Promotion, object>>[] includes)
            => await _repository.GetList(includes);

        public async Task<Promotion> GetByIdAsyncBL(int id, params Expression<Func<Promotion, object>>[] includes)
            => await _repository.GetByIdAsync(id, includes);

        public async Task<List<Promotion>> GetListByFilterAsyncBL(Expression<Func<Promotion, bool>> filter, params Expression<Func<Promotion, object>>[] includes)
            => await _repository.GetListByFilterAsync(filter, includes);

        public async Task<List<Promotion>> GetPagedAsyncBL(int page, int pageSize, params Expression<Func<Promotion, object>>[] includes)
             => await _repository.GetPagedAsync(page, pageSize, includes);

        public async Task<List<Promotion>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task InsertAsyncBL(Promotion entity)
        {
            await _repository.InsertAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsyncBL(Promotion entity)
        {
            await _repository.UpdateAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsyncBL(Promotion entity)
        {
            await _repository.DeleteAsync(entity);
            await _uow.SaveAsync();
        }
    }
}
