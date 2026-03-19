using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.UI.DTOs.ServiceDTOs
{
    public class UpdateServiceDTO
    {
        public int Id { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceIcon { get; set; }
    }
}
