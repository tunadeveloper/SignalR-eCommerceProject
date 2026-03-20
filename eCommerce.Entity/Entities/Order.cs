using eCommerce.Entity.Entities.Common;

namespace eCommerce.Entity.Entities
{
    public class Order:BaseEntity
    {
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public string TrackingNumber { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
