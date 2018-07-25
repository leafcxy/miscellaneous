using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Domain.reply
{

    public class Reply
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Reply()
        {
            ReplyId = Int32.MinValue;
            MessageId = Int32.MinValue;
            UserId = Int32.MinValue;
            ReplyInfo = String.Empty;
            ReplyDatetime = new DateTime(1900, 1, 1, 0, 0, 0);
        }

        #endregion

        #region 字段
        /// <summary>
        /// 主键 
        /// </summary>
        public int ReplyId { get; set; }
        /// <summary>
        /// 信息ID 
        /// </summary>
        public int MessageId { get; set; }
        /// <summary>
        /// 用户ID 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 回复内容 
        /// </summary>
        public string ReplyInfo { get; set; }
        /// <summary>
        /// 回复日期 
        /// </summary>
        public DateTime ReplyDatetime { get; set; }

        #endregion
    }
}
