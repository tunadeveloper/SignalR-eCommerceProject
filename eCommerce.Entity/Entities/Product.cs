using eCommerce.Entity.Entities.Common;

namespace eCommerce.Entity.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public List<string> ProductImage { get; set; }
        public float ProductOldPrice { get; set; }
        public float ProductNewPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCode { get; set; }
        public bool ProductIsStock { get; set; }
        public bool ProductIsFeatured { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
