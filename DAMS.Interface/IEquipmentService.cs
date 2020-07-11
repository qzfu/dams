using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Models;

namespace DAMS.Interface
{
    public interface IEquipmentService
    {
        /// <summary>
        /// 同步资源时，往此表中插入设备编号
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        bool IfNoExistAndSaveEquipmentNo(string no);

        /// <summary>
        /// 设备人员关系维护
        /// </summary>
        /// <param name="no"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        bool SaveUserName(string no, string name);

        bool SaveUserNames(List<Equipments> list);
        /// <summary>
        /// 获取设备人员关系列表
        /// </summary>
        /// <returns></returns>
        List<Equipments> GetEquipments();
    }
}
