using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using LibUsbDotNet.DeviceNotify;
using DAMS.Common;
using DAMS.Models;
using DAMS.Interface;
using DAMS.Core.ClassFactory;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Remoting.Messaging;

namespace DAMS.UI.Common
{
    public class DeviceControl
    {
        private IResourceService deviceService = Assembler<IResourceService>.Create();
        delegate void DeviceNotifyDelegate();
        delegate void SetCopySpeedCallback();//安全线程访问
        private int flushReadLength;// { get; set; }
        private string desRoot; //{ get; set; }

        //private delegate int FlushFileDelegate();

        public DeviceControl()
        {
            desRoot = CommonHelper.GetAppSettings("desdirectory");
            flushReadLength =  Convert.ToInt32(CommonHelper.GetAppSettings("FlushReadLength"));
        }
        /// <summary>
        /// 校验盘符信息
        /// </summary>
        /// <param name="root">U盘根目录</param>
        /// <param name="vid">Vid</param>
        /// <param name="pid">Pid</param>
        /// <param name="serialNumber">serialNumber</param>
        /// <returns>0新增盘符，1中断续传，-1不同磁盘</returns>
        public int CheckDeviceToken(string root, int vid, int pid, string serialNumber)
        {
            string xmlPath = root + "deviceToken.xml";
            if (!File.Exists(xmlPath))
            {
                XmlDocument doc = new XmlDocument();
                //获取根节点对象
                XDocument document = new XDocument();
                XElement node = new XElement("token");
                node.SetElementValue("vid", vid);
                node.SetElementValue("pid", pid);
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
                    var nodeVid = nodes.FirstOrDefault(x => x.Name == "vid").Value;
                    var nodePid = nodes.FirstOrDefault(x => x.Name == "pid").Value;
                    var nodeSerialNumber = nodes.FirstOrDefault(x => x.Name == "serialNumber").Value;
                    if (nodeVid == vid.ToString() && nodePid == pid.ToString() && nodeSerialNumber == serialNumber)
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

        public void CopyFilesTo(DirectoryInfo sourceDirectory, int vid, int pid, string serialNumber)
        {
            //创建目标根目录
            CommonHelper.CreateDirectoryIfNotExist(desRoot);
            //以U盘vid.Pid.serialNumber创建目标文件家
            var deviceInfo = vid.ToString() + "." + pid.ToString() + "." + serialNumber;
            var filePath = @"/" + deviceInfo;
            var destinationPath = desRoot + filePath;
            CommonHelper.CreateDirectoryIfNotExist(destinationPath);
            //获取目标文件夹中已存在的文件列表
            List<Resources> currResources = deviceService.GetCurrentDiskResourceList(vid, pid, serialNumber);
            List<Resources> resList = new List<Resources>();
            CopyTo(sourceDirectory, filePath, destinationPath, currResources, deviceInfo);
        }

        private void CopyTo(DirectoryInfo sourceDirectory, string filePath, string destinationPath, List<Resources> currResources, string deviceInfo)
        {
            //复制文件夹下面的文件
            FileInfo[] fileArray = sourceDirectory.GetFiles();
            foreach (FileInfo file in fileArray)
            {
                if (file.Name == "deviceToken.xml")
                {
                    continue;
                }
                var itemFileFullName = filePath + "/" + file.Name;
                var resModel = currResources.FirstOrDefault(x => String.Compare(x.FileName, itemFileFullName) == 0);
                //文件已经存在且已经Copy完毕跳过本层循环
                if (resModel != null && resModel.IsCopyEnd == 1)
                {
                    continue;
                }
                if (resModel == null)
                {
                    resModel = new Resources()
                    {
                        Extension = file.Extension,
                        Alias = file.Name,
                        FilePath = filePath,
                        FileName = itemFileFullName,
                        DeviceInfo = deviceInfo,
                        CreatedTime = DateTime.Now,
                        UserId="Admin",
                        UserName="管理员",
                        IsCopyEnd = 0
                    };

                    deviceService.AddResource(resModel, deviceInfo);
                }
                //源文件文件地址名称
                var fromFile = file.FullName;
                //定义目标文件地址名称
                var tofile = destinationPath + "/" + file.Name;
                //异步执行Copy文件中断续传从
                Action<string, string,int> fileAction = FileHelper.CopyFile;
                AsyncCallback callBack = new AsyncCallback(FlushCopyFileCallBack);
                fileAction.BeginInvoke(fromFile, tofile, flushReadLength, callBack, resModel);
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
                var itemFilePath = filePath + "/" + dirPath;
                var itemDirPath = destinationPath + "/" + dirPath;
                CopyTo(dir, itemFilePath, itemDirPath, currResources, deviceInfo);
            }
        }
        public void FlushCopyFileCallBack(IAsyncResult ar)
        {
            AsyncResult async = (AsyncResult)ar;
            var action = (Action<string, string,int>)async.AsyncDelegate;
            action.EndInvoke(ar);
            var resModel = ar.AsyncState as Resources;
            //更新当前资源采集状态为已完成
            deviceService.UpdateCopyStateResource(resModel);
        }
    }
}
