/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 10:20:28
** 描述：mg_organise(角色信息)表的Service实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Dao.IBatis.Common;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.Management;
using Comit.XJPublicServicePlatform.Web.Domain.Management;
using Comit.XJPublicServicePlatform.Web.Service.Management.Interface;

namespace Comit.XJPublicServicePlatform.Web.Service.Management
{
    public class MgOrganiseService : IMgOrganiseService
    {
    	#region 属性
        public IMapper DataMapper { get; set; }
        public IMgOrganiseDao MgOrganiseDao { get; set; }

        public CommonDao Dao { get; set; }

        #endregion
        
        #region IMgOrganiseService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>记录主键ID</returns>
        public long AddMgOrganise(HttpContextBase httpContextBase, MgOrganise mgOrganise)
        {
        	long id = 0;
            int a = 3;
            CommonDao commonDao = new CommonDao();
            if(String.IsNullOrEmpty(mgOrganise.RoleId))
            {
                object obj = commonDao.GetSingleRecord("select max(role_id)+1 as newId from mg_organise", DataMapper.Get());
                mgOrganise.RoleId = ((Hashtable)obj)["newId"].ToString();
                for(int i=a - mgOrganise.RoleId.Length;i>0;i--)
                {
                    mgOrganise.RoleId = "0" + mgOrganise.RoleId;
                }
            }
            try
            {
                id = MgOrganiseDao.AddMgOrganise(mgOrganise, DataMapper.Get());
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
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateMgOrganise(HttpContextBase httpContextBase, MgOrganise mgOrganise)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgOrganiseDao.UpdateMgOrganise(mgOrganise, sqlMap);
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
        /// <param name="mgOrganise">查询条件，MgOrganise实例</param>
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        public IList<MgOrganise> GetMgOrganises(HttpContextBase httpContextBase, MgOrganise mgOrganise)
        {
        	IList<MgOrganise> mgOrganises = new List<MgOrganise>();

            try
            {
                mgOrganises = MgOrganiseDao.GetMgOrganises(mgOrganise, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return mgOrganises;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        public IList<MgOrganise> FindMgOrganises(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<MgOrganise> mgOrganises = new List<MgOrganise>();

            try
            {
                mgOrganises = MgOrganiseDao.FindMgOrganises(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return mgOrganises;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的MgOrganise List实例</returns>
        public IList<MgOrganise> GetAllMgOrganiseBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<MgOrganise> mgOrganises = new List<MgOrganise>();

            try
            {
                mgOrganises = MgOrganiseDao.GetAllMgOrganiseBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return mgOrganises;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mgOrganise">MgOrganise实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteMgOrganise(HttpContextBase httpContextBase, MgOrganise mgOrganise)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgOrganiseDao.DeleteMgOrganise(mgOrganise,sqlMap );
                Dao.Delete("update  user_role_relate set operator_type='Disuse' where role_id='" + mgOrganise.RoleId + "'", sqlMap);
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
        public int DeleteMgOrganises(HttpContextBase httpContextBase, IList<long> ids)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgOrganiseDao.DeleteMgOrganises(ids,sqlMap );
                foreach(long roleId in ids)
                {

                    Dao.Update("update  user_role_relate set operate_type='Disuse' where role_id in (select role_id from mg_organise where id=" + roleId.ToString() + ")", sqlMap);
                }
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
        public int BatchDeleteMgOrganiseBySql(HttpContextBase httpContextBase, string whereSql)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = MgOrganiseDao.BatchDeleteMgOrganiseBySql(whereSql,sqlMap );
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
        /// 配置权限
        /// </summary>
        /// <param name="sql">配置脚本</param>
        /// <returns></returns>
        public int AddPopedoms(string sql)
        {
            ISqlMapper sqlMap = DataMapper.Get();
            int i;
            i = Dao.Update(sql, sqlMap);
            return i;
        }



        #endregion
   	}
}
