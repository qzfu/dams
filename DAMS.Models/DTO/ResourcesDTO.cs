using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Models.DTO
{
    public class ResourcesDTO
    {
        public string ResourceName { get; set; }
        public int ResourceId { get; set; }
        public int ResourceType { get; set; }
        public string UserId { get; set; }
        public string EquipmentNo { get; set; }
        public string UserName { get; set; }
        public int DepartId { get; set; }
        public DateTime? UploadTime { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string Alias { get; set; }
        public string Extension { get; set; }
        /// <summary>
        /// VID.PID.SerialNumber
        /// </summary>
        public string DeviceInfo { get; set; }
    }
}
