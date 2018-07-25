using LeaveWord.Domain.message;
using LeaveWord.Domain.reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveWord.ViewModels
{
    public class HomeViewModel
    {
        public MessageViewModel MViewModel { get; set; }
        public List<ReplyViewModel> RViewModels { get; set; }
    }
}