using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBDC.Model
{
    public class UserInfo
    {
        public string userid { get; set; }      //id
        public string pwd { get; set; }         //密码
        public string name { get; set; }        //昵称
        public string question { get; set; }    //密保问题
        public string answer { get; set; }      //密保答案
        public byte[] image { get; set; }       //头像
        public string wordid { get; set; }      //背到第几个单词
        public string bookid { get; set; }      //背单词的书
        public string usertable { get; set; }   //用户个人表名
        public int number { get; set; }         //记忆策略
    }
}
