using eCommerce.Business.Abstracts;
using eCommerce.DataAccess.Repositories;
using eCommerce.DataAccess.UnitOfWorks;
using eCommerce.Entity.Entities;
using System.Linq.Expressions;

namespace eCommerce.Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Category> _repository;

        public CategoryManager(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.Categories;
        }

        public async Task<List<Category>> GetListBL(params Expression<Func<Category, object>>[] includes)
            => await _repository.GetList(includes);

        public async Task<Category> GetByIdAsyncBL(int id, params Expression<Func<Category, object>>[] includes)
            => await _repository.GetByIdAsync(id, includes);

        public async Task<List<Category>> GetListByFilterAsyncBL(Expression<Func<Category, bool>> filter, params Expression<Func<Category, object>>[] includes)
            => await _repository.GetListByFilterAsync(filter, includes);

        public async Task<List<Category>> GetPagedAsyncBL(int page, int pageSize, params Expression<Func<Category, object>>[] includes)
             => await _repository.GetPagedAsync(page, pageSize, includes);

        public async Task<List<Category>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task InsertAsyncBL(Category entity)
        {
            await _repository.InsertAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsyncBL(Category entity)
        {
            await _repository.UpdateAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsyncBL(Category entity)
        {
            await _uow.Categories.DeleteWithProductsAsync(entity.Id);
        }

        public async Task DeleteWithProductsAsyncBL(int categoryId)
        {
            await _uow.Categories.DeleteWithProductsAsync(categoryId);
        }

        public async Task<int> GetCountAsyncBL()
        {
            return await _repository.GetCountAsync();
        }
    }
}
