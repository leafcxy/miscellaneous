/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-31 16:32:19
** 描述：io_enclosure_history(进出围栏记录表)表的Dao接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Common;

namespace Comit.XJPublicServicePlatform.Web.Dao.Interface.Common
{
    public interface IIoEnclosureHistoryDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ioEnclosureHistory">IoEnclosureHistory实例</param>
        /// <returns>记录主键ID</returns>
        long AddIoEnclosureHistory(IoEnclosureHistory ioEnclosureHistory, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ioEnclosureHistory">IoEnclosureHistory实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateIoEnclosureHistory(IoEnclosureHistory ioEnclosureHistory, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="ioEnclosureHistory">查询条件，IoEnclosureHistory实例</param>
        /// <returns>满足查询条件的IoEnclosureHistory List实例</returns>
        IList<IoEnclosureHistory> GetIoEnclosureHistorys(IoEnclosureHistory ioEnclosureHistory, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的IoEnclosureHistory List实例</returns>
        IList<IoEnclosureHistory> FindIoEnclosureHistorys(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
         /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的IoEnclosureHistory List实例</returns>
        IList<IoEnclosureHistory> GetAllIoEnclosureHistoryBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的IoEnclosureHistory List实例</returns>
        int GetIoEnclosureHistoryCountBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ioEnclosureHistory">IoEnclosureHistory实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteIoEnclosureHistory(IoEnclosureHistory ioEnclosureHistory, ISqlMapper sqlMapper);
	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteIoEnclosureHistoryBySql(string whereSql, ISqlMapper sqlMapper);	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteIoEnclosureHistorys(IList<long> ids, ISqlMapper sqlMapper);
        #endregion

        IList<IoEnclosureHistory> GetInEnclosureSort(Hashtable HT, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的IoEnclosureHistory 
        IList<IoEnclosureHistory> GetAllIoEnclosureHistoryBySqlAndShipName(string whereSql, ISqlMapper sqlMapper);

        IList<IoEnclosureHistory> GetIoEnclosureHistorysThroughNB(string whereSql, ISqlMapper sqlMapper);


        IList<IoEnclosureHistory> ShipInEnclosureSearch(Hashtable HT, ISqlMapper sqlMapper);
   	}
}
