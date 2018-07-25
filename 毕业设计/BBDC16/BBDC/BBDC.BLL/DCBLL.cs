using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDC.DAL;
using BBDC.Model;
using System.Data;

namespace BBDC.BLL
{
    public class DCBLL
    {
        DCDAL dal = new DCDAL();
        //得到一个对象实体
        public DCInfo GetModel(string bookid, string wordid)
        {
            return dal.GetModel(bookid, wordid);
        }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string wordid, string book)
        {
            return dal.Exists(wordid, book);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BBDC.Model.DCInfo model, string book)
        {
            return dal.Add(model, book);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BBDC.Model.DCInfo model, string book)
        {
            return dal.Update(model, book);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string wordid, string book)
        {

            return dal.Delete(wordid, book);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string wordidlist, string book)
        {
            return dal.DeleteList(wordidlist, book);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BBDC.Model.DCInfo GetModelByCxy(string wordid, string book)
        {

            return dal.GetModelByCxy(wordid, book);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public BBDC.Model.book GetModelByCache(string wordid)
        //{

        //    string CacheKey = "c1Model-" + wordid;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(wordid);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (BBDC.Model.c1)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string book)
        {
            return dal.GetList(strWhere, book);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder, string book)
        {
            return dal.GetList(Top, strWhere, filedOrder, book);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BBDC.Model.DCInfo> GetModelList(string strWhere, string book)
        {
            DataSet ds = dal.GetList(strWhere, book);
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList(string book)
        {
            return GetList("", book);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere, string book)
        {
            return dal.GetRecordCount(strWhere, book);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<BBDC.Model.DCInfo> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, string book)
        {
            DataSet ds = dal.GetListByPage(strWhere, orderby, startIndex, endIndex, book);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
