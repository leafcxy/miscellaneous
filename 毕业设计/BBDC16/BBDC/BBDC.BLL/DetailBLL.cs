using System;
using System.Data;
using System.Collections.Generic;
using BBDC.DAL;
using BBDC.Model;
namespace BBDC.BLL
{
    /// <summary>
    /// Nw1
    /// </summary>
    public partial class DetailBLL
    {
        private readonly BBDC.DAL.DetailDAL dal = new BBDC.DAL.DetailDAL();
        public DetailBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BBDC.Model.DetailInfo model, String nw)
        {
            return dal.Add(model, nw);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BBDC.Model.DetailInfo model, String nw)
        {
            return dal.Update(model, nw);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(String nw)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.Delete(nw);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BBDC.Model.DetailInfo GetModel(String nw)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel(nw);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public BBDC.Model.detail GetModelByCache()
        //{
        //    //该表无主键信息，请自定义主键/条件字段
        //    string CacheKey = "Nw1Model-" ;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel();
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (BBDC.Model.Nw1)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, String nw)
        {
            return dal.GetList(strWhere, nw);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder, String nw)
        {
            return dal.GetList(Top, strWhere, filedOrder, nw);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BBDC.Model.DetailInfo> GetModelList(string strWhere, String nw)
        {
            DataSet ds = dal.GetList(strWhere, nw);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BBDC.Model.DetailInfo> DataTableToList(DataTable dt)
        {
            List<BBDC.Model.DetailInfo> modelList = new List<BBDC.Model.DetailInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BBDC.Model.DetailInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
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
        public DataSet GetAllList(String nw)
        {
            return GetList("", nw);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere, String nw)
        {
            return dal.GetRecordCount(strWhere, nw);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, String nw)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex, nw);
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
        String[] mwdict = new String[] { "Nw1", "Nw2", "Nw3", "Nw4" };
        public DetailInfo findDetail(String word)
        {
            DetailInfo a = new DetailInfo();
            word = word.Replace("'", " ");
            foreach(string n in mwdict)
            {
                if (GetModelList("exam like " + "'" + "%" + word + "%" + "'", n).Count > 0)
                {
                    a = GetModelList("exam like " + "'" + "%"+ word + "%" + "'", n)[0];
                }
            }
            return a;
        }

        #endregion  ExtensionMethod
    }
}

