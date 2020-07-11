using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using DAMS.Interface;
using DAMS.Models;

namespace DAMS.Core
{
    public class EquipmentService : IEquipmentService
    {
        /// <summary>
        /// 同步资源时，往此表中插入设备编号
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public bool IfNoExistAndSaveEquipmentNo(string no)
        {
            using (var db = new EFDbContext())
            {
                if (!db.Equipments.Any(x => x.EquipmentNo == no))
                {
                    db.Equipments.Add(new Equipments
                    {
                        EquipmentNo = no,
                        UserId = 0,
                        Name = string.Empty,
                        Remark = string.Empty,
                        CreatedTime = DateTime.Now
                    });
                    return db.SaveChanges() > 0;
                }
                return true;
            }
        }

        /// <summary>
        /// 设备人员关系维护
        /// </summary>
        /// <param name="no"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool SaveUserName(string no, string name)
        {
            using (var db = new EFDbContext())
            {
                var data = db.Equipments.FirstOrDefault(x => x.EquipmentNo == no);
                if (data != null)
                {
                    data.Name = name;
                }
                else
                {
                    db.Equipments.Add(new Equipments
                    {
                        EquipmentNo = no,
                        UserId = 0,
                        Name = name,
                        Remark = string.Empty,
                        CreatedTime = DateTime.Now
                    });
                }
                return db.SaveChanges() > 0;
            }
        }

        public bool SaveUserNames(List<Equipments> list)
        {
            foreach (var item in list)
            {
                this.SaveUserName(item.EquipmentNo, item.Name);
            }
            return true;
        }

        /// <summary>
        /// 获取设备人员关系列表
        /// </summary>
        /// <returns></returns>
        public List<Equipments> GetEquipments()
        {
            using (var db = new EFDbContext())
            {
                return db.Equipments.ToList();
            }
        }
    }
}
