using DAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.UI.Common
{
    public class LoginUser
    {
        /// <summary>
        /// 当前用户登录ID
        /// </summary>
        public static string loginID = "";

        /// <summary>
        /// 当前用户
        /// </summary>
        public static Users CurrentUser = new Users();
    }
}
