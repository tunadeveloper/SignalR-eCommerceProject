using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.UI.DTOs.PromotionDTOs
{
    public class UpdatePromotionDTO
    {
        public int Id { get; set; }
        public string PromotionTitle { get; set; }
        public string PromotionSubtitle { get; set; }
        public string PromotionDescription { get; set; }
        public string PromotionImage { get; set; }
    }
}
