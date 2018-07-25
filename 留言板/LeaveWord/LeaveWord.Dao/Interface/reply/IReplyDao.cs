using IBatisNet.DataMapper;
using LeaveWord.Domain.reply;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Dao.Interface.reply
{
    public interface IReplyDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="reply">Reply实例</param>
        /// <returns>记录主键ID</returns>
        int AddReply(Reply reply, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="reply">Reply实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateReply(Reply reply, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="reply">查询条件，Reply实例</param>
        /// <returns>满足查询条件的Reply List实例</returns>
        IList<Reply> GetReplys(Reply reply, ISqlMapper sqlMapper);

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        int GetReplyCount(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Reply List实例</returns>
        IList<Reply> FindReplys(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的Reply List实例</returns>
        IList<Reply> GetAllReplyBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="reply">Reply实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteReply(Reply reply, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteReplyBySql(string whereSql, ISqlMapper sqlMapper);
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteReplys(IList<long> ids, ISqlMapper sqlMapper);
        #endregion
    }
}
