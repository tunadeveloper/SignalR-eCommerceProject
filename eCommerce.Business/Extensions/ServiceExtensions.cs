using eCommerce.Business.Abstracts;
using eCommerce.Business.Concretes;
using eCommerce.Business.Mappings;
using eCommerce.Business.SignalR;
using eCommerce.DataAccess.Concretes;
using eCommerce.DataAccess.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Business.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IPromotionService, PromotionManager>();
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<ISignalRHubService, SignalRHubService>();

            services.AddAutoMapper(typeof(CategoryProfile).Assembly);
        }
    }
}
