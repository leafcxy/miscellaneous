using IBatisNet.DataMapper;
using LeaveWord.Domain.user;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Dao.Interface.user
{
    public interface IUsersInRolesDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>记录主键ID</returns>
        int AddUsersInRoles(UsersInRoles usersInRoles, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateUsersInRoles(UsersInRoles usersInRoles, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="usersInRoles">查询条件，UsersInRoles实例</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        IList<UsersInRoles> GetUsersInRoless(UsersInRoles usersInRoles, ISqlMapper sqlMapper);

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <param name="whereSql"></param>
        /// <param name="sqlMapper"></param>
        /// <returns></returns>
        int GetUsersInRolesCount(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        IList<UsersInRoles> FindUsersInRoless(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的UsersInRoles List实例</returns>
        IList<UsersInRoles> GetAllUsersInRolesBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="usersInRoles">UsersInRoles实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteUsersInRoles(UsersInRoles usersInRoles, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteUsersInRolesBySql(string whereSql, ISqlMapper sqlMapper);
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteUsersInRoless(IList<long> ids, ISqlMapper sqlMapper);
        #endregion
    }
}
