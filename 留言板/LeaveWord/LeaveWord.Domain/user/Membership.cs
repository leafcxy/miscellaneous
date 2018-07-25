using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Domain.user
{
    public class Membership
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Membership()
        {
            UserId = Int32.MinValue;
            CreateDate = new DateTime(1900, 1, 1, 0, 0, 0);
            ConfirmationToken = String.Empty;
            IsConfirmed = false;
            LastPasswordFailureDate = new DateTime(1900, 1, 1, 0, 0, 0);
            PasswordFailuresSinceLastSuccess = Int32.MinValue;
            Password = String.Empty;
            PasswordChangedDate = new DateTime(1900, 1, 1, 0, 0, 0);
            PasswordSalt = String.Empty;
            PasswordVerificationToken = String.Empty;
            PasswordVerificationTokenExpirationDate = new DateTime(1900, 1, 1, 0, 0, 0);
        }

        #endregion

        #region 字段

        /// <summary>
        /// 用户ID 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 创建日期 
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 较检令牌 
        /// </summary>
        public string ConfirmationToken { get; set; }
        /// <summary>
        /// 较检结果 
        /// </summary>
        public bool IsConfirmed { get; set; }
        /// <summary>
        /// 最近一次登录失败日期 
        /// </summary>
        public DateTime LastPasswordFailureDate { get; set; }
        /// <summary>
        /// 从上次登录起登录失败次数 
        /// </summary>
        public int PasswordFailuresSinceLastSuccess { get; set; }
        /// <summary>
        /// 密码 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 密码更改日期 
        /// </summary>
        public DateTime PasswordChangedDate { get; set; }
        /// <summary>
        ///  密码盐度
        /// </summary>
        public string PasswordSalt { get; set; }
        /// <summary>
        /// 密码验证令牌 
        /// </summary>
        public string PasswordVerificationToken { get; set; }
        /// <summary>
        /// 密码验证令牌过期日期 
        /// </summary>
        public DateTime PasswordVerificationTokenExpirationDate { get; set; }

        #endregion
    }
}
