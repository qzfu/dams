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
    [Table("Departments")]
    public class Departments
    {
        [Key]
        public int DeptId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int ParentId { get; set; }
        [MaxLength(2000)]
        public string Remark { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
