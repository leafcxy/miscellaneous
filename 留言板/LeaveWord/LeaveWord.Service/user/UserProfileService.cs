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
    public class UserProfileService : IUserProfileService
    {
        #region 属性
        public IMapper DataMapper { get; set; }
        public IUserProfileDao UserProfileDao { get; set; }

        #endregion

        #region IUserProfileService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userProfile">UserProfile实例</param>
        /// <returns>记录主键ID</returns>
        public int AddUserProfile(HttpContextBase httpContextBase, UserProfile userProfile)
        {
            int id = 0;


            try
            {
                id = UserProfileDao.AddUserProfile(userProfile, DataMapper.Get());
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
        /// <param name="userProfile">UserProfile实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateUserProfile(HttpContextBase httpContextBase, UserProfile userProfile)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = UserProfileDao.UpdateUserProfile(userProfile, sqlMap);
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
        /// <param name="userProfile">查询条件，UserProfile实例</param>
        /// <returns>满足查询条件的UserProfile List实例</returns>
        public IList<UserProfile> GetUserProfiles(HttpContextBase httpContextBase, UserProfile userProfile)
        {
            IList<UserProfile> userProfiles = new List<UserProfile>();

            try
            {
                userProfiles = UserProfileDao.GetUserProfiles(userProfile, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return userProfiles;
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UserProfile List实例</returns>
        public int GetUserProfileCount(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            try
            {
                count = UserProfileDao.GetUserProfileCount(whereSql, DataMapper.Get());
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
        /// <returns>满足查询条件的UserProfile List实例</returns>
        public IList<UserProfile> FindUserProfiles(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<UserProfile> userProfiles = new List<UserProfile>();

            try
            {
                userProfiles = UserProfileDao.FindUserProfiles(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return userProfiles;
        }

        public IList<UserProfile> GetPageUsers(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<UserProfile> userProfiles = new List<UserProfile>();

            try
            {
                userProfiles = UserProfileDao.GetPageUsers(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return userProfiles;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的UserProfile List实例</returns>
        public IList<UserProfile> GetAllUserProfileBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<UserProfile> userProfiles = new List<UserProfile>();

            try
            {
                userProfiles = UserProfileDao.GetAllUserProfileBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return userProfiles;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userProfile">UserProfile实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteUserProfile(HttpContextBase httpContextBase, UserProfile userProfile)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = UserProfileDao.DeleteUserProfile(userProfile, sqlMap);
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
        public int DeleteUserProfiles(HttpContextBase httpContextBase, IList<long> ids)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = UserProfileDao.DeleteUserProfiles(ids, sqlMap);
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
        public int BatchDeleteUserProfileBySql(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = UserProfileDao.BatchDeleteUserProfileBySql(whereSql, sqlMap);
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
