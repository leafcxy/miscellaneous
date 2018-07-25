/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 17:04:57
** 描述：user_role_relate(用户和角色的关系)表的Service实现(自动生成 )
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
    public class UserRoleRelateService : IUserRoleRelateService
    {
    	#region 属性
        public IMapper DataMapper { get; set; }
        public IUserRoleRelateDao UserRoleRelateDao { get; set; }

        #endregion
        
        #region IUserRoleRelateService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userRoleRelate">UserRoleRelate实例</param>
        /// <returns>记录主键ID</returns>
        public long AddUserRoleRelate(HttpContextBase httpContextBase, UserRoleRelate userRoleRelate)
        {
        	long id = 0;

            try
            {
                id = UserRoleRelateDao.AddUserRoleRelate(userRoleRelate, DataMapper.Get());
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
        /// <param name="userRoleRelate">UserRoleRelate实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateUserRoleRelate(HttpContextBase httpContextBase, UserRoleRelate userRoleRelate)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = UserRoleRelateDao.UpdateUserRoleRelate(userRoleRelate, sqlMap);
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
        /// <param name="userRoleRelate">查询条件，UserRoleRelate实例</param>
        /// <returns>满足查询条件的UserRoleRelate List实例</returns>
        public IList<UserRoleRelate> GetUserRoleRelates(HttpContextBase httpContextBase, UserRoleRelate userRoleRelate)
        {
        	IList<UserRoleRelate> userRoleRelates = new List<UserRoleRelate>();

            try
            {
                userRoleRelates = UserRoleRelateDao.GetUserRoleRelates(userRoleRelate, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return userRoleRelates;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的UserRoleRelate List实例</returns>
        public IList<UserRoleRelate> FindUserRoleRelates(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<UserRoleRelate> userRoleRelates = new List<UserRoleRelate>();

            try
            {
                userRoleRelates = UserRoleRelateDao.FindUserRoleRelates(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return userRoleRelates;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UserRoleRelate List实例</returns>
        public IList<UserRoleRelate> GetAllUserRoleRelateBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<UserRoleRelate> userRoleRelates = new List<UserRoleRelate>();

            try
            {
                userRoleRelates = UserRoleRelateDao.GetAllUserRoleRelateBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return userRoleRelates;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UserRoleRelate List实例</returns>
        public IList<UserRoleRelate> GetAllUserRoleRelateBySql(string whereSql)
        {
            IList<UserRoleRelate> userRoleRelates = new List<UserRoleRelate>();

            try
            {
                userRoleRelates = UserRoleRelateDao.GetAllUserRoleRelateBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return userRoleRelates;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userRoleRelate">UserRoleRelate实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteUserRoleRelate(HttpContextBase httpContextBase, UserRoleRelate userRoleRelate)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = UserRoleRelateDao.DeleteUserRoleRelate(userRoleRelate,sqlMap );
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
        public int DeleteUserRoleRelates(HttpContextBase httpContextBase, IList<long> ids)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = UserRoleRelateDao.DeleteUserRoleRelates(ids,sqlMap );
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
        public int BatchDeleteUserRoleRelateBySql(HttpContextBase httpContextBase, string whereSql)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = UserRoleRelateDao.BatchDeleteUserRoleRelateBySql(whereSql,sqlMap );
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
