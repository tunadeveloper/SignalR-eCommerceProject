using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.UI.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
