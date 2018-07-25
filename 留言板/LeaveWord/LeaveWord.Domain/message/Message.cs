using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Domain.message
{
    public class Message
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Message()
        {
            MessageId = Int32.MinValue;
            UserId = Int32.MinValue;
            MessageInfo = String.Empty;
            MessageTag = Int32.MinValue;
            MessageDatetime = new DateTime(1900, 1, 1, 0, 0, 0);
        }

        #endregion

        #region 字段

        /// <summary>
        /// 主键 
        /// </summary>
        public int MessageId { get; set; }
        /// <summary>
        /// 用户ID 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 信息内容 
        /// </summary>
        public string MessageInfo { get; set; }
        /// <summary>
        /// 信息标签 
        /// </summary>
        public int MessageTag { get; set; }
        /// <summary>
        /// 信息创建日期 
        /// </summary>
        public DateTime MessageDatetime { get; set; }

        #endregion
        
    }
}
