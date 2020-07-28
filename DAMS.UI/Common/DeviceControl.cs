using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using LibUsbDotNet.DeviceNotify;
using DAMS.Common;
using DAMS.Models;
using DAMS.Interface;
using DAMS.Core.ClassFactory;
using DAMS.Models.DTO;

namespace DAMS.UI.Common
{
    public class DeviceControl
    {
        private IResourceService deviceService = Assembler<IResourceService>.Create();
        private ICategoryService categoryService = Assembler<ICategoryService>.Create();
        private IEquipmentService equipmentService = Assembler<IEquipmentService>.Create();
        delegate void DeviceNotifyDelegate();

        private int flushReadLength;
        private string desRoot; 
        //总文件数量
        private double totalLength;
        private double currentProgress;
        private string deviceInfo;
        private int percent;
        private bool progressAbort = false;
        private List<Catagorys> categorys;
        
        public delegate void UpdateProgress(string deviceInfo,int precent);
        public UpdateProgress SetProgressDelegate;

        public DeviceControl()
        {
            desRoot = CommonHelper.GetAppSettings("desdirectory");
            var setRoot = deviceService.GetDownLoadUrl();
            //获取配置路径
            if (!string.IsNullOrEmpty(setRoot))
                desRoot = setRoot;

            flushReadLength =  Convert.ToInt32(CommonHelper.GetAppSettings("FlushReadLength"));
            totalLength = 0d;
            currentProgress = 0d;
            percent = 0;
            categorys = categoryService.GetCategorysByType((int)EnumData.CatagoryType.FileType);
        }
        /// <summary>
        /// 校验盘符信息
        /// </summary>
        /// <param name="root">U盘根目录</param>
        /// <param name="vid">Vid</param>
        /// <param name="pid">Pid</param>
        /// <param name="serialNumber">serialNumber</param>
        /// <returns>0新增盘符，1中断续传，-1不同磁盘</returns>
        public int CheckDeviceToken(string root, string serialNumber)
        {
            string xmlPath = root + "deviceToken.xml";
            if (!File.Exists(xmlPath))
            {
                XmlDocument doc = new XmlDocument();
                //获取根节点对象
                XDocument document = new XDocument();
                XElement node = new XElement("token");
                node.SetElementValue("serialNumber", serialNumber);
                node.Save(xmlPath);
                return 0;
            }
            else
            {
                try
                {
                    XDocument doc = XDocument.Load(xmlPath);
                    XElement nodeRoot = doc.Root;
                    IEnumerable<XElement> nodes = nodeRoot.Elements();
                    var nodeSerialNumber = nodes.FirstOrDefault(x => x.Name == "serialNumber").Value;
                    if (nodeSerialNumber == serialNumber)
                    {
                        return 1;
                    }
                    return -1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public void CopyFilesTo(DirectoryInfo sourceDirectory, string serialNumber)
        {
            //若目标目录不存在，提示请先修改
            try
            {
                if (!Directory.Exists(desRoot))
                {
                    Directory.CreateDirectory(desRoot);
                }
            }
            catch
            {
                MessageUtil.ShowMessage("存储目录创建失败，请先修改！", EnumData.MessageType.Warning);
                return;
            }
            //创建目标根目录
            CommonHelper.CreateDirectoryIfNotExist(desRoot);
            //以U盘serialNumber创建目标文件夹
            deviceInfo = serialNumber;
            var filePath = desRoot + @"\" + deviceInfo;
            CommonHelper.CreateDirectoryIfNotExist(filePath);
            //获取目标文件夹中已存在的文件列表
            List<Resources> currResources = deviceService.GetCurrentDiskResourceList(serialNumber);
            var dicPath = new List<FileTransactionDTO>();
            var resources = new List<Resources>();
            CopyTo(sourceDirectory, filePath, currResources, deviceInfo, ref dicPath);
            //异步线程更新文件采集进度
            Action proressAction = UpdateProgressAction;
            proressAction.BeginInvoke(null, null);
            try
            {
                foreach (var item in dicPath)
                {
                    var fromFile = item.FromPath;
                    var toFile = item.ToPath;
                    var resModel = item.Resource;

                    //执行Copy文件中断续传
                    CopyFile(fromFile, toFile, flushReadLength);
                    //更新当前资源采集状态为已完成
                    deviceService.UpdateCopyStateResource(resModel);
                }
            }
            catch
            {
                progressAbort = true;
            }
        }

        private void CopyTo(DirectoryInfo sourceDirectory, string filePath, List<Resources> currResources, string deviceInfo, ref List<FileTransactionDTO> dicPath)
        {
            //复制文件夹下面的文件
            FileInfo[] fileArray = sourceDirectory.GetFiles();
            foreach (FileInfo file in fileArray)
            {
                if (file.Name == "deviceToken.xml")
                {
                    continue;
                }

                //获取文件大小
                totalLength += (double)file.Length / 1024d / 1024d;

                var uploadTime = file.CreationTime;
                var year = uploadTime.Year.ToString();
                var month = uploadTime.Month.ToString();
                var day = uploadTime.Day.ToString();
                var itemFilePath = filePath + @"\" + year + @"\" + month + @"\" + day;
                CommonHelper.CreateDirectoryIfNotExist(itemFilePath);
                var itemFileFullName = itemFilePath + @"\" + file.Name;
                var resModel = currResources.FirstOrDefault(x => String.Compare(x.FileName, itemFileFullName) == 0);
                //文件已经存在且已经Copy完毕跳过本层循环
                if (resModel != null && resModel.IsCopyEnd == 1)
                {
                    currentProgress += (double)file.Length / 1024d / 1024d;
                    continue;
                }
                if (resModel == null)
                {
                    var tempCategory = categorys.FirstOrDefault(x => x.ItemText.IndexOf(file.Extension.ToLower()) > -1);
                    var fileType = tempCategory != null ? Convert.ToInt32(tempCategory.ItemValue) : (int)EnumData.ResourceType.World;

                    resModel = new Resources()
                    {
                        Extension = file.Extension,
                        ResourceType = fileType,
                        Alias = file.Name,
                        FilePath = filePath,
                        FileName = itemFileFullName,
                        UploadTime = file.CreationTime,
                        IsCopyEnd = 0
                    };
                    deviceService.AddResource(resModel, deviceInfo);
                    equipmentService.IfNoExistAndSaveEquipmentNo(deviceInfo);
                }
                //源文件文件地址名称
                var fromFile = file.FullName;
                dicPath.Add(new FileTransactionDTO() {
                    FromPath = fromFile,
                    ToPath = itemFileFullName,
                    Resource = resModel
                });
            }
            //复制文件夹下面的子文件夹
            DirectoryInfo[] dirArray = sourceDirectory.GetDirectories();
            foreach (DirectoryInfo dir in dirArray)
            {
                var dirPath = dir.Name;
                if (dirPath.ToLower() == "system volume information")
                {
                    continue;
                }

                CopyTo(dir, filePath, currResources, deviceInfo, ref dicPath);
            }
        }

        /// <summary>
        /// 中断续传
        /// </summary>
        /// <param name="fromPath">源文件的路径</param>
        /// <param name="toPath">文件保存的路径</param>
        /// <param name="eachReadLength">每次读取的长度</param>
        /// <returns>是否复制成功</returns>
        private void CopyFile(string fromPath, string toPath, int eachReadLength)
        {
            //校验是否已经存在的文件
            long startPosition = 0;
            //已追加的方式写入文件流
            FileStream toFile;
            //读取中原文件终点位置长度
            if (File.Exists(toPath))
            {
                toFile = File.OpenWrite(toPath);
                startPosition = toFile.Length;
                currentProgress += (double)startPosition / 1024d / 1024d;
            }
            else
            {
                //如不存在目标文件则新建
                toFile = new FileStream(toPath, FileMode.Append, FileAccess.Write);
            }

            //将源文件读取成文件流
            FileStream fromFile = new FileStream(fromPath, FileMode.Open, FileAccess.Read);

            //实际读取的文件长度
            long toCopyLength = 0;
            //如果每次读取的长度小于 源文件的长度 分段读取
            long totalFileLength = fromFile.Length - startPosition;
            //调整源文件读取针位置
            fromFile.Seek(startPosition, SeekOrigin.Current);
            try
            {
                if (eachReadLength < totalFileLength)
                {
                    byte[] buffer = new byte[eachReadLength];
                    long copied = 0;
                    while (copied < totalFileLength)
                    {
                        toCopyLength = fromFile.Read(buffer, 0, eachReadLength);
                        fromFile.Flush();
                        toFile.Write(buffer, 0, eachReadLength);
                        toFile.Flush();
                        //流的当前位置
                        toFile.Position = fromFile.Position;
                        copied += toCopyLength;
                        currentProgress += (double)toCopyLength / 1024d / 1024d;
                    }
                    int left = (int)(totalFileLength - copied);
                    toCopyLength = fromFile.Read(buffer, 0, left);
                    fromFile.Flush();
                    toFile.Write(buffer, 0, left);
                    toFile.Flush();
                    currentProgress += (double)toCopyLength / 1024d / 1024d;
                }
                else
                {
                    //如果每次拷贝的文件长度大于源文件的长度 则将实际文件长度直接拷贝
                    byte[] buffer = new byte[totalFileLength];
                    fromFile.Read(buffer, 0, buffer.Length);
                    fromFile.Flush();
                    toFile.Write(buffer, 0, buffer.Length);
                    toFile.Flush();
                    currentProgress += (double)fromFile.Length / 1024d / 1024d;
                }
                fromFile.Close();
                toFile.Close();
                Action<string> deleteAction = DeleteResourceFileAction;
                deleteAction.BeginInvoke(fromPath, null, null);
            }
            catch
            {
                fromFile.Close();
                toFile.Close();
            }
            return;
        }

        /// <summary>
        /// 异步线程定时刷新进度
        /// </summary>
        public void UpdateProgressAction()
        {
            var temp = Convert.ToInt32(currentProgress * 100 / totalLength);
            percent = 1;
            while (percent < 100 && !progressAbort)//加载资源过程被强制拔出U盘的操作终止子线程
            {
                if (percent <= temp)
                {
                    SetProgressDelegate(deviceInfo, percent);
                    percent++;
                }
                else
                {
                    Thread.Sleep(2000);
                }
                temp = Convert.ToInt32(currentProgress * 100 / totalLength);
            }
            SetProgressDelegate(deviceInfo, percent);
        }

        /// <summary>
        /// 删除U盘源文件
        /// </summary>
        /// <param name="filePath"></param>
        public void DeleteResourceFileAction(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
