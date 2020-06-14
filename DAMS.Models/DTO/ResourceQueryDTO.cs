using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Models.DTO
{
    public class ResourceQueryDTO
    {
        public List<string> ResourceTypes { get; set; }
        public string DateType { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string EquipmentNo { get; set; }
    }
}
