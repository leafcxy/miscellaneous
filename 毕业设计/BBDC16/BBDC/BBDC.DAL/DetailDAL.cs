using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace BBDC.DAL
{
	/// <summary>
	/// 数据访问类:Nw
	/// </summary>
	public partial class DetailDAL
	{
		public DetailDAL()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BBDC.Model.DetailInfo model,String nw)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into "+nw+"(");
			strSql.Append("word,sound,meane,meanc,exam,meane2,meanc2,exam2,meane3,meanc3,exam3,meane4,meanc4,exam4,meane5,meanc5,exam5)");
			strSql.Append(" values (");
			strSql.Append("SQL2012word,SQL2012sound,SQL2012meane,SQL2012meanc,SQL2012exam,SQL2012meane2,SQL2012meanc2,SQL2012exam2,SQL2012meane3,SQL2012meanc3,SQL2012exam3,SQL2012meane4,SQL2012meanc4,SQL2012exam4,SQL2012meane5,SQL2012meanc5,SQL2012exam5)");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012word", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012sound", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012meane", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meanc", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012exam", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meane2", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meanc2", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012exam2", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meane3", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meanc3", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012exam3", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meane4", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meanc4", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012exam4", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meane5", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meanc5", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012exam5", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.word;
			parameters[1].Value = model.sound;
			parameters[2].Value = model.meane;
			parameters[3].Value = model.meanc;
			parameters[4].Value = model.exam;
			parameters[5].Value = model.meane2;
			parameters[6].Value = model.meanc2;
			parameters[7].Value = model.exam2;
			parameters[8].Value = model.meane3;
			parameters[9].Value = model.meanc3;
			parameters[10].Value = model.exam3;
			parameters[11].Value = model.meane4;
			parameters[12].Value = model.meanc4;
			parameters[13].Value = model.exam4;
			parameters[14].Value = model.meane5;
			parameters[15].Value = model.meanc5;
			parameters[16].Value = model.exam5;

			int rows=SqlHelper.ExecuteNonQuery(strSql.ToString(),CommandType.Text,parameters);
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
        public bool Update(BBDC.Model.DetailInfo model, String nw)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update "+nw+" set ");
			strSql.Append("word=SQL2012word,");
			strSql.Append("sound=SQL2012sound,");
			strSql.Append("meane=SQL2012meane,");
			strSql.Append("meanc=SQL2012meanc,");
			strSql.Append("exam=SQL2012exam,");
			strSql.Append("meane2=SQL2012meane2,");
			strSql.Append("meanc2=SQL2012meanc2,");
			strSql.Append("exam2=SQL2012exam2,");
			strSql.Append("meane3=SQL2012meane3,");
			strSql.Append("meanc3=SQL2012meanc3,");
			strSql.Append("exam3=SQL2012exam3,");
			strSql.Append("meane4=SQL2012meane4,");
			strSql.Append("meanc4=SQL2012meanc4,");
			strSql.Append("exam4=SQL2012exam4,");
			strSql.Append("meane5=SQL2012meane5,");
			strSql.Append("meanc5=SQL2012meanc5,");
			strSql.Append("exam5=SQL2012exam5");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012word", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012sound", SqlDbType.NVarChar,50),
					new SqlParameter("SQL2012meane", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meanc", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012exam", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meane2", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meanc2", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012exam2", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meane3", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meanc3", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012exam3", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meane4", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meanc4", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012exam4", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meane5", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012meanc5", SqlDbType.NVarChar,500),
					new SqlParameter("SQL2012exam5", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.word;
			parameters[1].Value = model.sound;
			parameters[2].Value = model.meane;
			parameters[3].Value = model.meanc;
			parameters[4].Value = model.exam;
			parameters[5].Value = model.meane2;
			parameters[6].Value = model.meanc2;
			parameters[7].Value = model.exam2;
			parameters[8].Value = model.meane3;
			parameters[9].Value = model.meanc3;
			parameters[10].Value = model.exam3;
			parameters[11].Value = model.meane4;
			parameters[12].Value = model.meanc4;
			parameters[13].Value = model.exam4;
			parameters[14].Value = model.meane5;
			parameters[15].Value = model.meanc5;
			parameters[16].Value = model.exam5;

			int rows=SqlHelper.ExecuteNonQuery(strSql.ToString(),CommandType.Text,parameters);
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
		public bool Delete(String nw)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from " + nw + " ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			int rows=SqlHelper.ExecuteNonQuery(strSql.ToString(),CommandType.Text,parameters);
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
		public BBDC.Model.DetailInfo GetModel(String nw)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 word,sound,meane,meanc,exam,meane2,meanc2,exam2,meane3,meanc3,exam3,meane4,meanc4,exam4,meane5,meanc5,exam5 from " + nw + " ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			BBDC.Model.DetailInfo model=new BBDC.Model.DetailInfo();
			DataSet ds=SqlHelper.ExecuteDataset(strSql.ToString(),CommandType.Text,parameters);
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
		public BBDC.Model.DetailInfo DataRowToModel(DataRow row)
		{
			BBDC.Model.DetailInfo model=new BBDC.Model.DetailInfo();
			if (row != null)
			{
				if(row["word"]!=null)
				{
					model.word=row["word"].ToString();
				}
				if(row["sound"]!=null)
				{
					model.sound=row["sound"].ToString();
				}
				if(row["meane"]!=null)
				{
					model.meane=row["meane"].ToString();
				}
				if(row["meanc"]!=null)
				{
					model.meanc=row["meanc"].ToString();
				}
				if(row["exam"]!=null)
				{
					model.exam=row["exam"].ToString();
				}
				if(row["meane2"]!=null)
				{
					model.meane2=row["meane2"].ToString();
				}
				if(row["meanc2"]!=null)
				{
					model.meanc2=row["meanc2"].ToString();
				}
				if(row["exam2"]!=null)
				{
					model.exam2=row["exam2"].ToString();
				}
				if(row["meane3"]!=null)
				{
					model.meane3=row["meane3"].ToString();
				}
				if(row["meanc3"]!=null)
				{
					model.meanc3=row["meanc3"].ToString();
				}
				if(row["exam3"]!=null)
				{
					model.exam3=row["exam3"].ToString();
				}
				if(row["meane4"]!=null)
				{
					model.meane4=row["meane4"].ToString();
				}
				if(row["meanc4"]!=null)
				{
					model.meanc4=row["meanc4"].ToString();
				}
				if(row["exam4"]!=null)
				{
					model.exam4=row["exam4"].ToString();
				}
				if(row["meane5"]!=null)
				{
					model.meane5=row["meane5"].ToString();
				}
				if(row["meanc5"]!=null)
				{
					model.meanc5=row["meanc5"].ToString();
				}
				if(row["exam5"]!=null)
				{
					model.exam5=row["exam5"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(string strWhere, String nw)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select word,sound,meane,meanc,exam,meane2,meanc2,exam2,meane3,meanc3,exam3,meane4,meanc4,exam4,meane5,meanc5,exam5 ");
            strSql.Append(" FROM " + nw + " ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SqlHelper.ExecuteDataset(strSql.ToString(),CommandType.Text);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder, String nw)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" word,sound,meane,meanc,exam,meane2,meanc2,exam2,meane3,meanc3,exam3,meane4,meanc4,exam4,meane5,meanc5,exam5 ");
            strSql.Append(" FROM " + nw + " ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.ExecuteDataset(strSql.ToString(),CommandType.Text);
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
        public int GetRecordCount(string strWhere, String nw)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM " + nw + " ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = SqlHelper.ExecuteScalar(strSql.ToString(),CommandType.Text);
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, String nw)
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
            strSql.Append(")AS Row, T.*  from " + nw + " T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return SqlHelper.ExecuteDataset(strSql.ToString(),CommandType.Text);
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
			parameters[0].Value = "Nw1";
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

