using System.Collections;
using System.Collections.Generic;
using System.Web;
using LeaveWord.Domain.user;

namespace LeaveWord.Service.user.Interface
{
    public interface IUserProfileService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userProfile">UserProfile实例</param>
        /// <returns>记录主键ID</returns>

        int AddUserProfile(HttpContextBase httpContextBase, UserProfile userProfile);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="userProfile">UserProfile实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateUserProfile(HttpContextBase httpContextBase, UserProfile userProfile);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="userProfile">查询条件，UserProfile实例</param>
        /// <returns>满足查询条件的UserProfile List实例</returns>
        IList<UserProfile> GetUserProfiles(HttpContextBase httpContextBase, UserProfile userProfile);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UserProfile List实例</returns>
        int GetUserProfileCount(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的UserProfile List实例</returns>
        IList<UserProfile> FindUserProfiles(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的UserProfile List实例</returns>
        IList<UserProfile> GetPageUsers(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UserProfile List实例</returns>
        IList<UserProfile> GetAllUserProfileBySql(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userProfile">UserProfile实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteUserProfile(HttpContextBase httpContextBase, UserProfile userProfile);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteUserProfiles(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteUserProfileBySql(HttpContextBase httpContextBase, string whereSql);



        #endregion
    }
}
