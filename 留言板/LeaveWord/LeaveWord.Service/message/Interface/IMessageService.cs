using System.Collections;
using System.Collections.Generic;
using System.Web;
using LeaveWord.Domain.message;

namespace LeaveWord.Service.message.Interface
{
    public interface IMessageService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="message">Message实例</param>
        /// <returns>记录主键ID</returns>

        int AddMessage(HttpContextBase httpContextBase, Message message);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="message">Message实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateMessage(HttpContextBase httpContextBase, Message message);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetMessages(HttpContextBase httpContextBase, Message message);

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetPageMessages(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetPageMessagesByWords(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetPageMessagesId(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetAllPageMessages(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Message List实例</returns>
        int GetMessageCount(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> FindMessages(HttpContextBase httpContextBase, Hashtable parameter);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetAllMessageBySql(HttpContextBase httpContextBase, string whereSql);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="message">Message实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMessage(HttpContextBase httpContextBase, Message message);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMessages(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteMessageBySql(HttpContextBase httpContextBase, string whereSql);



        #endregion
    }
}
