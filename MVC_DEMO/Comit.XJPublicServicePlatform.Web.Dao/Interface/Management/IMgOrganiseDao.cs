/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 10:20:28
** 描述：mg_organise(角色信息)表的Dao接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Management;

namespace Comit.XJPublicServicePlatform.Web.Dao.Interface.Management
{
    public interface IMgOrganiseDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>记录主键ID</returns>
        long AddMgOrganise(MgOrganise mgOrganise, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateMgOrganise(MgOrganise mgOrganise, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="mgOrganise">查询条件，MgOrganise实例</param>
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        IList<MgOrganise> GetMgOrganises(MgOrganise mgOrganise, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        IList<MgOrganise> FindMgOrganises(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
         /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        IList<MgOrganise> GetAllMgOrganiseBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMgOrganise(MgOrganise mgOrganise, ISqlMapper sqlMapper);
	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteMgOrganiseBySql(string whereSql, ISqlMapper sqlMapper);	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMgOrganises(IList<long> ids, ISqlMapper sqlMapper);
        #endregion
   	}
}
