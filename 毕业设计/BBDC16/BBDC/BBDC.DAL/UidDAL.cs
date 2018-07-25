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
    public class UidDAL
    {
        #region 更新一条数据
        public int Update(UidInfo model,string usertable)
        {
            string sql = "update " + usertable + " set review=@review,game=@game where bookid=@bookid and wordid=@wordid";

            SqlParameter[] parameters = {
                    new SqlParameter("@bookid", model.bookid),
                    new SqlParameter("@wordid", model.wordid),
                    new SqlParameter("@review", model.review),
                    new SqlParameter("@game", model.game),
            };
            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 重置更新全部数据的game
        public int UpdateGame(string usertable)
        {
            string sql = "update " + usertable + " set game=@game";

            SqlParameter[] parameters = {
                    new SqlParameter("@game", "0"),
            };
            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion
        #region 根据是否游戏过获取单词列表
        public List<UidInfo> GetListByGame(string usertable)
        {
            string sql = "select * from " + usertable + " where game=@game";
            SqlParameter[] parameters = {
                     new SqlParameter("@game", "0")
            };
            DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, parameters);
            DataTable dt = ds.Tables[0];
            List<UidInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<UidInfo>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(DataRowToModel(dr));
                }
            }
            return list;
        }
        #endregion
        #region 将数据集表中的行转换为对象
        public UidInfo DataRowToModel(DataRow row)
        {
            UidInfo model = new UidInfo();
            if (row != null)
            {
                if (row["bookid"] != null)
                {
                    model.bookid = row["bookid"].ToString();
                }
                if (row["wordid"] != null)
                {
                    model.wordid = row["wordid"].ToString();
                }
                if (row["review"] != null)
                {
                    model.review = (int)row["review"];
                }
                if (row["game"] != null)
                {
                    model.game = (int)row["game"];
                }
            }
            return model;
        }
        #endregion

        #region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(BBDC.Model.UidInfo model, String uid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into " + uid + "(");
			strSql.Append("bookid,wordid,review,game)");
			strSql.Append(" values (");
			strSql.Append("'"+model.bookid+"'"+","+"'"+model.wordid+"'"+","+model.review+","+model.game+")");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012bookid", SqlDbType.VarChar,50),
					new SqlParameter("SQL2012wordid", SqlDbType.VarChar,50),
					new SqlParameter("SQL2012review", SqlDbType.Int,4),
					new SqlParameter("SQL2012game", SqlDbType.Int,4)};
			parameters[0].Value = model.bookid;
			parameters[1].Value = model.wordid;
			parameters[2].Value = model.review;
			parameters[3].Value = model.game;

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
        public bool UpdateByCxy(BBDC.Model.UidInfo model, String uid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update " + uid + " set ");
			strSql.Append("bookid=SQL2012bookid,");
			strSql.Append("wordid=SQL2012wordid,");
			strSql.Append("review=SQL2012review,");
			strSql.Append("game=SQL2012game,");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012bookid", SqlDbType.VarChar,50),
					new SqlParameter("SQL2012wordid", SqlDbType.VarChar,50),
					new SqlParameter("SQL2012review", SqlDbType.Int,4),
					new SqlParameter("SQL2012game", SqlDbType.Int,4)};
			parameters[0].Value = model.bookid;
			parameters[1].Value = model.wordid;
			parameters[2].Value = model.review;
			parameters[3].Value = model.game;

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
        public bool Delete(string strWhere, String uid)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from " + uid + " ");
			strSql.Append(" where "+strWhere+" ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public BBDC.Model.UidInfo GetModel(String uid)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 bookid,wordid,review,game from " + uid + " ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			BBDC.Model.UidInfo model=new BBDC.Model.UidInfo();
            DataSet ds = SqlHelper.ExecuteDataset(strSql.ToString(), CommandType.Text, parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BBDC.Model.UidInfo DataRowToModelByCxy(DataRow row)
		{
			BBDC.Model.UidInfo model=new BBDC.Model.UidInfo();
			if (row != null)
			{
				if(row["bookid"]!=null)
				{
					model.bookid=row["bookid"].ToString();
				}
				if(row["wordid"]!=null)
				{
					model.wordid=row["wordid"].ToString();
				}
				if(row["review"]!=null && row["review"].ToString()!="")
				{
					model.review=int.Parse(row["review"].ToString());
				}
				if(row["game"]!=null && row["game"].ToString()!="")
				{
					model.game=int.Parse(row["game"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(string strWhere, String uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select bookid,wordid,review,game ");
            strSql.Append(" FROM " + uid + " ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return SqlHelper.ExecuteDataset(strSql.ToString(), CommandType.Text);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder, String uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" bookid,wordid,review,game ");
			strSql.Append(" FROM " +uid+" ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return SqlHelper.ExecuteDataset(strSql.ToString(), CommandType.Text);
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
        public int GetRecordCount(string strWhere, String uid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM " + uid + " ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, String uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.wordid desc");
			}
            strSql.Append(")AS Row, T.*  from " + uid + " T ");
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
			parameters[0].Value = "U000001";
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
