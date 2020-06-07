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
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        [MaxLength(20)]
        public string RoleName { get; set; }
        public int Level { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
