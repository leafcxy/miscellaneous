/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-23 09:53:09
** 描述：页面公用的Service接口，需要住页面添加公用方法的在这里添加
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Domain.Common;
using System.Data;

namespace Comit.XJPublicServicePlatform.Web.Service.Common.Interface
{
    public interface ICommonPageAISService
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>记录主键ID</returns>
        IList<Codemapdesc> GetSelectsInfo(string idName, string selectValue, HttpContextBase httpContextBase);

        /// <summary>
        /// 根据表名，关联外键，条件，选择值绑定下拉框
        /// </summary>
        /// <param name="GetSelectsKey">GetSelectsKey实例</param>
        /// <returns>记录主键ID</returns>
        IList GetSelectsKey(string WhereSql, string foreignName,string alias, string selectValue, HttpContextBase httpContextBase);

        /// <summary>
        /// 自定义sql查找结果集
        /// </summary>
        /// <param name="selectSql"></param>
        /// <param name="?"></param>
        /// <param name="httpContextBase"></param>
        /// <returns></returns>
        IList GetListBySql(string selectSql,HttpContextBase httpContextBase);

        /// <summary>
        /// 自定义sql获取结果数量
        /// </summary>
        /// <param name="selectSql"></param>
        /// <param name="?"></param>
        /// <param name="httpContextBase"></param>
        /// <returns></returns>
        int GetCountBySql(string selectSql, HttpContextBase httpContextBase);

        /// <summary>
        /// 自定义sql查找结果集
        /// </summary>
        /// <param name="selectSql"></param>
        /// <param name="?"></param>
        /// <param name="httpContextBase"></param>
        /// <returns></returns>
        DataTable GetDataTableBySql(string selectSql, HttpContextBase httpContextBase);

        
        #endregion
    }
}
