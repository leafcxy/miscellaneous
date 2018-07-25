/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 17:04:57
** 描述：user_role_relate(用户和角色的关系)表的Dao实现(自动生成 )
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
    public class UserRoleRelateDao : IUserRoleRelateDao
    {
    	#region 属性

        #endregion
        
        #region IUserRoleRelateDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userRoleRelate">UserRoleRelate实例</param>
        /// <returns>记录主键ID</returns>
        public long AddUserRoleRelate(UserRoleRelate userRoleRelate, ISqlMapper sqlMapper)
        {
        	long id = 0;

            try
            {
                id = Convert.ToInt64(sqlMapper.Insert("UserRoleRelate.AddUserRoleRelate", userRoleRelate));
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
        /// <param name="userRoleRelate">UserRoleRelate实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateUserRoleRelate(UserRoleRelate userRoleRelate, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                //
                if (userRoleRelate != null && userRoleRelate.Id > 0) 
                {
                	count = sqlMapper.Update("UserRoleRelate.UpdateUserRoleRelate", userRoleRelate);
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
        /// <param name="userRoleRelate">查询条件，UserRoleRelate实例</param>
        /// <returns>满足查询条件的UserRoleRelate List实例</returns>
        public IList<UserRoleRelate> GetUserRoleRelates(UserRoleRelate userRoleRelate, ISqlMapper sqlMapper)
        {
        	IList<UserRoleRelate> userRoleRelates = new List<UserRoleRelate>();

            try
            {
                userRoleRelates = sqlMapper.QueryForList<UserRoleRelate>("UserRoleRelate.GetUserRoleRelates", userRoleRelate);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return userRoleRelates;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的UserRoleRelate List实例</returns>
        public IList<UserRoleRelate> FindUserRoleRelates(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<UserRoleRelate> userRoleRelates = new List<UserRoleRelate>();

            try
            {
                userRoleRelates = sqlMapper.QueryForList<UserRoleRelate>("UserRoleRelate.FindUserRoleRelates", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return userRoleRelates;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<UserRoleRelate>  GetAllUserRoleRelateBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<UserRoleRelate> userRoleRelates = new List<UserRoleRelate>();
            try
            {
                 userRoleRelates = sqlMapper.QueryForList<UserRoleRelate>("UserRoleRelate.GetAllUserRoleRelateBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return userRoleRelates;
            
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userRoleRelate">UserRoleRelate实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteUserRoleRelate(UserRoleRelate userRoleRelate, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("UserRoleRelate.DeleteUserRoleRelate", userRoleRelate);
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
        public int  BatchDeleteUserRoleRelateBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count  = sqlMapper.Delete("UserRoleRelate.BatchDeleteUserRoleRelateBySql", whereSql);
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
        public int DeleteUserRoleRelates(IList<long> ids, ISqlMapper sqlMapper)
        {
        	int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("UserRoleRelate.DeleteUserRoleRelates", ids);
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
        public int CountUserRoleRelates(Hashtable parameter, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("UserRoleRelate.CountUserRoleRelates", parameter);
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
        /// <returns>满足查询条件的UserRoleRelate List实例</returns>
        public IList<UserRoleRelate> PageUserRoleRelates(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
        	IList<UserRoleRelate> userRoleRelates = new List<UserRoleRelate>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                userRoleRelates = sqlMapper.QueryForList<UserRoleRelate>("UserRoleRelate.PageUserRoleRelates", param);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return userRoleRelates;
        }

        #endregion
   	}
}
