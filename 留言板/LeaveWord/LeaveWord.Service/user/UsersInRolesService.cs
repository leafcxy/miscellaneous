using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using LeaveWord.DataMapper;
using IBatisNet.DataMapper;
using LeaveWord.Dao.Interface.user;
using LeaveWord.Domain.user;
using LeaveWord.Service.user.Interface;

namespace LeaveWord.Service.user
{
    public class UsersInRolesService : IUsersInRolesService
    {
        #region 属性
        public IMapper DataMapper { get; set; }
        public IUsersInRolesDao UsersInRolesDao { get; set; }

        #endregion

        #region IUsersInRolesService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>记录主键ID</returns>
        public int AddUsersInRoles(HttpContextBase httpContextBase, UsersInRoles usersInRoles)
        {
            int id = 0;


            try
            {
                id = UsersInRolesDao.AddUsersInRoles(usersInRoles, DataMapper.Get());
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
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateUsersInRoles(HttpContextBase httpContextBase, UsersInRoles usersInRoles)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = UsersInRolesDao.UpdateUsersInRoles(usersInRoles, sqlMap);
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
        /// <param name="usersInRoles">查询条件，UsersInRoles实例</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        public IList<UsersInRoles> GetUsersInRoless(HttpContextBase httpContextBase, UsersInRoles usersInRoles)
        {
            IList<UsersInRoles> usersInRoless = new List<UsersInRoles>();

            try
            {
                usersInRoless = UsersInRolesDao.GetUsersInRoless(usersInRoles, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return usersInRoless;
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        public int GetUsersInRolesCount(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            try
            {
                count = UsersInRolesDao.GetUsersInRolesCount(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return count;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        public IList<UsersInRoles> FindUsersInRoless(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<UsersInRoles> usersInRoless = new List<UsersInRoles>();

            try
            {
                usersInRoless = UsersInRolesDao.FindUsersInRoless(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return usersInRoless;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        public IList<UsersInRoles> GetAllUsersInRolesBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<UsersInRoles> usersInRoless = new List<UsersInRoles>();

            try
            {
                usersInRoless = UsersInRolesDao.GetAllUsersInRolesBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return usersInRoless;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteUsersInRoles(HttpContextBase httpContextBase, UsersInRoles usersInRoles)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = UsersInRolesDao.DeleteUsersInRoles(usersInRoles, sqlMap);
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
        public int DeleteUsersInRoless(HttpContextBase httpContextBase, IList<long> ids)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = UsersInRolesDao.DeleteUsersInRoless(ids, sqlMap);
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
        public int BatchDeleteUsersInRolesBySql(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = UsersInRolesDao.BatchDeleteUsersInRolesBySql(whereSql, sqlMap);
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
