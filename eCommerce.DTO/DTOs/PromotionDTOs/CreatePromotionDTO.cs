using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DTO.DTOs.PromotionDTOs
{
    public class CreatePromotionDTO
    {
        public string PromotionTitle { get; set; }
        public string PromotionSubtitle { get; set; }
        public string PromotionDescription { get; set; }
        public string PromotionImage { get; set; }
    }
}
