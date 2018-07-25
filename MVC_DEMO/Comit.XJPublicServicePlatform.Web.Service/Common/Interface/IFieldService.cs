/******************************************************************************** 
** 作者：余穗海
** 时间：2014-07-25 10:21:53
** 描述：field(field)表的Service接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Domain.Common;

namespace Comit.XJPublicServicePlatform.Web.Service.Common.Interface
{
    public interface IFieldService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="field">Field实例</param>
        /// <returns>记录主键ID</returns>
        int AddField(HttpContextBase httpContextBase, Field field);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="field">Field实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateField(HttpContextBase httpContextBase, Field field);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="field">查询条件，Field实例</param>
        /// <returns>满足查询条件的Field List实例</returns>
        IList<Field> GetFields(HttpContextBase httpContextBase, Field field);
		
		/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Field List实例</returns>
        IList<Field> FindFields(HttpContextBase httpContextBase, Hashtable parameter);
        
 	/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Field List实例</returns>
        IList<Field> GetAllFieldBySql(HttpContextBase httpContextBase, string whereSql);
    
       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="field">Field实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteField(HttpContextBase httpContextBase, Field field);
		
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteFields(HttpContextBase httpContextBase, IList<int> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteFieldBySql(HttpContextBase httpContextBase, string whereSql);


		
        #endregion
   	}
}
