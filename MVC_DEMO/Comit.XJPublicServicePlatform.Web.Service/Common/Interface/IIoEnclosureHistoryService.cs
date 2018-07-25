/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-31 16:32:19
** 描述：io_enclosure_history(进出围栏记录表)表的Service接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Domain.Common;

namespace Comit.XJPublicServicePlatform.Web.Service.Common.Interface
{
    public interface IIoEnclosureHistoryService
    {
        #region 成员

        IList<IoEnclosureHistory> GetListConsume(HttpContextBase httpContextBase);
        void StartConsume();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ioEnclosureHistory">IoEnclosureHistory实例</param>
        /// <returns>记录主键ID</returns>
        long AddIoEnclosureHistory(HttpContextBase httpContextBase, IoEnclosureHistory ioEnclosureHistory);

        IList<IoEnclosureHistory> GetIoEnclosureHistorysThroughNB(HttpContextBase httpContextBase, string whereSql);
        IList<IoEnclosureHistory> GetIoEnclosureHistorysThroughNB(string whereSql);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ioEnclosureHistory">IoEnclosureHistory实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateIoEnclosureHistory(HttpContextBase httpContextBase, IoEnclosureHistory ioEnclosureHistory);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="ioEnclosureHistory">查询条件，IoEnclosureHistory实例</param>
        /// <returns>满足查询条件的IoEnclosureHistory List实例</returns>
        IList<IoEnclosureHistory> GetIoEnclosureHistorys(HttpContextBase httpContextBase, IoEnclosureHistory ioEnclosureHistory);
		
		/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的IoEnclosureHistory List实例</returns>
        IList<IoEnclosureHistory> FindIoEnclosureHistorys(HttpContextBase httpContextBase, Hashtable parameter);
        
 	    /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的IoEnclosureHistory List实例</returns>
        IList<IoEnclosureHistory> GetAllIoEnclosureHistoryBySql(HttpContextBase httpContextBase, string whereSql);

        /// 获取数量
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的IoEnclosureHistory List实例</returns>
        int GetIoEnclosureHistoryCountBySql(HttpContextBase httpContextBase, string whereSql);

        
       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ioEnclosureHistory">IoEnclosureHistory实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteIoEnclosureHistory(HttpContextBase httpContextBase, IoEnclosureHistory ioEnclosureHistory);
		
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteIoEnclosureHistorys(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteIoEnclosureHistoryBySql(HttpContextBase httpContextBase, string whereSql);


		
        #endregion
        IList<IoEnclosureHistory> GetInEnclosureSort(HttpContextBase httpContextBase, Hashtable HT);

        IList<IoEnclosureHistory> ShipInEnclosureSearch(HttpContextBase httpContextBase, Hashtable HT);
        IList<IoEnclosureHistory> GetAllIoEnclosureHistoryBySqlAndShipName(string whereSql);
   	}
}
