using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Models;

namespace DAMS.Interface
{
    public interface IUserService
    {
        List<Users> GetUsers();

        Users GetUserByUserId(string userId,string password);
    }
}
