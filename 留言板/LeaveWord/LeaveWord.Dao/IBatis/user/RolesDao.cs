using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using LeaveWord.Dao.Interface.user;
using LeaveWord.DataMapper;
using LeaveWord.Domain.user;

namespace LeaveWord.Dao.IBatis.user
{
    public class RolesDao : IRolesDao
    {
        #region 属性

        #endregion

        #region IRolesDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="roles">Roles实例</param>
        /// <returns>记录主键ID</returns>
        public int AddRoles(Roles roles, ISqlMapper sqlMapper)
        {
            int id = 0;

            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("Roles.AddRoles", roles));
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
        /// <param name="roles">Roles实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateRoles(Roles roles, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                //
                if (roles != null && roles.RoleId > 0)
                {
                    count = sqlMapper.Update("Roles.UpdateRoles", roles);
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
        /// <param name="roles">查询条件，Roles实例</param>
        /// <returns>满足查询条件的Roles List实例</returns>
        public IList<Roles> GetRoless(Roles roles, ISqlMapper sqlMapper)
        {
            IList<Roles> roless = new List<Roles>();

            try
            {
                roless = sqlMapper.QueryForList<Roles>("Roles.GetRoless", roles);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return roless;
        }

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        public int GetRolesCount(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("Roles.GetRolesCount", whereSql);
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
        /// <returns>满足查询条件的Roles List实例</returns>
        public IList<Roles> FindRoless(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Roles> roless = new List<Roles>();

            try
            {
                roless = sqlMapper.QueryForList<Roles>("Roles.FindRoless", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return roless;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<Roles> GetAllRolesBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<Roles> roless = new List<Roles>();
            try
            {
                roless = sqlMapper.QueryForList<Roles>("Roles.GetAllRolesBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return roless;

        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="roles">Roles实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteRoles(Roles roles, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("Roles.DeleteRoles", roles);
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
        public int BatchDeleteRolesBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count = sqlMapper.Delete("Roles.BatchDeleteRolesBySql", whereSql);
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
        public int DeleteRoless(IList<long> ids, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("Roles.DeleteRoless", ids);
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
        public int CountRoless(Hashtable parameter, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("Roles.CountRoless", parameter);
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
        /// <returns>满足查询条件的Roles List实例</returns>
        public IList<Roles> PageRoless(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Roles> roless = new List<Roles>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                roless = sqlMapper.QueryForList<Roles>("Roles.PageRoless", param);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return roless;
        }

        #endregion
    }
}
