using System.Linq.Expressions;

namespace eCommerce.Business.Repositories
{
    public interface IRepositoryService<T> where T : class
    {
        Task InsertAsyncBL(T entity);
        Task UpdateAsyncBL(T entity);
        Task DeleteAsyncBL(T entity);
        Task<List<T>> GetListBL(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsyncBL(int id, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetListByFilterAsyncBL(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetPagedAsyncBL(int page, int pageSize, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetListNoTrackingAsyncBL();
    }
}
