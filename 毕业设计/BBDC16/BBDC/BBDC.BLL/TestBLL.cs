using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDC.DAL;
using BBDC.Model;
using System.Data.SqlClient;
using System.Data;

namespace BBDC.BLL
{
    public class TestBLL
    {
        private readonly BBDC.DAL.TestDAL td = new BBDC.DAL.TestDAL();
        private readonly BBDC.Model.UserInfo ui = new UserInfo();
        DCDAL dal = new DCDAL();
        string uid;

        #region datafirdview要显示的数据


        /// <summary>
        /// 返回给上级联合查询得到的单词id单词意思
        /// </summary>
        public List<BBDC.Model.DCInfo> GetModelList(string strWhere, string book)
        {
            DataSet ds = td.GetWordMean(GetBidUserid(true), GetBidUserid(false),this.uid);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BBDC.Model.DCInfo> DataTableToList(DataTable dt)
        {
            List<BBDC.Model.DCInfo> modelList = new List<BBDC.Model.DCInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BBDC.Model.DCInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelByCxy(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        #endregion


        //获得单表的单词个数
        //public int Backwordnum(string bookid)
        //{
        //    int num = td.Backwordnum(bookid);
        //    return num;
        //}
        //获得wordid数组
        public int[] Getwordid()
        {
            string n = GetBidUserid(false);
            string m = GetBidUserid(true);
            return td.Getwordid(n,m);
        }

        ///<summary>
        ///汉题英填
        ///</summary>
        //将单词数组返回
        public String[] GetHanToYing(int wordid, string bookid)
        {
            //int wordid = Haveid(bookid);
            string[] str = td.GetHanToYing(wordid, bookid);
            return str;
        }

        //首先获取用户的uid，通过uid获取用户的bookid和usertable，再遍历U542中的wordid，再根据wordid返回对应的word

        //获得用户的uid
        public string GetUid()
        {
            return uid;
        }
        public void Getuserid(string uid)
        {
            this.uid = uid;
        }
        //获得bookid和usertable对返回bid错返回ut
        public string GetBidUserid(bool type)
        {
            string uid = GetUid();
            string[] str = td.GetBidUserid(uid);
            if (type)
            {
                return str[0];
            }
            else
            {
                return str[1];
            }
        }
        //根据bookid获得书名
        public string Getdescribe(string bookid)
        {
            return td.Getdescribe(bookid);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        //获得对应id的单词和中文对返
        //获得联合查询获得的单词和意思
        public List<BBDC.Model.DCInfo> GetWordMeanList()
        {
            DataSet ds = td.GetWordMean(GetBidUserid(true), GetBidUserid(false),this.uid);
            return DataTableToList(ds.Tables[0]);
        }
        //更新是否背过单词
        public void Updatare(int wordid)
        {
            td.Updatare(GetBidUserid(false), wordid);
        }
    }
}
