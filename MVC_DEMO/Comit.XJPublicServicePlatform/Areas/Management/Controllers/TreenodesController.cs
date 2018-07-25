/******************************************************************************** 
** 作者：李鸿庭
** 时间：2014-08-06 09:09:08
** 描述：TreeNodes(菜单节点)表的Controller(自动生成 )
*********************************************************************************/

/*填写在sqlMap.config
	<!--菜单节点-->
    <sqlMap resource="Setting/ORM/Maps/Treenodes.xml" />
*/
/*填写在unity.config的typeAliases节之下
	<!--菜单节点-->
   	<typeAlias alias="ITreenodesDao" type="Comit.XJPublicServicePlatform.Web.Dao.Interface.ComitMap.ITreenodesDao, Comit.XJPublicServicePlatform.Web.Dao"/>
	<typeAlias alias="TreenodesDao" type="Comit.XJPublicServicePlatform.Web.Dao.IBatis.ComitMap.TreenodesDao, Comit.XJPublicServicePlatform.Web.Dao"/>
	<typeAlias alias="ITreenodesService" type="Comit.XJPublicServicePlatform.Web.Service.ComitMap.Interface.ITreenodesService, Comit.XJPublicServicePlatform.Web.Service"/>
	<typeAlias alias="TreenodesService" type="Comit.XJPublicServicePlatform.Web.Service.ComitMap.TreenodesService, Comit.XJPublicServicePlatform.Web.Service"/>
*/

/*填写在unity.config的types节之下
	<!--菜单节点-->
   	<type type="ITreenodesDao" mapTo="TreenodesDao">
		<lifetime type="singleton"/>
	    <typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">

		</typeConfig>
	</type>
	<type type="ITreenodesService" mapTo="TreenodesService">
    	<lifetime type="singleton"/>
    	<typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">
        	<property name="TreenodesDao" propertyType="TreenodesDao">
           		<dependency />
         	</property>
	   	<property name="DataMapper" propertyType="TeMapper">
	        	<dependency />
	   	</property>
     	</typeConfig>
  	</type>
  	<type type="XJPublicServicePlatform.Areas.Management.Controllers.TreenodesController,XJPublicServicePlatform.">
    	<typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">
        	<property name="TreenodesService" propertyType="TreenodesService">
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
    public class TreenodesController : TeController
    {
    	#region 属性

        public ITreenodesService TreenodesService { get; set; }

        #endregion
        
        #region Action
        
        /// <summary>
        /// GET 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult TreenodesList()
        {
            this.BasePage_Load("菜单节点列表", "page");
            return View();
        }

        /// <summary>
        /// 详情页 初始化页面
        /// </summary>
        /// <returns></returns>
        public ActionResult TreenodesDetail()
        {
            string id = Security.DecryptQueryString(Request.QueryString["id"]);
            Treenodes treenodes = new Treenodes();
            if (id != null && id != "null" && id != "")
            {//查询时页面初始化
                treenodes = TreenodesService.GetTreenodess(HttpContext, new Treenodes() { Id = int.Parse(id) }).FirstOrDefault();
                if (treenodes == null)
                {
                    treenodes = new Treenodes()
                    {
                        //初始化工作
                    };
                }
            }
            else
            {//新增时页面初始化
                treenodes = new Treenodes()
                {
                    //初始化工作
                };
            }
            //其他页面初始化，如下拉框选择
            ViewBag.Title="菜单节点详情";
            this.BasePage_Load("菜单节点详情", "page");
            return View(treenodes);
        }

        /// <summary>
        /// 详细页面操作
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Operate(Treenodes objTreenodes)
        {
            if (ModelState.IsValid)
            {//是否正确绑定
                if (objTreenodes.Id == -2147483648||objTreenodes.Id == -9223372036854775808)
                {//根据主键是否为空，来判断是否新增

                    return Create(objTreenodes);
                }
                else if (objTreenodes.Id != -2147483648&&objTreenodes.Id != -9223372036854775808)
                {//根据主键是否为空，来判断是否修改
                    return Edit(objTreenodes);
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
        /// <param name="objTreenodes">Treenodes实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Treenodes objTreenodes)
        {
            //数据记录状态
            objTreenodes.OperateType = "Add";
            objTreenodes.OperatePerson = GetOperatePerson();
            objTreenodes.OperateTime = GetOperateTime();
            //数据新增
            objTreenodes.Id = TreenodesService.AddTreenodes(HttpContext, objTreenodes);
           if(objTreenodes.Id > 0)
           {
                //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objTreenodes.Id, SuccessInfo = "新增成功！" });
           }
           else
           {
                //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objTreenodes.Id, SuccessInfo = "新增失败！" });
           }
        }

        /// <summary>
        /// POST 编辑
        /// </summary>
        /// <param name="objTreenodes">Treenodes实例</param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Edit(Treenodes objTreenodes)
        {
            //数据记录状态变更
              objTreenodes.OperateType = "Update";
            objTreenodes.OperatePerson = GetOperatePerson();
            objTreenodes.OperateTime = GetOperateTime();
            //数据修改
            int count = TreenodesService.UpdateTreenodes(HttpContext, objTreenodes);

           if(count > 0)
           {
               //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objTreenodes.Id, SuccessInfo = "修改成功！" });
           }
           else
           {
               //操作成功返回
                 return Json(new { PkName = "Id", PkValue = objTreenodes.Id, SuccessInfo = "修改失败！" });
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

            count = TreenodesService.DeleteTreenodess(HttpContext, lids);

           if(count > 0)
           {
               //删除后，跳转到列表页面，并提示
               return Json(new { Url = "TreenodesList", SuccessInfo = "删除成功！" });
           }
           else
           {
               //删除后，跳转到列表页面，并提示
               return Json(new { Url = "TreenodesList", SuccessInfo = "删除失败！" });
           }
        }

                
        #endregion
   	}
}
