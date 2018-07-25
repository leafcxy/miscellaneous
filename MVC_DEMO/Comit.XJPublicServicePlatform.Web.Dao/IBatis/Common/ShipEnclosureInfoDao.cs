/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-31 16:32:20
** 描述：ship_enclosure_info(船舶所处围栏信息)表的Dao实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.Common;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Common;

namespace Comit.XJPublicServicePlatform.Web.Dao.IBatis.Common
{
    public class ShipEnclosureInfoDao : IShipEnclosureInfoDao
    {
    	#region 属性
        private static ShipEnclosureInfoDao shipEnclosureInfoDao;

        /// <summary>
        /// 以单态的形式返回dao
        /// </summary>
        /// <returns></returns>
        public static ShipEnclosureInfoDao GetDao()
        {
            if (shipEnclosureInfoDao == null)
                shipEnclosureInfoDao = new ShipEnclosureInfoDao();

            return shipEnclosureInfoDao;
        }
        #endregion
        
        #region IShipEnclosureInfoDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="shipEnclosureInfo">ShipEnclosureInfo实例</param>
        /// <returns>记录主键ID</returns>
        public long AddShipEnclosureInfo(ShipEnclosureInfo shipEnclosureInfo, ISqlMapper sqlMapper)
        {
        	long id = 0;

            try
            {
                id = Convert.ToInt64(sqlMapper.Insert("ShipEnclosureInfo.AddShipEnclosureInfo", shipEnclosureInfo));
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return id;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="shipEnclosureInfo">ShipEnclosureInfo实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateShipEnclosureInfo(ShipEnclosureInfo shipEnclosureInfo, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                //
                if (shipEnclosureInfo != null && shipEnclosureInfo.Id > 0) 
                {
                	count = sqlMapper.Update("ShipEnclosureInfo.UpdateShipEnclosureInfo", shipEnclosureInfo);
                }
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return count;
        }
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="shipEnclosureInfo">查询条件，ShipEnclosureInfo实例</param>
        /// <returns>满足查询条件的ShipEnclosureInfo List实例</returns>
        public IList<ShipEnclosureInfo> GetShipEnclosureInfos(ShipEnclosureInfo shipEnclosureInfo, ISqlMapper sqlMapper)
        {
        	IList<ShipEnclosureInfo> shipEnclosureInfos = new List<ShipEnclosureInfo>();

            try
            {
                shipEnclosureInfos = sqlMapper.QueryForList<ShipEnclosureInfo>("ShipEnclosureInfo.GetShipEnclosureInfos", shipEnclosureInfo);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return shipEnclosureInfos;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的ShipEnclosureInfo List实例</returns>
        public IList<ShipEnclosureInfo> FindShipEnclosureInfos(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<ShipEnclosureInfo> shipEnclosureInfos = new List<ShipEnclosureInfo>();

            try
            {
                shipEnclosureInfos = sqlMapper.QueryForList<ShipEnclosureInfo>("ShipEnclosureInfo.FindShipEnclosureInfos", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return shipEnclosureInfos;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<ShipEnclosureInfo>  GetAllShipEnclosureInfoBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<ShipEnclosureInfo> shipEnclosureInfos = new List<ShipEnclosureInfo>();
            try
            {
                 shipEnclosureInfos = sqlMapper.QueryForList<ShipEnclosureInfo>("ShipEnclosureInfo.GetAllShipEnclosureInfoBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return shipEnclosureInfos;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<ShipEnclosureInfo> GetAllShipEnclosureInfoBySqlJoinShip(string whereSql, ISqlMapper sqlMapper)
        {
            IList<ShipEnclosureInfo> shipEnclosureInfos = new List<ShipEnclosureInfo>();
            try
            {
                shipEnclosureInfos = sqlMapper.QueryForList<ShipEnclosureInfo>("ShipEnclosureInfo.GetAllShipEnclosureInfoBySqlJoinShip", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return shipEnclosureInfos;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</
        public IList<ShipEnclosureInfo> GetAllShipEnclosureInfoBySqlAndShipName(string whereSql, ISqlMapper sqlMapper)
        {
            IList<ShipEnclosureInfo> shipEnclosureInfos = new List<ShipEnclosureInfo>();
            try
            {
                shipEnclosureInfos = sqlMapper.QueryForList<ShipEnclosureInfo>("ShipEnclosureInfo.GetAllShipEnclosureInfoBySqlAndShipName", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }
            return shipEnclosureInfos;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="shipEnclosureInfo">ShipEnclosureInfo实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteShipEnclosureInfo(ShipEnclosureInfo shipEnclosureInfo, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("ShipEnclosureInfo.DeleteShipEnclosureInfo", shipEnclosureInfo);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return count;
        }

        /// <summary>
        /// 根据条件语句whereSql批量删除记录
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        public int  BatchDeleteShipEnclosureInfoBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count  = sqlMapper.Delete("ShipEnclosureInfo.BatchDeleteShipEnclosureInfoBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }
            return count;
        }

		
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteShipEnclosureInfos(IList<long> ids, ISqlMapper sqlMapper)
        {
        	int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("ShipEnclosureInfo.DeleteShipEnclosureInfos", ids);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return count;
        }

        /// <summary>
        /// 分页：计数
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的记录数</returns>
        public int CountShipEnclosureInfos(Hashtable parameter, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("ShipEnclosureInfo.CountShipEnclosureInfos", parameter);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return count;
        }

        /// <summary>
        /// 分页：列表
        /// </summary>
        /// <param name="sortName">排序字段名称</param>
        /// <param name="sortOrder">排序字段方式：asc/desc</param>
        /// <param name="start">当页记录开始序号</param>
        /// <param name="limit">当页记录数</param>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的ShipEnclosureInfo List实例</returns>
        public IList<ShipEnclosureInfo> PageShipEnclosureInfos(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
        	IList<ShipEnclosureInfo> shipEnclosureInfos = new List<ShipEnclosureInfo>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                shipEnclosureInfos = sqlMapper.QueryForList<ShipEnclosureInfo>("ShipEnclosureInfo.PageShipEnclosureInfos", param);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return shipEnclosureInfos;
        }

        #endregion
   	}
}
