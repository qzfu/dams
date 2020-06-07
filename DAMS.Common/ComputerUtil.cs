using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Common
{
    public class ComputerUtil
    {
        public static string GetComputerIp()
        {
            try
            {
                //获取本机IP并显示
                var hostIP = System.Net.Dns.GetHostEntry(Environment.MachineName);
                return hostIP.AddressList[0].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
