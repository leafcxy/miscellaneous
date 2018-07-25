using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Domain.user
{
    public class UserProfile
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserProfile()
        {
            UserId = Int32.MinValue;
            UserName = String.Empty;
        }

        #endregion

        #region 字段
        /// <summary>
        /// 用户ID 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名 
        /// </summary>
        public string UserName { get; set; }

        #endregion
    }
}
