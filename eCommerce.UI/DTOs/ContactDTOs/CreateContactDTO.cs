using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.UI.DTOs.ContactDTOs
{
    public class CreateContactDTO
    {
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactAddress { get; set; }
        public string ContactWorkTime { get; set; }
        public string ContactMap { get; set; }
    }
}
