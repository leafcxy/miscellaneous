/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-25 14:08:57
** 描述：mg_users(用户信息
   
   登录密码：按)表的Dao实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.Management;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Management;

namespace Comit.XJPublicServicePlatform.Web.Dao.IBatis.Management
{
    public class MgUsersDao : IMgUsersDao
    {
    	#region 属性

        #endregion
        
        #region IMgUsersDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mgUsers">MgUsers实例</param>
        /// <returns>记录主键ID</returns>
        public long AddMgUsers(MgUsers mgUsers, ISqlMapper sqlMapper)
        {
        	long id = 0;

            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("MgUsers.AddMgUsers", mgUsers));
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
        /// <param name="mgUsers">MgUsers实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateMgUsers(MgUsers mgUsers, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                //
                if (mgUsers != null && mgUsers.Id > 0) 
                {
                	count = sqlMapper.Update("MgUsers.UpdateMgUsers", mgUsers);
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
        /// <param name="mgUsers">查询条件，MgUsers实例</param>
        /// <returns>满足查询条件的MgUsers List实例</returns>
        public IList<MgUsers> GetMgUserss(MgUsers mgUsers, ISqlMapper sqlMapper)
        {
        	IList<MgUsers> mgUserss = new List<MgUsers>();

            try
            {
                mgUserss = sqlMapper.QueryForList<MgUsers>("MgUsers.GetMgUserss", mgUsers);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return mgUserss;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的MgUsers List实例</returns>
        public IList<MgUsers> FindMgUserss(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<MgUsers> mgUserss = new List<MgUsers>();

            try
            {
                mgUserss = sqlMapper.QueryForList<MgUsers>("MgUsers.FindMgUserss", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return mgUserss;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<MgUsers>  GetAllMgUsersBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<MgUsers> mgUserss = new List<MgUsers>();
            try
            {
                 mgUserss = sqlMapper.QueryForList<MgUsers>("MgUsers.GetAllMgUsersBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return mgUserss;
            
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mgUsers">MgUsers实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteMgUsers(MgUsers mgUsers, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                // 删除部门
                count = sqlMapper.Delete("MgUsers.DeleteMgUsers", mgUsers);
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
        public int  BatchDeleteMgUsersBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count  = sqlMapper.Delete("MgUsers.BatchDeleteMgUsersBySql", whereSql);
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
        public int DeleteMgUserss(IList<long> ids, ISqlMapper sqlMapper)
        {
        	int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("MgUsers.DeleteMgUserss", ids);
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
        public int CountMgUserss(Hashtable parameter, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("MgUsers.CountMgUserss", parameter);
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
        /// <returns>满足查询条件的MgUsers List实例</returns>
        public IList<MgUsers> PageMgUserss(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
        	IList<MgUsers> mgUserss = new List<MgUsers>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                mgUserss = sqlMapper.QueryForList<MgUsers>("MgUsers.PageMgUserss", param);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return mgUserss;
        }

        #endregion
   	}
}
