using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using Comit.XJPublicServicePlatform.Web.Common;
using Comit.XJPublicServicePlatform.Web.Dao.IBatis.Common;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using Comit.XJPublicServicePlatform.Web.Domain.Common;
using Comit.XJPublicServicePlatform.Web.Service.Common.Interface;
using IBatisNet.DataMapper;

namespace Comit.XJPublicServicePlatform.Web.Service.Common
{
    public class DataListService : IDataListService
    {
        #region 属性
        public IMapper DataMapper { get; set; }
        public CommonDao Dao { get; set; }
        public IFieldService FieldService { get; set; }

        private int total;                          ///总记录数
        private string totalSql = "";               ///合计sql
        private string totalStr;                    ///合计的列数据
        private string sortname;                    ///用于排序的字段名
        private string query = "";                  ///用于查询的字符串
        private string qtype = "";                  ///用于查询的字段
        private string qcheck;                      ///查询输入验证
        private string isLook = "false";            ///变量，是否显示查看栏
        private string isCheck = "false";           ///变量，是否显示选择框
        private string key = "";                    ///变量，主键的字段名
        private string whereSql = "";               ///变量，查询条件
        private string addSql = "";                 ///变量，查询sql扩展
        #endregion

        #region IDataListService 成员

        public object GetSetInfo(string strSql)
        {
            return null;
        }

