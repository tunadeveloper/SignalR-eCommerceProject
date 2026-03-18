using eCommerce.Business.Abstracts;
using eCommerce.DataAccess.Repositories;
using eCommerce.DataAccess.UnitOfWorks;
using eCommerce.Entity.Entities;
using System.Linq.Expressions;

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

        public async Task<Product> GetByIdAsyncBL(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<List<Product>> GetListBL()
            => await _repository.GetList();

        public async Task<List<Product>> GetListByFilterAsyncBL(Expression<Func<Product, bool>> filter)
            => await _repository.GetListByFilterAsync(filter);

        public async Task<List<Product>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task<List<Product>> GetPagedAsyncBL(int page, int pageSize)
             => await _repository.GetPagedAsync(page, pageSize);

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
