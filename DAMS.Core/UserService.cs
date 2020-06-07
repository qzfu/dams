using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
