using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;
using Microsoft.Extensions.Logging;

namespace eCommerce.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICategory Categories { get; }
        IContact Contacts { get; }
        IMessage Messages { get; }
        IProduct Products { get; }
        IService Services { get; }
        IPromotion Promotion { get; }
        IOrder Orders { get; }
        IOrderDetail OrderDetails { get; }

        Task<int> SaveAsync();
    }
}
