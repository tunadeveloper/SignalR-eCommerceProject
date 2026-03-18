using eCommerce.Entity.Entities.Common;

namespace eCommerce.Entity.Entities
{
    public class Promotion:BaseEntity
    {
        public string PromotionTitle { get; set; }
        public string PromotionSubtitle { get; set; }
        public string PromotionDescription { get; set; }
        public string PromotionImage { get; set; }
    }
}
