using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.UI.DTOs.ProductDTOs
{
    public class CreateProductDTO
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
    }
}
