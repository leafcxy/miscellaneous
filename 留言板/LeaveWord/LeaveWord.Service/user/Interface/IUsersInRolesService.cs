using System.Collections;
using System.Collections.Generic;
using System.Web;
using LeaveWord.Domain.user;

namespace LeaveWord.Service.user.Interface
{
    public interface IUsersInRolesService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>记录主键ID</returns>

        int AddUsersInRoles(HttpContextBase httpContextBase, UsersInRoles usersInRoles);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateUsersInRoles(HttpContextBase httpContextBase, UsersInRoles usersInRoles);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="usersInRoles">查询条件，UsersInRoles实例</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        IList<UsersInRoles> GetUsersInRoless(HttpContextBase httpContextBase, UsersInRoles usersInRoles);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        int GetUsersInRolesCount(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        IList<UsersInRoles> FindUsersInRoless(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        IList<UsersInRoles> GetAllUsersInRolesBySql(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteUsersInRoles(HttpContextBase httpContextBase, UsersInRoles usersInRoles);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteUsersInRoless(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteUsersInRolesBySql(HttpContextBase httpContextBase, string whereSql);



        #endregion
    }
}
