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

        public async Task InsertAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _table.Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public async Task<List<T>> GetList(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table.Where(filter);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<List<T>> GetPagedAsync(int page, int pageSize, params Expression<Func<T, object>>[] includes)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            IQueryable<T> query = _table;

            foreach (var include in includes)
                query = query.Include(include);

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<T>> GetListNoTrackingAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }
    }
}