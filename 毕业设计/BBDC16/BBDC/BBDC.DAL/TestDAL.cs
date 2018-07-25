using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BBDC.DAL
{
    public class TestDAL
    {
        //找到某张表的单词个数 select count(1)wordid from 出
        public int Backwordnum(string bookid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1)wordid FROM " + bookid);
            //if (word.Trim() != "")
            //{
            //    strSql.Append(" where word = " + "'" + word + "'");
            //}
            int obj = Convert.ToInt32(SqlHelper.ExecuteScalar(strSql.ToString(), CommandType.Text));
            if (obj == 0)
            {
                return 0;
            }
            else
            {
                return obj;
            }
        }
        ///<summary>
        ///汉题英填
        ///</summary>
        //}首先根据bll层传来的单词id和表名获得那组单词的单词和意思，然后分别返回单词和意思，然后就bll层获得这些东西判断是否正确
        //获得中文题目
        // select word,mean from c1 where wordid = '25'
        public string Getmean(int wordid, string bookid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mean FROM " + bookid + " ");
            strSql.Append(" where wordid =" + "'" + wordid + "'");

            object obj = SqlHelper.ExecuteScalar(strSql.ToString(), CommandType.Text);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return Convert.ToString(obj);
            }
        }
        public string Getword(int wordid, string bookid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select word FROM " + bookid + " ");

            strSql.Append(" where wordid =" + "'" + wordid + "'");

            object obj = SqlHelper.ExecuteScalar(strSql.ToString(), CommandType.Text);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return Convert.ToString(obj);
            }
        }
        public string[] GetHanToYing(int wordid, string bookid)
        {
            string[] str = { Getword(wordid, bookid), Getmean(wordid, bookid) };
            return str;
        }





        //首先获取用户的uid，通过uid获取用户的bookid和usertable，再遍历U542中的wordid，再根据wordid返回对应的word
        //select bookid ,usertable from [User] where userid = '542'
        //返回bookid和usertable
        public string[] GetBidUserid(string uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select bookid ,usertable from [User]");
            if (uid.Trim() != "")
            {
                strSql.Append(" where userid = " + "'" + uid + "'");
            }
            DataSet ds = SqlHelper.ExecuteDataset(strSql.ToString(), CommandType.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string[] str = { ds.Tables[0].Rows[0][0].ToString(), ds.Tables[0].Rows[0][1].ToString() };
                return str;
            }
            else
            {
                return null;
            }
        }
        //获得usertable中的wordid列表select wordid from U542 where review = 0 and bookid = 'd4'
        public int[] Getwordid(string usertable,string bookid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select wordid ");
            if (usertable.Trim() != "")
            {
                strSql.Append(" from " + usertable + " where review = 0 and bookid = '" + bookid + "'");
            }
            DataSet ds = SqlHelper.ExecuteDataset(strSql.ToString(), CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int[] wordidlie = new int[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    wordidlie[i] = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                }
                return wordidlie;
            }
            else
            {
                int[] m = new int[1] { 0 };
                return m;
            }
        }
        //背过东西写入数据库 UPDATE U542 SET review = 0 WHERE wordid = 1
        public int Updatare(string usertable, int wordid)
        {
            string sql = "UPDATE " + usertable + " SET review = 0 WHERE wordid = " + wordid;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text);
        }
        //select b.wordid,word,mean from c1 b, U542 u where b.wordid = u.wordid and  u.bookid =(select bookid from [User] where userid = 542)
        //联合查询出word和mean
        public DataSet GetWordMean(string bookid, string usertable,string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.wordid,word,mean from " + bookid + " b, " + usertable + " u where b.wordid = u.wordid and u.bookid = (select bookid from [User] where userid = " + userid + " )");

            //SqlParameter[] parameters = {
            //    new SqlParameter("@bookid",bookid),
            //    new SqlParameter("@usertable",usertable)
            //};
            return SqlHelper.ExecuteDataset(strSql.ToString(), CommandType.Text);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    string[] wordlie = new string[2];
            //    for (int i = 0; i < 2; i++)
            //    {
            //        wordlie[i] = Convert.ToString(ds.Tables[0].Rows[0][i]);
            //    }
            //    return wordlie;
            //}
            //else
            //{
            //    return null;
            //}
        }
        //根据biijid返回字典名select describe from dict where bookid = 'c1'
        public string Getdescribe(string bookid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select describe from dict ");
            if (bookid.Trim() != null)
            {
                strSql.Append(" where bookid = '" + bookid + "'");
            }
            object obj = SqlHelper.ExecuteScalar(strSql.ToString(), CommandType.Text);
            if (obj != null)
            {
                return Convert.ToString(obj);
            }
            else
            {
                return null;
            }
        }
    }
}
