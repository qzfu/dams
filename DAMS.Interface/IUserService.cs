using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Models;
using DAMS.Models.DTO;

namespace DAMS.Interface
{
    public interface IUserService
    {
        List<Users> GetUsers();

        Users GetUserByUserId(string userId,string password);

        bool SaveUserByUserId(Users user);
        List<Roles> GetAllRolese();
        bool SaveChangePassword(string userId, string newPassWord);
    }
}
