using eCommerce.Entity.Entities.Common;

namespace eCommerce.Entity.Entities
{
    public class ShippingCompany : BaseEntity
    {
        public string CompanyName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
