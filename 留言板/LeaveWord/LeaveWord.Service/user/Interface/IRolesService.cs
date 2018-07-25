using System.Collections;
using System.Collections.Generic;
using System.Web;
using LeaveWord.Domain.user;

namespace LeaveWord.Service.user.Interface
{
    public interface IRolesService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="roles">Roles实例</param>
        /// <returns>记录主键ID</returns>

        int AddRoles(HttpContextBase httpContextBase, Roles roles);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="roles">Roles实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateRoles(HttpContextBase httpContextBase, Roles roles);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="roles">查询条件，Roles实例</param>
        /// <returns>满足查询条件的Roles List实例</returns>
        IList<Roles> GetRoless(HttpContextBase httpContextBase, Roles roles);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Roles List实例</returns>
        int GetRolesCount(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Roles List实例</returns>
        IList<Roles> FindRoless(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Roles List实例</returns>
        IList<Roles> GetAllRolesBySql(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="roles">Roles实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteRoles(HttpContextBase httpContextBase, Roles roles);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteRoless(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteRolesBySql(HttpContextBase httpContextBase, string whereSql);



        #endregion
    }
}
