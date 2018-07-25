using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDC.Model;
using BBDC.DAL;
using System.Data;

namespace BBDC.BLL
{
    public class UidBLL
    {
        UidDAL dal = new UidDAL();
        //更新一条数据
        public int Update(UidInfo model, string usertable)
        {
            return dal.Update(model,usertable);
        }
        //重置更新全部数据的game
        public int UpdateGame(string usertable)
        {
            return dal.UpdateGame(usertable);
        }
        //获得数据列表
        public List<UidInfo> GetListByGame(string usertable)
        {
            return dal.GetListByGame(usertable);
        }

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BBDC.Model.UidInfo model, String uid)
        {
            return dal.Add(model, uid);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateByCxy(BBDC.Model.UidInfo model, String uid)
        {
            return dal.UpdateByCxy(model, uid);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string strWhere, String uid)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.Delete(strWhere, uid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BBDC.Model.UidInfo GetModel(String uid)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel(uid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public BBDC.Model.userRecord GetModelByCache()
        //{
        //    //该表无主键信息，请自定义主键/条件字段
        //    string CacheKey = "U000001Model-" ;
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
        //    return (BBDC.Model.U000001)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, String uid)
        {
            return dal.GetList(strWhere, uid);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder, String uid)
        {
            return dal.GetList(Top, strWhere, filedOrder, uid);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BBDC.Model.UidInfo> GetModelList(string strWhere, String uid)
        {
            DataSet ds = dal.GetList(strWhere, uid);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BBDC.Model.UidInfo> DataTableToList(DataTable dt)
        {
            List<BBDC.Model.UidInfo> modelList = new List<BBDC.Model.UidInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BBDC.Model.UidInfo model;
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
        public DataSet GetAllList(String uid)
        {
            return GetList("", uid);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere, String uid)
        {
            return dal.GetRecordCount(strWhere, uid);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, String uid)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex, uid);
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
