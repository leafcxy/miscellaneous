/******************************************************************************** 
** 作者：张权
** 时间：2016-05-25 11:49:22
** 描述：employee(员工信息)表的Service接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Domain.employee;

namespace Comit.XJPublicServicePlatform.Web.Service.employee.Interface
{
    public interface IEmployeeService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="employee">Employee实例</param>
        /// <returns>记录主键ID</returns>

            int AddEmployee(HttpContextBase httpContextBase, Employee employee);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="employee">Employee实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateEmployee(HttpContextBase httpContextBase, Employee employee);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="employee">查询条件，Employee实例</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        IList<Employee> GetEmployees(HttpContextBase httpContextBase, Employee employee);

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        int GetEmployeeCount(HttpContextBase httpContextBase, string whereSql);
		
		/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        IList<Employee> FindEmployees(HttpContextBase httpContextBase, Hashtable parameter);
        
 	/// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        IList<Employee> GetAllEmployeeBySql(HttpContextBase httpContextBase, string whereSql);
    
       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employee">Employee实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteEmployee(HttpContextBase httpContextBase, Employee employee);
		
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteEmployees(HttpContextBase httpContextBase, IList<long> ids);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="whereSql">查询条件，自定义where条件</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteEmployeeBySql(HttpContextBase httpContextBase, string whereSql);


		
        #endregion
   	}
}
