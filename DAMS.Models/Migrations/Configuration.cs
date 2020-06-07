using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAMS.Models.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DAMS.Models.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());//设置Sql生成器为Mysql的
        }

        protected override void Seed(DAMS.Models.EFDbContext context)
        {
            var users = new List<Users>
            {
                new Users{Id=1,UserId="admin", DeptId=0, Enabled=true, Gender = 0, 
                    UserName="admin",Password="21218CCA77804D2BA1922C33E0151105",
                    RoleId=1,CreatedTime=DateTime.Now}
            };
            DbSet<Users> userSet = context.Set<Users>();
            userSet.AddOrUpdate(m => new { m.UserId }, users.ToArray());
            context.SaveChanges();

            var roles = new List<Roles>
            {
                new Roles{ RoleId=1, RoleName="管理员",CreatedTime=DateTime.Now, IsAdmin=true}
            };
            DbSet<Roles> roleSet = context.Set<Roles>();
            roleSet.AddOrUpdate(m => new { m.RoleId }, roles.ToArray());
            context.SaveChanges();
        }
    }
}
