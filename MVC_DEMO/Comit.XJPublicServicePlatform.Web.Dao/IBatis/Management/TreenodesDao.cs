/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-08-06 09:09:09
** 描述：TreeNodes(菜单节点)表的Dao实现(自动生成 )
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
    public class TreenodesDao : ITreenodesDao
    {
    	#region 属性

        #endregion
        
        #region ITreenodesDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>记录主键ID</returns>
        public long AddTreenodes(Treenodes treenodes, ISqlMapper sqlMapper)
        {
        	long id = 0;

            try
            {
                id = Convert.ToInt64(sqlMapper.Insert("Treenodes.AddTreenodes", treenodes));
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
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateTreenodes(Treenodes treenodes, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                //
                if (treenodes != null && treenodes.Id > 0) 
                {
                	count = sqlMapper.Update("Treenodes.UpdateTreenodes", treenodes);
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
        /// <param name="treenodes">查询条件，Treenodes实例</param>
        /// <returns>满足查询条件的Treenodes List实例</returns>
        public IList<Treenodes> GetTreenodess(Treenodes treenodes, ISqlMapper sqlMapper)
        {
        	IList<Treenodes> treenodess = new List<Treenodes>();

            try
            {
                treenodess = sqlMapper.QueryForList<Treenodes>("Treenodes.GetTreenodess", treenodes);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return treenodess;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Treenodes List实例</returns>
        public IList<Treenodes> FindTreenodess(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Treenodes> treenodess = new List<Treenodes>();

            try
            {
                treenodess = sqlMapper.QueryForList<Treenodes>("Treenodes.FindTreenodess", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return treenodess;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<Treenodes>  GetAllTreenodesBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<Treenodes> treenodess = new List<Treenodes>();
            try
            {
                 treenodess = sqlMapper.QueryForList<Treenodes>("Treenodes.GetAllTreenodesBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return treenodess;
            
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteTreenodes(Treenodes treenodes, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("Treenodes.DeleteTreenodes", treenodes);
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
        public int  BatchDeleteTreenodesBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count  = sqlMapper.Delete("Treenodes.BatchDeleteTreenodesBySql", whereSql);
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
        public int DeleteTreenodess(IList<long> ids, ISqlMapper sqlMapper)
        {
        	int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("Treenodes.DeleteTreenodess", ids);
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
        public int CountTreenodess(Hashtable parameter, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("Treenodes.CountTreenodess", parameter);
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
        /// <returns>满足查询条件的Treenodes List实例</returns>
        public IList<Treenodes> PageTreenodess(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
        	IList<Treenodes> treenodess = new List<Treenodes>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                treenodess = sqlMapper.QueryForList<Treenodes>("Treenodes.PageTreenodess", param);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return treenodess;
        }

        #endregion
   	}
}
