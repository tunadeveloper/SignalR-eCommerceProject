using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DTO.DTOs.CategoryDTOs
{
    public class ResultCategoryDTO
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
