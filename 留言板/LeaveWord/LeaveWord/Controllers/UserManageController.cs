using LeaveWord.Models;
using LeaveWord.Service.user.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace LeaveWord.Controllers
{
    public class UserManageController : Controller
    {
        public IUserProfileService UserProfileService { get; set; }
        public IMembershipService MembershipService { get; set; }
        //
        // GET: /UserManage/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            //string[] a = Roles.GetUsersInRole("Simple");

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult GetPageUsers(int page = 1, int rows = 10)
        {
            var ht = new Hashtable();
            ht.Add("pageNumber", page);
            ht.Add("pageSize", rows);
            IList<LeaveWord.Domain.user.UserProfile> b = UserProfileService.GetPageUsers(HttpContext, ht);
            List<UserViewModel> v = new List<UserViewModel>();
            foreach (var i in b)
            {
                var c = MembershipService.GetAllMembershipBySql(HttpContext, "where UserId =" + i.UserId)[0];
                UserViewModel t = new UserViewModel();
                t.uid = i.UserId;
                t.uname = i.UserName;
                t.cdate = c.CreateDate.ToString();
                t.fdate = c.LastPasswordFailureDate.ToString();
                v.Add(t);

            }
            var vt = new Hashtable();
            vt.Add("page", page);
            vt.Add("rows", v);
            vt.Add("total", UserProfileService.GetUserProfileCount(HttpContext, ""));
            return Json(vt);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public int Delete(int id = 0)
        {
            if(id == 1){
                return 0;
            }
            return UserProfileService.DeleteUserProfile(HttpContext,new LeaveWord.Domain.user.UserProfile(){
                UserId = id
            });

        }
    }
}
