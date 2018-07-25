/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-23 09:53:09
** 描述：codemapdesc(数据字典)表的Service接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Domain.Common;

namespace Comit.XJPublicServicePlatform.Web.Service.Common.Interface
{
    public interface ICodemapdescService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>记录主键ID</returns>
        int AddCodemapdesc(HttpContextBase httpContextBase, Codemapdesc codemapdesc);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateCodemapdesc(HttpContextBase httpContextBase, Codemapdesc codemapdesc);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="codemapdesc">查询条件，Codemapdesc实例</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        IList<Codemapdesc> GetCodemapdescs(HttpContextBase httpContextBase, Codemapdesc codemapdesc);
		
		/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        IList<Codemapdesc> FindCodemapdescs(HttpContextBase httpContextBase, Hashtable parameter);
        
 	    /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        //IList<Codemapdesc> GetAllCodemapdescBySql(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        IList<Codemapdesc> GetAllCodemapdescBySql(string whereSql);
    
       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteCodemapdesc(HttpContextBase httpContextBase, Codemapdesc codemapdesc);
		
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteCodemapdescs(HttpContextBase httpContextBase, IList<int> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteCodemapdescBySql(HttpContextBase httpContextBase, string whereSql);


		
        #endregion
   	}
}
