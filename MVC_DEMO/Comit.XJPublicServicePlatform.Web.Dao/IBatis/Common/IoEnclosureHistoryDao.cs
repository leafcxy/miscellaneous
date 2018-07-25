/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-31 16:32:19
** 描述：io_enclosure_history(进出围栏记录表)表的Dao实现(自动生成 )
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
    public class IoEnclosureHistoryDao : IIoEnclosureHistoryDao
    {
    	#region 属性

        #endregion
        
        #region IIoEnclosureHistoryDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ioEnclosureHistory">IoEnclosureHistory实例</param>
        /// <returns>记录主键ID</returns>
        public long AddIoEnclosureHistory(IoEnclosureHistory ioEnclosureHistory, ISqlMapper sqlMapper)
        {
        	long id = 0;

            try
            {
                id = Convert.ToInt64(sqlMapper.Insert("IoEnclosureHistory.AddIoEnclosureHistory", ioEnclosureHistory));
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
        /// <param name="ioEnclosureHistory">IoEnclosureHistory实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateIoEnclosureHistory(IoEnclosureHistory ioEnclosureHistory, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                //
                if (ioEnclosureHistory != null && ioEnclosureHistory.Id > 0) 
                {
                	count = sqlMapper.Update("IoEnclosureHistory.UpdateIoEnclosureHistory", ioEnclosureHistory);
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
        /// <param name="ioEnclosureHistory">查询条件，IoEnclosureHistory实例</param>
        /// <returns>满足查询条件的IoEnclosureHistory List实例</returns>
        public IList<IoEnclosureHistory> GetIoEnclosureHistorys(IoEnclosureHistory ioEnclosureHistory, ISqlMapper sqlMapper)
        {
        	IList<IoEnclosureHistory> ioEnclosureHistorys = new List<IoEnclosureHistory>();

            try
            {
                ioEnclosureHistorys = sqlMapper.QueryForList<IoEnclosureHistory>("IoEnclosureHistory.GetIoEnclosureHistorys", ioEnclosureHistory);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return ioEnclosureHistorys;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的IoEnclosureHistory List实例</returns>
        public IList<IoEnclosureHistory> FindIoEnclosureHistorys(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<IoEnclosureHistory> ioEnclosureHistorys = new List<IoEnclosureHistory>();

            try
            {
                ioEnclosureHistorys = sqlMapper.QueryForList<IoEnclosureHistory>("IoEnclosureHistory.FindIoEnclosureHistorys", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return ioEnclosureHistorys;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<IoEnclosureHistory>  GetAllIoEnclosureHistoryBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<IoEnclosureHistory> ioEnclosureHistorys = new List<IoEnclosureHistory>();
            try
            {
                 ioEnclosureHistorys = sqlMapper.QueryForList<IoEnclosureHistory>("IoEnclosureHistory.GetAllIoEnclosureHistoryBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return ioEnclosureHistorys;
            
        }

        public int GetIoEnclosureHistoryCountBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int Count = 0;
            try
            {
                Count = sqlMapper.QueryForObject<int>("IoEnclosureHistory.GetIoEnclosureHistoryCountBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return Count;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ioEnclosureHistory">IoEnclosureHistory实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteIoEnclosureHistory(IoEnclosureHistory ioEnclosureHistory, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("IoEnclosureHistory.DeleteIoEnclosureHistory", ioEnclosureHistory);
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
        public int  BatchDeleteIoEnclosureHistoryBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count  = sqlMapper.Delete("IoEnclosureHistory.BatchDeleteIoEnclosureHistoryBySql", whereSql);
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
        public int DeleteIoEnclosureHistorys(IList<long> ids, ISqlMapper sqlMapper)
        {
        	int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("IoEnclosureHistory.DeleteIoEnclosureHistorys", ids);
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
        public int CountIoEnclosureHistorys(Hashtable parameter, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("IoEnclosureHistory.CountIoEnclosureHistorys", parameter);
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
        /// <returns>满足查询条件的IoEnclosureHistory List实例</returns>
        public IList<IoEnclosureHistory> PageIoEnclosureHistorys(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
        	IList<IoEnclosureHistory> ioEnclosureHistorys = new List<IoEnclosureHistory>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                ioEnclosureHistorys = sqlMapper.QueryForList<IoEnclosureHistory>("IoEnclosureHistory.PageIoEnclosureHistorys", param);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return ioEnclosureHistorys;
        }

        #endregion

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</
        public IList<IoEnclosureHistory> GetAllIoEnclosureHistoryBySqlAndShipName(string whereSql, ISqlMapper sqlMapper)
        {
            IList<IoEnclosureHistory> IoEnclosureHistorys = new List<IoEnclosureHistory>();
            try
            {
                IoEnclosureHistorys = sqlMapper.QueryForList<IoEnclosureHistory>("IoEnclosureHistory.GetAllIoEnclosureHistoryBySqlAndShipName", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }
            return IoEnclosureHistorys;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</
        public IList<IoEnclosureHistory> GetInEnclosureSort(Hashtable HT, ISqlMapper sqlMapper)
        {
            IList<IoEnclosureHistory> IoEnclosureHistorys = new List<IoEnclosureHistory>();
            try
            {
                IoEnclosureHistorys = sqlMapper.QueryForList<IoEnclosureHistory>("IoEnclosureHistory.GetInEnclosureSort", HT);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }
            return IoEnclosureHistorys;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</
        public IList<IoEnclosureHistory> ShipInEnclosureSearch(Hashtable HT, ISqlMapper sqlMapper)
        {
            IList<IoEnclosureHistory> IoEnclosureHistorys = new List<IoEnclosureHistory>();
            try
            {
                IoEnclosureHistorys = sqlMapper.QueryForList<IoEnclosureHistory>("IoEnclosureHistory.ShipInEnclosureSearch", HT);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }
            return IoEnclosureHistorys;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</
        public IList<IoEnclosureHistory> GetIoEnclosureHistorysThroughNB(string whereSql, ISqlMapper sqlMapper)
        {
            IList<IoEnclosureHistory> IoEnclosureHistorys = new List<IoEnclosureHistory>();
            try
            {
                IoEnclosureHistorys = sqlMapper.QueryForList<IoEnclosureHistory>("IoEnclosureHistory.GetIoEnclosureHistorysThroughNB", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }
            return IoEnclosureHistorys;
        }
   	}
}
