using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Common;
using DAMS.Interface;
using DAMS.Models;
using DAMS.Models.DTO;
using System.Data.Entity;
using MySql.Data.MySqlClient;

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
        public DeviceRecords GetDeviceRecords(int myPID, int myVID)
        {
            using (var db = new EFDbContext())
            {
                return db.DeviceRecords.FirstOrDefault(x => x.PID == myPID && x.VID == myVID);
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

        public List<Resources> GetCurrentDiskResourceList(string serialNumber)
        {
            using (var db = new EFDbContext())
            {
                return db.Resources.Where(x => x.DeviceInfo == serialNumber).ToList();
            }
        }
        public void AddResource(Resources resource, string deviceInfo)
        {
            using (var db = new EFDbContext())
            {
                resource.UserId = "Admin";
                resource.UserName = "管理员";
                resource.CreatedTime = DateTime.Now;
                resource.IsCopyEnd = 0;
                resource.DeviceInfo = deviceInfo;
                db.Resources.Add(resource);
                db.SaveChanges();
                return;
            }
        }
        public void AddResources(List<Resources> resources, string deviceInfo)
        {
            using (var db = new EFDbContext())
            {
                foreach (var resource in resources)
                {
                    resource.UserId = "Admin";
                    resource.UserName = "管理员";
                    resource.CreatedTime = DateTime.Now;
                    resource.IsCopyEnd = 0;
                    resource.DeviceInfo = deviceInfo;
                }
                db.Resources.AddRange(resources);
                db.SaveChanges();
                return;
            }
        }
        /// <summary>
        /// 根据资源id删除数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteReoucrceByIds(List<int> ids)
        {
            using (var db = new EFDbContext())
            {
                var rescources = db.Resources.Where(x => ids.Contains(x.ResourceId)).ToList();
                db.Resources.RemoveRange(rescources);
                db.SaveChanges();
            }
            return true;
        }

        /// <summary>
        /// 修改文件复制状态
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool UpdateCopyStateResource(Resources res)
        {
            using (var db = new EFDbContext())
            {
                var entity = db.Resources.FirstOrDefault(x => x.ResourceId == res.ResourceId);
                entity.IsCopyEnd = 1;
                db.Entry(entity).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取项目尺寸
        /// </summary>
        /// <returns></returns>
        public Catagorys GetWinSize()
        {
            using (var db = new EFDbContext())
            {
                return db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.Size);
            }
        }

        /// <summary>
        /// 设置项目尺寸
        /// </summary>
        /// <returns></returns>
        public bool SetWinSize(string itemValue, string itemText)
        {
            using (var db = new EFDbContext())
            {
                var data = db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.Size);
                if (data == null)
                {
                    db.Catagorys.Add(new Catagorys
                    {
                        Type = (int)EnumData.CatagoryType.Size,
                        ItemText = itemText,
                        ItemValue = itemValue,
                        Remark = "系统分辨率",
                        CreatedTime = DateTime.Now
                    });
                }
                else
                {
                    data.ItemText = itemText;
                    data.ItemValue = itemValue;
                }
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 获取加载优盘个数
        /// </summary>
        /// <returns></returns>
        public Catagorys GetIndexCount()
        {
            using (var db = new EFDbContext())
            {
                return db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.IndexCount);
            }
        }
        /// <summary>
        /// 设置首页展示个数
        /// </summary>
        /// <returns></returns>
        public bool SetIndexCount(string itemValue, string itemText)
        {
            using (var db = new EFDbContext())
            {
                var data = db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.IndexCount);
                if (data == null)
                {
                    db.Catagorys.Add(new Catagorys
                    {
                        Type = (int)EnumData.CatagoryType.IndexCount,
                        ItemText = itemText,
                        ItemValue = itemValue,
                        Remark = "加载U盘个数",
                        CreatedTime = DateTime.Now
                    });
                }
                else
                {
                    data.ItemText = itemText;
                    data.ItemValue = itemValue;
                }
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 测试mysql连接
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool TestMySqlConnect(string con)
        {
            try
            {
                MySqlConnection myCon = new MySqlConnection(con);

                myCon.Open();

                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 保存第一次登陆时间，和注册状态
        /// </summary>
        public void SetStartDate()
        {
            using (var db = new EFDbContext())
            {
                var data = db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.StartEnd);
                if (data == null)
                {
                    db.Catagorys.Add(new Catagorys
                    {
                        Type = (int)EnumData.CatagoryType.StartEnd,
                        ItemText = DateTime.Now.ToString("yyyy-MM-dd"),
                        ItemValue = DateTime.Now.ToString("yyyy-MM-dd"),
                        Remark = "",
                        CreatedTime = DateTime.Now
                    });
                    db.SaveChanges();
                }

                data = db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.Register);
                var registerCode = MD5Helper.GenerateMD5(RegistrationHelper.getRNum());
                if (data == null)
                {
                    db.Catagorys.Add(new Catagorys
                    {
                        Type = (int)EnumData.CatagoryType.Register,
                        ItemText = registerCode,
                        ItemValue = "0",
                        Remark = "",
                        CreatedTime = DateTime.Now
                    });
                    db.SaveChanges();
                }
                else
                {
                    if (data.ItemText == "0" || data.ItemText == "1")
                    {
                        data.ItemText = registerCode;
                        db.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// 注册成功保存记录
        /// </summary>
        /// <returns></returns>
        public bool SaveRegister(string code)
        {
            using (var db = new EFDbContext())
            {

                var data = db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.Register);
                if (data == null)
                {
                    var registerCode = MD5Helper.GenerateMD5(RegistrationHelper.getRNum());
                    db.Catagorys.Add(new Catagorys
                    {
                        Type = (int)EnumData.CatagoryType.Register,
                        ItemText = registerCode,
                        ItemValue = code,
                        Remark = "",
                        CreatedTime = DateTime.Now
                    });
                }
                else
                {
                    //data.ItemText = "1";
                    data.ItemValue = code;
                }
                try
                {

                    return db.SaveChanges() > 0;
                }
                catch (DbEntityValidationException ex)
                {

                    throw ex;
                }
            }
        }

        /// <summary>
        /// 校验是否登陆成功
        /// </summary>
        /// <returns></returns>
        public bool CheckRegistered()
        {
            using (var db = new EFDbContext())
            {

                var data = db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.Register);
                if (data == null)
                {
                    var registerCode = MD5Helper.GenerateMD5(RegistrationHelper.getRNum());
                    db.Catagorys.Add(new Catagorys
                    {
                        Type = (int)EnumData.CatagoryType.Register,
                        ItemText = registerCode,
                        ItemValue = "0",
                        Remark = "",
                        CreatedTime = DateTime.Now
                    });

                    db.SaveChanges();
                    return false;
                }
                else
                {
                    if (MD5Helper.GenerateMD5(data.ItemValue) != data.ItemText)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
        }

        /// <summary>
        /// 校验是否当前使用是否有效（未过试用期或注册过）
        /// </summary>
        /// <returns></returns>
        public bool CheckEffective()
        {
            using (var db = new EFDbContext())
            {
                var data = db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.Register);
                if (data == null)
                {
                    var registerCode = MD5Helper.GenerateMD5(RegistrationHelper.getRNum());
                    db.Catagorys.Add(new Catagorys
                    {
                        Type = (int)EnumData.CatagoryType.Register,
                        ItemText = registerCode,
                        ItemValue = "0",
                        Remark = "",
                        CreatedTime = DateTime.Now
                    });
                    db.SaveChanges();
                    return false;
                }
                else
                {
                    if (MD5Helper.GenerateMD5(data.ItemValue) == data.ItemText && RegistrationHelper.getRNum() == data.ItemValue) return true;

                    var date = db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.StartEnd);

                    if (date == null)
                    {
                        db.Catagorys.Add(new Catagorys
                        {
                            Type = (int)EnumData.CatagoryType.StartEnd,
                            ItemText = DateTime.Now.ToString("yyyy-MM-dd"),
                            ItemValue = DateTime.Now.ToString("yyyy-MM-dd"),
                            Remark = "",
                            CreatedTime = DateTime.Now
                        });
                        db.SaveChanges();
                        return false;
                    }
                    else
                    {
                        var startDate = DateTime.Now.AddMonths(-1);
                        DateTime.TryParse(date.ItemValue, out startDate);

                        TimeSpan sp = DateTime.Today.Subtract(startDate);
                        if (sp.Days >= 1)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }


                }
            }
        }

        /// <summary>
        /// 获取剩余天数
        /// </summary>
        /// <returns></returns>
        public int GetRemainDays()
        {
            using (var db = new EFDbContext())
            {
                if (CheckEffective())
                {
                    var cfg = db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.StartEnd);
                    var startDate = Convert.ToDateTime(cfg.ItemValue);

                    var span = DateTime.Today.Subtract(startDate);

                    return 1 - span.Days;
                }
                return 0;
            }

        }

        /// <summary>
        /// 保存文件下载路径
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool SaveDownLoadUrl(string url)
        {

            using (var db = new EFDbContext())
            {
                var date = db.Catagorys.FirstOrDefault(x => x.Type == (int)EnumData.CatagoryType.DownLoadUrl);

                if (date == null)
                {
                    db.Catagorys.Add(new Catagorys
                    {
                        Type = (int) EnumData.CatagoryType.DownLoadUrl,
                        ItemText = url,
                        ItemValue = url,
                        Remark = "",
                        CreatedTime = DateTime.Now
                    });
                    db.SaveChanges();
                    return false;
                }
                else
                {
                    date.ItemText = url;
                    date.ItemValue = url;
                }
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 保存文件下载路径
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetDownLoadUrl()
        {
            using (var db = new EFDbContext())
            {
                var data = db.Catagorys.FirstOrDefault(x => x.Type == (int) EnumData.CatagoryType.DownLoadUrl);
                if (data == null)
                    return string.Empty;

                return data.ItemValue;
            }
        }

    }
}
