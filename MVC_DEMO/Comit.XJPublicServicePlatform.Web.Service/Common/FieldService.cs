/******************************************************************************** 
** 作者：余穗海
** 时间：2014-07-25 10:21:53
** 描述：field(field)表的Service实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Common;
using Comit.XJPublicServicePlatform.Web.Service.Common.Interface;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.Common;


namespace Comit.XJPublicServicePlatform.Web.Service.Common
{
    public class FieldService : IFieldService
    {
    	#region 属性
        public IMapper DataMapper { get; set; }
        public IFieldDao FieldDao { get; set; }

        #endregion
        
        #region IFieldService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="field">Field实例</param>
        /// <returns>记录主键ID</returns>
        public int AddField(HttpContextBase httpContextBase, Field field)
        {
        	int id = 0;

            try
            {
                id = FieldDao.AddField(field, DataMapper.Get());
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
        /// <param name="field">Field实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateField(HttpContextBase httpContextBase, Field field)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = FieldDao.UpdateField(field, sqlMap);
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
        /// <param name="field">查询条件，Field实例</param>
        /// <returns>满足查询条件的Field List实例</returns>
        public IList<Field> GetFields(HttpContextBase httpContextBase, Field field)
        {
        	IList<Field> fields = new List<Field>();

            try
            {
                fields = FieldDao.GetFields(field, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return fields;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Field List实例</returns>
        public IList<Field> FindFields(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Field> fields = new List<Field>();

            try
            {
                fields = FieldDao.FindFields(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return fields;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Field List实例</returns>
        public IList<Field> GetAllFieldBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<Field> fields = new List<Field>();

            try
            {
                fields = FieldDao.GetAllFieldBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return fields;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="field">Field实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteField(HttpContextBase httpContextBase, Field field)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = FieldDao.DeleteField(field,sqlMap );
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
        public int DeleteFields(HttpContextBase httpContextBase, IList<int> ids)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = FieldDao.DeleteFields(ids,sqlMap );
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
        public int BatchDeleteFieldBySql(HttpContextBase httpContextBase, string whereSql)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = FieldDao.BatchDeleteFieldBySql(whereSql,sqlMap );
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
