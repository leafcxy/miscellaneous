/******************************************************************************** 
** 作者：余穗海
** 时间：2015-04-01 10:20:46
** 描述：login_record(用户登录记录表;)表的Dao实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.Common;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Common;

namespace Comit.XJPublicServicePlatform.Web.Dao.IBatis.Common
{
    public class LoginRecordDao : ILoginRecordDao
    {
    	#region 属性

        #endregion
        
        #region ILoginRecordDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>记录主键ID</returns>
        public int AddLoginRecord(LoginRecord loginRecord, ISqlMapper sqlMapper)
        {
        	int id = 0;

            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("LoginRecord.AddLoginRecord", loginRecord));
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
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateLoginRecord(LoginRecord loginRecord, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                //
                if (loginRecord != null && loginRecord.Id > 0) 
                {
                	count = sqlMapper.Update("LoginRecord.UpdateLoginRecord", loginRecord);
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
        /// <param name="loginRecord">查询条件，LoginRecord实例</param>
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        public IList<LoginRecord> GetLoginRecords(LoginRecord loginRecord, ISqlMapper sqlMapper)
        {
        	IList<LoginRecord> loginRecords = new List<LoginRecord>();

            try
            {
                loginRecords = sqlMapper.QueryForList<LoginRecord>("LoginRecord.GetLoginRecords", loginRecord);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return loginRecords;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        public IList<LoginRecord> FindLoginRecords(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<LoginRecord> loginRecords = new List<LoginRecord>();

            try
            {
                loginRecords = sqlMapper.QueryForList<LoginRecord>("LoginRecord.FindLoginRecords", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return loginRecords;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<LoginRecord>  GetAllLoginRecordBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<LoginRecord> loginRecords = new List<LoginRecord>();
            try
            {
                 loginRecords = sqlMapper.QueryForList<LoginRecord>("LoginRecord.GetAllLoginRecordBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return loginRecords;
            
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="loginRecord">LoginRecord实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteLoginRecord(LoginRecord loginRecord, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("LoginRecord.DeleteLoginRecord", loginRecord);
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
        public int  BatchDeleteLoginRecordBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count  = sqlMapper.Delete("LoginRecord.BatchDeleteLoginRecordBySql", whereSql);
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
        public int DeleteLoginRecords(IList<long> ids, ISqlMapper sqlMapper)
        {
        	int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("LoginRecord.DeleteLoginRecords", ids);
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
        public int CountLoginRecords(Hashtable parameter, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("LoginRecord.CountLoginRecords", parameter);
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
        /// <returns>满足查询条件的LoginRecord List实例</returns>
        public IList<LoginRecord> PageLoginRecords(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
        	IList<LoginRecord> loginRecords = new List<LoginRecord>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                loginRecords = sqlMapper.QueryForList<LoginRecord>("LoginRecord.PageLoginRecords", param);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return loginRecords;
        }

        #endregion
   	}
}
