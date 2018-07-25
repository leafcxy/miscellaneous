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
    public class MyWordController : Controller
    {
        public IMessageService MessageService { get; set; }
        public IReplyService ReplyService { get; set; }
        public IUserProfileService UserProfileService { get; set; }
        //
        // GET: /MyWord/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        //
        // POST: /MyWord/GetDataList
        [HttpPost]
        [Authorize]
        public JsonResult GetDataList(int page = 1, int rows = 10)
        {

            var temp1 = UserProfileService.GetAllUserProfileBySql(HttpContext, "where UserName ='" + User.Identity.Name + "'");
            int temp = 0;
            foreach (var i in temp1)
            {
                temp = i.UserId;
            }
            //var t = new Hashtable();
            //t.Add("pageNumber", pageNumber);
            //t.Add("pageSize", pageSize);
            //IList<Message> ListMessage = MessageService.GetPageMessages(HttpContext, t);
            //var a = new Hashtable();
            //a.Add("total", ListMessage.Count);
            //a.Add("rows", ListMessage);
            //a.Add("page", pageNumber);
            //return Json(a, JsonRequestBehavior.AllowGet);

            List<HomeViewModel> HomeViewModels = new List<HomeViewModel>();
            List<MessageViewModel> MessageViewModels = new List<MessageViewModel>();
            var ht = new Hashtable();
            ht.Add("pageNumber", page);
            ht.Add("pageSize", rows);
            ht.Add("UserId", temp);
            IList<Message> Messages = MessageService.GetPageMessagesId(HttpContext, ht);
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
            re.Add("total", MessageService.GetMessageCount(HttpContext, "where UserId ="+temp));
            re.Add("rows", HomeViewModels);
            re.Add("page", page);
            return Json(re, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        [HttpPost]
        public int Edit(string WordInfo, int id = 0)
        {
            return MessageService.UpdateMessage(HttpContext, new Message() {
                MessageId = id,
                MessageDatetime = DateTime.Now,
                MessageTag = 2,
                MessageInfo = WordInfo,
                UserId=UserProfileService.GetAllUserProfileBySql(HttpContext,"where UserName = '"+User.Identity.Name + "'")[0].UserId
            });
        }
        //
        // POST: /MyWord/Delete
        [Authorize]
        [HttpPost]
        public int Delete(int id = 0)
        {
            return MessageService.DeleteMessage(HttpContext,new Message(){
                MessageId = id
            });
        }
    }
}
