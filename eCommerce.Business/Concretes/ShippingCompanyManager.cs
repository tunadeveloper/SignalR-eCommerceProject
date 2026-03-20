using eCommerce.Business.Abstracts;
using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.UnitOfWorks;
using eCommerce.Entity.Entities;
using System.Linq.Expressions;

namespace eCommerce.Business.Concretes
{
    public class ShippingCompanyManager : IShippingCompanyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IShippingCompany _repository;

        public ShippingCompanyManager(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.ShippingCompanies;
        }

        public async Task<List<ShippingCompany>> GetListBL(params Expression<Func<ShippingCompany, object>>[] includes)
            => await _repository.GetList(includes);

        public async Task<ShippingCompany> GetByIdAsyncBL(int id, params Expression<Func<ShippingCompany, object>>[] includes)
            => await _repository.GetByIdAsync(id, includes);

        public async Task<List<ShippingCompany>> GetListByFilterAsyncBL(Expression<Func<ShippingCompany, bool>> filter, params Expression<Func<ShippingCompany, object>>[] includes)
            => await _repository.GetListByFilterAsync(filter, includes);

        public async Task<List<ShippingCompany>> GetPagedAsyncBL(int page, int pageSize, params Expression<Func<ShippingCompany, object>>[] includes)
            => await _repository.GetPagedAsync(page, pageSize, includes);

        public async Task<List<ShippingCompany>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task InsertAsyncBL(ShippingCompany entity)
        {
            await _repository.InsertAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsyncBL(ShippingCompany entity)
        {
            await _repository.UpdateAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsyncBL(ShippingCompany entity)
        {
            await _repository.DeleteAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task<int> GetCountAsyncBL()
            => await _repository.GetCountAsync();
    }
}

