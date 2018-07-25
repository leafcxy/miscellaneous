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
    public class MembershipService : IMembershipService
    {
        #region 属性
        public IMapper DataMapper { get; set; }
        public IMembershipDao MembershipDao { get; set; }

        #endregion

        #region IMembershipService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="membership">Membership实例</param>
        /// <returns>记录主键ID</returns>
        public int AddMembership(HttpContextBase httpContextBase, Membership membership)
        {
            int id = 0;


            try
            {
                id = MembershipDao.AddMembership(membership, DataMapper.Get());
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
        /// <param name="membership">Membership实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateMembership(HttpContextBase httpContextBase, Membership membership)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = MembershipDao.UpdateMembership(membership, sqlMap);
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
        /// <param name="membership">查询条件，Membership实例</param>
        /// <returns>满足查询条件的Membership List实例</returns>
        public IList<Membership> GetMemberships(HttpContextBase httpContextBase, Membership membership)
        {
            IList<Membership> memberships = new List<Membership>();

            try
            {
                memberships = MembershipDao.GetMemberships(membership, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return memberships;
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Membership List实例</returns>
        public int GetMembershipCount(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            try
            {
                count = MembershipDao.GetMembershipCount(whereSql, DataMapper.Get());
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
        /// <returns>满足查询条件的Membership List实例</returns>
        public IList<Membership> FindMemberships(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Membership> memberships = new List<Membership>();

            try
            {
                memberships = MembershipDao.FindMemberships(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return memberships;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Membership List实例</returns>
        public IList<Membership> GetAllMembershipBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<Membership> memberships = new List<Membership>();

            try
            {
                memberships = MembershipDao.GetAllMembershipBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return memberships;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="membership">Membership实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteMembership(HttpContextBase httpContextBase, Membership membership)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = MembershipDao.DeleteMembership(membership, sqlMap);
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
        public int DeleteMemberships(HttpContextBase httpContextBase, IList<long> ids)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = MembershipDao.DeleteMemberships(ids, sqlMap);
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
        public int BatchDeleteMembershipBySql(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = MembershipDao.BatchDeleteMembershipBySql(whereSql, sqlMap);
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
