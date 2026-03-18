using eCommerce.Entity.Entities.Common;

namespace eCommerce.Entity.Entities
{
    public class Service:BaseEntity
    {
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceIcon { get; set; }
    }
}
