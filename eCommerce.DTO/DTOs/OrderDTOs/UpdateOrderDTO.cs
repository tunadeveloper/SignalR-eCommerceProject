namespace eCommerce.DTO.DTOs.OrderDTOs
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public string TrackingNumber { get; set; }
    }
}

