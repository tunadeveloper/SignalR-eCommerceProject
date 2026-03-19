using eCommerce.Business.Hubs;
using eCommerce.DataAccess.UnitOfWorks;
using Microsoft.AspNetCore.SignalR;

namespace eCommerce.Business.SignalR
{
    public class SignalRHubService : ISignalRHubService
    {
        private readonly IHubContext<SignalRHub, ISignalRClient> _hubContext;
        private readonly IUnitOfWork _uow;

        public SignalRHubService(IHubContext<SignalRHub, ISignalRClient> hubContext, IUnitOfWork uow)
        {
            _hubContext = hubContext;
            _uow = uow;
        }

        public async Task SendCountsAsync()
        {
            await _hubContext.Clients.All.CategoryCount(await _uow.Categories.GetCountAsync());
            await _hubContext.Clients.All.ProductCount(await _uow.Products.GetCountAsync());
            await _hubContext.Clients.All.MessageCount(await _uow.Messages.GetCountAsync());
            await _hubContext.Clients.All.ContactCount(await _uow.Contacts.GetCountAsync());
            await _hubContext.Clients.All.PromotionCount(await _uow.Promotion.GetCountAsync());
            await _hubContext.Clients.All.ServiceCount(await _uow.Services.GetCountAsync());
        }
    }
}
