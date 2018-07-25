/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 17:04:57
** 描述：user_role_relate(用户和角色的关系)表的Controller(自动生成 )
*********************************************************************************/

/*填写在sqlMap.config
	<!--用户和角色的关系-->
    <sqlMap resource="Setting/ORM/Maps/ComitMap/UserRoleRelate.xml" />
*/
/*填写在unity.config的typeAliases节之下
	<!--用户和角色的关系-->
   	<typeAlias alias="IUserRoleRelateDao" type="XJPublicServicePlatform.Web.Dao.Interface.ComitMap.IUserRoleRelateDao, XJPublicServicePlatform.Web.Dao"/>
	<typeAlias alias="UserRoleRelateDao" type="XJPublicServicePlatform.Web.Dao.IBatis.ComitMap.UserRoleRelateDao, XJPublicServicePlatform.Web.Dao"/>
	<typeAlias alias="IUserRoleRelateService" type="XJPublicServicePlatform.Web.Service.ComitMap.Interface.IUserRoleRelateService, XJPublicServicePlatform.Web.Service"/>
	<typeAlias alias="UserRoleRelateService" type="XJPublicServicePlatform.Web.Service.ComitMap.UserRoleRelateService, XJPublicServicePlatform.Web.Service"/>
*/

/*填写在unity.config的types节之下
	<!--用户和角色的关系-->
   	<type type="IUserRoleRelateDao" mapTo="UserRoleRelateDao">
		<lifetime type="singleton"/>
	    <typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">

		</typeConfig>
	</type>
	<type type="IUserRoleRelateService" mapTo="UserRoleRelateService">
    	<lifetime type="singleton"/>
    	<typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">
        	<property name="UserRoleRelateDao" propertyType="UserRoleRelateDao">
           		<dependency />
         	</property>
	   	<property name="DataMapper" propertyType="TeMapper">
	        	<dependency />
	   	</property>
     	</typeConfig>
  	</type>
  	<type type="Comit.XJPublicServicePlatform.Web.Areas.Management.Controllers.UserRoleRelateController,XJPublicServicePlatform.">
    	<typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">
        	<property name="UserRoleRelateService" propertyType="UserRoleRelateService">
                <dependency />
          	</property>
        	<property name="CommonPageService" propertyType="CommonPageService">
                <dependency />
          	</property>
    	</typeConfig>
	</type>
*/

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
    public class UserRoleRelateController : TeController
    {
    	#region 属性

        public IUserRoleRelateService UserRoleRelateService { get; set; }
        public IMgOrganiseService MgOrganiseService { get; set; }

        #endregion
        
        #region Action
        
        /// <summary>
        /// GET 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            this.BasePage_Load("用户和角色的关系列表", "page");
            return View();
        }

        /// <summary>
        /// 详情页 初始化页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            string id = Security.DecryptQueryString(Request.QueryString["id"]);
            UserRoleRelate userRoleRelate = new UserRoleRelate();
            if (id != null && id != "null" && id != "")
            {//查询时页面初始化
                userRoleRelate = UserRoleRelateService.GetUserRoleRelates(HttpContext, new UserRoleRelate() { Id = int.Parse(id) }).FirstOrDefault();
                if (userRoleRelate == null)
                {
                    userRoleRelate = new UserRoleRelate()
                    {
                        //初始化工作
                    };
                }
            }
            else
            {//新增时页面初始化
                userRoleRelate = new UserRoleRelate()
                {
                    //初始化工作
                };
            }
            //其他页面初始化，如下拉框选择
            //获取角色list
            IList<MgOrganise> listMgOrganise = MgOrganiseService.GetAllMgOrganiseBySql(HttpContext," where 1=1");
            ViewData["list"] = new MultiSelectList(listMgOrganise, "RoleId", "RoleName", null);
            ViewBag.RoldId = new SelectList(listMgOrganise, "RoleId", "RoleName");
            //获取该用户的角色信息
            IList<UserRoleRelate> listUserRoleRelate = UserRoleRelateService.GetUserRoleRelates(HttpContext, new UserRoleRelate() { UserCode = "administrator" });

            ViewBag.Title="用户和角色的关系详情";
            this.BasePage_Load("用户和角色的关系详情", "page");
           
            return View(userRoleRelate);
        }

        /// <summary>
        /// 详细页面操作
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Operate(UserRoleRelate objUserRoleRelate)
        {
            objUserRoleRelate.RoleId = Request.Form["form-field-checkbox"].ToString();

            if (ModelState.IsValid)
            {//是否正确绑定
                if (objUserRoleRelate.Id == -2147483648||objUserRoleRelate.Id == -9223372036854775808)
                {//根据主键是否为空，来判断是否新增

                    return Create(objUserRoleRelate);
                }
                else if (objUserRoleRelate.Id != -2147483648&&objUserRoleRelate.Id != -9223372036854775808)
                {//根据主键是否为空，来判断是否修改
                    return Edit(objUserRoleRelate);
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
        /// <param name="objUserRoleRelate">UserRoleRelate实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(UserRoleRelate objUserRoleRelate)
        {
            //数据记录状态
            objUserRoleRelate.OperateType = "Add";
            objUserRoleRelate.OperatePerson = GetOperatePerson();
            objUserRoleRelate.OperateTime = GetOperateTime();
            //数据新增
            objUserRoleRelate.Id = UserRoleRelateService.AddUserRoleRelate(HttpContext, objUserRoleRelate);
           if(objUserRoleRelate.Id > 0)
           {
                //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objUserRoleRelate.Id, SuccessInfo = "新增成功！" });
           }
           else
           {
                //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objUserRoleRelate.Id, SuccessInfo = "新增失败！" });
           }
        }

        /// <summary>
        /// POST 编辑
        /// </summary>
        /// <param name="objUserRoleRelate">UserRoleRelate实例</param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Edit(UserRoleRelate objUserRoleRelate)
        {
            //数据记录状态变更
              objUserRoleRelate.OperateType = "Update";
            objUserRoleRelate.OperatePerson = GetOperatePerson();
            objUserRoleRelate.OperateTime = GetOperateTime();
            //数据修改
            int count = UserRoleRelateService.UpdateUserRoleRelate(HttpContext, objUserRoleRelate);

           if(count > 0)
           {
               //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objUserRoleRelate.Id, SuccessInfo = "修改成功！" });
           }
           else
           {
               //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objUserRoleRelate.Id, SuccessInfo = "修改失败！" });
           }
        }

        /// <summary>
        /// 删除一条或多条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string id)
        {
            int count = 0;
            long[] ids = id.Split(',').Select(s => long.Parse(s)).ToArray();
            IList<long> lids = new List<long>(ids);

            count = UserRoleRelateService.DeleteUserRoleRelates(HttpContext, lids);

           if(count > 0)
           {
               //删除后，跳转到列表页面，并提示
                 return Json(new { Url = "index", SuccessInfo = "删除成功！" });
           }
           else
           {
               //删除后，跳转到列表页面，并提示
                 return Json(new { Url = "index", SuccessInfo = "删除失败！" });
           }
        }

                
        #endregion
   	}
}
