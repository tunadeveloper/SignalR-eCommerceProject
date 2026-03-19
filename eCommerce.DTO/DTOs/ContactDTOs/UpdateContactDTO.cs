using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DTO.DTOs.ContactDTOs
{
    public class UpdateContactDTO
    {
        public int Id { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactAddress { get; set; }
        public string ContactWorkTime { get; set; }
        public string ContactMap { get; set; }
    }
}
