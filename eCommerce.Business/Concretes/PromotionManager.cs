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

        public async Task<Promotion> GetByIdAsyncBL(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<List<Promotion>> GetListBL()
            => await _repository.GetList();

        public async Task<List<Promotion>> GetListByFilterAsyncBL(Expression<Func<Promotion, bool>> filter)
            => await _repository.GetListByFilterAsync(filter);

        public async Task<List<Promotion>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task<List<Promotion>> GetPagedAsyncBL(int page, int pageSize)
             => await _repository.GetPagedAsync(page, pageSize);

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
