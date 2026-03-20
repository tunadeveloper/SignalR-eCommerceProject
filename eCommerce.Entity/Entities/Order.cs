using eCommerce.Entity.Entities.Common;

namespace eCommerce.Entity.Entities
{
    public class Order:BaseEntity
    {
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }

        public int ShippingCompanyId { get; set; }
        public ShippingCompany ShippingCompany { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
