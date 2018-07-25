/******************************************************************************** 
** 作者：余穗海
** 时间：2014-07-25 10:21:53
** 描述：field(field)表的Dao接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Common;

namespace Comit.XJPublicServicePlatform.Web.Dao.Interface.Common
{
    public interface IFieldDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="field">Field实例</param>
        /// <returns>记录主键ID</returns>
        int AddField(Field field, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="field">Field实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateField(Field field, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="field">查询条件，Field实例</param>
        /// <returns>满足查询条件的Field List实例</returns>
        IList<Field> GetFields(Field field, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Field List实例</returns>
        IList<Field> FindFields(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
         /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的Field List实例</returns>
        IList<Field> GetAllFieldBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="field">Field实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteField(Field field, ISqlMapper sqlMapper);
	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteFieldBySql(string whereSql, ISqlMapper sqlMapper);	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteFields(IList<int> ids, ISqlMapper sqlMapper);
        #endregion
   	}
}
