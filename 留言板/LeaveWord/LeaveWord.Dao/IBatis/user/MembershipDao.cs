using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using LeaveWord.Dao.Interface.user;
using LeaveWord.DataMapper;
using LeaveWord.Domain.user;

namespace LeaveWord.Dao.IBatis.user
{
    public class MembershipDao : IMembershipDao
    {
        #region 属性

        #endregion

        #region IMembershipDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="membership">Membership实例</param>
        /// <returns>记录主键ID</returns>
        public int AddMembership(Membership membership, ISqlMapper sqlMapper)
        {
            int id = 0;

            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("Membership.AddMembership", membership));
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
        /// <param name="membership">Membership实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateMembership(Membership membership, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                //
                if (membership != null && membership.UserId > 0)
                {
                    count = sqlMapper.Update("Membership.UpdateMembership", membership);
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
        /// <param name="membership">查询条件，Membership实例</param>
        /// <returns>满足查询条件的Membership List实例</returns>
        public IList<Membership> GetMemberships(Membership membership, ISqlMapper sqlMapper)
        {
            IList<Membership> memberships = new List<Membership>();

            try
            {
                memberships = sqlMapper.QueryForList<Membership>("Membership.GetMemberships", membership);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return memberships;
        }

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        public int GetMembershipCount(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("Membership.GetMembershipCount", whereSql);
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
        /// <returns>满足查询条件的Membership List实例</returns>
        public IList<Membership> FindMemberships(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Membership> memberships = new List<Membership>();

            try
            {
                memberships = sqlMapper.QueryForList<Membership>("Membership.FindMemberships", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return memberships;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<Membership> GetAllMembershipBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<Membership> memberships = new List<Membership>();
            try
            {
                memberships = sqlMapper.QueryForList<Membership>("Membership.GetAllMembershipBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return memberships;

        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="membership">Membership实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteMembership(Membership membership, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("Membership.DeleteMembership", membership);
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
        public int BatchDeleteMembershipBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count = sqlMapper.Delete("Membership.BatchDeleteMembershipBySql", whereSql);
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
        public int DeleteMemberships(IList<long> ids, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("Membership.DeleteMemberships", ids);
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
        public int CountMemberships(Hashtable parameter, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("Membership.CountMemberships", parameter);
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
        /// <returns>满足查询条件的Membership List实例</returns>
        public IList<Membership> PageMemberships(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Membership> memberships = new List<Membership>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                memberships = sqlMapper.QueryForList<Membership>("Membership.PageMemberships", param);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return memberships;
        }

        #endregion
    }
}
