/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-25 14:48:37
** 描述：mg_users(用户信息
   
   登录密码：按)表的Controller(自动生成 )
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
using Comit.XJPublicServicePlatform.Web.Dao.IBatis.Management;

using System.Data;
using Comit.XJPublicServicePlatform.Web.Dao.IBatis.Common;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using IBatisNet.DataMapper;


namespace Comit.XJPublicServicePlatform.Areas.Management.Controllers
{
	///[HandleError(Order = 1)]
    ///[UrlAuthorize(Order = 2)]
    public class MgUsersController : TeController
    {
    	#region 属性

        public IMgUsersService MgUsersService { get; set; }
        public IMgOrganiseService MgOrganiseService { get; set; }
        public IUserRoleRelateService UserRoleRelateService { get; set; }
        #endregion
        public CommonDao objCommonDao { get; set; }
        public IMapper DataMapper { get; set; }
        public ExcelExport objExcelExport { get; set; }
        #region Action
        
        /// <summary>
        /// GET 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult MgUsersList()
        {
            this.BasePage_Load("用户信息", "treeNodePage");
            return View();
        }

        /// <summary>
        /// 详情页 初始化页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MgUsersDetail()
        {
            string id = Security.DecryptQueryString(Request.QueryString["id"]);
            MgUsers mgUsers = new MgUsers();
            ViewBag.CanDelete = "1";
            if (id != null && id != "null" && id != "")
            {//查询时页面初始化
                mgUsers = MgUsersService.GetMgUserss(HttpContext, new MgUsers() { Id = long.Parse(id) }).FirstOrDefault();
                if (mgUsers == null)
                {
                    mgUsers = new MgUsers()
                    {
                        //初始化工作

                    };
                }
                else
                {
                    if (mgUsers.UserCode == Session["user_code"].ToString())
                    {//不能删除自己的账号
                        ViewBag.CanDelete = "0";
                    }
                }
            }
            else
            {//新增时页面初始化
                mgUsers = new MgUsers()
                {
                    //初始化工作
                };
            }
            //其他页面初始化，如下拉框选择
            //获取角色list
            IList<MgOrganise> listMgOrganise = MgOrganiseService.GetAllMgOrganiseBySql(HttpContext, " where 1=1 and operate_type!='Disuse'");
            IList<UserRoleRelate> listUserRoleRelate = UserRoleRelateService.GetUserRoleRelates(HttpContext, new UserRoleRelate() { UserCode = mgUsers.UserCode, OperateType = "Add" });
            ViewData["list"] = new MultiSelectList(listMgOrganise, "RoleId", "RoleName", listUserRoleRelate.Select(userRoleRelate=>userRoleRelate.RoleId));
            ////获取该用户的角色信息
            //IList<UserRoleRelate> listUserRoleRelate = UserRoleRelateService.GetUserRoleRelates(HttpContext, new UserRoleRelate() { UserCode = mgUsers.UserCode, OperateType = "Add" });
            //ViewData["userRolelist"] = listUserRoleRelate;
            ViewBag.Title="用户信息";
            ViewBag.role_nam = "111111";
            this.BasePage_Load("用户信息", "page");
            Session["userRole"] = mgUsers.UserCode;
            return View(mgUsers);
        }

