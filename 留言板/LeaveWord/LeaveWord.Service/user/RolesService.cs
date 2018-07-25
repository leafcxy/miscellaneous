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
    public class RolesService : IRolesService
    {
        #region 属性
        public IMapper DataMapper { get; set; }
        public IRolesDao RolesDao { get; set; }

        #endregion

        #region IRolesService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="roles">Roles实例</param>
        /// <returns>记录主键ID</returns>
        public int AddRoles(HttpContextBase httpContextBase, Roles roles)
        {
            int id = 0;


            try
            {
                id = RolesDao.AddRoles(roles, DataMapper.Get());
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
        /// <param name="roles">Roles实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateRoles(HttpContextBase httpContextBase, Roles roles)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = RolesDao.UpdateRoles(roles, sqlMap);
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
        /// <param name="roles">查询条件，Roles实例</param>
        /// <returns>满足查询条件的Roles List实例</returns>
        public IList<Roles> GetRoless(HttpContextBase httpContextBase, Roles roles)
        {
            IList<Roles> roless = new List<Roles>();

            try
            {
                roless = RolesDao.GetRoless(roles, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return roless;
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Roles List实例</returns>
        public int GetRolesCount(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            try
            {
                count = RolesDao.GetRolesCount(whereSql, DataMapper.Get());
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
        /// <returns>满足查询条件的Roles List实例</returns>
        public IList<Roles> FindRoless(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Roles> roless = new List<Roles>();

            try
            {
                roless = RolesDao.FindRoless(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return roless;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Roles List实例</returns>
        public IList<Roles> GetAllRolesBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<Roles> roless = new List<Roles>();

            try
            {
                roless = RolesDao.GetAllRolesBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return roless;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="roles">Roles实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteRoles(HttpContextBase httpContextBase, Roles roles)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = RolesDao.DeleteRoles(roles, sqlMap);
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
        public int DeleteRoless(HttpContextBase httpContextBase, IList<long> ids)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = RolesDao.DeleteRoless(ids, sqlMap);
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
        public int BatchDeleteRolesBySql(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = RolesDao.BatchDeleteRolesBySql(whereSql, sqlMap);
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
