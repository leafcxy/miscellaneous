using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BBDC.DAL
{

    public class FanyiDAL
    {
        //首先获取到dict的数据列表，再循环获取每张表的内容
        //这个是查询有没有这个单词的方法

        //DictDAL dal = new DictDAL();
        //英译汉
        public string GetWord(string word)
        {
            string stringwhere = "";
            string dstcol;
            string re = null;
            string get = null;
            DataSet ds = GetList(stringwhere);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)//得到行集合
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dstcol = Convert.ToString(dt.Rows[i][1]);
                    if (SearchWord(word, dstcol) == 1)
                    {
                        //return dstcol;
                        //continue;
                        re = Getmean(word, dstcol);
                        if (re != null)
                            break;
                    }
                    else
                    {
                        return get = "查无此词";
                    }
                }
                return re;
            }
            
            return ("查无此词");
        }
        //汉译英
        public string GetChinese(string mean)
        {
            string stringwhere = "";
            string dstcol;
            string re = null;
            string get = null;
            DataSet ds = GetList(stringwhere);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)//得到行集合
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dstcol = Convert.ToString(dt.Rows[i][1]);
                    if (SearchChinese(mean, dstcol) == 1)
                    {
                        //return dstcol;
                        //continue;
                        re = Getchinese(mean, dstcol);
                        if (re != null)
                            break;
                    }
                    else
                    {
                        return get = "查无此词";
                    }
                }
                return re;
            }

            return ("查无此词");
        }

        // 获得dict的数据列表
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select describe,bookid");
            strSql.Append(" FROM dict ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataset(strSql.ToString(), CommandType.Text);
        }
        //找到某张表是否存在这个单词
        public int SearchWord(string word, string colname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + colname);
            if (word.Trim() != "")
            {
                strSql.Append(" where word = " + "'" + word + "'");
            }
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
        //找到某张表是否存在这个中文
        public int SearchChinese(string mean, string colname)
        {
            //select count(1) FROM c3 where mean like '%安静的%'
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + colname);
            if (mean.Trim() != "")
            {
                strSql.Append(" where mean like " + "'%" + mean + "%'");
            }
            int obj = Convert.ToInt32(SqlHelper.ExecuteScalar(strSql.ToString(), CommandType.Text));
            if (obj != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //输出这个单词的意思
        public string Getmean(string word, string colname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mean FROM " + colname + " ");
            if (word.Trim() != "")
            {
                strSql.Append(" where word =" + "'" + word + "'");
            }
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
        //输出这个中文的单词
        public string Getchinese(string mean, string colname)
        {
            //select word from c3 where mean like '%科目%'
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select word FROM " + colname + " ");
            if (mean.Trim() != "")
            {
                strSql.Append(" where mean like" + "'%" + mean + "%'");
            }
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








    }
}
