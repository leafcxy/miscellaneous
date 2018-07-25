using LeaveWord.Domain.message;
using LeaveWord.Domain.reply;
using LeaveWord.Models;
using LeaveWord.Service.message.Interface;
using LeaveWord.Service.reply.Interface;
using LeaveWord.Service.user.Interface;
using LeaveWord.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace LeaveWord.Controllers
{
    public class WordManageController : Controller
    {
        public IMessageService MessageService { get; set; }
        public IReplyService ReplyService { get; set; }
        public IUserProfileService UserProfileService { get; set; }
        //
        // GET: /WordManage/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
           
            return View();
        }
        //
        // POST: /WordManage/GetDataList
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult GetDataList(int page = 1, int rows = 10)
        {
            List<HomeViewModel> HomeViewModels = new List<HomeViewModel>();
            List<MessageViewModel> MessageViewModels = new List<MessageViewModel>();
            var ht = new Hashtable();
            ht.Add("pageNumber", page);
            ht.Add("pageSize", rows);
            IList<Message> Messages = MessageService.GetAllPageMessages(HttpContext, ht);
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
            re.Add("total", MessageService.GetMessageCount(HttpContext, ""));
            re.Add("rows", HomeViewModels);
            re.Add("page", page);
            return Json(re, JsonRequestBehavior.AllowGet);
        }
        //
        // POST: /WordManage/Reply
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public int Reply(string WordInfo, int id = 0)
        {
            return ReplyService.AddReply(HttpContext,new Reply(){
                ReplyId = 0,
                UserId = UserProfileService.GetAllUserProfileBySql(HttpContext,"where UserName = '"+User.Identity.Name+"'")[0].UserId,
                MessageId = id,
                ReplyInfo = WordInfo,
                ReplyDatetime = DateTime.Now
            });
        }
        //
        // POST: /WordManage/Open
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public int Open(int id = 0)
        {
            Message a = MessageService.GetAllMessageBySql(HttpContext, "where MessageId =" + id)[0];
            return MessageService.UpdateMessage(HttpContext,new Message(){
                MessageId = id,
                UserId = a.UserId,
                MessageInfo = a.MessageInfo,
                MessageTag = 1,
                MessageDatetime = a.MessageDatetime
            });
        }
    }
}
