/******************************************************************************** 
** 作者：余穗海
** 时间：2015-04-01 10:20:46
** 描述：login_record(用户登录记录表;)表的Dao接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Common;

namespace Comit.XJPublicServicePlatform.Web.Dao.Interface.Common
{
    public interface ILoginRecordDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>记录主键ID</returns>
        int AddLoginRecord(LoginRecord loginRecord, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateLoginRecord(LoginRecord loginRecord, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="loginRecord">查询条件，LoginRecord实例</param>
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        IList<LoginRecord> GetLoginRecords(LoginRecord loginRecord, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        IList<LoginRecord> FindLoginRecords(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
         /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        IList<LoginRecord> GetAllLoginRecordBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteLoginRecord(LoginRecord loginRecord, ISqlMapper sqlMapper);
	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteLoginRecordBySql(string whereSql, ISqlMapper sqlMapper);	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteLoginRecords(IList<long> ids, ISqlMapper sqlMapper);
        #endregion
   	}
}
