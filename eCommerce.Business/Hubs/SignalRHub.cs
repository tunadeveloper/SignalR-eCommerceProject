using eCommerce.Business.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace eCommerce.Business.Hubs
{
    public class SignalRHub : Hub<ISignalRClient>
    {
        private readonly ISignalRHubService _hubService;

        public SignalRHub(ISignalRHubService hubService)
        {
            _hubService = hubService;
        }

        public override async Task OnConnectedAsync()
        {
            await _hubService.SendCountsAsync();
            await base.OnConnectedAsync();
        }
    }
}
