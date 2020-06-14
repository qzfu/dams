using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Interface;
using DAMS.Models;

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
    }
}
