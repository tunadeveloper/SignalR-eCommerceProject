namespace eCommerce.Business.SignalR
{
    public interface ISignalRHubService
    {
        Task SendCountsAsync();
    }
}
