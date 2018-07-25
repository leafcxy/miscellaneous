using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Domain.reply
{
    public class ReplyViewModel
    {
        public int ReplyId { get; set; }
        public int MessageId { get; set; }
        public string UserName { get; set; }
        public string ReplyInfo { get; set; }
        public string ReplyDatetime { get; set; }
    }
}
