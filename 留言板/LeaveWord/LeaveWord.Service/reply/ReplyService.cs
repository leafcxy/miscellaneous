using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using LeaveWord.DataMapper;
using IBatisNet.DataMapper;
using LeaveWord.Dao.Interface.reply;
using LeaveWord.Domain.reply;
using LeaveWord.Service.reply.Interface;

namespace LeaveWord.Service.reply
{
    public class ReplyService : IReplyService
    {
        #region 属性
        public IMapper DataMapper { get; set; }
        public IReplyDao ReplyDao { get; set; }

        #endregion

        #region IReplyService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="reply">Reply实例</param>
        /// <returns>记录主键ID</returns>
        public int AddReply(HttpContextBase httpContextBase, Reply reply)
        {
            int id = 0;


            try
            {
                id = ReplyDao.AddReply(reply, DataMapper.Get());
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
        /// <param name="reply">Reply实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateReply(HttpContextBase httpContextBase, Reply reply)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = ReplyDao.UpdateReply(reply, sqlMap);
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
        /// <param name="reply">查询条件，Reply实例</param>
        /// <returns>满足查询条件的Reply List实例</returns>
        public IList<Reply> GetReplys(HttpContextBase httpContextBase, Reply reply)
        {
            IList<Reply> replys = new List<Reply>();

            try
            {
                replys = ReplyDao.GetReplys(reply, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return replys;
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Reply List实例</returns>
        public int GetReplyCount(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            try
            {
                count = ReplyDao.GetReplyCount(whereSql, DataMapper.Get());
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
        /// <returns>满足查询条件的Reply List实例</returns>
        public IList<Reply> FindReplys(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Reply> replys = new List<Reply>();

            try
            {
                replys = ReplyDao.FindReplys(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return replys;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Reply List实例</returns>
        public IList<Reply> GetAllReplyBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<Reply> replys = new List<Reply>();

            try
            {
                replys = ReplyDao.GetAllReplyBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return replys;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="reply">Reply实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteReply(HttpContextBase httpContextBase, Reply reply)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = ReplyDao.DeleteReply(reply, sqlMap);
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
        public int DeleteReplys(HttpContextBase httpContextBase, IList<long> ids)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = ReplyDao.DeleteReplys(ids, sqlMap);
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
        public int BatchDeleteReplyBySql(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = ReplyDao.BatchDeleteReplyBySql(whereSql, sqlMap);
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
