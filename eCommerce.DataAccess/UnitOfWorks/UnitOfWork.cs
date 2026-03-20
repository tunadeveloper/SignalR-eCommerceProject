using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.Concretes;
using eCommerce.DataAccess.EntityFrameworks;
using eCommerce.DataAccess.Repositories;
using eCommerce.Entity.Entities;

namespace eCommerce.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceContext _context;

        public ICategory Categories { get; }
        public IContact Contacts { get; }
        public IMessage Messages { get; }
        public IProduct Products { get; }
        public IService Services { get; }
        public IPromotion Promotion { get; }
        public IOrder Orders { get; }
        public IOrderDetail OrderDetails { get; }
        public IPaymentTransaction PaymentTransactions { get; }
        public IShippingCompany ShippingCompanies { get; }

        public UnitOfWork(ECommerceContext context)
        {
            _context = context;

            Categories = new EfCategory(context);
            Contacts = new EfContact(context);
            Messages = new EfMessage(context);
            Products = new EfProduct(context);
            Services = new EfService(context);
            Promotion = new EfPromotion(context);
            Orders = new EfOrder(context);
            OrderDetails = new EfOrderDetail(context);
            PaymentTransactions = new EfPaymentTransaction(context);
            ShippingCompanies = new EfShippingCompany(context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        public async ValueTask DisposeAsync() => await _context.DisposeAsync();
    }
}
