using System.Linq.Expressions;

namespace eCommerce.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetList();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetPagedAsync(int page, int pageSize);
        Task<List<T>> GetListNoTrackingAsync();
    }
}
