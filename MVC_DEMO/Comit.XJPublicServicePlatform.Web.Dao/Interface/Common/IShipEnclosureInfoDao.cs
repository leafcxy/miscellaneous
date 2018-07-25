/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-31 16:32:20
** 描述：ship_enclosure_info(船舶所处围栏信息)表的Dao接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Common;

namespace Comit.XJPublicServicePlatform.Web.Dao.Interface.Common
{
    public interface IShipEnclosureInfoDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="shipEnclosureInfo">ShipEnclosureInfo实例</param>
        /// <returns>记录主键ID</returns>
        long AddShipEnclosureInfo(ShipEnclosureInfo shipEnclosureInfo, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="shipEnclosureInfo">ShipEnclosureInfo实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateShipEnclosureInfo(ShipEnclosureInfo shipEnclosureInfo, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="shipEnclosureInfo">查询条件，ShipEnclosureInfo实例</param>
        /// <returns>满足查询条件的ShipEnclosureInfo List实例</returns>
        IList<ShipEnclosureInfo> GetShipEnclosureInfos(ShipEnclosureInfo shipEnclosureInfo, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的ShipEnclosureInfo List实例</returns>
        IList<ShipEnclosureInfo> FindShipEnclosureInfos(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的ShipEnclosureInfo List实例</returns>
        IList<ShipEnclosureInfo> GetAllShipEnclosureInfoBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的ShipEnclosureInfo List实例</returns>
        IList<ShipEnclosureInfo> GetAllShipEnclosureInfoBySqlJoinShip(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的ShipEnclosureInfo 
        IList<ShipEnclosureInfo> GetAllShipEnclosureInfoBySqlAndShipName(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="shipEnclosureInfo">ShipEnclosureInfo实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteShipEnclosureInfo(ShipEnclosureInfo shipEnclosureInfo, ISqlMapper sqlMapper);
	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteShipEnclosureInfoBySql(string whereSql, ISqlMapper sqlMapper);	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteShipEnclosureInfos(IList<long> ids, ISqlMapper sqlMapper);
        #endregion
   	}
}
