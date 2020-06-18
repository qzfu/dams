using System;
using System.IO;
using System.Web;

namespace DAMS.Common
{
    public class FileHelper
    {
        /// <summary>
        /// 上传文件 字节数据至文件中。
        /// </summary>
        /// <param name="mStream">文件字节数组</param>
        /// <param name="sAbsolutePath">上传文件绝对路径</param>
        /// <param name="sUpFileName">保存文件名</param>
        /// <returns>true：上传成功、false：上传失败</returns>
        public static bool SaveFile(byte[] arrByte, string sAbsolutePath, string sUpFileName)
        {
            if (!Directory.Exists(sAbsolutePath))
            {
                Directory.CreateDirectory(sAbsolutePath);
            }
            string sFullFileName = string.Format("{0}\\{1}", sAbsolutePath, sUpFileName);
            return WriteBytesToDiskFile(arrByte, sFullFileName);
        }

        /// <summary>
        /// 上传文件 流至文件中。
        /// </summary>
        /// <param name="mStream">内存流</param>
        /// <param name="sAbsolutePath">上传文件绝对路径</param>
        /// <param name="sUpFileName">保存文件名</param>
        /// <returns>true：上传成功、false：上传失败</returns>
        public static bool UpLoadFile(MemoryStream mStream, string sAbsolutePath, string sUpFileName)
        {
            return SaveFile(mStream.ToArray(), sAbsolutePath, sUpFileName);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="sFilePath">删除文件相对路径</param>
        /// <returns>TRUE：调用成功 FALSE：调用失败</returns>
        public static bool DeleteFile(string sAbsolutePath)
        {
            try
            {
                File.Delete(sAbsolutePath);
                return true;
            }
            catch (Exception ex)
            {
               // Log.Error("删除文件：" + sAbsolutePath + " 失败。", ex);
                return false;
            }
        }

        /// <summary>
        /// 获取一个新的文件名(时间+升级数字)
        /// </summary>
        /// <param name="extension">扩展名(如：jpg)</param>
        /// <returns>新文件名称</returns>
        public static string GetNewFileName(string extension)
        {
            return Guid.NewGuid() + "." + extension.Replace(".", string.Empty).Trim();
        }

        /// <summary>
        /// 获取一个新的文件名(时间+升级数字)
        /// </summary>
        /// <param name="time">生成时间(如：yyyyMMddHHmmssfff)</param>
        /// <param name="extension">扩展名(如：jpg)</param>
        /// <returns>新文件名称</returns>
        public static string GetNewFileName(DateTime time, string extension)
        {
            return Guid.NewGuid() + "." + extension.Replace(".", string.Empty).Trim();
            //Random random = new Random(time.Millisecond);
            //return string.Format("{0}{1}.{2}", time.ToString("yyyyMMddHHmmssfff"), random.Next(0, 9999).ToString("0000"), extension.Replace(".", string.Empty).Trim());
        }

        /// <summary>
        /// 文件保存路径
        /// </summary>
        /// <param name="sRelativePath">相对路径</param>
        /// <param name="isLocal">是否本地</param>
        /// <returns></returns>
        public static string GetSavePath(string sRelativePath, bool isLocal)
        {
            string path = sRelativePath;
            if (isLocal)
            {
                path = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, sRelativePath.Replace("/", "\\"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }

            return path;
        }

        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="relatePath">相对路径</param>
        /// <returns></returns>
        public static bool IsExist(string relatePath)
        {
            return File.Exists(AppDomain.CurrentDomain.BaseDirectory + relatePath);
        }

        /// <summary>
        /// 将字节数组数据写入到指定的文件中。会直接覆盖已存在的文件。
        /// </summary>
        /// <param name="arrByte">文件字节数组</param>
        /// <param name="sFullFileName">上传文件完整路径</param>
        /// <returns>true：文件保存成功、false：文件保持失败</returns>
        private static bool WriteBytesToDiskFile(byte[] arrByte, string sFullFileName)
        {
            bool b = true;
            FileStream fsFile = new FileStream(sFullFileName, FileMode.Create, FileAccess.ReadWrite);
            try
            {
                fsFile.Write(arrByte, 0, arrByte.Length);
            }
            catch
            {
                b = false;
            }
            finally
            {
                fsFile.Flush();
                fsFile.Close();
            }
            return b;
        }

        /// <summary> 
        /// 将 Stream 转成 byte[] 
        /// </summary> 
        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = null;
            try
            {
                bytes = new byte[stream.Length];

                stream.Read(bytes, 0, bytes.Length);
                stream.Seek(0, SeekOrigin.Begin);
            }
            catch (Exception ex)
            {
                //Log.Error("Error-FileHandler.StreamToBytes", ex);
            }
            return bytes;
        }

        /// <summary> 
        /// 将 byte[] 转成 Stream 
        /// </summary> 
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary>
        /// 取路径中的文件扩展名
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static string GetFileExt(string path)
        {
            return path.Substring(path.LastIndexOf('.') + 1);
        }

        /// <summary>
        /// 获取文件流
        /// </summary>
        /// <param name="absolutePath">绝对路径</param>
        /// <returns></returns>
        public static FileStream GetFile(string absolutePath)
        {
            return File.Open(absolutePath, FileMode.Open);
        }

        /// <summary>
        /// 创建一个日期格式文件夹名 yyyy-MM
        /// </summary>
        /// <returns></returns>
        public static string GetfolderName()
        {
            return DateTime.Now.ToString("yyyy-MM");
        }

        /// <summary>
        /// 验证文件路径是否存在，不存在就创建此路径
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CreateFilePath(string filePath)
        {
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                return true;
            }
            catch (Exception ex)
            {
                //Log.Info(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除文件夹下文件某一类型文件
        /// </summary>
        /// <param name="directory"></param>
        public static void DeleteDirectoryContents(string directory, string extension)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);

                foreach (FileInfo currFile in di.GetFiles())
                {

                    if (currFile.Extension == extension)
                        currFile.Delete();
                }
            }
            catch 
            {
                // Log.Info(ex.Message);
            }
        }

        /// <summary>
        /// 中断续传
        /// </summary>
        /// <param name="fromPath">源文件的路径</param>
        /// <param name="toPath">文件保存的路径</param>
        /// <param name="eachReadLength">每次读取的长度</param>
        /// <returns>是否复制成功</returns>
        public static void CopyFile(string fromPath, string toPath, int eachReadLength)
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
            if (eachReadLength < totalFileLength)
            {
                byte[] buffer = new byte[eachReadLength];
                long copied = 0;
                while (copied <= totalFileLength)
                {
                    toCopyLength = fromFile.Read(buffer, 0, eachReadLength);
                    fromFile.Flush();
                    toFile.Write(buffer, 0, eachReadLength);
                    toFile.Flush();
                    //流的当前位置
                    toFile.Position = fromFile.Position;
                    copied += toCopyLength;

                }
                int left = (int)(totalFileLength - copied);
                toCopyLength = fromFile.Read(buffer, 0, left);
                fromFile.Flush();
                toFile.Write(buffer, 0, left);
                toFile.Flush();
            }
            else
            {
                //如果每次拷贝的文件长度大于源文件的长度 则将实际文件长度直接拷贝
                byte[] buffer = new byte[fromFile.Length];
                fromFile.Read(buffer, 0, buffer.Length);
                fromFile.Flush();
                toFile.Write(buffer, 0, buffer.Length);
                toFile.Flush();

            }
            fromFile.Close();
            toFile.Close();
            return;
        }

    }
}
