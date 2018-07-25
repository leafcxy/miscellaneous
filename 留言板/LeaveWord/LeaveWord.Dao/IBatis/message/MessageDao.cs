using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using LeaveWord.Dao.Interface.message;
using LeaveWord.DataMapper;
using LeaveWord.Domain.message;

namespace LeaveWord.Dao.IBatis.message
{
    public class MessageDao : IMessageDao
    {
        #region 属性

        #endregion

        #region IMessageDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="message">Message实例</param>
        /// <returns>记录主键ID</returns>
        public int AddMessage(Message message, ISqlMapper sqlMapper)
        {
            int id = 0;

            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("Message.AddMessage", message));
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
        /// <param name="message">Message实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateMessage(Message message, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                //
                if (message != null && message.MessageId > 0)
                {
                    count = sqlMapper.Update("Message.UpdateMessage", message);
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
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> GetMessages(Message message, ISqlMapper sqlMapper)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = sqlMapper.QueryForList<Message>("Message.GetMessages", message);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return messages;
        }
        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> GetPageMessages(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = sqlMapper.QueryForList<Message>("Message.GetPageMessages", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return messages;
        }
        public IList<Message> GetPageMessagesByWords(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = sqlMapper.QueryForList<Message>("Message.GetPageMessagesByWords", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return messages;
        }
        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> GetPageMessagesId(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = sqlMapper.QueryForList<Message>("Message.GetPageMessagesId", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return messages;
        }
        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> GetAllPageMessages(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = sqlMapper.QueryForList<Message>("Message.GetAllPageMessages", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return messages;
        }

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        public int GetMessageCount(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("Message.GetMessageCount", whereSql);
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
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> FindMessages(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = sqlMapper.QueryForList<Message>("Message.FindMessages", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return messages;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<Message> GetAllMessageBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<Message> messages = new List<Message>();
            try
            {
                messages = sqlMapper.QueryForList<Message>("Message.GetAllMessageBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return messages;

        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="message">Message实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteMessage(Message message, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("Message.DeleteMessage", message);
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
        public int BatchDeleteMessageBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count = sqlMapper.Delete("Message.BatchDeleteMessageBySql", whereSql);
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
        public int DeleteMessages(IList<long> ids, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("Message.DeleteMessages", ids);
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
        public int CountMessages(Hashtable parameter, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("Message.CountMessages", parameter);
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
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> PageMessages(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Message> messages = new List<Message>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                messages = sqlMapper.QueryForList<Message>("Message.PageMessages", param);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return messages;
        }

        #endregion
    }
}
