using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;
using Microsoft.Extensions.Logging;

namespace eCommerce.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Contact> Contacts { get; }
        IRepository<Message> Messages { get; }
        IRepository<Product> Products { get; }
        IRepository<Service> Services { get; }
        IRepository<Promotion> Promotion { get; }

        Task<int> SaveAsync();
    }
}
