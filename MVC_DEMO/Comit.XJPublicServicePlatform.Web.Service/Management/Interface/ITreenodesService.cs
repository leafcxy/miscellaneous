/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-08-06 09:09:09
** 描述：TreeNodes(菜单节点)表的Service接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Domain.Management;

namespace Comit.XJPublicServicePlatform.Web.Service.Management.Interface
{
    public interface ITreenodesService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>记录主键ID</returns>
        long AddTreenodes(HttpContextBase httpContextBase, Treenodes treenodes);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateTreenodes(HttpContextBase httpContextBase, Treenodes treenodes);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="treenodes">查询条件，Treenodes实例</param>
        /// <returns>满足查询条件的Treenodes List实例</returns>
        IList<Treenodes> GetTreenodess(HttpContextBase httpContextBase, Treenodes treenodes);
		
		/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Treenodes List实例</returns>
        IList<Treenodes> FindTreenodess(HttpContextBase httpContextBase, Hashtable parameter);
        
 	/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Treenodes List实例</returns>
        IList<Treenodes> GetAllTreenodesBySql(HttpContextBase httpContextBase, string whereSql);
    
       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteTreenodes(HttpContextBase httpContextBase, Treenodes treenodes);
		
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteTreenodess(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteTreenodesBySql(HttpContextBase httpContextBase, string whereSql);


		
        #endregion
   	}
}
