using eCommerce.Entity.Entities.Common;

namespace eCommerce.Entity.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