        /// <summary>
        /// 详细页面操作
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Operate(MgUsers objMgUsers)
        {
            if (objMgUsers.Id > 0)
            {
                
                MgUsers Model = MgUsersService.GetAllMgUsersBySql(HttpContext, "WHERE Id = " + objMgUsers.Id).FirstOrDefault();
                if (Model != null && string.IsNullOrEmpty(objMgUsers.Password))
                {
                    objMgUsers.Password = Model.Password;
                }
            }
            if (ModelState.IsValid)
            {//是否正确绑定
                if (objMgUsers.Id == -2147483648||objMgUsers.Id == -9223372036854775808)
                {//根据主键是否为空，来判断是否新增

                    return Create(objMgUsers);
                }
                else if (objMgUsers.Id != -2147483648&&objMgUsers.Id != -9223372036854775808)
                {//根据主键是否为空，来判断是否修改
                    return Edit(objMgUsers);
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
        /// <param name="objMgUsers">MgUsers实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(MgUsers objMgUsers)
        {
            //用户账号不能重复
            if(CheckUserName(objMgUsers.UserCode).Equals("1"))
            {
                return Json(new { PkName = "Id", PkValue = objMgUsers.Id, SuccessInfo = "新增失败！用户账号[" + objMgUsers.UserCode + "]已经存在。" });
            }
            //数据记录状态
            objMgUsers.OperateType = "Add";
            objMgUsers.OperatePerson = GetOperatePerson();
            objMgUsers.OperateTime = GetOperateTime();
            objMgUsers.Password = Security.EncryptPassWord(objMgUsers.Password);
            //数据新增
            objMgUsers.Id = MgUsersService.AddMgUsers(HttpContext, objMgUsers);
           if(objMgUsers.Id > 0)
           {
               Session["userRole"] = objMgUsers.UserCode;
                //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objMgUsers.Id, SuccessInfo = "新增成功！" });
           }
           else
           {
                //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objMgUsers.Id, SuccessInfo = "新增失败！" });
           }
        }

        /// <summary>
        /// POST 编辑
        /// </summary>
        /// <param name="objMgUsers">MgUsers实例</param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Edit(MgUsers objMgUsers)
        {
            //数据记录状态变更
              objMgUsers.OperateType = "Update";
            objMgUsers.OperatePerson = GetOperatePerson();
            objMgUsers.OperateTime = GetOperateTime();
            objMgUsers.Password = Security.EncryptPassWord(objMgUsers.Password);
            //数据修改
            int count = MgUsersService.UpdateMgUsers(HttpContext, objMgUsers);

           if(count > 0)
           {
               //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objMgUsers.Id, SuccessInfo = "修改成功！" });
           }
           else
           {
               //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objMgUsers.Id, SuccessInfo = "修改失败！" });
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

            count = MgUsersService.DeleteMgUserss(HttpContext, lids);

           if(count > 0)
           {
               //删除后，跳转到列表页面，并提示
               return Json(new { Url = "MgUsersList", SuccessInfo = "删除成功！" });
           }
           else
           {
               //删除后，跳转到列表页面，并提示
               return Json(new { Url = "MgUsersList", SuccessInfo = "删除失败！" });
           }
        }

        /// <summary>
        /// 增加角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save()
        {
            UserRoleRelate objUserRoleRelate = new UserRoleRelate();
            string[] ids=new string[] { "" };
            string roldIds;
            if(Request.Form["role"]!=null)
            {
                roldIds = Request.Form["role"].ToString();
                ids = roldIds.Split(',');
            }
            
            int count = 0;
            //先删除该用户的角色配置再重新配置
            int z = UserRoleRelateService.BatchDeleteUserRoleRelateBySql(HttpContext, " where operate_type!='Disuse' and user_code='" + Session["userRole"].ToString() + "'");
            for (int i = 0; i < ids.Count(); i++)
            {
                objUserRoleRelate.RoleId = ids[i].ToString();
                objUserRoleRelate.UserCode = Session["userRole"].ToString();
                objUserRoleRelate.OperateType = "Add";
                long n = UserRoleRelateService.AddUserRoleRelate(HttpContext, objUserRoleRelate);
                if (n != 0)
                {
                    count++;
                }   
            }

            if (count == ids.Count())
            {
                //删除后，跳转到列表页面，并提示
                return Json(new { SuccessInfo = "保存成功！" });
            }
            else
            {
                //删除后，跳转到列表页面，并提示
                return Json(new { SuccessInfo = "保存失败！" });
            }
        }

        /// <summary>
        /// 检查是否有该角色
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckRole(string roleId)
        {
            ContentResult ctRes = new ContentResult();
            UserRoleRelate objUserRoleRelate = new UserRoleRelate();
            objUserRoleRelate = UserRoleRelateService.GetUserRoleRelates(HttpContext, new UserRoleRelate() { UserCode=Session["userRole"].ToString(), RoleId = roleId }).FirstOrDefault();
            if (objUserRoleRelate != null)
            {
                ctRes.Content = "true";
            }
            else
            { ctRes.Content = "false"; }

            return ctRes;
        }

        /// <summary>
        /// 检查用户名是否已经存在
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public string CheckUserName(string userCode)
        {
            string isExist = "0";

            MgUsers users = new MgUsers { UserCode = userCode };

            isExist = MgUsersService.GetMgUserss(HttpContext,users).Count > 0 ? "1" : "0";
            //isExist = MgUsersService.GetAllMgUsersBySql(HttpContext, " where user_code='" + userCode + "' and operate_type!='Disuse'").Count > 0 ? "1" : "0";

            return isExist;
        }
                
        #endregion

        /// <summary>
        /// 导出预警信息
        /// </summary>
        /// <param name="starTime"></param>
        /// <param name="endTime"></param>
        /// <param name="warnType"></param>
        /// <returns></returns>
        
        public string Expect(string starTime, string endTime, string warnType)
        {
            try
            {
                string str = "";
                //str = RuleOptionService.getWarnStr(starTime, endTime, warnType);
                DataTable dt = new DataTable();
                //dt = ToDataTable(RuleOptionService.getWarnStr(starTime, endTime, warnType));
                DataSet ds = new DataSet();
                ds = objCommonDao.GetDataSetBySql("select ship_name,wg_time from wg_sea_info", DataMapper.Get());
                dt = ds.Tables[0];
                ExcelExport EE = new ExcelExport();
                //objExcelExport.ExportExcel("aaa", dt);
                EE.ExportExcel("aaa", dt);
                //return Json(new { SuccessInfo = "导出成功！" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //return Json(new { SuccessInfo = "导出成功" });
            }

            return "";
        }
        [HttpPost]
        public ActionResult UploadFile()
        {
            System.Web.HttpFileCollectionBase imgFile = Request.Files;
            
            UploadFiles up = new UploadFiles();
            string fileUrl = up.Upload(imgFile);
            fileUrl = fileUrl.Substring(fileUrl.IndexOf("Assets") - 1);
            if (true)
            {
                //删除后，跳转到列表页面，并提示
                return Json(new { SuccessInfo = fileUrl});
            }
            else
            {
                //删除后，跳转到列表页面，并提示
                return Json(new { SuccessInfo = "保存失败！" });
            }
        }
   	}
}