/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 10:20:28
** 描述：mg_organise(角色信息)表的Controller(自动生成 )
*********************************************************************************/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Comit.XJPublicServicePlatform.Web.Common;
using Comit.XJPublicServicePlatform.Web.Service.Common.Interface;
using Comit.XJPublicServicePlatform.Web.Domain;
using Comit.XJPublicServicePlatform.Web.Domain.Management;
using Comit.XJPublicServicePlatform.Web.Service.Management.Interface;
using Comit.XJPublicServicePlatform.Web.Service.Management;

namespace Comit.XJPublicServicePlatform.Areas.Management.Controllers
{
    ///[HandleError(Order = 1)]
    ///[UrlAuthorize(Order = 2)]
    
    public class MgOrganiseController : TeController
    {
        #region 属性

        public IMgOrganiseService MgOrganiseService { get; set; }

        public ITreenodesService TreenodesService { get; set; }
        public IMgPopedomService MgPopedomService { get; set; }
        #endregion

        #region Action

        /// <summary>
        /// GET 首页
        /// </summary>
        /// <returns></returns>
        
        public ActionResult MgOrganiseList()
        {
            this.BasePage_Load("角色信息列表", "treeNodePage");
            return View();
        }

        /// <summary>
        /// 详情页 初始化页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MgOrganiseDetail()
        {
            string id = Security.DecryptQueryString(Request.QueryString["id"]);
            MgOrganise mgOrganise = new MgOrganise();
            if (id != null && id != "null" && id != "")
            {//查询时页面初始化
                mgOrganise = MgOrganiseService.GetMgOrganises(HttpContext, new MgOrganise() { Id = int.Parse(id) }).FirstOrDefault();
                if (mgOrganise == null)
                {
                    mgOrganise = new MgOrganise()
                    {
                        //初始化工作
                    };
                }
            }
            else
            {//新增时页面初始化
                mgOrganise = new MgOrganise()
                {
                    //初始化工作
                };
            }
            //其他页面初始化，如下拉框选择
            //ViewBag.OperateType = GetSelectsInfo("操作类型", mgOrganise.OperateType);
            ViewBag.RoleStateList = GetSelectsInfo("是否启用", mgOrganise.OperateType);
            ViewBag.RoleId = mgOrganise.RoleId;
            IList<Treenodes> listTreeNodes = TreenodesService.GetAllTreenodesBySql(HttpContext, " where 1=1");


            //<input type=checkbox id='001'onclick='javascript:checkAll(this);' /><span>首页</span><span style='margin-left: 145px'><b>查看权限</b></span><span style='margin-left: 20px'><b>增改权限</b></span><span style='margin-left: 20px'><b>删除权限</b></span><span style='margin-left: 20px'><b>全选节点权限</b></span>
            string htmlStr = "{\"001\":{\"name\":\"首页\",\"type\":\"folder\",\"additionalParameters\":{\"children\":{\"appliances\":{\"name\":\"1\",\"type\":\"item\"}}}}} ";
            //htmlStr = GetJsonStr();
            htmlStr = GetTreeNode("0", listTreeNodes);
            ViewBag.Jstr = GetTreeNode("0", listTreeNodes);
            //生成json格式的字符串
            //页面拼接展示

            //ViewBag.tree = htmlStr;

            //ViewData["listTreeNodes"] = new MultiSelectList(listTreeNodes, "RoleId", "RoleName", listUserRoleRelate.Select(userRoleRelate => userRoleRelate.RoleId)); ;
            
            ViewBag.Title = "角色信息详情";
            this.BasePage_Load("角色信息详情", "page");
            return View(mgOrganise);
        }

