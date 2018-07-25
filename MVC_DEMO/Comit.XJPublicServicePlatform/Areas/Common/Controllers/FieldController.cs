/******************************************************************************** 
** 作者：余穗海
** 时间：2014-07-25 10:27:06
** 描述：field(field)表的Controller(自动生成 )
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
using Comit.XJPublicServicePlatform.Web.Domain.Common;
using Comit.XJPublicServicePlatform.Web.Service.Common;

namespace Comit.XJPublicServicePlatform.Areas.Common.Controllers
{
	///[HandleError(Order = 1)]
    ///[UrlAuthorize(Order = 2)]
    public class FieldController : TeController
    {
    	#region 属性

        public IFieldService FieldService { get; set; }

        #endregion
        
        #region Action
        
        /// <summary>
        /// GET 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            this.BasePage_Load("field列表", "page");
            return View();
        }

        /// <summary>
        /// 详情页 初始化页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            string id = Security.DecryptQueryString(Request.QueryString["id"]);
            Field field = new Field();
            if (id != null && id != "null" && id != "")
            {//查询时页面初始化
                field = FieldService.GetFields(HttpContext, new Field() { Id = int.Parse(id) }).FirstOrDefault();
                if (field == null)
                {
                    field = new Field()
                    {
                        //初始化工作
                    };
                }
            }
            else
            {//新增时页面初始化
                field = new Field()
                {
                    //初始化工作
                };
            }
            //其他页面初始化，如下拉框选择

            ViewBag.Title="field详情";
            this.BasePage_Load("field详情", "page");
            return View(field);
        }

        /// <summary>
        /// 详细页面操作
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Operate(Field objField)
        {
            if (ModelState.IsValid)
            {//是否正确绑定
                if (objField.Id == -2147483648)
                {//根据主键是否为空，来判断是否新增

                    return Create(objField);
                }
                else if (objField.Id != -2147483648)
                {//根据主键是否为空，来判断是否修改
                    return Edit(objField);
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
        /// <param name="objField">Field实例</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Field objField)
        {
            //数据新增
            objField.Id = FieldService.AddField(HttpContext, objField);
            //操作成功返回
            return Json(new { PkName = "Id", PkValue = objField.Id, SuccessInfo = "新增成功！" });
        }

        /// <summary>
        /// POST 编辑
        /// </summary>
        /// <param name="objField">Field实例</param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Edit(Field objField)
        {
            //数据修改
            int count = FieldService.UpdateField(HttpContext, objField);
            //操作成功返回
            return Json(new { PkName = "Id", PkValue = objField.Id, SuccessInfo = "修改成功！" });
        }

        /// <summary>
        /// 删除一条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string[] id)
        {
            int count = 0;

            //删除后，跳转到列表页面，并提示
            return Json(new { Url = "index", SuccessInfo = "删除成功！" });
        }

                
        #endregion
   	}
}
