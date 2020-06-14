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
    }
}
