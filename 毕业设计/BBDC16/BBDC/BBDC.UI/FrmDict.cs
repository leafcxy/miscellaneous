using BBDC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBDC.UI
{
    public partial class FrmDict : Form
    {

        public FrmDict()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 当前唯一实例
        /// 公共成员可以记录上一次操作的结果，静态成员不能释放，只到程序OVER
        /// </summary>
        private static FrmDict f = null;
        private static DCInfo b = null;
        private static String tn = null;
        //true为增;false为改
        private static bool flag;
        /// <summary>
        /// 返回当前的唯一实例 -- 单例模式
        /// </summary>
        /// <returns></returns>
        public static FrmDict GetSington(DCInfo _b, bool _flag, String _tn)
        {
            //IsDisposed标记当前窗体被释放，但是释放并不等于null,内存空间其实还没有真正收回
            if (f == null || f.IsDisposed == true)
            {
                f = new FrmDict();
            }
            b = _b;
            flag = _flag;
            tn = _tn;
            return f;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            this.Close();
        }
        private readonly BBDC.BLL.DCBLL book = new BBDC.BLL.DCBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (isNoNull())
                {
                    if (flag)
                    {
                        book.Add(new DCInfo()
                        {
                            wordid = textBox1.Text,
                            word = textBox2.Text,
                            mean = textBox3.Text
                        }, tn);
                        this.Close();
                    }
                    else
                    {
                        book.Update(new DCInfo()
                        {
                            wordid = textBox1.Text,
                            word = textBox2.Text,
                            mean = textBox3.Text
                        }, tn);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据异常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.ToString());
            }


        }
        private bool isNoNull()
        {
            if (textBox1.Text.Trim() != "")
            {
                if (textBox2.Text.Trim() != "")
                {
                    if (textBox3.Text.Trim() != "")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void FrmDict_Load(object sender, EventArgs e)
        {
            if (flag)
            {
                textBox1.Clear();
                textBox1.Enabled = true;
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                textBox1.Text = b.wordid;
                textBox1.Enabled = false;
                textBox2.Text = b.word;
                textBox3.Text = b.mean;
            }
        }
    }
}
