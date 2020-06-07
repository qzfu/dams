using System;
using System.Collections.Generic;
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
    }
}
