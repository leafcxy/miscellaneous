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
    public class OAuthMembershipService : IOAuthMembershipService
    {
        #region 属性
        public IMapper DataMapper { get; set; }
        public IOAuthMembershipDao OAuthMembershipDao { get; set; }

        #endregion

        #region IOAuthMembershipService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="oAuthMembership">OAuthMembership实例</param>
        /// <returns>记录主键ID</returns>
        public int AddOAuthMembership(HttpContextBase httpContextBase, OAuthMembership oAuthMembership)
        {
            int id = 0;


            try
            {
                id = OAuthMembershipDao.AddOAuthMembership(oAuthMembership, DataMapper.Get());
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
        /// <param name="oAuthMembership">OAuthMembership实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateOAuthMembership(HttpContextBase httpContextBase, OAuthMembership oAuthMembership)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = OAuthMembershipDao.UpdateOAuthMembership(oAuthMembership, sqlMap);
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
        /// <param name="oAuthMembership">查询条件，OAuthMembership实例</param>
        /// <returns>满足查询条件的OAuthMembership List实例</returns>
        public IList<OAuthMembership> GetOAuthMemberships(HttpContextBase httpContextBase, OAuthMembership oAuthMembership)
        {
            IList<OAuthMembership> oAuthMemberships = new List<OAuthMembership>();

            try
            {
                oAuthMemberships = OAuthMembershipDao.GetOAuthMemberships(oAuthMembership, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return oAuthMemberships;
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的OAuthMembership List实例</returns>
        public int GetOAuthMembershipCount(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            try
            {
                count = OAuthMembershipDao.GetOAuthMembershipCount(whereSql, DataMapper.Get());
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
        /// <returns>满足查询条件的OAuthMembership List实例</returns>
        public IList<OAuthMembership> FindOAuthMemberships(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<OAuthMembership> oAuthMemberships = new List<OAuthMembership>();

            try
            {
                oAuthMemberships = OAuthMembershipDao.FindOAuthMemberships(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return oAuthMemberships;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的OAuthMembership List实例</returns>
        public IList<OAuthMembership> GetAllOAuthMembershipBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<OAuthMembership> oAuthMemberships = new List<OAuthMembership>();

            try
            {
                oAuthMemberships = OAuthMembershipDao.GetAllOAuthMembershipBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return oAuthMemberships;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oAuthMembership">OAuthMembership实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteOAuthMembership(HttpContextBase httpContextBase, OAuthMembership oAuthMembership)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = OAuthMembershipDao.DeleteOAuthMembership(oAuthMembership, sqlMap);
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
        public int DeleteOAuthMemberships(HttpContextBase httpContextBase, IList<long> ids)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = OAuthMembershipDao.DeleteOAuthMemberships(ids, sqlMap);
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
        public int BatchDeleteOAuthMembershipBySql(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = OAuthMembershipDao.BatchDeleteOAuthMembershipBySql(whereSql, sqlMap);
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