        /// <summary>
        /// 详细页面操作
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        //[UrlAuthorizeAttribute]
        public ActionResult Operate(MgOrganise objMgOrganise)
        {
            if (ModelState.IsValid)
            {//是否正确绑定
                if (objMgOrganise.Id == -2147483648 || objMgOrganise.Id == -9223372036854775808)
                {//根据主键是否为空，来判断是否新增

                    return Create(objMgOrganise);
                }
                else if (objMgOrganise.Id != -2147483648 && objMgOrganise.Id != -9223372036854775808)
                {//根据主键是否为空，来判断是否修改
                    return Edit(objMgOrganise);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }


        /// <summary>
        /// POST 创建
        /// </summary>
        /// <param name="objMgOrganise">MgOrganise实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(MgOrganise objMgOrganise)
        {
            //数据记录状态
            objMgOrganise.OperateType = "Add";
            objMgOrganise.OperatePerson = GetOperatePerson();
            objMgOrganise.OperateTime = GetOperateTime();
            //数据新增
            objMgOrganise.Id = MgOrganiseService.AddMgOrganise(HttpContext, objMgOrganise);
            if (objMgOrganise.Id > 0)
            {
                objMgOrganise = MgOrganiseService.GetMgOrganises(HttpContext, objMgOrganise).FirstOrDefault();
                //操作成功返回
                return Json(new { PkName = "Id", PkValue = objMgOrganise.Id, RoleId=objMgOrganise.RoleId, SuccessInfo = "新增成功！" });
            }
            else
            {
                //操作成功返回
                return Json(new { PkName = "Id", PkValue = objMgOrganise.Id, RoleId = objMgOrganise.RoleId, SuccessInfo = "新增失败！" });
            }
        }

        /// <summary>
        /// POST 编辑
        /// </summary>
        /// <param name="objMgOrganise">MgOrganise实例</param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Edit(MgOrganise objMgOrganise)
        {
            //数据记录状态变更
            objMgOrganise.OperateType = "Update";
            objMgOrganise.OperatePerson = GetOperatePerson();
            objMgOrganise.OperateTime = GetOperateTime();
            //数据修改
            int count = MgOrganiseService.UpdateMgOrganise(HttpContext, objMgOrganise);

            if (count > 0)
            {
                //操作成功返回
                return Json(new { PkName = "Id", PkValue = objMgOrganise.Id, RoleId = objMgOrganise.RoleId, SuccessInfo = "修改成功！" });
            }
            else
            {
                //操作成功返回
                return Json(new { PkName = "Id", PkValue = objMgOrganise.Id, RoleId = objMgOrganise.RoleId, SuccessInfo = "修改失败！" });
            }
        }

        /// <summary>
        /// 删除一条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string id)
        {
            int count = 0;
            long[] ids = id.Split(',').Select(s => long.Parse(s)).ToArray();
            IList<long> lids = new List<long>(ids);

            count = MgOrganiseService.DeleteMgOrganises(HttpContext, lids);

            if (count > 0)
            {
                //删除后，跳转到列表页面，并提示
                return Json(new { Url = "MgOrganiseList", SuccessInfo = "删除成功！" });
            }
            else
            {
                //删除后，跳转到列表页面，并提示
                return Json(new { Url = "MgOrganiseList", SuccessInfo = "删除失败！" });
            }
        }


        public string GetTreeNode(string id, IList<Treenodes> treenodesList)
        {
            //获取该角色的权限配置
            string popedomStr = "";
            IList<MgPopedom> popedomList = MgPopedomService.GetAllMgPopedomBySql(HttpContext, " where role_id='" + ViewBag.RoleId + "' and operate_type<>'Disuse'");//
            if (popedomList.Count != 0)
            {
                foreach (MgPopedom mgPopedom in popedomList)
                {
                    popedomStr += mgPopedom.PrivilegeFlag.ToString() + ",";
                }
            }
            //匹配样式
            double len = 0;
            var query = from treenodes in treenodesList
                        where treenodes.ParentId == id
                        select treenodes;
            string htmlStr = "";
            htmlStr += "{ ";
            foreach (var treenode in query.ToList<Treenodes>())
            {
                //判断该节点是否是父节点    
                var querySubNode = from treenodes in treenodesList
                                   where treenodes.ParentId == treenode.PrivilegeId
                                   select treenodes;
                len = 285 - 12 * treenode.NodeName.Replace(" ", "").Length - ((treenode.PrivilegeId.Length / 3) - 1) * 18;
                //组公用的选择控件
                string checStr = "<span style=\'margin-left: " + len + "px\'><input type=checkbox id=\'sel-" + treenode.PrivilegeId + "\' ParentId=\'sel-" + treenode.ParentId + "\'";
                if (popedomStr.Contains("sel-" + treenode.PrivilegeId + ","))
                {//如果查看权限选中
                    checStr += " checked=checked ";
                }
                checStr += " onchange=\'javascript:checkObj(this,1);\' />";
                checStr += "</span><span style=\'margin-left: 50px\'>";
                checStr += "<input type=checkbox id=\'add-" + treenode.PrivilegeId + "\' ParentId=\'add-" + treenode.ParentId + "\'";
                if (popedomStr.Contains(",add-" + treenode.PrivilegeId + ","))
                {//如果增改权限选中
                    checStr += " checked=checked ";
                }
                checStr += "onchange=\'javascript:checkObj(this,1);\' />"
                    + "</span><span style=\'margin-left: 50px\'>"
                    + "<input type=checkbox id=\'del-" + treenode.PrivilegeId + "\' ParentId=\'del-" + treenode.ParentId + "\'";
                if (popedomStr.Contains(",del-" + treenode.PrivilegeId + ","))
                {//如果删除权限选中
                    checStr += " checked=checked ";
                }
                checStr += "onchange=\'javascript:checkObj(this,1);\' />"
                    + "</span><span style=\'margin-left: 50px\'>"
                    + "<input type=checkbox id=\'" + treenode.PrivilegeId + "\' ParentId=\'" + treenode.ParentId + "\'";
                if (popedomStr.Contains("," + treenode.PrivilegeId + ","))
                {//如果删除权限选中
                    checStr += " checked=checked ";
                }
                checStr += "onchange=\'javascript:selectAll(this,1);\' /></span>\",";
                if (querySubNode.ToArray<Comit.XJPublicServicePlatform.Web.Domain.Management.Treenodes>().Length == 0)
                {
                    htmlStr += "\"" + treenode.PrivilegeId + "\": {\"name\":\"<span>" + treenode.NodeName + "</span>" + checStr + ""
                        + "\"type\":\"item\"},";
                }
                else
                {
                    //<span style=\'margin-left: 145px\'><b>查看权限</b></span><span style=\'margin-left: 20px\'><b>增改权限</b></span><span style=\'margin-left: 20px\'><b>删除权限</b></span><span style=\'margin-left: 20px\'><b>全选节点权限</b></span>\",
                    htmlStr += "\"" + treenode.PrivilegeId + "\": {\"name\":\"<span>" + treenode.NodeName + "</span>" + checStr + "\"type\":\"folder\",\"additionalParameters\":{\"children\":"
                        + GetTreeNode(treenode.PrivilegeId, treenodesList)
                        + "}},";
                }
            }
            if (htmlStr.EndsWith(","))
            {
                htmlStr = htmlStr.Substring(0, htmlStr.LastIndexOf(","));
            }
            return htmlStr + "}";
        }

        public string GetJsonStr()
        {
            string str = "{";

            #region ///旧的转换方法
            str = "var tree_data = {";
            IList<Treenodes> listTreeNodes = TreenodesService.GetAllTreenodesBySql(HttpContext, " where 1=1");
            List<Treenodes> FirstNodes = listTreeNodes.Where(treenodes => treenodes.ParentId == "0").ToList();
            List<Treenodes> SecNodes = listTreeNodes.Where(treenodes => treenodes.ParentId.Length == 3).ToList();
            List<Treenodes> ThrNodes = listTreeNodes.Where(treenodes => treenodes.ParentId.Length == 6).ToList();
            //获取该角色的权限配置
            string popedomStr = "";
            IList popedomList = MgPopedomService.GetAllMgPopedomBySql(HttpContext, " where role_id='" + ViewBag.RoleId + "' and operate_type<>'Disuse'");
            if (popedomList.Count != 0)
            {
                foreach (Hashtable hashtable in popedomList)
                {
                    popedomStr += hashtable["privilege_flag"].ToString() + ",";
                }
            }

            foreach (Treenodes node in FirstNodes)
            {
                str += "'" + node.PrivilegeId + "':{name:'" + node.NodeName + "<input type=checkbox id='" + node.PrivilegeId + "'onclick=\'javascript:checkAll(this);\' /><span>" + node.NodeName + "</span><span style=\'margin-left: 145px\'><b>查看权限</b></span><span style=\'margin-left: 20px\'><b>增改权限</b></span><span style=\'margin-left: 20px\'><b>删除权限</b></span><span style=\'margin-left: 20px\'><b>全选节点权限</b></span>\"\r\n);',type:'folder'},";
            }
            //去掉最后的逗号
            str = str.Substring(0, str.Length - 1) + "}";
            //获取二级节点的配置
            foreach (Treenodes node in FirstNodes)
            {
                str += " tree_data['" + node.PrivilegeId + "']['additionalParameters'] = {'children' : {";
                foreach (Treenodes secnode in SecNodes.Where(tree => tree.ParentId == node.PrivilegeId))
                {
                    str += "'" + secnode.PrivilegeId + "' : {name: '" + secnode.NodeName + " <span style=\'margin-left: 50px\'><input type=checkbox id=\'(sel)" + secnode.PrivilegeId + "\' ParentId=\'(sel)" + secnode.ParentId + "\'";
                    if (popedomStr.Contains(",(sel)" + secnode.PrivilegeId + ","))
                    {//如果查看权限选中
                        str += " checked ";
                    }
                    str += " onclick=\'javascript:checkObj(this,1);\' />";
                    str += "</span><span style=\'margin-left: 50px\'>";
                    str += "<input type=checkbox id=\'(add)" + secnode.PrivilegeId + "\' ParentId=\'(add)" + secnode.ParentId + "\'";
                    if (popedomStr.Contains(",(add)" + secnode.PrivilegeId + ","))
                    {//如果增改权限选中
                        str += " checked ";
                    }
                    str += "onclick=\'javascript:checkObj(this,1);\' />"
                        + "</span><span style=\'margin-left: 50px\'>"
                        + "<input type=checkbox id=\'(del)" + secnode.PrivilegeId + "\' ParentId=\'(del)" + secnode.ParentId + "\'";
                    if (popedomStr.Contains(",(del)" + secnode.PrivilegeId + ","))
                    {//如果删除权限选中
                        str += " checked ";
                    }
                    str += "onclick=\'javascript:checkObj(this,1);\' />"
                        + "</span><span style=\'margin-left: 50px\'>"
                        + "<input type=checkbox id=\'" + secnode.PrivilegeId + "\' ParentId=\'" + secnode.ParentId + "\'";
                    if (popedomStr.Contains("," + secnode.PrivilegeId + ","))
                    {//如果删除权限选中
                        str += " checked ";
                    }
                    str += "onclick=\'javascript:selectAll(this,1);\' />"
                        + "</span>\",\"\",\"\",\"main\");\r\n";
                    string treeType = ThrNodes.Where(tree => tree.ParentId == secnode.PrivilegeId).Count() > 0 ? "folder" : "item";
                    str += "', type: '" + treeType + "'},";
                }
                if (str.EndsWith(","))
                {
                    str = str.Substring(0, str.LastIndexOf(",")) + "}";
                }

            }
            //获取第三级的节点
            if (ThrNodes.Count != 0)
            {
                foreach (Treenodes node in FirstNodes)
                {
                    str += " tree_data['" + node.PrivilegeId + "']['additionalParameters']['children']";
                    foreach (Treenodes secnode in SecNodes.Where(tree => tree.ParentId == node.PrivilegeId))
                    {
                        str += "['" + secnode.PrivilegeId + "']['additionalParameters']={'children':{ ";
                        foreach (Treenodes thrnode in ThrNodes.Where(tree => tree.ParentId == node.PrivilegeId))
                        {
                            str += "'" + thrnode.PrivilegeId + "' : {name: '" + thrnode.NodeName + " <span style=\'margin-left: 50px\'><input type=checkbox id=\'(sel)" + thrnode.PrivilegeId + "\' ParentId=\'(sel)" + thrnode.ParentId + "\'";
                            if (popedomStr.Contains(",(sel)" + thrnode.PrivilegeId + ","))
                            {//如果查看权限选中
                                str += " checked ";
                            }
                            str += " onclick=\'javascript:checkObj(this,1);\' />";
                            str += "</span><span style=\'margin-left: 50px\'>";
                            str += "<input type=checkbox id=\'(add)" + thrnode.PrivilegeId + "\' ParentId=\'(add)" + thrnode.ParentId + "\'";
                            if (popedomStr.Contains(",(add)" + thrnode.PrivilegeId + ","))
                            {//如果增改权限选中
                                str += " checked ";
                            }
                            str += "onclick=\'javascript:checkObj(this,1);\' />"
                                + "</span><span style=\'margin-left: 50px\'>"
                                + "<input type=checkbox id=\'(del)" + thrnode.PrivilegeId + "\' ParentId=\'(del)" + thrnode.ParentId + "\'";
                            if (popedomStr.Contains(",(del)" + thrnode.PrivilegeId + ","))
                            {//如果删除权限选中
                                str += " checked ";
                            }
                            str += "onclick=\'javascript:checkObj(this,1);\' />"
                                + "</span><span style=\'margin-left: 50px\'>"
                                + "<input type=checkbox id=\'" + thrnode.PrivilegeId + "\' ParentId=\'" + thrnode.ParentId + "\'";
                            if (popedomStr.Contains("," + thrnode.PrivilegeId + ","))
                            {//如果删除权限选中
                                str += " checked ";
                            }
                            str += "onclick=\'javascript:selectAll(this,1);\' />"
                                + "</span>\",\"\",\"\",\"main\");\r\n";
                            str += "', type: 'item'},";
                        }
                    }
                    if (str.EndsWith(","))
                    {
                        str = str.Substring(0, str.LastIndexOf(",")) + "}";
                    }
                }
            }
            #endregion

            str += "}";
            return str;
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save()
        {
            //先删除该角色配置
            string sqlTmp = " delete FROM mg_popedom where role_id = '" + Request.Form["RoleId"].ToString() + "';";
            string treeId = Request.Form["ParaTreeId"];
            string[] arrTmp = treeId.Split(',');
            string oldId = "";
            string privilegeFlag = "";
            foreach (string tmp in arrTmp)
            {
                string id = tmp.Replace("sel-", "").Replace("add-", "").Replace("del-", "");
                if (id != oldId)
                {
                    if (oldId != "" && (privilegeFlag.Contains("sel-") || privilegeFlag.Contains("add-") || privilegeFlag.Contains("del-")))
                    {
                        sqlTmp += " insert into mg_popedom (role_id,privilege_id,privilege_flag,sys_code,operate_person,operate_time,operate_type) values ('" + Request.Form["RoleId"].ToString() + "','" + oldId.Substring(0, oldId.Length) + "','" + privilegeFlag + "','" + oldId.Substring(oldId.Length - 1) + "','administrator','" + DateTime.Now + "','Add');";//" + Session["user_code"].ToString() + "

                    }
                    oldId = id;
                    privilegeFlag = "";

                }
                privilegeFlag += tmp + ",";
            }
            int n = MgOrganiseService.AddPopedoms(sqlTmp);
            if (n > 0)
            { return Json(new { Url = "MgOrganiseList", SuccessInfo = "保存成功！" }); }
            else
            { return Json(new { Url = "MgOrganiseList", SuccessInfo = "保存失败！" }); }   
        }

        #endregion
    }
}
