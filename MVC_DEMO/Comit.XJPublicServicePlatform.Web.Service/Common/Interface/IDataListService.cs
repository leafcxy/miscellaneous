using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Comit.XJPublicServicePlatform.Web.Domain.Common;

namespace Comit.XJPublicServicePlatform.Web.Service.Common.Interface
{
    public interface IDataListService
    {
        DataTable GetDataList(int PageNum, int PageCount, JQGrilBind SearchFilter, string OrderField, string OrderSort, PartialViewParameter PVP, out int TotalCount);
        DataSet GetDataSetBySql(string sql);
        DataTable GetFields(string Query_Id, out DataTable DtQDef);
    }
}