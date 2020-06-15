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
        [MaxLength(500)]
        public string FilePath { get; set; }
        [MaxLength(600)]
        public string FileName { get; set; }
        [MaxLength(300)]
        public string Alias { get; set; }
        [MaxLength(20)]
        public string Extension { get; set; }
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 是否中断续传，0：中断，1：复制完成
        /// </summary>
        public int IsCopyEnd { get; set; }
        /// <summary>
        /// VID.PID.SerialNumber
        /// </summary>
        public string DeviceInfo { get; set; }
    }
}
