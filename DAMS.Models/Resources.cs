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
    [Table("Resources")]
    public class Resources
    {
        [Key]
        public int ResourceId { get; set; }
        public int ResourceType { get; set; }
        [MaxLength(20)]
        public string UserId { get; set; }
        [MaxLength(50)]
        public string EquipmentNo { get; set; }
        [MaxLength(20)]
        public string UserName { get; set; }
        public int DepartId { get; set; }
        public DateTime? UploadTime { get; set; }
        [MaxLength(200)]
        public string FilePath { get; set; }
        [MaxLength(200)]
        public string FileName { get; set; }
        [MaxLength(300)]
        public string Alias { get; set; }
        [MaxLength(20)]
        public string Extension { get; set; }
    }
}
