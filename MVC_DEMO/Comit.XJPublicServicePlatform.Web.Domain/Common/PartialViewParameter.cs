using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comit.XJPublicServicePlatform.Web.Domain.Common
{
    public class PartialViewParameter
    {
        public PartialViewParameter()
        {
            QueryId = "";
            PrimaryKey = "Id";
            SonSQL = "";
            OrderSQL = "";
            ActionDirect = "";
            Title = "";
            TreeId = "";
            IsShowDelete = true;
            IsShowAdd = true;
            IsShowSelect = true;
            IsShowView = true;
            AddBtnRedirect = "";
            IsShowPager = true;
            Height = "100%";
            DefaultPageCount = 10;
            CustomAction = "";
            IsShowSearch = true;
            IsShowOption = true;
            SetWidth = -1;
        }
        //Query_Def表所对应的Id
        public int SetWidth { get; set; }
        public string QueryId { get; set; }
        //子SQL
        public string SonSQL { get; set;}
        //排序SQL子句(不包括ORDER BY)
        public string OrderSQL { get; set; }
        //操作列是放左边还是放右边(可选值"left","right")
        public string ActionDirect { get; set; }
        //主键
        public string PrimaryKey { get; set; }
        //列表顶部显示的标题
        public string Title{ get; set; }
        //列表节点ID
        public string TreeId { get; set; }
        //是否显示删除按钮
        public bool IsShowDelete{ get; set; }
        //是否显示添加按钮
        public bool IsShowAdd { get; set; }
        //是否显示选择CheckBox列
        public bool IsShowSelect{ get; set; }
        //是否显示查看按钮(实际上是编辑按钮)
        public bool IsShowView{ get; set; }
        //添加页面的跳转地址
        public string AddBtnRedirect{ get; set; }
        //是否显示分页下行
        public bool IsShowPager{ get; set; }
        //列表显示的高度是多少
        public string Height{ get; set; }
        //默认一页显示的行数
        public int DefaultPageCount{ get; set; }
        //自定义操作
        public string CustomAction { get; set; }
        //自定义操作
        public bool IsShowSearch { get; set; }
        //显示操作列
        public bool IsShowOption { get; set; }
    }
}