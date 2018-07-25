/******************************************************************************** 
** 作者：余穗海
** 时间：2015-04-01 10:20:46
** 描述：login_record(用户登录记录表;)表的Service接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Domain.Common;

namespace Comit.XJPublicServicePlatform.Web.Service.Common.Interface
{
    public interface ILoginRecordService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>记录主键ID</returns>
        int AddLoginRecord(HttpContextBase httpContextBase, LoginRecord loginRecord);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateLoginRecord(HttpContextBase httpContextBase, LoginRecord loginRecord);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="loginRecord">查询条件，LoginRecord实例</param>
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        IList<LoginRecord> GetLoginRecords(HttpContextBase httpContextBase, LoginRecord loginRecord);
		
		/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        IList<LoginRecord> FindLoginRecords(HttpContextBase httpContextBase, Hashtable parameter);
        
 	/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        IList<LoginRecord> GetAllLoginRecordBySql(HttpContextBase httpContextBase, string whereSql);
    
       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteLoginRecord(HttpContextBase httpContextBase, LoginRecord loginRecord);
		
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteLoginRecords(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteLoginRecordBySql(HttpContextBase httpContextBase, string whereSql);


		
        #endregion
   	}
}
