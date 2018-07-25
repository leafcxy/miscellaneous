using System.Collections;
using System.Collections.Generic;
using System.Web;
using LeaveWord.Domain.reply;

namespace LeaveWord.Service.reply.Interface
{
    public interface IReplyService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="reply">Reply实例</param>
        /// <returns>记录主键ID</returns>

        int AddReply(HttpContextBase httpContextBase, Reply reply);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="reply">Reply实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateReply(HttpContextBase httpContextBase, Reply reply);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="reply">查询条件，Reply实例</param>
        /// <returns>满足查询条件的Reply List实例</returns>
        IList<Reply> GetReplys(HttpContextBase httpContextBase, Reply reply);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Reply List实例</returns>
        int GetReplyCount(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Reply List实例</returns>
        IList<Reply> FindReplys(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Reply List实例</returns>
        IList<Reply> GetAllReplyBySql(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="reply">Reply实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteReply(HttpContextBase httpContextBase, Reply reply);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteReplys(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteReplyBySql(HttpContextBase httpContextBase, string whereSql);



        #endregion
    }
}
