/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 10:20:28
** 描述：mg_organise(角色信息)表的Service接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Domain.Management;

namespace Comit.XJPublicServicePlatform.Web.Service.Management.Interface
{
    public interface IMgOrganiseService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>记录主键ID</returns>
        long AddMgOrganise(HttpContextBase httpContextBase, MgOrganise mgOrganise);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateMgOrganise(HttpContextBase httpContextBase, MgOrganise mgOrganise);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="mgOrganise">查询条件，MgOrganise实例</param>
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        IList<MgOrganise> GetMgOrganises(HttpContextBase httpContextBase, MgOrganise mgOrganise);
		
		/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        IList<MgOrganise> FindMgOrganises(HttpContextBase httpContextBase, Hashtable parameter);
        
 	/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        IList<MgOrganise> GetAllMgOrganiseBySql(HttpContextBase httpContextBase, string whereSql);
    
       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMgOrganise(HttpContextBase httpContextBase, MgOrganise mgOrganise);
		
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMgOrganises(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteMgOrganiseBySql(HttpContextBase httpContextBase, string whereSql);


		 /// <summary>
        /// 配置权限
        /// </summary>
        /// <param name="sql">配置脚本</param>
        /// <returns></returns>
        int AddPopedoms(string sql);
        #endregion
   	}
}
