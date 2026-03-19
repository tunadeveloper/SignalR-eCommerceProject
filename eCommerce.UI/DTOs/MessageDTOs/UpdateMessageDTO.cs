using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.UI.DTOs.MessageDTOs
{
    public class UpdateMessageDTO
    {
        public int Id { get; set; }
        public string MessageNameSurname { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
    }
}
