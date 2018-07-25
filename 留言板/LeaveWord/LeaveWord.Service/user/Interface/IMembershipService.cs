using System.Collections;
using System.Collections.Generic;
using System.Web;
using LeaveWord.Domain.user;

namespace LeaveWord.Service.user.Interface
{
    public interface IMembershipService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="membership">Membership实例</param>
        /// <returns>记录主键ID</returns>

        int AddMembership(HttpContextBase httpContextBase, Membership membership);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="membership">Membership实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateMembership(HttpContextBase httpContextBase, Membership membership);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="membership">查询条件，Membership实例</param>
        /// <returns>满足查询条件的Membership List实例</returns>
        IList<Membership> GetMemberships(HttpContextBase httpContextBase, Membership membership);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Membership List实例</returns>
        int GetMembershipCount(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Membership List实例</returns>
        IList<Membership> FindMemberships(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Membership List实例</returns>
        IList<Membership> GetAllMembershipBySql(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="membership">Membership实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMembership(HttpContextBase httpContextBase, Membership membership);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMemberships(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteMembershipBySql(HttpContextBase httpContextBase, string whereSql);



        #endregion
    }
}
