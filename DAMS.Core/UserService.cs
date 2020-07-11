using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using DAMS.Interface;
using DAMS.Models;

namespace DAMS.Core
{
    public class UserService : IUserService
    {
        public List<Users> GetUsers()
        {
            using (var db = new EFDbContext())
            {
                return db.Users.Where(u => u.Enabled).ToList();
            }
        }
        public Users GetUserByUserId(string userId, string password)
        {
            using (var db = new EFDbContext())
            {
                return db.Users.FirstOrDefault(u => u.Enabled && u.UserId == userId && u.Password == password);
            }
        }

        public bool SaveUserByUserId(Users user)
        {
            using (var db = new EFDbContext())
            {
                var data = db.Users.FirstOrDefault(u => u.Enabled && u.UserId == user.UserId);
                if (data == null) return false;

                data.RoleId = user.RoleId;
                data.UserName = user.UserName;
                data.Gender = user.Gender;

                return db.SaveChanges() > 0;
            }
        }

        public List<Roles> GetAllRolese()
        {
            using (var db = new EFDbContext())
            {
                return db.Roles.ToList();
            }
        }

        public bool SaveChangePassword(string userId, string newPassWord)
        {
            using (var db = new EFDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Enabled && u.UserId == userId);
                if (user == null) return false;

                user.Password = newPassWord;

                return db.SaveChanges() > 0;
            }
        }
    }
}
