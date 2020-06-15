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

namespace DAMS.UI.Common
{
    public class DeviceControl
    {
        private IResourceService deviceService = Assembler<IResourceService>.Create();
        delegate void DeviceNotifyDelegate();
        delegate void SetCopySpeedCallback();//安全线程访问
        private int flushReadLength;// { get; set; }
        private string desRoot; //{ get; set; }
        public DeviceControl()
        {
            desRoot = CommonHelper.GetAppSettings("desdirectory");
            flushReadLength =  Convert.ToInt32(CommonHelper.GetAppSettings("FlushReadLength"));
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
            CopyTo(sourceDirectory, filePath, destinationPath, currResources, ref resList);
            deviceService.AddResource(resList, deviceInfo);
        }

        private void CopyTo(DirectoryInfo sourceDirectory, string filePath, string destinationPath, List<Resources> currResources, ref List<Resources> resList)
        {
            //复制文件夹下面的文件
            FileInfo[] fileArray = sourceDirectory.GetFiles();
            foreach (FileInfo file in fileArray)
            {
                var itemFileFullName = filePath + "/" + file.Name;
                var resModel = currResources.FirstOrDefault(x => String.Compare(x.FileName, itemFileFullName) == 0);
                //文件已经存在且已经Copy完毕跳过本层循环
                if (resModel != null && resModel.IsCopyEnd == 1)
                {
                    continue;
                }
                if (resModel == null)
                {
                    resList.Add(new Resources()
                    {
                        Extension = file.Extension,
                        Alias=file.Name,
                        FilePath = filePath,
                        FileName = itemFileFullName,
                        IsCopyEnd=0
                    });
                }
                //源文件文件地址名称
                var fromFile = file.FullName;
                //定义目标文件地址名称
                var tofile = destinationPath + "/" + file.Name;
                //异步执行Copy文件中断续传从
                Action<string, string, int> fileAction = FileHelper.CopyFile;
                fileAction.BeginInvoke(fromFile, tofile, flushReadLength, null, null);
            }
            //复制文件夹下面的子文件夹
            DirectoryInfo[] dirArray = sourceDirectory.GetDirectories();
            foreach (DirectoryInfo dir in dirArray)
            {
                var dirPath = dir.Name;
                var itemFilePath = filePath + "/" + dirPath;
                var itemDirPath = destinationPath + "/" + dirPath;
                CopyTo(sourceDirectory, itemFilePath, itemDirPath, currResources, ref resList);
            }
        }
        public void FlushCopyFileCallBack()
        { 
            
        }
    }
}
