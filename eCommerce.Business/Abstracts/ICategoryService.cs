using eCommerce.Business.Repositories;
using eCommerce.Entity.Entities;

namespace eCommerce.Business.Abstracts
{
    public interface ICategoryService:IRepositoryService<Category>
    {
        Task DeleteWithProductsAsyncBL(int categoryId);
    }
}
