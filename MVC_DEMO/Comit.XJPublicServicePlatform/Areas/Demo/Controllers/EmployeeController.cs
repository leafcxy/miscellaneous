/******************************************************************************** 
** 作者：张权
** 时间：2016-05-26 10:15:46
** 描述：employee(员工信息)表的Controller(自动生成 )
*********************************************************************************/

/*填写在sqlMap.config
	<!--员工信息-->
    <sqlMap resource="Setting/ORM/Maps/Employee.xml" />
*/
/*填写在unity.config的typeAliases节之下
	<!--员工信息-->
   	<typeAlias alias="IEmployeeDao" type="Comit.XJPublicServicePlatform.Web.Dao.Interface.Demo.IEmployeeDao, Comit.XJPublicServicePlatform.Web.Dao"/>
	<typeAlias alias="EmployeeDao" type="Comit.XJPublicServicePlatform.Web.Dao.IBatis.Demo.EmployeeDao, Comit.XJPublicServicePlatform.Web.Dao"/>
	<typeAlias alias="IEmployeeService" type="Comit.XJPublicServicePlatform.Web.Service.Demo.Interface.IEmployeeService, Comit.XJPublicServicePlatform.Web.Service"/>
	<typeAlias alias="EmployeeService" type="Comit.XJPublicServicePlatform.Web.Service.Demo.EmployeeService, Comit.XJPublicServicePlatform.Web.Service"/>
*/

/*填写在unity.config的types节之下
	<!--员工信息-->
   	<type type="IEmployeeDao" mapTo="EmployeeDao">
		<lifetime type="singleton"/>
	    <typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">

		</typeConfig>
	</type>
	<type type="IEmployeeService" mapTo="EmployeeService">
    	<lifetime type="singleton"/>
    	<typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">
        	<property name="EmployeeDao" propertyType="EmployeeDao">
           		<dependency />
         	</property>
	   	<property name="DataMapper" propertyType="TeMapper">
	        	<dependency />
	   	</property>
     	</typeConfig>
  	</type>
  	<type type="Comit.XJPublicServicePlatform.Areas.Demo.Controllers.EmployeeController,Comit.XJPublicServicePlatform">
    	<typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement,Microsoft.Practices.Unity.Configuration">
        	<property name="EmployeeService" propertyType="EmployeeService">
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
using Comit.XJPublicServicePlatform.Web.Domain.employee;
using Comit.XJPublicServicePlatform.Web.Service.employee.Interface;

namespace Comit.XJPublicServicePlatform.Areas.Demo.Controllers
{
	///[HandleError(Order = 1)]
    ///[UrlAuthorize(Order = 2)]
    public class EmployeeController : TeController
    {
    	#region 属性

        public IEmployeeService EmployeeService { get; set; }

        #endregion
        
        #region Action
        
        /// <summary>
        /// GET 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeList()
        {
            this.BasePage_Load("员工信息列表", "page");
            ViewBag.AddType = true;
            return View();
        }

        /// <summary>
        /// 详情页 初始化页面
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeDetail()
        {
            string id = Security.DecryptQueryString(Request.QueryString["id"]);
            Employee employee = new Employee();
            if (id != null && id != "null" && id != "")
            {//查询时页面初始化
                employee = EmployeeService.GetEmployees(HttpContext, new Employee() { Id = int.Parse(id) }).FirstOrDefault();
                if (employee == null)
                {
                    employee = new Employee()
                    {
                        //初始化工作
                    };
                }
            }
            else
            {//新增时页面初始化
                employee = new Employee()
                {
                    //初始化工作
                };
            }
            //其他页面初始化，如下拉框选择
            ViewBag.Province = GetSelectsInfo("省", employee.Province);
            ViewBag.City = GetSelectsInfo("市", employee.City);
            ViewBag.Title="员工信息详情";
            this.BasePage_Load("员工信息详情", "page");
            return View(employee);
        }
        

        /// <summary>
        /// POST 创建
        /// </summary>
        /// <param name="objEmployee">Employee实例</param>
        /// <returns></returns>
        [ActionName("Operate")]
        [AcceptVerbs(HttpVerbs.Post)]
        [ButtonActionMethodAttribute(Name = "button", Value = "新增")]
        public ActionResult Create(Employee objEmployee)
        {
            if (ModelState.IsValid && objEmployee.Id == -2147483648)
            {//是否正确绑定
                //数据记录状态
                  objEmployee.OperateType = "Add";
                objEmployee.OperatePerson = GetOperatePerson();
                objEmployee.OperateTime = GetOperateTime();
                //数据新增
                  objEmployee.Id = EmployeeService.AddEmployee(HttpContext, objEmployee);
               if(objEmployee.Id > 0)
               {
                   //操作成功返回
                     return Json(new { PkName = "Id", PkValue = objEmployee.Id, SuccessInfo = "新增成功！" });
               }
               else
               {
                    //操作成功返回
                       return Json(new { PkName = "Id", PkValue = objEmployee.Id, SuccessInfo = "新增失败！" });
               }
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// POST 编辑
        /// </summary>
        /// <param name="objEmployee">Employee实例</param>
        /// <returns></returns>

        [ActionName("Operate")]
        [AcceptVerbs(HttpVerbs.Post)]
        [ButtonActionMethodAttribute(Name = "button", Value = "修改")]
        public ActionResult Edit(Employee objEmployee)
        {
            if (ModelState.IsValid && objEmployee.Id != -2147483648)
            {//是否正确绑定
                //数据记录状态变更
                  objEmployee.OperateType = "Update";
                objEmployee.OperatePerson = GetOperatePerson();
                objEmployee.OperateTime = GetOperateTime();
                //数据修改
                int count = EmployeeService.UpdateEmployee(HttpContext, objEmployee);

               if(count > 0)
               {
                   //操作成功返回
                     return Json(new { PkName = "Id", PkValue = objEmployee.Id, SuccessInfo = "修改成功！" });
               }
               else
               {
                   //操作成功返回
                     return Json(new { PkName = "Id", PkValue = objEmployee.Id, SuccessInfo = "修改失败！" });
               }
            }
            else
            {
                return View();
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

            count = EmployeeService.DeleteEmployees(HttpContext, lids);

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
