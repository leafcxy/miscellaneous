/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 18:56:15
** 描述：mg_popedom(权限管理
   
   )表的Service接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Domain.Management;

namespace Comit.XJPublicServicePlatform.Web.Service.Management.Interface
{
    public interface IMgPopedomService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>记录主键ID</returns>
        long AddMgPopedom(HttpContextBase httpContextBase, MgPopedom mgPopedom);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateMgPopedom(HttpContextBase httpContextBase, MgPopedom mgPopedom);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="mgPopedom">查询条件，MgPopedom实例</param>
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        IList<MgPopedom> GetMgPopedoms(HttpContextBase httpContextBase, MgPopedom mgPopedom);
		
		/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        IList<MgPopedom> FindMgPopedoms(HttpContextBase httpContextBase, Hashtable parameter);
        
 	/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        IList<MgPopedom> GetAllMgPopedomBySql(HttpContextBase httpContextBase, string whereSql);
    
       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMgPopedom(HttpContextBase httpContextBase, MgPopedom mgPopedom);
		
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMgPopedoms(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteMgPopedomBySql(HttpContextBase httpContextBase, string whereSql);


		
        #endregion
   	}
}
