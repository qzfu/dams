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
        public int PID { get; set; }
        public int VID { get; set; }
        [MaxLength(50)]
        public string SerialNumber { get; set; }
        public int IsCopyEnd { get; set; }
    }
}
