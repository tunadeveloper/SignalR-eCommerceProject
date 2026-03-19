using System.Linq.Expressions;

namespace eCommerce.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetList(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetPagedAsync(int page, int pageSize, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetListNoTrackingAsync();
    }
}
