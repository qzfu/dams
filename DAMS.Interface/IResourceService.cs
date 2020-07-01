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
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        List<Resources> GetCurrentDiskResourceList(string serialNumber);
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

        /// <summary>
        /// 保存第一次登陆时间，和注册状态
        /// </summary>
        void SetStartDate();

        /// <summary>
        /// 注册成功保存记录
        /// </summary>
        /// <returns></returns>
        bool SaveRegister(string code);

        /// <summary>
        /// 校验是否登陆成功
        /// </summary>
        /// <returns></returns>
        bool CheckRegistered();

        /// <summary>
        /// 校验是否当前使用是否有效（未过试用期或注册过）
        /// </summary>
        /// <returns></returns>
        bool CheckEffective();

        /// <summary>
        /// 获取剩余天数
        /// </summary>
        /// <returns></returns>
        int GetRemainDays();
    }
}
