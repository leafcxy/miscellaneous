/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 18:56:15
** 描述：mg_popedom(权限管理
   
   )表的Dao接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Management;

namespace Comit.XJPublicServicePlatform.Web.Dao.Interface.Management
{
    public interface IMgPopedomDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>记录主键ID</returns>
        long AddMgPopedom(MgPopedom mgPopedom, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateMgPopedom(MgPopedom mgPopedom, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="mgPopedom">查询条件，MgPopedom实例</param>
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        IList<MgPopedom> GetMgPopedoms(MgPopedom mgPopedom, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        IList<MgPopedom> FindMgPopedoms(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
         /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        IList<MgPopedom> GetAllMgPopedomBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMgPopedom(MgPopedom mgPopedom, ISqlMapper sqlMapper);
	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteMgPopedomBySql(string whereSql, ISqlMapper sqlMapper);	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMgPopedoms(IList<long> ids, ISqlMapper sqlMapper);
        #endregion
   	}
}
