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
    [Table("Catagorys")]
    public class Catagorys
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        [MaxLength(100)]
        public string ItemValue { get; set; }
        [MaxLength(200)]
        public string ItemText { get; set; }
        [MaxLength(2000)]
        public string Remark { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
