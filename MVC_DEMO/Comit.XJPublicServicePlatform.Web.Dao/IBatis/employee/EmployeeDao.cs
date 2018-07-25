/******************************************************************************** 
** 作者：张权
** 时间：2016-05-25 11:49:22
** 描述：employee(员工信息)表的Dao实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.employee;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.employee;

namespace Comit.XJPublicServicePlatform.Web.Dao.IBatis.employee
{
    public class EmployeeDao : IEmployeeDao
    {
    	#region 属性

        #endregion
        
        #region IEmployeeDao 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="employee">Employee实例</param>
        /// <returns>记录主键ID</returns>
        public int AddEmployee(Employee employee, ISqlMapper sqlMapper)
        { 
            int id = 0;

            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("Employee.AddEmployee", employee));
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
        /// <param name="employee">Employee实例</param>
        /// <returns>被修改的记录数</returns>
        public int UpdateEmployee(Employee employee, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                //
                if (employee != null && employee.Id > 0) 
                {
                	count = sqlMapper.Update("Employee.UpdateEmployee", employee);
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
        /// <param name="employee">查询条件，Employee实例</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        public IList<Employee> GetEmployees(Employee employee, ISqlMapper sqlMapper)
        {
        	IList<Employee> employees = new List<Employee>();

            try
            {
                employees = sqlMapper.QueryForList<Employee>("Employee.GetEmployees", employee);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return employees;
        }

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        public int GetEmployeeCount(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("Employee.GetEmployeeCount", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return count;
        }
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        public IList<Employee> FindEmployees(Hashtable parameter, ISqlMapper sqlMapper)
        {
            IList<Employee> employees = new List<Employee>();

            try
            {
                employees = sqlMapper.QueryForList<Employee>("Employee.FindEmployees", parameter);
            }
            catch (Exception e)
            {
                // 抛出异常
                throw e;
            }

            return employees;
        }

        /// <summary>
        /// 根据条件语句whereSql获取所有记录（未分页）
        /// </summary>
        /// <param name="whereSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList<Employee>  GetAllEmployeeBySql(string whereSql, ISqlMapper sqlMapper)
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                 employees = sqlMapper.QueryForList<Employee>("Employee.GetAllEmployeeBySql", whereSql);
            }
            catch (Exception e)
            {
                // 抛出异常
                  throw e;
            }

            return employees;
            
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employee">Employee实例</param>
        /// <returns>被删除的记录数</returns>
        public int DeleteEmployee(Employee employee, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                // 删除
                count = sqlMapper.Delete("Employee.DeleteEmployee", employee);
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
        public int  BatchDeleteEmployeeBySql(string whereSql, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count  = sqlMapper.Delete("Employee.BatchDeleteEmployeeBySql", whereSql);
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
        public int DeleteEmployees(IList<long> ids, ISqlMapper sqlMapper)
        {
        	int count = 0;
            try
            {
                // 删除部门
                count = sqlMapper.Delete("Employee.DeleteEmployees", ids);
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
        public int CountEmployees(Hashtable parameter, ISqlMapper sqlMapper)
        {
        	int count = 0;

            try
            {
                count = sqlMapper.QueryForObject<int>("Employee.CountEmployees", parameter);
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
        /// <returns>满足查询条件的Employee List实例</returns>
        public IList<Employee> PageEmployees(string sortName, string sortOrder, int start, int limit, Hashtable parameter, ISqlMapper sqlMapper)
        {
        	IList<Employee> employees = new List<Employee>();

            Hashtable param = parameter == null ? new Hashtable() : parameter;
            param["SortName"] = sortName;
            param["SortOrder"] = sortOrder;
            param["StartRow"] = start;
            param["EndRow"] = start + limit - 1;

            try
            {
                employees = sqlMapper.QueryForList<Employee>("Employee.PageEmployees", param);
            }
            catch (Exception e)
            {
            	// 抛出异常
                throw e;
            }

            return employees;
        }

        #endregion
   	}
}
