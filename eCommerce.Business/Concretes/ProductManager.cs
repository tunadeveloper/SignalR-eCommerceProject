using eCommerce.Business.Abstracts;
using eCommerce.DataAccess.Repositories;
using eCommerce.DataAccess.UnitOfWorks;
using eCommerce.Entity.Entities;
using System.Linq.Expressions;
using static System.Net.WebRequestMethods;

namespace eCommerce.Business.Concretes
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Product> _repository;

        public ProductManager(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.Products;
        }

        public async Task<List<Product>> GetListBL(params Expression<Func<Product, object>>[] includes)
            => await _repository.GetList(includes);

        public async Task<Product> GetByIdAsyncBL(int id, params Expression<Func<Product, object>>[] includes)
            => await _repository.GetByIdAsync(id, includes);

        public async Task<List<Product>> GetListByFilterAsyncBL(Expression<Func<Product, bool>> filter, params Expression<Func<Product, object>>[] includes)
            => await _repository.GetListByFilterAsync(filter, includes);

        public async Task<List<Product>> GetPagedAsyncBL(int page, int pageSize, params Expression<Func<Product, object>>[] includes)
            => await _repository.GetPagedAsync(page,page,includes);

        public async Task<List<Product>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task InsertAsyncBL(Product entity)
        {
            await _repository.InsertAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsyncBL(Product entity)
        {
            await _repository.UpdateAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsyncBL(Product entity)
        {
            await _repository.DeleteAsync(entity);
            await _uow.SaveAsync();
        }
    }
}
