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
        DeviceRecords GetDeviceRecords(int myPID, int myVID);

        /// <summary>
        /// 根据管理界面查询资源
        /// </summary>
        /// <param name="queryItem"></param>
        /// <returns></returns>
        List<ResourcesDTO> GetResourcesByQuery(ResourceQueryDTO queryItem);
        /// <summary>
        /// 获取原磁盘文件列表
        /// </summary>
        /// <param name="vid"></param>
        /// <param name="pid"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        List<Resources> GetCurrentDiskResourceList(int vid, int pid, string serialNumber);
        /// <summary>
        /// 新增资源
        /// </summary>
        /// <param name="resources"></param>
        /// <param name="deviceInfo"></param>
        void AddResources(List<Resources> resources, string deviceInfo);
        /// <summary>
        /// 新增单个资源
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="deviceInfo"></param>
        void AddResource(Resources resource, string deviceInfo);

        /// <summary>
        /// 根据资源id删除数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteReoucrceByIds(List<int> ids);

        /// <summary>
        /// 修改文件复制状态
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        bool UpdateCopyStateResource(Resources res);

        /// <summary>
        /// 获取项目尺寸
        /// </summary>
        /// <returns></returns>
        Catagorys GetWinSize();

        /// <summary>
        /// 设置项目尺寸
        /// </summary>
        /// <returns></returns>
        bool SetWinSize(string itemValue, string itemText);

        /// <summary>
        /// 获取加载优盘个数
        /// </summary>
        /// <returns></returns>
        Catagorys GetIndexCount();
        /// <summary>
        /// 设置首页展示个数
        /// </summary>
        /// <returns></returns>
        bool SetIndexCount(string itemValue, string itemText);

        /// <summary>
        /// 测试mysql连接
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        bool TestMySqlConnect(string con);
    }
}
