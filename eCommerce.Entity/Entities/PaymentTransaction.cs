using eCommerce.Entity.Entities.Common;

namespace eCommerce.Entity.Entities
{
    public class PaymentTransaction : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string PaymentMethod { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
