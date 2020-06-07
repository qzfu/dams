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
    [Table("Equipments")]
    public class Equipments
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string EquipmentNo { get; set; }
        public int UserId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(2000)]
        public string Remark { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
