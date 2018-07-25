using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDC.Model;
using System.Data.SqlClient;
using System.Data;

namespace BBDC.DAL
{
    public class DCDAL
    {
        #region 得到一个对象实体
        public DCInfo GetModel(string bookid, string wordid)
        {   //User为sql中的关键字，加[]转换
            string sql = "select * from " + bookid + " where wordid=@wordid";
            SqlParameter[] parameters = {
                    new SqlParameter("@wordid",wordid)
            };

            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 将数据集表中的行转换为对象
        public DCInfo DataRowToModel(DataRow row)
        {
            DCInfo model = new DCInfo();
            if (row != null)
            {
                if (row["wordid"] != null)
                {
                    model.wordid = row["wordid"].ToString();
                }
                if (row["word"] != null)
                {
                    model.word = row["word"].ToString();
                }
                if (row["mean"] != null)
                {
                    model.mean = row["mean"].ToString();
                }
            }
            return model;
        }
        #endregion

        #region  BasicMethodByCxy

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string wordid, string book)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + book);
            strSql.Append(" where wordid=SQL2012wordid ");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012wordid", SqlDbType.VarChar,50)			};
            parameters[0].Value = wordid;

            //return DbHelperSQL.Exists(strSql.ToString(),parameters);
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), CommandType.Text, parameters) > 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BBDC.Model.DCInfo model, string book)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + book + "(");
            strSql.Append("wordid,word,mean)");
            strSql.Append(" values (");
            strSql.Append("'" + model.wordid + "','" + model.word + "','" + model.mean + "')");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012wordid", SqlDbType.VarChar,50),
					new SqlParameter("SQL2012word", SqlDbType.VarChar,50),
					new SqlParameter("SQL2012mean", SqlDbType.VarChar,50)};
            parameters[0].Value = model.wordid;
            parameters[1].Value = model.word;
            parameters[2].Value = model.mean;

            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BBDC.Model.DCInfo model, string book)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + book + " set ");
            strSql.Append("word='" + model.word + "',");
            strSql.Append("mean='" + model.mean + "'");
            strSql.Append(" where wordid='" + model.wordid + "' ");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012word", SqlDbType.VarChar,50),
					new SqlParameter("SQL2012mean", SqlDbType.VarChar,50),
					new SqlParameter("SQL2012wordid", SqlDbType.VarChar,50)};
            parameters[0].Value = model.word;
            parameters[1].Value = model.mean;
            parameters[2].Value = model.wordid;

            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string wordid, string book)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + book + " ");
            strSql.Append(" where wordid=" + wordid + " ");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012wordid", SqlDbType.VarChar,50)			};
            parameters[0].Value = wordid;

            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string wordidlist, string book)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + book + " ");
            strSql.Append(" where wordid in (" + wordidlist + ")  ");
            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BBDC.Model.DCInfo GetModelByCxy(string wordid, string book)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 wordid,word,mean from " + book + " ");
            strSql.Append(" where wordid='" + wordid + "' ");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012wordid", SqlDbType.VarChar,50)			};
            parameters[0].Value = wordid;

            BBDC.Model.DCInfo model = new BBDC.Model.DCInfo();
            DataSet ds = SqlHelper.ExecuteDataset(strSql.ToString(), CommandType.Text, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModelByCxy(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BBDC.Model.DCInfo DataRowToModelByCxy(DataRow row)
        {
            BBDC.Model.DCInfo model = new BBDC.Model.DCInfo();
            if (row != null)
            {
                if (row["wordid"] != null)
                {
                    model.wordid = row["wordid"].ToString();
                }
                if (row["word"] != null)
                {
                    model.word = row["word"].ToString();
                }
                if (row["mean"] != null)
                {
                    model.mean = row["mean"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string book)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select wordid,word,mean ");
            strSql.Append(" FROM " + book + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataset(strSql.ToString(), CommandType.Text);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder, string book)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" wordid,word,mean ");
            strSql.Append(" FROM " + book + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.ExecuteDataset(strSql.ToString(), CommandType.Text);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere, string book)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + book + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SqlHelper.ExecuteScalar(strSql.ToString(), CommandType.Text);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, string book)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.wordid desc");
            }
            strSql.Append(")AS Row, T.*  from " + book + " T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.ExecuteDataset(strSql.ToString(), CommandType.Text);
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012PageSize", SqlDbType.Int),
                    new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
                    new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
                    new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
                    new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "c1";
            parameters[1].Value = "wordid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
    }
}
