using System.Linq.Expressions;

namespace eCommerce.Business.Repositories
{
    public interface IRepositoryService<T> where T : class
    {
        Task InsertAsyncBL(T entity);
        Task UpdateAsyncBL(T entity);
        Task DeleteAsyncBL(T entity);
        Task<List<T>> GetListBL();
        Task<T> GetByIdAsyncBL(int id);
        Task<List<T>> GetListByFilterAsyncBL(Expression<Func<T, bool>> filter);
        Task<List<T>> GetPagedAsyncBL(int page, int pageSize);
        Task<List<T>> GetListNoTrackingAsyncBL();
    }
}
