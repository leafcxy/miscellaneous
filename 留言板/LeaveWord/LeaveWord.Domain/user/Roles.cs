using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Domain.user
{
    public class Roles
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Roles()
        {
            RoleId = Int32.MinValue;
            RoleName = String.Empty;
        }

        #endregion

        #region 字段
        /// <summary>
        /// 角色ID 
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 角色名字 
        /// </summary>
        public string RoleName { get; set; }
        #endregion
    }
}
