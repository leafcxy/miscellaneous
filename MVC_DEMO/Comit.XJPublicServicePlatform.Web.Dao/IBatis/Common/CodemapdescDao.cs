/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-23 09:53:09
** 描述：codemapdesc(数据字典)表的Dao实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.Common;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Common;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;

namespace Comit.XJPublicServicePlatform.Web.Dao.IBatis.Common
{
    public class CodemapdescDao : ICodemapdescDao
    {
    	#region 属性

        #endregion
        
        #region ICodemapdescDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>记录主键ID</returns>
        public int AddCodemapdesc(Codemapdesc codemapdesc, ISqlMapper sqlMapper)
        {
        	int id = 0;

            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("Codemapdesc.AddCodemapdesc", codemapdesc));
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
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateCodemapdesc(Codemapdesc codemapdesc, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                //
                if (codemapdesc != null && codemapdesc.CodemapdescId > 0) 
                {
                	count = sqlMapper.Update("Codemapdesc.UpdateCodemapdesc", codemapdesc);
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
        /// <param name="codemapdesc">查询条件，Codemapdesc实例</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        public IList<Codemapdesc> GetCodemapdescs(Codemapdesc codemapdesc, ISqlMapper sqlMapper)
        {
        	IList<Codemapdesc> codemapdescs = new List<Codemapdesc>();

            try
            {
                codemapdescs = sqlMapper.QueryForList<Codemapdesc>("Codemapdesc.GetCodemapdescs", codemapdesc);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return codemapdescs;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        public IList<Codemapdesc> FindCodemapdescs(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Codemapdesc> codemapdescs = new List<Codemapdesc>();

            try
            {
                codemapdescs = sqlMapper.QueryForList<Codemapdesc>("Codemapdesc.FindCodemapdescs", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return codemapdescs;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<Codemapdesc>  GetAllCodemapdescBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<Codemapdesc> codemapdescs = new List<Codemapdesc>();
            try
            {
                 codemapdescs = sqlMapper.QueryForList<Codemapdesc>("Codemapdesc.GetAllCodemapdescBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return codemapdescs;
            
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteCodemapdesc(Codemapdesc codemapdesc, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                // 删除部门
                count = sqlMapper.Delete("Codemapdesc.DeleteCodemapdesc", codemapdesc);
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
        public int  BatchDeleteCodemapdescBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count  = sqlMapper.Delete("Codemapdesc.BatchDeleteCodemapdescBySql", whereSql);
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
        public int DeleteCodemapdescs(IList<int> ids, ISqlMapper sqlMapper)
        {
        	int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("Codemapdesc.DeleteCodemapdescs", ids);
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
        public int CountCodemapdescs(Hashtable parameter, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("Codemapdesc.CountCodemapdescs", parameter);
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
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        public IList<Codemapdesc> PageCodemapdescs(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
        	IList<Codemapdesc> codemapdescs = new List<Codemapdesc>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                codemapdescs = sqlMapper.QueryForList<Codemapdesc>("Codemapdesc.PageCodemapdescs", param);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return codemapdescs;
        }

        #endregion
   	}
}
