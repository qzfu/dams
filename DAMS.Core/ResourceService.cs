using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Common;
using DAMS.Interface;
using DAMS.Models;
using DAMS.Models.DTO;

namespace DAMS.Core
{
    public class ResourceService : IResourceService
    {
        public List<Resources> GetResources()
        {
            using (var db = new EFDbContext())
            {
                return db.Resources.ToList();
            }
        }
        /// <summary>
        /// 获取中断U盘信息
        /// IsCopyEnd：1已完成，0中断
        /// </summary>
        /// <returns></returns>
        public DeviceRecords GetDeviceRecords(string myPID, string myVID)
        {
            using (var db = new EFDbContext())
            {
                return db.DeviceRecords.FirstOrDefault(x => x.IsCopyEnd == 0 && x.PID == myPID && x.VID == myVID);
            }
        }

        /// <summary>
        /// 根据管理界面查询资源
        /// </summary>
        /// <param name="queryItem"></param>
        /// <returns></returns>
        public List<ResourcesDTO> GetResourcesByQuery(ResourceQueryDTO queryItem)
        {
            using (var db = new EFDbContext())
            {
                var list = db.Resources.Where(x => 1 == 1);
                if (queryItem.ResourceTypes != null && queryItem.ResourceTypes.Count > 0)
                {
                    var resourceTypes = new List<int>();
                    queryItem.ResourceTypes.ForEach(x =>
                    {
                        resourceTypes.Add(EnumHelper.GetByDescription<DAMS.Common.EnumData.ResourceType>(x).Value);
                    });

                    list = list.Where(x => resourceTypes.Contains(x.ResourceType));
                }
                if (queryItem.DateType == "拍摄时间")
                {
                    if (queryItem.BeginDate != null)
                    {
                        list = list.Where(x => x.UploadTime >= queryItem.BeginDate);
                    }
                    if (queryItem.EndDate != null)
                    {
                        var endDate = queryItem.EndDate.AddDays(1);
                        list = list.Where(x => x.UploadTime < endDate);
                    }
                }
                else if (queryItem.DateType == "上传时间")
                {
                    if (queryItem.BeginDate != null)
                    {
                        list = list.Where(x => x.UploadTime >= queryItem.BeginDate);
                    }
                    if (queryItem.EndDate != null)
                    {
                        var endDate = queryItem.EndDate.AddDays(1);
                        list = list.Where(x => x.UploadTime < endDate);
                    }
                }

                if (!string.IsNullOrEmpty(queryItem.UserId))
                {
                    list = list.Where(x => x.UserId.Contains(queryItem.UserId));
                }
                if (!string.IsNullOrEmpty(queryItem.UserName))
                {
                    list = list.Where(x => x.UserName.Contains(queryItem.UserName));
                }
                if (!string.IsNullOrEmpty(queryItem.EquipmentNo))
                {
                    list = list.Where(x => x.EquipmentNo.Contains(queryItem.EquipmentNo));
                }

                var data = list.ToList();
                var result = new List<ResourcesDTO>();

                foreach (var temp in data)
                {
                    result.Add(new ResourcesDTO
                    {
                        ResourceName = EnumHelper.GetByValue<DAMS.Common.EnumData.ResourceType>(temp.ResourceType).Description,
                        ResourceId = temp.ResourceId,
                        ResourceType = temp.ResourceType,
                        UserId = temp.UserId,
                        EquipmentNo = temp.EquipmentNo,
                        UserName = temp.UserName,
                        DepartId = temp.DepartId,
                        UploadTime = temp.UploadTime,
                        FilePath = temp.FilePath,
                        FileName = temp.FileName,
                        Alias = temp.Alias,
                        Extension = temp.Extension
                    });
                }
                return result;
            }
        }
    }
}
