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

    }
}
