using DAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Interface
{
    public interface IResourceService
    {
        List<Resources> GetResources();
        /// <summary>
        /// 获取U盘信息
        /// </summary>
        /// <returns></returns>
        DeviceRecords GetDeviceRecords(string myPID, string myVID);
    }
}
