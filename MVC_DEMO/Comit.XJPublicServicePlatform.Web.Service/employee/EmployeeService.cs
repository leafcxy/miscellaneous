/******************************************************************************** 
** 作者：张权
** 时间：2016-05-25 11:49:22
** 描述：employee(员工信息)表的Service实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.employee;
using Comit.XJPublicServicePlatform.Web.Domain.employee;
using Comit.XJPublicServicePlatform.Web.Service.employee.Interface;

namespace Comit.XJPublicServicePlatform.Web.Service.employee
{
    public class EmployeeService : IEmployeeService
    {
    	#region 属性
        public IMapper DataMapper { get; set; }
        public IEmployeeDao EmployeeDao { get; set; }

        #endregion
        
        #region IEmployeeService 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="employee">Employee实例</param>
        /// <returns>记录主键ID</returns>
        public int AddEmployee(HttpContextBase httpContextBase, Employee employee)
        {
        	int  id = 0;


            try
            {
                id = EmployeeDao.AddEmployee(employee, DataMapper.Get());
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
        /// <param name="employee">Employee实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateEmployee(HttpContextBase httpContextBase, Employee employee)
        {
            int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = EmployeeDao.UpdateEmployee(employee, sqlMap);
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
        /// <param name="employee">查询条件，Employee实例</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        public IList<Employee> GetEmployees(HttpContextBase httpContextBase, Employee employee)
        {
        	IList<Employee> employees = new List<Employee>();

            try
            {
                employees = EmployeeDao.GetEmployees(employee, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return employees;
        }
        
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        public int GetEmployeeCount(HttpContextBase httpContextBase, string whereSql)
        {
            int count = 0;

            try
            {
                count = EmployeeDao.GetEmployeeCount(whereSql, DataMapper.Get());
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
        /// <returns>满足查询条件的Employee List实例</returns>
        public IList<Employee> FindEmployees(HttpContextBase httpContextBase, Hashtable parameter)
        {
            IList<Employee> employees = new List<Employee>();

            try
            {
                employees = EmployeeDao.FindEmployees(parameter, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return employees;
        }

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        public IList<Employee> GetAllEmployeeBySql(HttpContextBase httpContextBase, string whereSql)
        {
            IList<Employee> employees = new List<Employee>();

            try
            {
                employees = EmployeeDao.GetAllEmployeeBySql(whereSql, DataMapper.Get());
            }
            catch (Exception e)
            {
                throw e;
            }

            return employees;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employee">Employee实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteEmployee(HttpContextBase httpContextBase, Employee employee)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = EmployeeDao.DeleteEmployee(employee,sqlMap );
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
        public int DeleteEmployees(HttpContextBase httpContextBase, IList<long> ids)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = EmployeeDao.DeleteEmployees(ids,sqlMap );
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
        public int BatchDeleteEmployeeBySql(HttpContextBase httpContextBase, string whereSql)
        {
           int count = 0;

            // 获取sqlMap
            ISqlMapper sqlMap = DataMapper.Get();
            try
            {
                // 开启事务
                  sqlMap.BeginTransaction();
                count = EmployeeDao.BatchDeleteEmployeeBySql(whereSql,sqlMap );
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
