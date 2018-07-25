using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveWord.Domain.message
{
    public class MessageViewModel
    {
        public int MessageId { get; set; }
        public string UserName { get; set; }
        public string MessageInfo { get; set; }
        public int MessageTag { get; set; }
        public string MessageDatetime { get; set; }
    }
}
