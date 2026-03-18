using eCommerce.API.Concretes.Entities.Common;

namespace eCommerce.API.Concretes.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public List<string> ProductImage { get; set; }
        public float ProductOldPrice { get; set; }
        public float ProductNewPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCode { get; set; }
        public bool IsStock { get; set; }
        public bool IsFeatured { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
