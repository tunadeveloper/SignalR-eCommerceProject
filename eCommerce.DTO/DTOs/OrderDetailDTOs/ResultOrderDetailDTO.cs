namespace eCommerce.DTO.DTOs.OrderDetailDTOs
{
    public class ResultOrderDetailDTO
    {
        public string Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string OrderNumber { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

