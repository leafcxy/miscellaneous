using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBDC.BLL;
using BBDC.Model;

namespace BBDC.UI
{
    public partial class FrmTest : Form
    {
        private readonly BBDC.BLL.DCBLL book = new BBDC.BLL.DCBLL();
        private readonly BBDC.BLL.DictBLL dict = new BBDC.BLL.DictBLL();
        private readonly BBDC.BLL.TestBLL td = new BBDC.BLL.TestBLL();
        List<DictInfo> list;
        DateTime beginTime1;
        DateTime endTime1;
        int right = 0;
        int wrong = 0;
        int jindu = 0;
        static string bookid = "n3";
        int[] wordida;//存储单词id的数组
        public FrmTest()
        {
            InitializeComponent();
        }
        private void FrmTest_Load(object sender, EventArgs e)
        {
            Getuserid();
            Getwordid();
            bookid = td.GetBidUserid(true);
            
            dataGridView1.DataSource = td.GetModelList("", bookid);
            txt_test_show.Text = td.Getdescribe(td.GetBidUserid(true));
            btn_test_exit.Enabled = false;
        }
        public void PanelVisible()
        {
            panel_star.Visible = false;
            panel_test.Visible = false;
        }
        //开始测试按钮
        private void btn_test_star_Click(object sender, EventArgs e)
        {
            if (wordidnumcount() != 0)
            {
                PanelVisible();
                panel_test.Visible = true;
                timer_1.Enabled = true;
                beginTime1 = DateTime.Now;
                btn_test_star.Enabled = false;
                btn_test_exit.Enabled = true;
                textBox3_output.Text = mean(wordida[jindu]);
                //jindu += 1;
            }
            else
            {
                MessageBox.Show("你还没开始学习，请去记忆单词后再来测试");
            }
        }
        //提交按钮
        private void btn_test_submit_Click(object sender, EventArgs e)
        {
            string trueword = word(wordida[jindu]);
            string inputword = textBox4_input.Text;
            if (trueword == inputword)
            {
                label9_jieguo.Text = "回答正确";
                right += 1;
                td.Updatare(wordida[jindu]);
                MessageBox.Show("回答正确");
            }
            else
            {
                label9_jieguo.Text = "回答错误";
                MessageBox.Show("回答错误");
                wrong += 1;
            }
            if (jindu == wordidnumcount() - 1)
            {
                Exit();
            }
            else
            {
                jindu += 1;
                //MessageBox.Show(Convert.ToString(jindu));
                //MessageBox.Show(wordida[])
            }

            textBox3_output.Clear();
            textBox4_input.Clear();
            //Haveid(bookid);
            textBox3_output.Text = mean(wordida[jindu]);
            //MessageBox.Show(word(wordida[jindu]));
        }
        //退出按钮
        private void btn_test_exit_Click(object sender, EventArgs e)
        {
            Exit();
        }
        //退出事件
        public void Exit()
        {
            string sb = null;
            string str = lbl_test_time.Text;
            foreach (char c in str)
            {
                if (Convert.ToInt32(c) >= 48 && Convert.ToInt32(c) <= 57)
                {
                    sb += c;
                }
            }
            timer_1.Enabled = false;
            MessageBox.Show("你回答用了" + sb + "秒\n你回答对了" + right + "题，答错了" + wrong + "题");
            right = 0;
            wrong = 0;
            jindu = 0;
            PanelVisible();
            panel_star.Visible = true;
            btn_test_star.Enabled = true;
            btn_test_exit.Enabled = false;
        }
        private void timer_1_Tick(object sender, EventArgs e)
        {
            endTime1 = DateTime.Now;
            TimeSpan midTime = endTime1 - beginTime1;
            lbl_test_time.Text = "时间：" + midTime.Seconds.ToString();
        }


        //按顺序获得wordid,调用时记得检查一下数组的长度

        public void Getwordid()
        {
            int[] wordidnum = td.Getwordid();
            this.wordida = wordidnum;

        }
        public int wordidnumcount()//数组的最大值
        {
            int[] max = td.Getwordid();
            if(max[0] == 0)
            {
                return 0;
            }else
            {
                return max.Count();
            }   
        }
        //从数组获得单词
        public string word(int wordid)
        {
            string bookid = FrmTest.bookid;
            string[] str = td.GetHanToYing(wordid, bookid);
            return str[0];
        }
        //从数组获得意思
        public string mean(int wordid)
        {
            string bookid = FrmTest.bookid;
            string[] str = td.GetHanToYing(wordid, bookid);
            return str[1];
        }
        //从静态类获得userid
        public void Getuserid()
        {
            td.Getuserid(UserLoginInfo.userid);
        }

        
    }
}
