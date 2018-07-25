/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-25 14:08:57
** 描述：mg_users(用户信息
   
   登录密码：按)表的Dao接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Management;

namespace Comit.XJPublicServicePlatform.Web.Dao.Interface.Management
{
    public interface IMgUsersDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mgUsers">MgUsers实例</param>
        /// <returns>记录主键ID</returns>
        long AddMgUsers(MgUsers mgUsers, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mgUsers">MgUsers实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateMgUsers(MgUsers mgUsers, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="mgUsers">查询条件，MgUsers实例</param>
        /// <returns>满足查询条件的MgUsers List实例</returns>
        IList<MgUsers> GetMgUserss(MgUsers mgUsers, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的MgUsers List实例</returns>
        IList<MgUsers> FindMgUserss(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
         /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的MgUsers List实例</returns>
        IList<MgUsers> GetAllMgUsersBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mgUsers">MgUsers实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMgUsers(MgUsers mgUsers, ISqlMapper sqlMapper);
	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteMgUsersBySql(string whereSql, ISqlMapper sqlMapper);	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMgUserss(IList<long> ids, ISqlMapper sqlMapper);
        #endregion
   	}
}
