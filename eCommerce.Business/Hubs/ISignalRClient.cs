namespace eCommerce.Business.Hubs
{
    public interface ISignalRClient
    {
        Task CategoryCount(int count);
        Task ProductCount(int count);
        Task MessageCount(int count);
        Task ContactCount(int count);
        Task PromotionCount(int count);
        Task ServiceCount(int count);
    }
}
