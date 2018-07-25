using System.Collections;
using System.Collections.Generic;
using System.Web;
using LeaveWord.Domain.user;

namespace LeaveWord.Service.user.Interface
{
    public interface IOAuthMembershipService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="oAuthMembership">OAuthMembership实例</param>
        /// <returns>记录主键ID</returns>

        int AddOAuthMembership(HttpContextBase httpContextBase, OAuthMembership oAuthMembership);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="oAuthMembership">OAuthMembership实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateOAuthMembership(HttpContextBase httpContextBase, OAuthMembership oAuthMembership);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="oAuthMembership">查询条件，OAuthMembership实例</param>
        /// <returns>满足查询条件的OAuthMembership List实例</returns>
        IList<OAuthMembership> GetOAuthMemberships(HttpContextBase httpContextBase, OAuthMembership oAuthMembership);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的OAuthMembership List实例</returns>
        int GetOAuthMembershipCount(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的OAuthMembership List实例</returns>
        IList<OAuthMembership> FindOAuthMemberships(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的OAuthMembership List实例</returns>
        IList<OAuthMembership> GetAllOAuthMembershipBySql(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oAuthMembership">OAuthMembership实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteOAuthMembership(HttpContextBase httpContextBase, OAuthMembership oAuthMembership);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteOAuthMemberships(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteOAuthMembershipBySql(HttpContextBase httpContextBase, string whereSql);



        #endregion
    }
}
