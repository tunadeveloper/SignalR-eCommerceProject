namespace eCommerce.UI.DTOs.OrderDTOs
{
    public class CreateOrderDTO
    {
        public string CustomerName { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public int ShippingCompanyId { get; set; }
    }
}
