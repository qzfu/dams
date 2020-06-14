using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAMS.Models
{
    public class DeviceRecords
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string PID { get; set; }
        [MaxLength(50)]
        public string VID { get; set; }
        [MaxLength(50)]
        public string SerialNumber { get; set; }
        public string readBuffer { get; set; }
        public int IsCopyEnd { get; set; }
    }
}
