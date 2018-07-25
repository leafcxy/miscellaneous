using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comit.XJPublicServicePlatform.Web.Domain.Common
{
    public class Query_Def
    {
        public string Query_Id{ get; set; }
        public string Query_Desc{ get; set; }
        public string Edit_Path{ get; set; }
        public string Del_Path{ get; set; }
        public string Query_Sql{ get; set; }
        public string Query_Sql_2{ get; set; }
        public string Table_Name { get; set; }
    }
}