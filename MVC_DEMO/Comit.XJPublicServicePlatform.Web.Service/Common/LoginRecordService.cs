/******************************************************************************** 
** 作者：余穗海
** 时间：2015-04-01 10:20:46
** 描述：login_record(用户登录记录表;)表的Service实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using Comit.XJPublicServicePlatform.Web.Dao.IBatis.Common;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.Common;
using Comit.XJPublicServicePlatform.Web.Domain.Common;
using Comit.XJPublicServicePlatform.Web.Service.Common.Interface;

namespace Comit.XJPublicServicePlatform.Web.Service.Common
{
    public class LoginRecordService : ILoginRecordService
    {
    	#region 属性
        public IMapper DataMapper { get; set; }
        public ILoginRecordDao LoginRecordDao { get; set; }

        #endregion
        
        #region ILoginRecordService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>记录主键ID</returns>
        public int AddLoginRecord(HttpContextBase httpContextBase, LoginRecord loginRecord)
        {
        	int  id = 0;

            try
            {
                id = LoginRecordDao.AddLoginRecord(loginRecord, DataMapper.Get());
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
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateLoginRecord(HttpContextBase httpContextBase, LoginRecord loginRecord)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = LoginRecordDao.UpdateLoginRecord(loginRecord, sqlMap);
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
        /// <param name="loginRecord">查询条件，LoginRecord实例</param>
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        public IList<LoginRecord> GetLoginRecords(HttpContextBase httpContextBase, LoginRecord loginRecord)
        {
        	IList<LoginRecord> loginRecords = new List<LoginRecord>();

            try
            {
                loginRecords = LoginRecordDao.GetLoginRecords(loginRecord, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return loginRecords;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        public IList<LoginRecord> FindLoginRecords(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<LoginRecord> loginRecords = new List<LoginRecord>();

            try
            {
                loginRecords = LoginRecordDao.FindLoginRecords(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return loginRecords;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        public IList<LoginRecord> GetAllLoginRecordBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<LoginRecord> loginRecords = new List<LoginRecord>();

            try
            {
                loginRecords = LoginRecordDao.GetAllLoginRecordBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return loginRecords;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteLoginRecord(HttpContextBase httpContextBase, LoginRecord loginRecord)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = LoginRecordDao.DeleteLoginRecord(loginRecord,sqlMap );
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
        public int DeleteLoginRecords(HttpContextBase httpContextBase, IList<long> ids)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = LoginRecordDao.DeleteLoginRecords(ids,sqlMap );
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
        public int BatchDeleteLoginRecordBySql(HttpContextBase httpContextBase, string whereSql)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = LoginRecordDao.BatchDeleteLoginRecordBySql(whereSql,sqlMap );
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
