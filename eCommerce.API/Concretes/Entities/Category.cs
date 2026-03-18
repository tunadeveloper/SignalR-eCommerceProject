using eCommerce.API.Concretes.Entities.Common;

namespace eCommerce.API.Concretes.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
