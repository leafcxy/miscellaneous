/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 17:04:57
** 描述：user_role_relate(用户和角色的关系)表的Service接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Domain.Management;

namespace Comit.XJPublicServicePlatform.Web.Service.Management.Interface
{
    public interface IUserRoleRelateService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userRoleRelate">UserRoleRelate实例</param>
        /// <returns>记录主键ID</returns>
        long AddUserRoleRelate(HttpContextBase httpContextBase, UserRoleRelate userRoleRelate);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="userRoleRelate">UserRoleRelate实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateUserRoleRelate(HttpContextBase httpContextBase, UserRoleRelate userRoleRelate);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="userRoleRelate">查询条件，UserRoleRelate实例</param>
        /// <returns>满足查询条件的UserRoleRelate List实例</returns>
        IList<UserRoleRelate> GetUserRoleRelates(HttpContextBase httpContextBase, UserRoleRelate userRoleRelate);
		
		/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的UserRoleRelate List实例</returns>
        IList<UserRoleRelate> FindUserRoleRelates(HttpContextBase httpContextBase, Hashtable parameter);
        
 	    /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UserRoleRelate List实例</returns>
        IList<UserRoleRelate> GetAllUserRoleRelateBySql(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UserRoleRelate List实例</returns>
        IList<UserRoleRelate> GetAllUserRoleRelateBySql(string whereSql);
    
       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userRoleRelate">UserRoleRelate实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteUserRoleRelate(HttpContextBase httpContextBase, UserRoleRelate userRoleRelate);
		
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteUserRoleRelates(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteUserRoleRelateBySql(HttpContextBase httpContextBase, string whereSql);


		
        #endregion

    }
}
