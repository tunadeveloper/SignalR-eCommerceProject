using eCommerce.Entity.Entities.Common;

namespace eCommerce.Entity.Entities
{
    public class Message:BaseEntity
    {
        public string MessageNameSurname { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
    }
}
