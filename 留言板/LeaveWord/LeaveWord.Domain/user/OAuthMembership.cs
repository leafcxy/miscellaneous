using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Domain.user
{
    public class OAuthMembership
    {

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public OAuthMembership()
        {
            Provider = String.Empty;
            ProviderUserId = String.Empty;
            UserId = Int32.MinValue;
        }

        #endregion

        #region 字段
        /// <summary>
        /// 供应者 
        /// </summary>
        public string Provider { get; set; }
        /// <summary>
        /// 供应者ID 
        /// </summary>
        public string ProviderUserId { get; set; }
        /// <summary>
        /// 用户ID 
        /// </summary>
        public int UserId { get; set; }

        #endregion

    }
}
