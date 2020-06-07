using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Common
{
    public static class CommonHelper
    {
        /// <summary>
        /// 获取Config配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static void CopyFiles(DirectoryInfo sourceDirectory)
        {
            var desRoot = GetAppSettings("desdirectory");
            //创建目标根目录
            CreateDirectoryIfNotExist(desRoot);
            var filePath = @"/" + DateTime.Now.ToString("yyyyMMdd");
            var destinationPath = desRoot + filePath;
            CreateDirectoryIfNotExist(destinationPath);
            CopyTo(sourceDirectory, filePath, destinationPath);
        }

        /// <summary>
        /// 把源目录移复制目标目录下
        /// </summary>
        /// <param name="sourceDirectory">要移动的源目录</param>
        /// <param name="destinationPath">目标目录路径</param>
        public static void CopyTo(this DirectoryInfo sourceDirectory,string filePath, string destinationPath)
        {
            try
            {
                //复制文件夹下面的文件
                FileInfo[] fileArray = sourceDirectory.GetFiles();
                foreach (FileInfo file in fileArray)
                {
                    var fileName = FileHelper.GetNewFileName(file.Extension);
                    file.CopyTo(destinationPath + "/" + fileName);
                }
                //复制文件夹下面的子文件夹
                DirectoryInfo[] dirArray = sourceDirectory.GetDirectories();
                foreach (DirectoryInfo dir in dirArray)
                {
                    dir.CopyTo(filePath,destinationPath);
                }
            }
            catch (Exception e)
            {
                return;
            }
        }

        /// <summary>
        /// 不存在目录则创建目录
        /// </summary>
        /// <param name="path">要创建目录的路径</param>
        public static void CreateDirectoryIfNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
