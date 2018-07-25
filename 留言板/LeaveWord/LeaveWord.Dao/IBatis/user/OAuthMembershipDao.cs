using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using LeaveWord.Dao.Interface.user;
using LeaveWord.DataMapper;
using LeaveWord.Domain.user;

namespace LeaveWord.Dao.IBatis.user
{
    public class OAuthMembershipDao : IOAuthMembershipDao
    {
        #region 属性

        #endregion

        #region IOAuthMembershipDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="oAuthMembership">OAuthMembership实例</param>
        /// <returns>记录主键ID</returns>
        public int AddOAuthMembership(OAuthMembership oAuthMembership, ISqlMapper sqlMapper)
        {
            int id = 0;

            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("OAuthMembership.AddOAuthMembership", oAuthMembership));
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
        /// <param name="oAuthMembership">OAuthMembership实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateOAuthMembership(OAuthMembership oAuthMembership, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                //
                if (oAuthMembership != null && oAuthMembership.UserId > 0)
                {
                    count = sqlMapper.Update("OAuthMembership.UpdateOAuthMembership", oAuthMembership);
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
        /// <param name="oAuthMembership">查询条件，OAuthMembership实例</param>
        /// <returns>满足查询条件的OAuthMembership List实例</returns>
        public IList<OAuthMembership> GetOAuthMemberships(OAuthMembership oAuthMembership, ISqlMapper sqlMapper)
        {
            IList<OAuthMembership> oAuthMemberships = new List<OAuthMembership>();

            try
            {
                oAuthMemberships = sqlMapper.QueryForList<OAuthMembership>("OAuthMembership.GetOAuthMemberships", oAuthMembership);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return oAuthMemberships;
        }

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        public int GetOAuthMembershipCount(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("OAuthMembership.GetOAuthMembershipCount", whereSql);
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
        /// <returns>满足查询条件的OAuthMembership List实例</returns>
        public IList<OAuthMembership> FindOAuthMemberships(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<OAuthMembership> oAuthMemberships = new List<OAuthMembership>();

            try
            {
                oAuthMemberships = sqlMapper.QueryForList<OAuthMembership>("OAuthMembership.FindOAuthMemberships", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return oAuthMemberships;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<OAuthMembership> GetAllOAuthMembershipBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<OAuthMembership> oAuthMemberships = new List<OAuthMembership>();
            try
            {
                oAuthMemberships = sqlMapper.QueryForList<OAuthMembership>("OAuthMembership.GetAllOAuthMembershipBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return oAuthMemberships;

        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oAuthMembership">OAuthMembership实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteOAuthMembership(OAuthMembership oAuthMembership, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("OAuthMembership.DeleteOAuthMembership", oAuthMembership);
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
        public int BatchDeleteOAuthMembershipBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count = sqlMapper.Delete("OAuthMembership.BatchDeleteOAuthMembershipBySql", whereSql);
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
        public int DeleteOAuthMemberships(IList<long> ids, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("OAuthMembership.DeleteOAuthMemberships", ids);
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
        public int CountOAuthMemberships(Hashtable parameter, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("OAuthMembership.CountOAuthMemberships", parameter);
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
        /// <returns>满足查询条件的OAuthMembership List实例</returns>
        public IList<OAuthMembership> PageOAuthMemberships(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<OAuthMembership> oAuthMemberships = new List<OAuthMembership>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                oAuthMemberships = sqlMapper.QueryForList<OAuthMembership>("OAuthMembership.PageOAuthMemberships", param);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return oAuthMemberships;
        }

        #endregion
    }
}
