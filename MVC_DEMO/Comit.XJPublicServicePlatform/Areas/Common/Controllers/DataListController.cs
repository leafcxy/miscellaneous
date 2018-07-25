using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Comit.XJPublicServicePlatform.Web.Common;
using Comit.XJPublicServicePlatform.Web.Domain.Common;
using Comit.XJPublicServicePlatform.Web.Domain.Management;
using Comit.XJPublicServicePlatform.Web.Service.Common;

//应要求如此封装一个列表控件(不是最好的解决方案)

namespace Comit.XJPublicServicePlatform.Areas.Common.Controllers
{
    public class DataListController : Controller
    {
        public DataListService DataListService { get; set; }

        /// <summary>
        /// 数据列表显示(特别说明，在引用的时候，主键要注意区分大小写，否则可能会导致，编辑，删除操作获取到的Id号不正确)
        /// </summary>
        /// <param name="obj">该类型的实例</param>
        /// <param name="query_id">query_def的列表Id</param>
        /// <param name="TableName">该类型对应的表名</param>
        /// <returns></returns>
        public ActionResult DataGrid(PartialViewParameter PVP)
        {
            if(PVP.QueryId == "")
            {
                throw new Exception("QueryId为空，非法调用!");
            }
            DataTable DtQDef = new DataTable();
            DataTable DtField = DataListService.GetFields(PVP.QueryId, out DtQDef);
            ViewData["DtQDef"] = DtQDef;
            PVP.QueryId = Security.EncryptQueryString(PVP.QueryId);
            PVP.SonSQL = Security.EncryptQueryString(PVP.SonSQL);
            PVP.OrderSQL = Security.EncryptQueryString(PVP.OrderSQL);
            ViewData["PVP"] = PVP;

            return View(DtField);
        }
        /// <summary>
        /// 数据列表显示(特别说明，在引用的时候，主键要注意区分大小写，否则可能会导致，编辑，删除操作获取到的Id号不正确)
        /// </summary>
        /// <param name="obj">该类型的实例</param>
        /// <param name="query_id">query_def的列表Id</param>
        /// <param name="TableName">该类型对应的表名</param>
        /// <returns></returns>
        public ActionResult ShowDataGrid(PartialViewParameter PVP)
        {
            if (PVP.QueryId == "")
            {
                throw new Exception("QueryId为空，非法调用!");
            }
            DataTable DtQDef = new DataTable();
            DataTable DtField = DataListService.GetFields(PVP.QueryId, out DtQDef);
            ViewData["DtQDef"] = DtQDef;
            PVP.QueryId = Security.EncryptQueryString(PVP.QueryId);
            PVP.SonSQL = Security.EncryptQueryString(PVP.SonSQL);
            PVP.OrderSQL = Security.EncryptQueryString(PVP.OrderSQL);
            ViewData["PVP"] = PVP;

            return View(DtField);
        }
        /// <summary>
        /// 读取数据用于填充Gril
        /// </summary>
        /// <param name="page">当前请求第几页</param>
        /// <param name="rows">每页显示几行</param>
        /// <param name="sidx">按什么字段排序</param>
        /// <param name="sord">排序方式('desc'/'asc')</param>
        /// <returns></returns>
        public ActionResult GetList(string page, string rows, string sidx, string sord, string filters, string query_id, string SonS, string OrderS)
        {
            PartialViewParameter PVP = new PartialViewParameter();
            PVP.QueryId = Security.DecryptQueryString(query_id);
            PVP.SonSQL = Security.DecryptQueryString(SonS);
            PVP.OrderSQL = Security.DecryptQueryString(OrderS); 

            JQGrilBind SearchFilter = null;
            if(!string.IsNullOrEmpty(filters))
            {
                JavaScriptSerializer sr = new JavaScriptSerializer();
                SearchFilter = sr.Deserialize(filters, typeof(JQGrilBind)) as JQGrilBind;
            }

            //获取分页参数
            int PageNum = 1;
            int PageCount = 10;
            int.TryParse(page, out PageNum);
            int.TryParse(rows, out PageCount);
            
            //读取绑定数据列表需要的数据
            int TotalCount = 0;

            string OrderField = sidx;
            string OrderSort = sord;

            DataTable DtData = DataListService.GetDataList(PageNum, PageCount, SearchFilter, OrderField, OrderSort, PVP, out TotalCount);
            int TotalPageCount = Convert.ToInt32(Math.Ceiling((double)TotalCount / (double)PageCount));

            string jsondata = GetJQGrilJson(DtData, TotalPageCount, PageNum, TotalCount);
            return Content(jsondata);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oper">操作</param>
        /// <param name="query_id">Query_Def表的Id</param>
        /// <param name="id">要删除的数据的id数组</param>
        /// <returns></returns>
        public ActionResult Delete(string oper, string query_id, string[] id)
        {
            string QueryId = Security.DecryptQueryString(query_id);
            return Content(DataListService.DeleteDataList(QueryId, id).ToString());
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportExcel(string page, string rows, string sidx, string sord, string filters, string query_id, string SonS, string OrderS, string GridTitle)
        {
            ExcelExport EE = new ExcelExport();

            //DataTable dt = new DataTable();
            //dt.Columns.Add("Name");
            //dt.Columns.Add("Age");
            //DataRow dr = dt.NewRow();
            //dr["Name"] = "spring";
            //dr["Age"] = "20";
            //dt.Rows.Add(dr);
            //dt.AcceptChanges();

                        
            PartialViewParameter PVP = new PartialViewParameter();
            PVP.QueryId = Security.DecryptQueryString(query_id);
            PVP.SonSQL = Security.DecryptQueryString(SonS);
            PVP.OrderSQL = Security.DecryptQueryString(OrderS);

            JQGrilBind SearchFilter = null;
            if (!string.IsNullOrEmpty(Security.DecryptQueryString(filters)))
            {
                JavaScriptSerializer sr = new JavaScriptSerializer();
                SearchFilter = sr.Deserialize(Security.DecryptQueryString(filters), typeof(JQGrilBind)) as JQGrilBind;
            }

            //获取分页参数
            int PageNum = 1;
            int PageCount = 10;
            int.TryParse(Security.DecryptQueryString(page), out PageNum);
            int.TryParse(Security.DecryptQueryString(rows), out PageCount);

            //读取绑定数据列表需要的数据
            int TotalCount = 0;
            int TotalPageCount = 0;

            string OrderField = Security.DecryptQueryString(sidx);
            string OrderSort = Security.DecryptQueryString(sord);

            DataTable DtData = DataListService.GetDataList(PageNum, PageCount, SearchFilter, OrderField, OrderSort, PVP, out TotalCount);
            if(TotalCount != 0)
                TotalPageCount = Convert.ToInt32(Math.Ceiling((double)TotalCount / (double)PageCount));

            DataTable DtForExcel = new DataTable();

            //读取DtFields字段，用于获取Excel头部第一行的信息
            DataTable dtQDef = new DataTable();
            DataTable DtFields = DataListService.GetFields(PVP.QueryId, out dtQDef);
            foreach(DataRow dr in DtFields.Rows)
            {
                if(Convert.ToBoolean(dr["Is_Show"]))
                { 
                    DtForExcel.Columns.Add(Convert.ToString(dr["Field_Name"]));
                }
            }

            foreach (DataRow dr in DtData.Rows)
            {
                DataRow drAdd = DtForExcel.NewRow();
                foreach (DataRow da in DtFields.Rows)
                {
                    if (Convert.ToBoolean(da["Is_Show"]))
                    {
                        drAdd[Convert.ToString(da["Field_Name"])] = dr[Convert.ToString(da["Field_Code"])];
                    }
                }
                DtForExcel.Rows.Add(drAdd);
            }

            if (string.IsNullOrEmpty(Security.DecryptQueryString(GridTitle)))
            {
                GridTitle = "导出列表";
            }

            EE.ExportExcel(GridTitle, DtForExcel);
            if (DtForExcel == null || DtForExcel.Rows.Count <= 0)
            {
                return Content("<script>alert('当前列表并无可导出数据！');location.href='" + Request.UrlReferrer.PathAndQuery.ToString() + "';</script>");
            }
            return Content("");
        }

        /// <summary>
        /// 拼接JSON结果
        /// </summary>
        /// <param name="DtData">结果DataTable</param>
        /// <param name="TotalPageCount">总页数</param>
        /// <param name="PageNum">当前页</param>
        /// <param name="TotalCount">总记录数</param>
        /// <returns></returns>
        [NonAction]
        private string GetJQGrilJson(DataTable DtData, int TotalPageCount, int PageNum, int TotalCount)
        {
            JsonHelper helper = new JsonHelper();
            string json = helper.GetJSONString(DtData);
            string ResultJson = string.Empty;
            //总页数
            ResultJson += "{\"totalpages\":\"" + TotalPageCount + "\",";
            //当前第几页
            ResultJson += "\"currpage\":\"" + PageNum + "\",";
            //总共多少记录
            ResultJson += "\"totalrecords\":\"" + TotalCount + "\",";
            //DataTable转换得到的JSON字符串
            ResultJson += "\"griddata\":" + json + "}";
            return ResultJson;
        }
	}
}