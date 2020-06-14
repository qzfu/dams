using DAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Models.DTO;

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

        /// <summary>
        /// 根据管理界面查询资源
        /// </summary>
        /// <param name="queryItem"></param>
        /// <returns></returns>
        List<ResourcesDTO> GetResourcesByQuery(ResourceQueryDTO queryItem);
    }
}
