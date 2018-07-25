/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 18:56:15
** 描述：mg_popedom(权限管理
   
   )表的Dao实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.Management;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Management;

namespace Comit.XJPublicServicePlatform.Web.Dao.IBatis.Management
{
    public class MgPopedomDao : IMgPopedomDao
    {
    	#region 属性

        #endregion
        
        #region IMgPopedomDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>记录主键ID</returns>
        public long AddMgPopedom(MgPopedom mgPopedom, ISqlMapper sqlMapper)
        {
        	long id = 0;

            try
            {
                id = Convert.ToInt64(sqlMapper.Insert("MgPopedom.AddMgPopedom", mgPopedom));
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
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateMgPopedom(MgPopedom mgPopedom, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                //
                if (mgPopedom != null && mgPopedom.Id > 0) 
                {
                	count = sqlMapper.Update("MgPopedom.UpdateMgPopedom", mgPopedom);
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
        /// <param name="mgPopedom">查询条件，MgPopedom实例</param>
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        public IList<MgPopedom> GetMgPopedoms(MgPopedom mgPopedom, ISqlMapper sqlMapper)
        {
        	IList<MgPopedom> mgPopedoms = new List<MgPopedom>();

            try
            {
                mgPopedoms = sqlMapper.QueryForList<MgPopedom>("MgPopedom.GetMgPopedoms", mgPopedom);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return mgPopedoms;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        public IList<MgPopedom> FindMgPopedoms(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<MgPopedom> mgPopedoms = new List<MgPopedom>();

            try
            {
                mgPopedoms = sqlMapper.QueryForList<MgPopedom>("MgPopedom.FindMgPopedoms", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return mgPopedoms;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<MgPopedom>  GetAllMgPopedomBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<MgPopedom> mgPopedoms = new List<MgPopedom>();
            try
            {
                 mgPopedoms = sqlMapper.QueryForList<MgPopedom>("MgPopedom.GetAllMgPopedomBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return mgPopedoms;
            
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteMgPopedom(MgPopedom mgPopedom, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("MgPopedom.DeleteMgPopedom", mgPopedom);
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
        public int  BatchDeleteMgPopedomBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count  = sqlMapper.Delete("MgPopedom.BatchDeleteMgPopedomBySql", whereSql);
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
        public int DeleteMgPopedoms(IList<long> ids, ISqlMapper sqlMapper)
        {
        	int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("MgPopedom.DeleteMgPopedoms", ids);
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
        public int CountMgPopedoms(Hashtable parameter, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("MgPopedom.CountMgPopedoms", parameter);
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
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        public IList<MgPopedom> PageMgPopedoms(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
        	IList<MgPopedom> mgPopedoms = new List<MgPopedom>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                mgPopedoms = sqlMapper.QueryForList<MgPopedom>("MgPopedom.PageMgPopedoms", param);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return mgPopedoms;
        }

        #endregion
   	}
}
