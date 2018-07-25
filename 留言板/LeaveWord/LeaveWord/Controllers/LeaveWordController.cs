using LeaveWord.Domain.message;
using LeaveWord.Models;
using LeaveWord.Service.message.Interface;
using LeaveWord.Service.user.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace LeaveWord.Controllers
{
    public class LeaveWordController : Controller
    {
        public IMessageService MessageService { get; set; }
        public IUserProfileService UserProfileService { get; set; }
        //
        // GET: /LeaveWord/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        //
        // POST: /LeaveWord/
        [HttpPost]
        [Authorize]
        public int PostWords(string wordinfo)
        {
            //非空验证
            if (wordinfo.Trim() == "")
            {
                return 0;
            }
            var tet = User.Identity.Name;
            var test = UserProfileService.GetAllUserProfileBySql(HttpContext, "where UserName = '" + User.Identity.Name + "'");
            int a = MessageService.AddMessage(HttpContext, new Message()
            {
                MessageId = 0,
                UserId = UserProfileService.GetAllUserProfileBySql(HttpContext,"where UserName = '"+User.Identity.Name+"'")[0].UserId,
                MessageInfo = wordinfo,
                MessageTag = 2,
                MessageDatetime = DateTime.Now
            });
            return a;
        }
    }
}
