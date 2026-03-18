using eCommerce.Entity.Entities.Common;

namespace eCommerce.Entity.Entities
{
    public class Contact:BaseEntity
    {
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactAddress { get; set; }
        public string ContactWorkTime { get; set; }
        public string ContactMap { get; set; }
    }
}
