namespace eCommerce.UI.DTOs.OrderDTOs
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public int ShippingCompanyId { get; set; }
    }
}
