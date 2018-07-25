/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-25 14:08:57
** 描述：mg_users(用户信息
   
   登录密码：按)表的Service实现(自动生成 )
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
    public class MgUsersService : IMgUsersService
    {
    	#region 属性
        public IMapper DataMapper { get; set; }
        public IMgUsersDao MgUsersDao { get; set; }

        #endregion
        
        #region IMgUsersService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mgUsers">MgUsers实例</param>
        /// <returns>记录主键ID</returns>
        public long AddMgUsers(HttpContextBase httpContextBase, MgUsers mgUsers)
        {
            long id = 0;

            try
            {
                id = MgUsersDao.AddMgUsers(mgUsers, DataMapper.Get());
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
        /// <param name="mgUsers">MgUsers实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateMgUsers(HttpContextBase httpContextBase, MgUsers mgUsers)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgUsersDao.UpdateMgUsers(mgUsers, sqlMap);
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
        /// <param name="mgUsers">查询条件，MgUsers实例</param>
        /// <returns>满足查询条件的MgUsers List实例</returns>
        public IList<MgUsers> GetMgUserss(HttpContextBase httpContextBase, MgUsers mgUsers)
        {
        	IList<MgUsers> mgUserss = new List<MgUsers>();

            try
            {
                mgUserss = MgUsersDao.GetMgUserss(mgUsers, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return mgUserss;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的MgUsers List实例</returns>
        public IList<MgUsers> FindMgUserss(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<MgUsers> mgUserss = new List<MgUsers>();

            try
            {
                mgUserss = MgUsersDao.FindMgUserss(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return mgUserss;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的MgUsers List实例</returns>
        public IList<MgUsers> GetAllMgUsersBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<MgUsers> mgUserss = new List<MgUsers>();

            try
            {
                mgUserss = MgUsersDao.GetAllMgUsersBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return mgUserss;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mgUsers">MgUsers实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteMgUsers(HttpContextBase httpContextBase, MgUsers mgUsers)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgUsersDao.DeleteMgUsers(mgUsers,sqlMap );
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
        public int DeleteMgUserss(HttpContextBase httpContextBase, IList<long> ids)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgUsersDao.DeleteMgUserss(ids,sqlMap );
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
        public int BatchDeleteMgUsersBySql(HttpContextBase httpContextBase, string whereSql)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgUsersDao.BatchDeleteMgUsersBySql(whereSql,sqlMap );
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
