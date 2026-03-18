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

        public async Task<Category> GetByIdAsyncBL(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<List<Category>> GetListBL()
            => await _repository.GetList();

        public async Task<List<Category>> GetListByFilterAsyncBL(Expression<Func<Category, bool>> filter)
            => await _repository.GetListByFilterAsync(filter);

        public async Task<List<Category>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task<List<Category>> GetPagedAsyncBL(int page, int pageSize)
             => await _repository.GetPagedAsync(page, pageSize);

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
            await _repository.DeleteAsync(entity);
            await _uow.SaveAsync();
        }
    }
}
