using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using LeaveWord.DataMapper;
using IBatisNet.DataMapper;
using LeaveWord.Dao.Interface.message;
using LeaveWord.Domain.message;
using LeaveWord.Service.message.Interface;

namespace LeaveWord.Service.message
{
    public class MessageService : IMessageService
    {
        #region 属性
        public IMapper DataMapper { get; set; }
        public IMessageDao MessageDao { get; set; }

        #endregion

        #region IMessageService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="message">Message实例</param>
        /// <returns>记录主键ID</returns>
        public int AddMessage(HttpContextBase httpContextBase, Message message)
        {
            int id = 0;


            try
            {
                id = MessageDao.AddMessage(message, DataMapper.Get());
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
        /// <param name="message">Message实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateMessage(HttpContextBase httpContextBase, Message message)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = MessageDao.UpdateMessage(message, sqlMap);
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
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> GetMessages(HttpContextBase httpContextBase, Message message)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = MessageDao.GetMessages(message, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return messages;
        }

        

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> GetPageMessages(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = MessageDao.GetPageMessages(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return messages;
        }
        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> GetPageMessagesByWords(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = MessageDao.GetPageMessagesByWords(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return messages;
        }
        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> GetPageMessagesId(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = MessageDao.GetPageMessagesId(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return messages;
        }
        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="message">查询条件，Message实例</param>
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> GetAllPageMessages(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = MessageDao.GetAllPageMessages(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return messages;
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Message List实例</returns>
        public int GetMessageCount(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            try
            {
                count = MessageDao.GetMessageCount(whereSql, DataMapper.Get());
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
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> FindMessages(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = MessageDao.FindMessages(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return messages;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Message List实例</returns>
        public IList<Message> GetAllMessageBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<Message> messages = new List<Message>();

            try
            {
                messages = MessageDao.GetAllMessageBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return messages;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="message">Message实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteMessage(HttpContextBase httpContextBase, Message message)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = MessageDao.DeleteMessage(message, sqlMap);
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
        public int DeleteMessages(HttpContextBase httpContextBase, IList<long> ids)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = MessageDao.DeleteMessages(ids, sqlMap);
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
        public int BatchDeleteMessageBySql(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                sqlMap.BeginTransaction();
                count = MessageDao.BatchDeleteMessageBySql(whereSql, sqlMap);
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
