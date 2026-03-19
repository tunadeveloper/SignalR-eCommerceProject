using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.Concretes;
using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.DataAccess.EntityFrameworks
{
    public class EfCategory:Repository<Category>, ICategory
    {
        private readonly ECommerceContext _context;

        public EfCategory(ECommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteWithProductsAsync(int categoryId)
        {
            var category = await _context.Set<Category>().FirstOrDefaultAsync(x => x.Id == categoryId);
            if (category == null) return;

            var products = await _context.Set<Product>().Where(x => x.CategoryId == categoryId).ToListAsync();
            if (products.Count > 0)
                _context.Set<Product>().RemoveRange(products);

            _context.Set<Category>().Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
