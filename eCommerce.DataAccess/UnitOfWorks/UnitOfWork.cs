using eCommerce.DataAccess.Concretes;
using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;

namespace eCommerce.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceContext _context;

        public IRepository<Category> Categories { get; }
        public IRepository<Contact> Contacts { get; }
        public IRepository<Message> Messages { get; }
        public IRepository<Product> Products { get; }
        public IRepository<Service> Services { get; }
        public IRepository<Promotion> Promotion { get; }

        public UnitOfWork(ECommerceContext context)
        {
            _context = context;

            Categories = new Repository<Category>(context);
            Contacts = new Repository<Contact>(context);
            Messages = new Repository<Message>(context);
            Products = new Repository<Product>(context);
            Services = new Repository<Service>(context);
            Promotion = new Repository<Promotion>(context);
        }

        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
