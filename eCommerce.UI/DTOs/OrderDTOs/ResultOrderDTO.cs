namespace eCommerce.UI.DTOs.OrderDTOs
{
    public class ResultOrderDTO
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public int ShippingCompanyId { get; set; }
        public string ShippingCompanyName { get; set; }
    }
}
