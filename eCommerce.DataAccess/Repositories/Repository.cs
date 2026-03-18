using eCommerce.DataAccess.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ECommerceContext _context;
        private readonly DbSet<T> _table;
        public Repository(ECommerceContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task DeleteAsync(T entity)
        {
            _table.Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<List<T>> GetList()
        {
            return await _table.ToListAsync();
        }

        public async Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter)
        {
           return await _table.Where(filter).ToListAsync();
        }

        public async Task<List<T>> GetListNoTrackingAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetPagedAsync(int page, int pageSize)
        {
            if (page < 1) page = 1;
            if(pageSize < 1) pageSize = 10;

            return await _table
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            _table.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
        }
    }
}
