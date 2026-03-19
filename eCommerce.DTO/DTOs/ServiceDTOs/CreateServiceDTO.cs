using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DTO.DTOs.ServiceDTOs
{
    public class CreateServiceDTO
    {
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceIcon { get; set; }
    }
}
