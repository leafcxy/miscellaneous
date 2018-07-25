/******************************************************************************** 
** 作者：余穗海
** 时间：2014-07-25 10:21:53
** 描述：field(field)表的Dao实现(自动生成 )
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
    public class FieldDao : IFieldDao
    {
    	#region 属性

        #endregion
        
        #region IFieldDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="field">Field实例</param>
        /// <returns>记录主键ID</returns>
        public int AddField(Field field, ISqlMapper sqlMapper)
        {
        	int id = 0;

            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("Field.AddField", field));
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
        /// <param name="field">Field实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateField(Field field, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                //
                if (field != null && field.Id > 0) 
                {
                	count = sqlMapper.Update("Field.UpdateField", field);
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
        /// <param name="field">查询条件，Field实例</param>
        /// <returns>满足查询条件的Field List实例</returns>
        public IList<Field> GetFields(Field field, ISqlMapper sqlMapper)
        {
        	IList<Field> fields = new List<Field>();

            try
            {
                fields = sqlMapper.QueryForList<Field>("Field.GetFields", field);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return fields;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Field List实例</returns>
        public IList<Field> FindFields(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Field> fields = new List<Field>();

            try
            {
                fields = sqlMapper.QueryForList<Field>("Field.FindFields", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return fields;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<Field>  GetAllFieldBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<Field> fields = new List<Field>();
            try
            {
                 fields = sqlMapper.QueryForList<Field>("Field.GetAllFieldBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return fields;
            
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="field">Field实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteField(Field field, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                // 删除部门
                count = sqlMapper.Delete("Field.DeleteField", field);
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
        public int  BatchDeleteFieldBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count  = sqlMapper.Delete("Field.BatchDeleteFieldBySql", whereSql);
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
        public int DeleteFields(IList<int> ids, ISqlMapper sqlMapper)
        {
        	int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("Field.DeleteFields", ids);
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
        public int CountFields(Hashtable parameter, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("Field.CountFields", parameter);
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
        /// <returns>满足查询条件的Field List实例</returns>
        public IList<Field> PageFields(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
        	IList<Field> fields = new List<Field>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                fields = sqlMapper.QueryForList<Field>("Field.PageFields", param);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return fields;
        }

        #endregion
   	}
}
