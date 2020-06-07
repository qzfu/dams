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
    [Table("RecorderSettings")]
    public class RecorderSettings
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Resolution { get; set; }
        [MaxLength(10)]
        public string RunningType { get; set; }
        public bool AutoUplodFile { get; set; }
        public bool IsDelRecorder { get; set; }
        public bool IsSetPort { get; set; }
        public int RquipmentNum { get; set; }
        public int ColNum { get; set; }
        public int RawNum { get; set; }
        [MaxLength(50)]
        public string LocalNetwork { get; set; }
        [MaxLength(50)]
        public string NetworkAddress { get; set; }
        [MaxLength(50)]
        public string FtpAddress { get; set; }
        [MaxLength(20)]
        public string FtpPort { get; set; }
        [MaxLength(20)]
        public string FtpId { get; set; }
        [MaxLength(50)]
        public string FtpPassword { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
