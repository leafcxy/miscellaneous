using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using LeaveWord.Dao.Interface.user;
using LeaveWord.DataMapper;
using LeaveWord.Domain.user;

namespace LeaveWord.Dao.IBatis.user
{
    public class UserProfileDao : IUserProfileDao
    {
        #region 属性

        #endregion

        #region IUserProfileDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userProfile">UserProfile实例</param>
        /// <returns>记录主键ID</returns>
        public int AddUserProfile(UserProfile userProfile, ISqlMapper sqlMapper)
        {
            int id = 0;

            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("UserProfile.AddUserProfile", userProfile));
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return id;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="userProfile">UserProfile实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateUserProfile(UserProfile userProfile, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                //
                if (userProfile != null && userProfile.UserId > 0)
                {
                    count = sqlMapper.Update("UserProfile.UpdateUserProfile", userProfile);
                }
            }
            catch (Exception e)
            {
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
        public IList<UserProfile> GetUserProfiles(UserProfile userProfile, ISqlMapper sqlMapper)
        {
            IList<UserProfile> userProfiles = new List<UserProfile>();

            try
            {
                userProfiles = sqlMapper.QueryForList<UserProfile>("UserProfile.GetUserProfiles", userProfile);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return userProfiles;
        }

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        public int GetUserProfileCount(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("UserProfile.GetUserProfileCount", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return count;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的UserProfile List实例</returns>
        public IList<UserProfile> FindUserProfiles(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<UserProfile> userProfiles = new List<UserProfile>();

            try
            {
                userProfiles = sqlMapper.QueryForList<UserProfile>("UserProfile.FindUserProfiles", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return userProfiles;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的UserProfile List实例</returns>
        public IList<UserProfile> GetPageUsers(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<UserProfile> userProfiles = new List<UserProfile>();

            try
            {
                userProfiles = sqlMapper.QueryForList<UserProfile>("UserProfile.GetPageUsers", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return userProfiles;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<UserProfile> GetAllUserProfileBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<UserProfile> userProfiles = new List<UserProfile>();
            try
            {
                userProfiles = sqlMapper.QueryForList<UserProfile>("UserProfile.GetAllUserProfileBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return userProfiles;

        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userProfile">UserProfile实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteUserProfile(UserProfile userProfile, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("UserProfile.DeleteUserProfile", userProfile);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return count;
        }

        /// <summary>
        /// 根据条件语句whereSql批量删除记录
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        public int BatchDeleteUserProfileBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count = sqlMapper.Delete("UserProfile.BatchDeleteUserProfileBySql", whereSql);
            }
            catch (Exception e)
            {
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
        public int DeleteUserProfiles(IList<long> ids, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("UserProfile.DeleteUserProfiles", ids);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return count;
        }

        /// <summary>
        /// 分页：计数
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的记录数</returns>
        public int CountUserProfiles(Hashtable parameter, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("UserProfile.CountUserProfiles", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return count;
        }

        /// <summary>
        /// 分页：列表
        /// </summary>
        /// <param name="sortName">排序字段名称</param>
        /// <param name="sortOrder">排序字段方式：asc/desc</param>
        /// <param name="start">当页记录开始序号</param>
        /// <param name="limit">当页记录数</param>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的UserProfile List实例</returns>
        public IList<UserProfile> PageUserProfiles(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<UserProfile> userProfiles = new List<UserProfile>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                userProfiles = sqlMapper.QueryForList<UserProfile>("UserProfile.PageUserProfiles", param);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return userProfiles;
        }

        #endregion
    }
}
