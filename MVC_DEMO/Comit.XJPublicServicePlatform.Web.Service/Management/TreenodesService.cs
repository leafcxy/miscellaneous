/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-08-06 09:09:09
** 描述：TreeNodes(菜单节点)表的Service实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Dao.IBatis.Common;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.Management;
using Comit.XJPublicServicePlatform.Web.Domain.Management;
using Comit.XJPublicServicePlatform.Web.Service.Management.Interface;

namespace Comit.XJPublicServicePlatform.Web.Service.Management
{
    public class TreenodesService : ITreenodesService
    {
    	#region 属性
        public IMapper DataMapper { get; set; }
        public ITreenodesDao TreenodesDao { get; set; }

        #endregion
        
        #region ITreenodesService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>记录主键ID</returns>
        public long AddTreenodes(HttpContextBase httpContextBase, Treenodes treenodes)
        {
        	long  id = 0;

            try
            {
                id = TreenodesDao.AddTreenodes(treenodes, DataMapper.Get());
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
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateTreenodes(HttpContextBase httpContextBase, Treenodes treenodes)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = TreenodesDao.UpdateTreenodes(treenodes, sqlMap);
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
        /// <param name="treenodes">查询条件，Treenodes实例</param>
        /// <returns>满足查询条件的Treenodes List实例</returns>
        public IList<Treenodes> GetTreenodess(HttpContextBase httpContextBase, Treenodes treenodes)
        {
        	IList<Treenodes> treenodess = new List<Treenodes>();

            try
            {
                treenodess = TreenodesDao.GetTreenodess(treenodes, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return treenodess;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Treenodes List实例</returns>
        public IList<Treenodes> FindTreenodess(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Treenodes> treenodess = new List<Treenodes>();

            try
            {
                treenodess = TreenodesDao.FindTreenodess(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return treenodess;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Treenodes List实例</returns>
        public IList<Treenodes> GetAllTreenodesBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<Treenodes> treenodess = new List<Treenodes>();

            try
            {
                treenodess = TreenodesDao.GetAllTreenodesBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return treenodess;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="treenodes">Treenodes实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteTreenodes(HttpContextBase httpContextBase, Treenodes treenodes)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = TreenodesDao.DeleteTreenodes(treenodes,sqlMap );
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
        public int DeleteTreenodess(HttpContextBase httpContextBase, IList<long> ids)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = TreenodesDao.DeleteTreenodess(ids,sqlMap );
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
        public int BatchDeleteTreenodesBySql(HttpContextBase httpContextBase, string whereSql)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = TreenodesDao.BatchDeleteTreenodesBySql(whereSql,sqlMap );
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



        #endregion
   	}
}
