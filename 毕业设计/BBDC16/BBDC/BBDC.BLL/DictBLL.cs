using System;
using System.Data;
using System.Collections.Generic;
using BBDC.DAL;
using BBDC.Model;
namespace BBDC.BLL
{
	/// <summary>
	/// dict
	/// </summary>
	public partial class DictBLL
	{
        private readonly BBDC.DAL.DictDAL dal = new BBDC.DAL.DictDAL();
		public DictBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string bookid)
		{
			return dal.Exists(bookid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BBDC.Model.DictInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BBDC.Model.DictInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string bookid)
		{
			
			return dal.Delete(bookid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string bookidlist )
		{
			return dal.DeleteList(bookidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BBDC.Model.DictInfo GetModel(string bookid)
		{
			
			return dal.GetModel(bookid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        //public BBDC.Model.dict GetModelByCache(string bookid)
        //{
			
        //    string CacheKey = "dictModel-" + bookid;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(bookid);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (BBDC.Model.dict)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BBDC.Model.DictInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BBDC.Model.DictInfo> DataTableToList(DataTable dt)
		{
			List<BBDC.Model.DictInfo> modelList = new List<BBDC.Model.DictInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BBDC.Model.DictInfo model;
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
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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
        public void newTable(string tabName)
        {
            dal.newTable(tabName);
        }
		#endregion  ExtensionMethod

        public void dropTable(string tabName)
        {
            dal.dropTable(tabName);
        }
    }
}

