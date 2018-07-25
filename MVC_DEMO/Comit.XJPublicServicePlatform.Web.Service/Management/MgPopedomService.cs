/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 18:56:15
** 描述：mg_popedom(权限管理
   
   )表的Service实现(自动生成 )
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
    public class MgPopedomService : IMgPopedomService
    {
    	#region 属性
        public IMapper DataMapper { get; set; }
        public IMgPopedomDao MgPopedomDao { get; set; }

        #endregion
        
        #region IMgPopedomService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>记录主键ID</returns>
        public long AddMgPopedom(HttpContextBase httpContextBase, MgPopedom mgPopedom)
        {
        	long id = 0;

            try
            {
                id = MgPopedomDao.AddMgPopedom(mgPopedom, DataMapper.Get());
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
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateMgPopedom(HttpContextBase httpContextBase, MgPopedom mgPopedom)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgPopedomDao.UpdateMgPopedom(mgPopedom, sqlMap);
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
        /// <param name="mgPopedom">查询条件，MgPopedom实例</param>
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        public IList<MgPopedom> GetMgPopedoms(HttpContextBase httpContextBase, MgPopedom mgPopedom)
        {
        	IList<MgPopedom> mgPopedoms = new List<MgPopedom>();

            try
            {
                mgPopedoms = MgPopedomDao.GetMgPopedoms(mgPopedom, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return mgPopedoms;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        public IList<MgPopedom> FindMgPopedoms(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<MgPopedom> mgPopedoms = new List<MgPopedom>();

            try
            {
                mgPopedoms = MgPopedomDao.FindMgPopedoms(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return mgPopedoms;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的MgPopedom List实例</returns>
        public IList<MgPopedom> GetAllMgPopedomBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<MgPopedom> mgPopedoms = new List<MgPopedom>();

            try
            {
                mgPopedoms = MgPopedomDao.GetAllMgPopedomBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return mgPopedoms;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mgPopedom">MgPopedom实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteMgPopedom(HttpContextBase httpContextBase, MgPopedom mgPopedom)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgPopedomDao.DeleteMgPopedom(mgPopedom,sqlMap );
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
        public int DeleteMgPopedoms(HttpContextBase httpContextBase, IList<long> ids)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgPopedomDao.DeleteMgPopedoms(ids,sqlMap );
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
        public int BatchDeleteMgPopedomBySql(HttpContextBase httpContextBase, string whereSql)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgPopedomDao.BatchDeleteMgPopedomBySql(whereSql,sqlMap );
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
