/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-23 09:53:09
** 描述：codemapdesc(数据字典)表的Service实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.Common;
using Comit.XJPublicServicePlatform.Web.Domain.Common;
using Comit.XJPublicServicePlatform.Web.Service.Common.Interface;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using IBatisNet.DataMapper;

namespace Comit.XJPublicServicePlatform.Web.Service.Common
{
    public class CodemapdescService : ICodemapdescService
    {
    	#region 属性
        public IMapper DataMapper { get; set; }
        public ICodemapdescDao CodemapdescDao { get; set; }

        #endregion
        
        #region ICodemapdescService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>记录主键ID</returns>
        public int AddCodemapdesc(HttpContextBase httpContextBase, Codemapdesc codemapdesc)
        {
        	int id = 0;

            try
            {
                id = CodemapdescDao.AddCodemapdesc(codemapdesc, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return id;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateCodemapdesc(HttpContextBase httpContextBase, Codemapdesc codemapdesc)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = CodemapdescDao.UpdateCodemapdesc(codemapdesc, sqlMap);
                // 提交事务
                  sqlMap.CommitTransaction();
            }
            catch (Exception e)
            {
                // 回滚事务
                  sqlMap.RollBackTransaction();
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
        public IList<Codemapdesc> GetCodemapdescs(HttpContextBase httpContextBase, Codemapdesc codemapdesc)
        {
        	IList<Codemapdesc> codemapdescs = new List<Codemapdesc>();

            try
            {
                codemapdescs = CodemapdescDao.GetCodemapdescs(codemapdesc, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return codemapdescs;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        public IList<Codemapdesc> FindCodemapdescs(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Codemapdesc> codemapdescs = new List<Codemapdesc>();

            try
            {
                codemapdescs = CodemapdescDao.FindCodemapdescs(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return codemapdescs;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        //public IList<Codemapdesc> GetAllCodemapdescBySql(HttpContextBase httpContextBase, string whereSql)
        //{
        //    IList<Codemapdesc> codemapdescs = new List<Codemapdesc>();

        //    try
        //    {
        //        codemapdescs = CodemapdescDao.GetAllCodemapdescBySql(whereSql, DataMapper.Get());
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //    return codemapdescs;
        //}

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        public IList<Codemapdesc> GetAllCodemapdescBySql(string whereSql)
        {
            IList<Codemapdesc> codemapdescs = new List<Codemapdesc>();

            try
            {
                codemapdescs = CodemapdescDao.GetAllCodemapdescBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return codemapdescs;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteCodemapdesc(HttpContextBase httpContextBase, Codemapdesc codemapdesc)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = CodemapdescDao.DeleteCodemapdesc(codemapdesc,sqlMap );
                // 提交事务
                  sqlMap.CommitTransaction();
            }
            catch (Exception e)
            {
                // 回滚事务
                  sqlMap.RollBackTransaction();
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
        public int DeleteCodemapdescs(HttpContextBase httpContextBase, IList<int> ids)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = CodemapdescDao.DeleteCodemapdescs(ids,sqlMap );
                // 提交事务
                  sqlMap.CommitTransaction();
            }
            catch (Exception e)
            {
                // 回滚事务
                  sqlMap.RollBackTransaction();
                // 抛出异常
                  throw e;
            }
            return count;
        }

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        public int BatchDeleteCodemapdescBySql(HttpContextBase httpContextBase, string whereSql)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = CodemapdescDao.BatchDeleteCodemapdescBySql(whereSql,sqlMap );
                // 提交事务
                  sqlMap.CommitTransaction();
            }
            catch (Exception e)
            {
                // 回滚事务
                  sqlMap.RollBackTransaction();
                // 抛出异常
                  throw e;
            }
            return count;
        }

        public IList<Codemapdesc> GetSelectsInfo(string idName, string selectValue, HttpContextBase httpContextBase)
        {
            Hashtable parameter = new Hashtable();
            parameter["Id"] = idName;
            IList<Codemapdesc> codemapdescList = FindCodemapdescs(httpContextBase, parameter);

            return codemapdescList;
        }

        #endregion
   	}
}
