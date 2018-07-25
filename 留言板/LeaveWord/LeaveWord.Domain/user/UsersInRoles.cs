using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Domain.user
{
    public class UsersInRoles
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public UsersInRoles()
        {
            UserId = Int32.MinValue;
            RoleId = Int32.MinValue;
        }

        #endregion

        #region 字段

        /// <summary>
        /// 用户ID 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 角色ID 
        /// </summary>
        public int RoleId { get; set; }

        #endregion
    }
}
