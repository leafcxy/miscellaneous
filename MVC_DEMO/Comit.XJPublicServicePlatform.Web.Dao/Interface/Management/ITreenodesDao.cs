/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-08-06 09:09:08
** 描述：TreeNodes(菜单节点)表的Dao接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Management;

namespace Comit.XJPublicServicePlatform.Web.Dao.Interface.Management
{
    public interface ITreenodesDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>记录主键ID</returns>
        long AddTreenodes(Treenodes treenodes, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateTreenodes(Treenodes treenodes, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="treenodes">查询条件，Treenodes实例</param>
        /// <returns>满足查询条件的Treenodes List实例</returns>
        IList<Treenodes> GetTreenodess(Treenodes treenodes, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Treenodes List实例</returns>
        IList<Treenodes> FindTreenodess(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
         /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的Treenodes List实例</returns>
        IList<Treenodes> GetAllTreenodesBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteTreenodes(Treenodes treenodes, ISqlMapper sqlMapper);
	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteTreenodesBySql(string whereSql, ISqlMapper sqlMapper);	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteTreenodess(IList<long> ids, ISqlMapper sqlMapper);
        #endregion
   	}
}
