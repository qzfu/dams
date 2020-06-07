using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAMS.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string UserId { get; set; }
        public string Password { get; set; }
        [MaxLength(500)]
        public string ImageUrl { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public int DeptId { get; set; }
        public int Gender { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedTime { get; set; }
        [MaxLength(50)]
        public string ComputerIp { get; set; }
    }
}
