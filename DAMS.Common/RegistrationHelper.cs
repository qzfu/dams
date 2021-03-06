﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Common
{
    public class RegistrationHelper
    {
        /// <summary>
        /// 取得设备硬盘的卷标号
        /// </summary>
        /// <returns></returns>
        public static string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        /// <summary>
        /// 获得CPU的序列号
        /// </summary>
        /// <returns></returns>
        public static string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }

        /// <summary>
        /// 生成机器码
        /// </summary>
        /// <returns></returns>
        public static string getMNum()
        {
            string strNum = getCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号
            string strMNum = strNum.Substring(0, 24);//从生成的字符串中取出前24个字符做为机器码
            return strMNum;
        }
        public static int[] intCode = new int[127];//存储密钥
        public static int[] intNumber = new int[33];//存机器码的Ascii值
        public static char[] Charcode = new char[33];//存储机器码字
        public static void setIntCode()//给数组赋值小于10的数
        {
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i % 9;
            }
        }

        /// <summary>
        /// 生成注册码
        /// </summary>
        /// <returns></returns>
        public static string getRNum(string computerCode = null)
        {
            intCode = new int[127];
            intNumber = new int[25];
            Charcode = new char[25];

            setIntCode();//初始化127位数组
            string MNum = getMNum();//获取注册码
            if (!string.IsNullOrEmpty(computerCode))
            {
                MNum = computerCode;
            }
            if (MNum.Length != Charcode.Length - 1)
                return null;

            for (int i = 1; i < Charcode.Length; i++)//把机器码存入数组中
            {
                Charcode[i] = Convert.ToChar(MNum.Substring(i - 1, 1));
            }
            for (int j = 1; j < intNumber.Length; j++)//把字符的ASCII值存入一个整数组中。
            {
                intNumber[j] = intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
            }
            string strAsciiName = "";//用于存储注册码
            for (int j = 1; j < intNumber.Length; j++)
            {
                var code = intNumber[j] + (j % 3);

                if (code >= 48 && code <= 57)//判断字符ASCII值是否0－9之间
                {
                    strAsciiName += Convert.ToChar(code).ToString();
                }
                else if (code >= 65 && code <= 90)//判断字符ASCII值是否A－Z之间
                {
                    strAsciiName += Convert.ToChar(code).ToString();
                }
                else if (code >= 97 && code <= 122)//判断字符ASCII值是否a－z之间
                {
                    strAsciiName += Convert.ToChar(code).ToString();
                }
                else//判断字符ASCII值不在以上范围内
                {
                    if (code > 122)//判断字符ASCII值是否大于z
                    {
                        strAsciiName += Convert.ToChar(code - 10).ToString();
                    }
                    else
                    {
                        strAsciiName += Convert.ToChar(code - 9).ToString();
                    }
                }
            }
            return strAsciiName;//返回注册码
        }

        /// <summary>
        /// 生成注册码
        /// </summary>
        /// <returns></returns>
        public static string getRNumWithDate(DateTime date, string computerCode = null)
        {
            intCode = new int[127];
            intNumber = new int[33];
            Charcode = new char[33];

            setIntCode();//初始化127位数组
            string MNum = getMNum();//获取注册码
            if (!string.IsNullOrEmpty(computerCode))
            {
                MNum = computerCode;
            }
            MNum += date.ToString("yyyyMMdd");

            if (MNum.Length != Charcode.Length - 1)
                return null;

            for (int i = 1; i < Charcode.Length; i++)//把机器码存入数组中
            {
                Charcode[i] = Convert.ToChar(MNum.Substring(i - 1, 1));
            }
            for (int j = 1; j < intNumber.Length; j++)//把字符的ASCII值存入一个整数组中。
            {
                intNumber[j] = intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
            }
            string strAsciiName = "";//用于存储注册码
            for (int j = 1; j < intNumber.Length; j++)
            {
                var code = intNumber[j] + (j % 3);

                if (code >= 48 && code <= 57)//判断字符ASCII值是否0－9之间
                {
                    strAsciiName += Convert.ToChar(code).ToString();
                }
                else if (code >= 65 && code <= 90)//判断字符ASCII值是否A－Z之间
                {
                    strAsciiName += Convert.ToChar(code).ToString();
                }
                else if (code >= 97 && code <= 122)//判断字符ASCII值是否a－z之间
                {
                    strAsciiName += Convert.ToChar(code).ToString();
                }
                else//判断字符ASCII值不在以上范围内
                {
                    if (code > 122)//判断字符ASCII值是否大于z
                    {
                        strAsciiName += Convert.ToChar(code - 10).ToString();
                    }
                    else
                    {
                        strAsciiName += Convert.ToChar(code - 9).ToString();
                    }
                }
            }
            return strAsciiName;//返回注册码
        }
    }
}
