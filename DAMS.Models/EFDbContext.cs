using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using MySql.Data.Entity;

namespace DAMS.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class EFDbContext : DbContext, IDisposable
    {
        public EFDbContext()
            : base("name=EFDbContext")
        {
        }
        public DbSet<Catagorys> Catagorys { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Equipments> Equipments { get; set; }
        public DbSet<RecorderSettings> RecorderSettings { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //指定单数形式的表名
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
