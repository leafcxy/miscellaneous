using IBatisNet.DataMapper;
using LeaveWord.Domain.message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Dao.Interface.message
{
    public interface IMessageDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="message">Message实例</param>
        /// <returns>记录主键ID</returns>
        int AddMessage(Message message, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="message">Message实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateMessage(Message message, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetMessages(Message message, ISqlMapper sqlMapper);

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetPageMessages(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetPageMessagesByWords(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetPageMessagesId(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetAllPageMessages(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        int GetMessageCount(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> FindMessages(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的Message List实例</returns>
        IList<Message> GetAllMessageBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="message">Message实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMessage(Message message, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteMessageBySql(string whereSql, ISqlMapper sqlMapper);
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteMessages(IList<long> ids, ISqlMapper sqlMapper);
        #endregion
    }
}
