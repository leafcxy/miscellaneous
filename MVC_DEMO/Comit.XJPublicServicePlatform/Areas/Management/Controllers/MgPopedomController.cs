/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-07-28 18:56:15
** 描述：mg_popedom(权限管理
   
   )表的Controller(自动生成 )
*********************************************************************************/

/*填写在sqlMap.config
	<!--权限管理-->
    <sqlMap resource="Setting/ORM/Maps/ComitMap/MgPopedom.xml" />
*/
/*填写在unity.config的typeAliases节之下
	<!--权限管理-->
   	<typeAlias alias="IMgPopedomDao" type="XJPublicServicePlatform.Web.Dao.Interface.ComitMap.IMgPopedomDao, XJPublicServicePlatform.Web.Dao"/>
	<typeAlias alias="MgPopedomDao" type="XJPublicServicePlatform.Web.Dao.IBatis.ComitMap.MgPopedomDao, XJPublicServicePlatform.Web.Dao"/>
	<typeAlias alias="IMgPopedomService" type="XJPublicServicePlatform.Web.Service.ComitMap.Interface.IMgPopedomService, XJPublicServicePlatform.Web.Service"/>
	<typeAlias alias="MgPopedomService" type="XJPublicServicePlatform.Web.Service.ComitMap.MgPopedomService, XJPublicServicePlatform.Web.Service"/>
*/

/*填写在unity.config的types节之下
	<!--权限管理 -->
   	<type type="IMgPopedomDao" mapTo="MgPopedomDao">
		<lifetime type="singleton"/>
	    <typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">

		</typeConfig>
	</type>
	<type type="IMgPopedomService" mapTo="MgPopedomService">
    	<lifetime type="singleton"/>
    	<typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">
        	<property name="MgPopedomDao" propertyType="MgPopedomDao">
           		<dependency />
         	</property>
	   	<property name="DataMapper" propertyType="TeMapper">
	        	<dependency />
	   	</property>
     	</typeConfig>
  	</type>
  	<type type="XJPublicServicePlatform.Areas.Management.Controllers.MgPopedomController,XJPublicServicePlatform.">
    	<typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">
        	<property name="MgPopedomService" propertyType="MgPopedomService">
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
    public class MgPopedomController : TeController
    {
    	#region 属性

        public IMgPopedomService MgPopedomService { get; set; }

        #endregion
        
        #region Action
        
        /// <summary>
        /// GET 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            this.BasePage_Load("权限管理列表", "page");
            return View();
        }

        /// <summary>
        /// 详情页 初始化页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            string id = Security.DecryptQueryString(Request.QueryString["id"]);
            MgPopedom mgPopedom = new MgPopedom();
            if (id != null && id != "null" && id != "")
            {//查询时页面初始化
                mgPopedom = MgPopedomService.GetMgPopedoms(HttpContext, new MgPopedom() { Id = int.Parse(id) }).FirstOrDefault();
                if (mgPopedom == null)
                {
                    mgPopedom = new MgPopedom()
                    {
                        //初始化工作
                    };
                }
            }
            else
            {//新增时页面初始化
                mgPopedom = new MgPopedom()
                {
                    //初始化工作
                };
            }
            //其他页面初始化，如下拉框选择

            ViewBag.Title="权限管理详情";
            this.BasePage_Load("权限管理详情", "page");
            return View(mgPopedom);
        }

        /// <summary>
        /// 详细页面操作
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Operate(MgPopedom objMgPopedom)
        {
            if (ModelState.IsValid)
            {//是否正确绑定
                if (objMgPopedom.Id == -2147483648||objMgPopedom.Id == -9223372036854775808)
                {//根据主键是否为空，来判断是否新增

                    return Create(objMgPopedom);
                }
                else if (objMgPopedom.Id != -2147483648&&objMgPopedom.Id != -9223372036854775808)
                {//根据主键是否为空，来判断是否修改
                    return Edit(objMgPopedom);
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
        /// <param name="objMgPopedom">MgPopedom实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(MgPopedom objMgPopedom)
        {
            //数据记录状态
            objMgPopedom.OperateType = "Add";
            objMgPopedom.OperatePerson = GetOperatePerson();
            objMgPopedom.OperateTime = GetOperateTime();
            //数据新增
            objMgPopedom.Id = MgPopedomService.AddMgPopedom(HttpContext, objMgPopedom);
           if(objMgPopedom.Id > 0)
           {
                //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objMgPopedom.Id, SuccessInfo = "新增成功！" });
           }
           else
           {
                //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objMgPopedom.Id, SuccessInfo = "新增失败！" });
           }
        }

        /// <summary>
        /// POST 编辑
        /// </summary>
        /// <param name="objMgPopedom">MgPopedom实例</param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Edit(MgPopedom objMgPopedom)
        {
            //数据记录状态变更
              objMgPopedom.OperateType = "Update";
            objMgPopedom.OperatePerson = GetOperatePerson();
            objMgPopedom.OperateTime = GetOperateTime();
            //数据修改
            int count = MgPopedomService.UpdateMgPopedom(HttpContext, objMgPopedom);

           if(count > 0)
           {
               //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objMgPopedom.Id, SuccessInfo = "修改成功！" });
           }
           else
           {
               //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objMgPopedom.Id, SuccessInfo = "修改失败！" });
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

            count = MgPopedomService.DeleteMgPopedoms(HttpContext, lids);

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
