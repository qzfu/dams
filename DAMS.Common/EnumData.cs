using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Common
{
    public class EnumData
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public enum MessageType
        {
            Error,
            Information,
            Warning,
            Confirm,
            Ask,
            DialogInfo
        }


        /// <summary>
        /// 文件类型
        /// </summary>
        public enum ResourceType
        {
            [Description("视频")]
            Video = 1,
            [Description("音频")]
            VoiceFrequency = 2,
            [Description("文档")]
            World = 3
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        public enum CatagoryType
        {
            [Description("项目尺寸")]
            Size = 1,
            [Description("加载优盘个数")]
            IndexCount = 2,
            [Description("项目第一次启动时间")]
            StartEnd = 3,
            [Description("是否注册过")]
            Register = 4,
            [Description("文件类型格式")]
            FileType = 5,
        }
    }
}
