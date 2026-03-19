using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;

namespace eCommerce.DataAccess.Abstracts
{
    public interface ICategory : IRepository<Category>
    {
        Task DeleteWithProductsAsync(int categoryId);
    }
}
