/******************************************************************************** 
** 作者：张权
** 时间：2016-05-25 11:49:22
** 描述：employee(员工信息)表的Dao接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.employee;

namespace Comit.XJPublicServicePlatform.Web.Dao.Interface.employee
{
    public interface IEmployeeDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="employee">Employee实例</param>
        /// <returns>记录主键ID</returns>
            int AddEmployee(Employee employee, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="employee">Employee实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateEmployee(Employee employee, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="employee">查询条件，Employee实例</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        IList<Employee> GetEmployees(Employee employee, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 统计数量
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        int GetEmployeeCount(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        IList<Employee> FindEmployees(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
         /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的Employee List实例</returns>
        IList<Employee> GetAllEmployeeBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employee">Employee实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteEmployee(Employee employee, ISqlMapper sqlMapper);
	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteEmployeeBySql(string whereSql, ISqlMapper sqlMapper);	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteEmployees(IList<long> ids, ISqlMapper sqlMapper);
        #endregion
   	}
}
