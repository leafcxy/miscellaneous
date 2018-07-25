/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 10:20:28
** 描述：mg_organise(角色信息)表的Dao实现(自动生成 )
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
    public class MgOrganiseDao : IMgOrganiseDao
    {
    	#region 属性

        #endregion
        
        #region IMgOrganiseDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>记录主键ID</returns>
        public long AddMgOrganise(MgOrganise mgOrganise, ISqlMapper sqlMapper)
        {
        	long id = 0;

            try
            {
                id = Convert.ToInt64(sqlMapper.Insert("MgOrganise.AddMgOrganise", mgOrganise));
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
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateMgOrganise(MgOrganise mgOrganise, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                //
                if (mgOrganise != null && mgOrganise.Id > 0) 
                {
                	count = sqlMapper.Update("MgOrganise.UpdateMgOrganise", mgOrganise);
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
        /// <param name="mgOrganise">查询条件，MgOrganise实例</param>
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        public IList<MgOrganise> GetMgOrganises(MgOrganise mgOrganise, ISqlMapper sqlMapper)
        {
        	IList<MgOrganise> mgOrganises = new List<MgOrganise>();

            try
            {
                mgOrganises = sqlMapper.QueryForList<MgOrganise>("MgOrganise.GetMgOrganises", mgOrganise);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return mgOrganises;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        public IList<MgOrganise> FindMgOrganises(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<MgOrganise> mgOrganises = new List<MgOrganise>();

            try
            {
                mgOrganises = sqlMapper.QueryForList<MgOrganise>("MgOrganise.FindMgOrganises", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return mgOrganises;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<MgOrganise>  GetAllMgOrganiseBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<MgOrganise> mgOrganises = new List<MgOrganise>();
            try
            {
                 mgOrganises = sqlMapper.QueryForList<MgOrganise>("MgOrganise.GetAllMgOrganiseBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return mgOrganises;
            
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteMgOrganise(MgOrganise mgOrganise, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("MgOrganise.DeleteMgOrganise", mgOrganise);
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
        public int  BatchDeleteMgOrganiseBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count  = sqlMapper.Delete("MgOrganise.BatchDeleteMgOrganiseBySql", whereSql);
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
        public int DeleteMgOrganises(IList<long> ids, ISqlMapper sqlMapper)
        {
        	int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("MgOrganise.DeleteMgOrganises", ids);
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
        public int CountMgOrganises(Hashtable parameter, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("MgOrganise.CountMgOrganises", parameter);
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
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        public IList<MgOrganise> PageMgOrganises(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
        	IList<MgOrganise> mgOrganises = new List<MgOrganise>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                mgOrganises = sqlMapper.QueryForList<MgOrganise>("MgOrganise.PageMgOrganises", param);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return mgOrganises;
        }

        #endregion
   	}
}
