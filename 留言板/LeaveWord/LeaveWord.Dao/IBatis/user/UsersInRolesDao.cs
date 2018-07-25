using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using LeaveWord.Dao.Interface.user;
using LeaveWord.DataMapper;
using LeaveWord.Domain.user;

namespace LeaveWord.Dao.IBatis.user
{
    public class UsersInRolesDao : IUsersInRolesDao
    {
        #region 属性

        #endregion

        #region IUsersInRolesDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>记录主键ID</returns>
        public int AddUsersInRoles(UsersInRoles usersInRoles, ISqlMapper sqlMapper)
        {
            int id = 0;

            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("UsersInRoles.AddUsersInRoles", usersInRoles));
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
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateUsersInRoles(UsersInRoles usersInRoles, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                //
                if (usersInRoles != null && usersInRoles.UserId > 0)
                {
                    count = sqlMapper.Update("UsersInRoles.UpdateUsersInRoles", usersInRoles);
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
        /// <param name="usersInRoles">查询条件，UsersInRoles实例</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        public IList<UsersInRoles> GetUsersInRoless(UsersInRoles usersInRoles, ISqlMapper sqlMapper)
        {
            IList<UsersInRoles> usersInRoless = new List<UsersInRoles>();

            try
            {
                usersInRoless = sqlMapper.QueryForList<UsersInRoles>("UsersInRoles.GetUsersInRoless", usersInRoles);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return usersInRoless;
        }

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        public int GetUsersInRolesCount(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("UsersInRoles.GetUsersInRolesCount", whereSql);
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
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        public IList<UsersInRoles> FindUsersInRoless(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<UsersInRoles> usersInRoless = new List<UsersInRoles>();

            try
            {
                usersInRoless = sqlMapper.QueryForList<UsersInRoles>("UsersInRoles.FindUsersInRoless", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return usersInRoless;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<UsersInRoles> GetAllUsersInRolesBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<UsersInRoles> usersInRoless = new List<UsersInRoles>();
            try
            {
                usersInRoless = sqlMapper.QueryForList<UsersInRoles>("UsersInRoles.GetAllUsersInRolesBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return usersInRoless;

        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteUsersInRoles(UsersInRoles usersInRoles, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("UsersInRoles.DeleteUsersInRoles", usersInRoles);
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
        public int BatchDeleteUsersInRolesBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count = sqlMapper.Delete("UsersInRoles.BatchDeleteUsersInRolesBySql", whereSql);
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
        public int DeleteUsersInRoless(IList<long> ids, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("UsersInRoles.DeleteUsersInRoless", ids);
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
        public int CountUsersInRoless(Hashtable parameter, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("UsersInRoles.CountUsersInRoless", parameter);
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
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        public IList<UsersInRoles> PageUsersInRoless(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<UsersInRoles> usersInRoless = new List<UsersInRoles>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                usersInRoless = sqlMapper.QueryForList<UsersInRoles>("UsersInRoles.PageUsersInRoless", param);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return usersInRoless;
        }

        #endregion
    }
}
