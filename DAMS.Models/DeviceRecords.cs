using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Models
{
    public class DeviceRecords
    {
        public int Id { get; set; }
        public int PID { get; set; }
        public int VID { get; set; }
        public string SerialNumber { get; set; }
        public string readBuffer { get; set; }
        public int IsCopyEnd { get; set; }
    }
}
