using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Common
{
    public class ConstConfig
    {
        /// <summary>
        /// 通知应用程序更改设备或计算机的硬件配置。
        /// </summary>
        public const int WM_DEVICECHANGE = 0x219;
        /// <summary>
        /// U盘插入
        /// </summary>
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        /// <summary>
        /// 当前配置发生了变化 
        /// </summary>
        public const int DBT_CONFIGCHANGED = 0x0018;
        public const int DBT_CUSTOMEVENT = 0x8006;
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        /// <summary>
        /// 设备已经被清除
        /// </summary>
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;
        /// <summary>
        /// 与设备有关的事件
        /// </summary>
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;
        /// <summary>
        /// 设备节点发生了变化
        /// </summary>
        public const int DBT_DEVNODES_CHANGED = 0x0007;
        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        public const int DBT_USERDEFINED = 0xFFFF;
    }
}
