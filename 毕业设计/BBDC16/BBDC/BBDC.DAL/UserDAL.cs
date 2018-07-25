using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDC.Model;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BBDC.DAL
{
    public class UserDAL
    {
        #region  BasicMethod

        #region 增加一条数据
        public int Add(UserInfo model)
        {
            string sql = "insert into [User](userid,pwd,name,question,answer,image,wordid,bookid,usertable,number) values(@userid,@pwd,@name,@question,@answer,@image,@wordid,@bookid,@usertable,@number)";
            string sqlTable = "create table " + model.usertable + " (bookid varchar(50),wordid varchar(50),review int,game int constraint pk_b_w_id_" + model.userid + " primary key (bookid,wordid))"; //新建用户个人表，表名为参数时表名、约束名必须动态拼接，注意空格

            SqlParameter[] parameters = {
                    new SqlParameter("@userid", model.userid),
                    new SqlParameter("@pwd", model.pwd),
                    new SqlParameter("@name", model.name),
                    new SqlParameter("@question", model.question),
                    new SqlParameter("@answer", model.answer),
                    new SqlParameter("@image", model.image),
                    new SqlParameter("@wordid", model.wordid),
                    new SqlParameter("@bookid", model.bookid),
                    new SqlParameter("@usertable", model.usertable),
                    new SqlParameter("@number", model.number),
            };
            SqlParameter[] parametersTable = {
                //new SqlParameter("@usertable", model.usertable) // 空参
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            int rowsTable = SqlHelper.ExecuteNonQuery(sqlTable, CommandType.Text, parametersTable); 
            return rows;
        }
        #endregion

        #region 更新一条数据
        public int Update(UserInfo model)
        {
            string sql = "update [User] set pwd=@pwd,name=@name,question=@question,answer=@answer,image=@image,wordid=@wordid,bookid=@bookid,number=@number where userid=@userid ";

            SqlParameter[] parameters = {
                    new SqlParameter("@userid", model.userid),
                    new SqlParameter("@pwd", model.pwd),
                    new SqlParameter("@name", model.name),
                    new SqlParameter("@question", model.question),
                    new SqlParameter("@answer", model.answer),
                    new SqlParameter("@image", model.image),
                    new SqlParameter("@wordid", model.wordid),
                    new SqlParameter("@bookid", model.bookid),
                    new SqlParameter("@number",model.number)
                    //new SqlParameter("@usertable", model.usertable)
            };

            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows;
        }
        #endregion

        #region 更新bookid和number
        public bool Updatenumber(UserInfo model)
        {
            string sql = "update [User] set bookid=@bookid,wordid=@wordid,number=@number where userid=@userid ";
            SqlParameter[] parameters = {
                new SqlParameter("@userid", model.userid),
                new SqlParameter("@bookid", model.bookid),
                new SqlParameter("@wordid", model.wordid),
                new SqlParameter("@number", model.number)
            };
            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows > 0;
        }
        #endregion

        #region 更新wordid
        public bool Updatewordid(UserInfo model)
        {
            string sql = "update [User] set wordid=@wordid where userid=@userid ";
            SqlParameter[] parameters = {
                new SqlParameter("@userid", model.userid),
                new SqlParameter("@wordid", model.wordid)
            };
            int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            return rows > 0;
        }
        #endregion

        #region 删除一条数据
        //public int Delete(string userName)
        //{
        //    string sql = "delete Admin where UserName=@UserName";
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@UserName", userName)
        //    };

        //    int rows = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
        //    return rows;
        //}
        #endregion

        #region 得到一个对象实体
        public UserInfo GetModel(string userId)
        {   //User为sql中的关键字，加[]转换
            string sql = "select * from [User] where userid=@userid";
            SqlParameter[] parameters = {
                    new SqlParameter("@userid",userId)
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
        public UserInfo DataRowToModel(DataRow row)
        {
            UserInfo model = new UserInfo();
            if (row != null)
            {
                if (row["userid"] != null)
                {
                    model.userid = row["userid"].ToString();
                }
                if (row["pwd"] != null)
                {
                    model.pwd = row["pwd"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["question"] != null)
                {
                    model.question = row["question"].ToString();
                }
                if (row["answer"] != null)
                {
                    model.answer = row["answer"].ToString();
                }
                if (row["image"] != null)
                {
                    model.image = ((byte[])row["image"]);//object转byte[]
                }
                if (row["wordid"] != null)
                {
                    model.wordid = row["wordid"].ToString();
                }
                if (row["bookid"] != null)
                {
                    model.bookid = row["bookid"].ToString();
                }
                if (row["usertable"] != null)
                {
                    model.usertable = row["usertable"].ToString();
                }
                if (row["number"] != null)
                {
                    model.number = Convert.ToInt32(row["number"]);
                }
            }
            return model;
        }
        #endregion

        #region 获得数据列表
        //public List<Admin> GetList()
        //{
        //    string sql = "select * from Admin";
        //    DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, null);
        //    DataTable dt = ds.Tables[0];
        //    List<Admin> list = null;
        //    if (dt.Rows.Count > 0)
        //    {
        //        list = new List<Admin>();
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            list.Add(DataRowToModel(dr));
        //        }
        //    }
        //    return list;
        //}
        //public List<Admin> GetListByUserName(string UserName)
        //{
        //    string sql = "select * from Admin where UserName = @UserName";
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@UserName", UserName)
        //    };
        //    DataSet ds = SqlHelper.ExecuteDataset(sql, CommandType.Text, parameters);
        //    DataTable dt = ds.Tables[0];
        //    List<Admin> list = null;
        //    if (dt.Rows.Count > 0)
        //    {
        //        list = new List<Admin>();
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            list.Add(DataRowToModel(dr));
        //        }
        //    }
        //    return list;
        //}
        #endregion

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
