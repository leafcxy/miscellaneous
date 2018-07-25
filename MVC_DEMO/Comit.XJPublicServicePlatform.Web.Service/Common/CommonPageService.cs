/******************************************************************************** 
** 作者：罗海先
** 时间：2014-07-23 09:53:09
** 描述：codemapdesc(数据字典)表的Service实现(自动生成 )
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Dao.Interface.Common;
using Comit.XJPublicServicePlatform.Web.Domain.Common;
using Comit.XJPublicServicePlatform.Web.Service.Common.Interface;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.Dao.IBatis.Common;
using System.Data;
using System.ComponentModel;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Comit.XJPublicServicePlatform.Web.Service.Common
{
    public class CommonPageService : ICommonPageService
    {
        #region 属性
        public IMapper DataMapper { get; set; }
        public ICodemapdescService CodemapdescService { get; set; }
        public CommonDao objCommonDao { get; set; }

        #endregion

        #region 
        /// <summary>
        /// 获取数据字典IList
        /// </summary>
        /// <param name="idName"></param>
        /// <param name="selectValue"></param>
        /// <param name="httpContextBase"></param>
        /// <returns></returns>
        public IList<Codemapdesc> GetSelectsInfo(string idName, string selectValue, HttpContextBase httpContextBase)
        {
            Hashtable hashtableCodemapdescData=(Hashtable)httpContextBase.Session["hashtableCodemapdescData"];
            IList<Codemapdesc> codemapdescList = null;
            Hashtable parameter = new Hashtable();
            parameter["Id"] = idName;
            if (hashtableCodemapdescData == null)
            {//新增并保存session
                hashtableCodemapdescData = new Hashtable();
                codemapdescList = CodemapdescService.FindCodemapdescs(httpContextBase, parameter);
                hashtableCodemapdescData.Add(idName, codemapdescList);
                httpContextBase.Session.Add("hashtableCodemapdescData", hashtableCodemapdescData);
            }
            else
            {
                if (hashtableCodemapdescData[idName] != null)
                {//直接session获取
                    codemapdescList = (IList<Codemapdesc>)hashtableCodemapdescData[idName];
                }
                else
                {//新增并保存session
                    codemapdescList = CodemapdescService.FindCodemapdescs(httpContextBase, parameter);
                    hashtableCodemapdescData.Add(idName, codemapdescList);
                    httpContextBase.Session.Add("hashtableCodemapdescData", hashtableCodemapdescData);
                }
            }
            
            return codemapdescList;
        }


        /// <summary>
        /// 根据外键条件获取IList
        /// </summary>
        /// <param name="idName"></param>
        /// <param name="selectValue"></param>
        /// <param name="httpContextBase"></param>
        /// <returns></returns>
        public IList GetSelectsKey(string WhereSql, string foreignName, string alias, string selectValue,HttpContextBase httpContextBase)
        {
            IList ForeignKeyList = new ArrayList();
            ISqlMapper sqlMap = DataMapper.Get();
            ForeignKeyList = objCommonDao.GetAll(WhereSql, sqlMap);

            return ForeignKeyList;
        }

        /// <summary>
        /// 自定义sql查找结果集
        /// </summary>
        /// <param name="selectSql"></param>
        /// <param name="?"></param>
        /// <param name="httpContextBase"></param>
        /// <returns></returns>
        public IList GetListBySql(string selectSql,HttpContextBase httpContextBase)
        {
            IList list = new ArrayList();
            ISqlMapper sqlMap = DataMapper.Get();
            list = objCommonDao.GetAll(selectSql,sqlMap);
            return list;
        }


        /// <summary>
        /// 自定义sql获取结果数量
        /// </summary>
        /// <param name="selectSql"></param>
        /// <param name="?"></param>
        /// <param name="httpContextBase"></param>
        /// <returns></returns>
        public int GetCountBySql(string selectSql, HttpContextBase httpContextBase)
        {
            int count = 0;
            IList list = new ArrayList();
            ISqlMapper sqlMap = DataMapper.Get();
            list = objCommonDao.GetAll(selectSql, sqlMap);
            count = list.Count;
            return count;
        }


        /// <summary>
        /// 自定义sql查找结果集
        /// </summary>
        /// <param name="selectSql"></param>
        /// <param name="?"></param>
        /// <param name="httpContextBase"></param>
        /// <returns></returns>
        public DataTable GetDataTableBySql(string selectSql, HttpContextBase httpContextBase)
        {
            DataTable dt = new DataTable();
            ISqlMapper sqlMap = DataMapper.Get();
            dt = (DataTable)objCommonDao.GetAll(selectSql, sqlMap);
            return dt;
        }
        #endregion
    }
}
