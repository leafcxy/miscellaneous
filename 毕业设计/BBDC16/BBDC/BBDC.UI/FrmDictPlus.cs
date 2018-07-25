using BBDC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBDC.UI
{
    public partial class FrmDictPlus : Form
    {
        public FrmDictPlus()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 当前唯一实例
        /// 公共成员可以记录上一次操作的结果，静态成员不能释放，只到程序OVER
        /// </summary>
        private static FrmDictPlus f = null;
        /// <summary>
        /// 返回当前的唯一实例 -- 单例模式
        /// </summary>
        /// <returns></returns>
        public static FrmDictPlus GetSington()
        {
            //IsDisposed标记当前窗体被释放，但是释放并不等于null,内存空间其实还没有真正收回
            if (f == null || f.IsDisposed == true)
            {
                f = new FrmDictPlus();
            }
            return f;
        }
        private readonly BBDC.BLL.DictBLL dict = new BBDC.BLL.DictBLL();
        private readonly BBDC.BLL.DCBLL dc = new BBDC.BLL.DCBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DictInfo model = new DictInfo();
                model.bookid = "xb"+textBox1.Text;
                model.describe = textBox2.Text;
                dict.Add(model);
                dict.newTable(model.bookid);
                if (modelList.Count > 0)
                    foreach (DCInfo m in modelList)
                    {
                        dc.Add(new DCInfo()
                           {
                               wordid = m.wordid,
                               word = m.word,
                               mean = m.mean
                           }, model.bookid);
                    }


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据异常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dict.Exists("xb" + textBox1.Text))
                {
                    dict.Delete("xb"+textBox1.Text);
                    dict.dropTable("xb"+textBox1.Text);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDictPlus_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        List<DCInfo> modelList;
        private void button3_Click(object sender, EventArgs e)
        {
            modelList = new List<DCInfo>();
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofdFile.FileName;
                txtFilePath.Text = filePath;
                try
                {

                    if (File.Exists(filePath))
                    {
                        StreamReader sr = new StreamReader(filePath);
                        string input;
                        while ((input = sr.ReadLine()) != null)
                        {
                            string[] s = input.Split(new char[] { ',' });
                            modelList.Add(new DCInfo()
                            {
                                wordid = s[0],
                                word = s[1],
                                mean = s[2]
                            });
                        }
                        sr.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据异常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ofdFile.FileName = "";
                    txtFilePath.Text = "";
                }

            }
        }

    }
}