        /// <summary>
        /// 根据SQL查询返回DataSet
        /// </summary>
        public DataSet GetDataSetBySql(string sql)
        {
            ISqlMapper sqlMap = DataMapper.Get();
            DataSet ds = Dao.GetDataSetBySql(sql, sqlMap);
            return ds;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="PageNum">要查询第几页的数据</param>
        /// <param name="PageCount">一页显示几条记录</param>
        /// <param name="SearchField">搜索字段</param>
        /// <param name="SearchSymbol">搜索符</param>
        /// <param name="SearchValue">搜索值</param>
        /// <param name="query_id">query_def表的query_id</param>
        /// <param name="TableName">要查询的表名</param>
        /// <param name="TotalCount">表共有记录数</param>
        /// <param name="Qdef">Qdef的实体(包含query_def表的一条数据)</param>
        /// <param name="DtField">Field的DataTable</param>
        /// <returns></returns>
        public DataTable GetDataList(int PageNum, int PageCount, JQGrilBind SearchFilter, string OrderField, string OrderSort, PartialViewParameter PVP, out int TotalCount)
        {
            string fields = "";
            string querySqlTmp = "";
            string sqlTmp = "";
            DataSet ds = new DataSet();          

            ISqlMapper sqlMap = DataMapper.Get();
            //1、绑定Query_Def表对应的行，并转为实体类
            Hashtable HtQuery_Def = Dao.GetSingleRecord(string.Format("SELECT * FROM Query_Def WHERE Query_Id = '{0}'", PVP.QueryId), sqlMap) as Hashtable;
            Query_Def Qdef = new Query_Def()
            {
                Query_Id = Convert.ToString(HtQuery_Def["query_id"]),
                Query_Desc = Convert.ToString(HtQuery_Def["query_desc"]),
                Edit_Path = Convert.ToString(HtQuery_Def["edit_path"]),
                Del_Path = Convert.ToString(HtQuery_Def["del_path"]),
                Query_Sql = Convert.ToString(HtQuery_Def["query_sql"]),
                Query_Sql_2 = Convert.ToString(HtQuery_Def["query_sql_2"]),
                Table_Name = Convert.ToString(HtQuery_Def["table_name"])
            };

            //替换掉sql语句中的session_user_code为当前用户名
            
            querySqlTmp = Qdef.Query_Sql;//.Replace("session_user_code", Session["user_code"].ToString()).Replace("session_level_code", Session["level_code"].ToString());
            //addSql = PVP.SonSQL;
            //2、获得Field的多个行
            DataSet dsQDef = Dao.GetDataSetBySql(string.Format("SELECT * FROM Field WHERE Query_Id = '{0}'", PVP.QueryId), sqlMap);
            DataTable DtField = null;
            if (dsQDef.Tables.Count > 0)
            {
                DtField = dsQDef.Tables[0];
            }

            //如果没配置SQL排序则按页面设置的SQL排序
            if (Qdef.Query_Sql_2 != "")
                sortname = " " + Qdef.Query_Sql_2;
            else
                sortname = " " + PVP.OrderSQL;

            //将获取的数据转换成list
            IList<Field> list = new List<Field>();
            for (int i = 0; i < dsQDef.Tables[0].Rows.Count; i++)
            {
                Field field = new Field();
                field.Id = Convert.ToInt32(dsQDef.Tables[0].Rows[i]["Id"].ToString());
                field.QueryId = dsQDef.Tables[0].Rows[i]["Query_Id"].ToString();
                field.FieldCode = dsQDef.Tables[0].Rows[i]["Field_Code"].ToString();
                field.FieldName = dsQDef.Tables[0].Rows[i]["Field_Name"].ToString();
                field.IsKey = Convert.ToInt32(dsQDef.Tables[0].Rows[i]["Is_Key"].ToString());
                field.IsSelitem = Convert.ToInt32(dsQDef.Tables[0].Rows[i]["Is_Selitem"].ToString());
                field.IsShow = Convert.ToInt32(dsQDef.Tables[0].Rows[i]["Is_Show"].ToString());
                field.Width = dsQDef.Tables[0].Rows[i]["Width"].ToString();
                field.Href = dsQDef.Tables[0].Rows[i]["Href"].ToString();
                field.DataType = dsQDef.Tables[0].Rows[i]["Data_Type"].ToString();
                field.Formatter = dsQDef.Tables[0].Rows[i]["Formatter"].ToString();
                list.Add(field);
            }

            //获取查询sql
            GetWhereSql();
            //4、根据配置的字段类型组装SQL语句
            foreach (Field objFieldTemp in list)
            {//todo改成全部用StringBuilder

                if (objFieldTemp.IsShow == 1)
                {
                    fields += objFieldTemp.FieldCode;
                    if (objFieldTemp.Href == "1")
                    {
                        fields += "link',";
                    }
                    else
                    {
                        fields += ",";
                    }
                }
                if (objFieldTemp.IsKey == 1)
                {
                    key = objFieldTemp.FieldCode;
                }
            }

            //列里一定要有主键的值，所以不管有没有，在最后加一个“keyForList”列
            fields += key + " as keyForList";

            //报错就删代码是不负责任的 2014-08-15
            string SearchSQL = "";
            if (PVP.SonSQL != "")
            {
                SearchSQL += PVP.SonSQL;
            }
            if (SearchFilter != null && SearchFilter.groupOp == "AND")
            {
                foreach (SearchRules sr in SearchFilter.rules)
                {
                    if (querySqlTmp.ToLower().Contains("as " + sr.field.ToLower()))
                    {
                        string asSonSql = "as " + sr.field.ToLower();
                        int end = querySqlTmp.ToLower().IndexOf(asSonSql);
                        string sonsql = querySqlTmp.ToLower().Substring(0, end - 1).Trim();
                        int dend = sonsql.LastIndexOf(",");
                        string AsName = sonsql.Substring(dend + 1, sonsql.Length - dend - 1);
                        sr.field = AsName;
                    }
                    Field f = list.Where(m => m.FieldCode == sr.field).FirstOrDefault();
                    SearchSQL += SubqueriesSQL(sr,f);
                    
                 }
            }
            string OrderSQL = "";
            if (!string.IsNullOrEmpty(OrderField))
            {
                OrderSQL += " order by " + OrderField + " "+OrderSort;
            }
            else if (PVP.OrderSQL != "")
            {
                OrderSQL += " " + PVP.OrderSQL;
            }
            else
            {
                OrderSQL = "";
            }

            //4、获取纪录总数
            total = GetItemCount(querySqlTmp + SearchSQL);
            TotalCount = total;

            //获取分页后的sql                                               
            sqlTmp = GetOnePageDataSql(querySqlTmp + SearchSQL + OrderSQL, fields, PageNum, PageCount);
            
            ds = Dao.GetDataSetBySql(sqlTmp,sqlMap);

            HttpContext.Current.Session["SearchSQL"] = sqlTmp;

            //5、获取真正的数据，返回DataSet
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 读取Field表的内容，用于前台显示
        /// </summary>
        /// <param name="Query_Id"></param>
        /// <returns></returns>
        public bool DeleteDataList(string Query_Id, string[] id)
        {
            ISqlMapper sqlMap = DataMapper.Get();
            Hashtable HtQuery_Def = Dao.GetSingleRecord(string.Format("SELECT * FROM Query_Def WHERE Query_Id = '{0}'", Query_Id), sqlMap) as Hashtable;
            string TableName = Convert.ToString(HtQuery_Def["table_name"]);
            if(!string.IsNullOrEmpty(TableName))
            {
                string DeleteSQL = string.Format("UPDATE {0} SET OPERATE_TYPE = 'Disuse' WHERE Id IN ({1})", TableName, String.Join(",", id));
                if (Dao.Delete(DeleteSQL, sqlMap) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 读取Field表的内容
        /// </summary>
        /// <param name="Query_Id"></param>
        /// <returns></returns>
        public DataTable GetFields(string Query_Id, out DataTable DtQDef)
        {
            ISqlMapper sqlMap = DataMapper.Get();
            DataSet dsField = Dao.GetDataSetBySql("SELECT * FROM Field WHERE Query_Id = '" + Query_Id + "'", sqlMap);
            DataTable DtField = null;
            if (dsField.Tables.Count > 0)
            {
                DtField = dsField.Tables[0];
            }

            DataSet dsQDef = Dao.GetDataSetBySql("SELECT * FROM query_def WHERE Query_Id = '" + Query_Id + "'", sqlMap);
            DtQDef = null;
            if (dsQDef.Tables.Count > 0)
            {
                DtQDef = dsQDef.Tables[0];
            }

            return DtField;
        }

        /// <summary>
        /// 返回SQL子句
        /// </summary>
        /// <returns></returns>
        private string SubqueriesSQL(SearchRules sr, Field f)
        {
            string SonSQL = string.Empty;
            switch (sr.op)
            {
                case "eq":
                    SonSQL = " AND " + sr.field + " = '" + sr.data+"'";
                    break;
                case "ne":
                    SonSQL = " AND " + sr.field + " != '" + sr.data + "'";
                    break;
                case "bt":
                    SonSQL = " AND " + sr.field + " > '" + sr.data + "'";
                    break;
                case "lt":
                    SonSQL = " AND " + sr.field + " < '" + sr.data + "'";
                    break;
                case "bw":
                    SonSQL = " AND " + sr.field + " like '" + sr.data + "%'";
                    break;
                case "bn":
                    SonSQL = " AND " + sr.field + " not like '" + sr.data + "%'";
                    break;
                case "ew":
                    SonSQL = " AND " + sr.field + " like '%" + sr.data + "'";
                    break;
                case "en":
                    SonSQL = " AND " + sr.field + " not like '%" + sr.data + "'";
                    break;
                case "cn":
                    SonSQL = " AND " + sr.field + " like '%" + sr.data + "%'";
                    break;
                case "nc":
                    SonSQL = " AND " + sr.field + " not like '%" + sr.data + "%'";
                    break;
                case "in":
                    SonSQL = " AND " + sr.field + " in ('" + sr.data + "')";
                    break;
                case "ni":
                    SonSQL = " AND " + sr.field + " not in ('" + sr.data+"')";
                    break;
            }
            if (f != null && f.DataType == "int")
            {
                SonSQL = SonSQL.Replace("'","");
            }
            return SonSQL;
        }

        /// <summary>
        /// 获取查询sql(YSH)
        /// </summary>
        private void GetWhereSql()
        {
            //查询
            if (query != "" && qtype != "")
            {
                if (qcheck == "datetime")
                {
                    whereSql += " and " + qtype + " = '" + query + "'";
                }
                else
                {
                    whereSql += " and " + qtype + " like '%" + query + "%'";
                }
            }
        }

        /// <summary>
        /// 获得查询总记录数
        /// </summary>
        /// <param name="sqlTmp">要查询的sql(YSH)</param>
        /// <returns>总记录数</returns>
        private int GetItemCount(string sql)
        {
            string sqlTmp = "";
            if (totalSql == "")
            {
                sqlTmp = "select count(*) AS count  from (" + sql + ")  As dataTableForItemCount where 1=1 " + whereSql;
            }
            else
            {
                sqlTmp = "select count(*) AS count," + totalSql + ",''  from (" + sql + ")  As dataTableForItemCount where 1=1 " + whereSql;
            }
            ISqlMapper sqlMap = DataMapper.Get();
            DataTable dt = Dao.GetDataSetBySql(sqlTmp, sqlMap).Tables[0];
            if (dt.Columns.Count > 1)
            {
                totalStr = "\r\n,{'keyForList':'0',cell:[";
                if (this.isCheck == "True") totalStr += "'',";
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    totalStr += "'" + dt.Rows[0][i].ToString() + "',";
                }
                if (this.isLook == "True") totalStr += "'',";
                totalStr.TrimEnd(',');
                totalStr += "]}";
            }
            return Convert.ToInt32(dt.Rows[0]["count"].ToString());
        }

        /// <summary>
        /// 生成取得指定页数的那一页数据的sql语句
        /// </summary>
        /// <param name="sql">原sql语句</param>
        /// <param name="fields">要显示的列</param>
        /// <returns>返回取指定页数的那一页数据的sql语句</returns>
        private string GetOnePageDataSql(string sql, string fields, int page,int rp)
        {
            return string.Format("{0} {1} {2}", sql, whereSql, "Limit " +  Convert.ToString((page - 1) * rp)  +  ", " + Convert.ToString(Convert.ToInt32(rp)));
        }
        #endregion
    }
}