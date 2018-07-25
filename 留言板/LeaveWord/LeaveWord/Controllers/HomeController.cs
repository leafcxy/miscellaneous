using LeaveWord.Dao.IBatis.message;
using LeaveWord.Dao.Interface.message;
using LeaveWord.Domain.message;
using LeaveWord.Service.message.Interface;
using LeaveWord.ViewModels;
using LeaveWord.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using LeaveWord.Service.reply.Interface;
using LeaveWord.Service.user.Interface;
using LeaveWord.Domain.reply;

namespace LeaveWord.Controllers
{
    public class HomeController : Controller
    {
        public IMessageService MessageService { get; set; }
        public IReplyService ReplyService { get; set; }
        public IUserProfileService UserProfileService { get; set; }
        //
        // GET: /Home/
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        //
        // GET: /Home/GetDataList
        [HttpGet]
        public JsonResult GetDataList(int pageNumber = 1,int pageSize = 10)
        {
            List<HomeViewModel> HomeViewModels = new List<HomeViewModel>();
            List<MessageViewModel> MessageViewModels = new List<MessageViewModel>();
            var ht = new Hashtable();
            ht.Add("pageNumber", pageNumber);
            ht.Add("pageSize", pageSize);
            IList<Message> Messages = MessageService.GetPageMessages(HttpContext, ht);
            foreach (var i in Messages)
            {
                var a = String.Empty;
                foreach (var j in UserProfileService.GetAllUserProfileBySql(HttpContext, "where UserId = " + i.UserId))
                {
                    a = j.UserName;
                }
                if (a == "")
                {
                    a = "账户已注销！";
                }
                MessageViewModel b = new MessageViewModel()
                {
                    MessageId = i.MessageId,
                    UserName = a,
                    MessageInfo = i.MessageInfo,
                    MessageTag = i.MessageTag,
                    MessageDatetime = i.MessageDatetime.ToString()
                };
                MessageViewModels.Add(b);
            }
            foreach (var i in MessageViewModels)
            {
                HomeViewModel a = new HomeViewModel();
                a.MViewModel = i;
                //a.RViewModels = new List<ReplyViewModel>();
                var e = new List<ReplyViewModel>();
                var b = ReplyService.GetAllReplyBySql(HttpContext, "where MessageId = " + i.MessageId);
                foreach (var j in b)
                {
                    var c = String.Empty;
                    foreach (var k in UserProfileService.GetAllUserProfileBySql(HttpContext, "where UserId = " + j.UserId))
                    {
                        c = k.UserName;
                    }
                    var d = new ReplyViewModel()
                    {
                        ReplyId = j.ReplyId,
                        UserName = c,
                        MessageId = j.MessageId,
                        ReplyInfo = j.ReplyInfo,
                        ReplyDatetime = j.ReplyDatetime.ToString()
                    };
                    e.Add(d);
                }
                a.RViewModels = e;
                HomeViewModels.Add(a);
            }
            var re = new Hashtable();
            re.Add("total", MessageService.GetMessageCount(HttpContext, "where MessageTag=1"));
            re.Add("rows", HomeViewModels);
            re.Add("page", pageNumber);
            return Json(re, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Home/GetDataListByWords
        [HttpGet]
        public JsonResult GetDataListByWords(int pageNumber = 1, int pageSize = 10,string keywords = "")
        {
            if (keywords.Trim() == "")
            {
                RedirectToAction("GetDataList");
            }
            List<HomeViewModel> HomeViewModels = new List<HomeViewModel>();
            List<MessageViewModel> MessageViewModels = new List<MessageViewModel>();
            var ht = new Hashtable();
            ht.Add("pageNumber", pageNumber);
            ht.Add("pageSize", pageSize);
            ht.Add("words", keywords);
            IList<Message> Messages = MessageService.GetPageMessagesByWords(HttpContext, ht);
            foreach (var i in Messages)
            {
                var a = String.Empty;
                foreach (var j in UserProfileService.GetAllUserProfileBySql(HttpContext, "where UserId = " + i.UserId))
                {
                    a = j.UserName;
                }
                if (a == "")
                {
                    a = "账户已注销！";
                }
                MessageViewModel b = new MessageViewModel()
                {
                    MessageId = i.MessageId,
                    UserName = a,
                    MessageInfo = i.MessageInfo,
                    MessageTag = i.MessageTag,
                    MessageDatetime = i.MessageDatetime.ToString()
                };
                //if (b.MessageTag == 2)
                //{
                //    continue;
                //}
                MessageViewModels.Add(b);
            }
            foreach (var i in MessageViewModels)
            {
                HomeViewModel a = new HomeViewModel();
                a.MViewModel = i;
                //a.RViewModels = new List<ReplyViewModel>();
                var e = new List<ReplyViewModel>();
                var b = ReplyService.GetAllReplyBySql(HttpContext, "where MessageId = " + i.MessageId);
                foreach (var j in b)
                {
                    var c = String.Empty;
                    foreach (var k in UserProfileService.GetAllUserProfileBySql(HttpContext, "where UserId = " + j.UserId))
                    {
                        c = k.UserName;
                    }
                    var d = new ReplyViewModel()
                    {
                        ReplyId = j.ReplyId,
                        UserName = c,
                        MessageId = j.MessageId,
                        ReplyInfo = j.ReplyInfo,
                        ReplyDatetime = j.ReplyDatetime.ToString()
                    };
                    e.Add(d);
                }
                a.RViewModels = e;
                HomeViewModels.Add(a);
            }
            var re = new Hashtable();
            re.Add("total", MessageService.GetMessageCount(HttpContext, "where MessageInfo like '%" + keywords + "%' and MessageTag=1"));
            re.Add("rows", HomeViewModels);
            re.Add("page", pageNumber);
            return Json(re, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Home/About
        public ActionResult About()
        {
            ViewBag.Home = "Your app description page.";

            return View();
        }
        //
        // GET: /Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Home = "Your contact page.";

            return View();
        }
    }
}
