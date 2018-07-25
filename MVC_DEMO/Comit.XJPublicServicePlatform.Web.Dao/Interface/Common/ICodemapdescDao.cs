/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-23 09:53:09
** 描述：codemapdesc(数据字典)表的Dao接口(自动生成 )
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using Comit.XJPublicServicePlatform.Web.Domain.Common;
using IBatisNet.DataMapper;

namespace Comit.XJPublicServicePlatform.Web.Dao.Interface.Common
{
    public interface ICodemapdescDao
    {
        #region 成员

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>记录主键ID</returns>
        int AddCodemapdesc(Codemapdesc codemapdesc, ISqlMapper sqlMapper);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>被修改的记录数</returns>
        int UpdateCodemapdesc(Codemapdesc codemapdesc, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="codemapdesc">查询条件，Codemapdesc实例</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        IList<Codemapdesc> GetCodemapdescs(Codemapdesc codemapdesc, ISqlMapper sqlMapper);
        
        /// <summary>
        /// 获取多条
        /// </summary>
        /// <param name="parameter">查询条件，Hashtable实例</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        IList<Codemapdesc> FindCodemapdescs(Hashtable parameter, ISqlMapper sqlMapper);

        /// <summary>
        /// 获取多条
         /// </summary>
        /// <param name="parameter">查询条件，自定义sqly语句</param>
        /// <returns>满足查询条件的Codemapdesc List实例</returns>
        IList<Codemapdesc> GetAllCodemapdescBySql(string whereSql, ISqlMapper sqlMapper);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="codemapdesc">Codemapdesc实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteCodemapdesc(Codemapdesc codemapdesc, ISqlMapper sqlMapper);
	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int BatchDeleteCodemapdescBySql(string whereSql, ISqlMapper sqlMapper);	
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids">欲删除的记录的ID List实例</param>
        /// <returns>被删除的记录数</returns>
        int DeleteCodemapdescs(IList<int> ids, ISqlMapper sqlMapper);
        #endregion
   	}
}
