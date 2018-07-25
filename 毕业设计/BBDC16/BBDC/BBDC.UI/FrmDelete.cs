using BBDC.BLL;
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
    public partial class FrmDelete : Form
    {
        public FrmDelete()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 当前唯一实例
        /// 公共成员可以记录上一次操作的结果，静态成员不能释放，只到程序OVER
        /// </summary>
        private static FrmDelete f = null;
        private static DCInfo model = null;
        private static String bookid = null;
        /// <summary>
        /// 返回当前的唯一实例 -- 单例模式
        /// </summary>
        /// <returns></returns>
        public static FrmDelete GetSington(DCInfo _model, string _bookid)
        {
            //IsDisposed标记当前窗体被释放，但是释放并不等于null,内存空间其实还没有真正收回
            if (f == null || f.IsDisposed == true)
            {
                f = new FrmDelete();
            }
            model = _model;
            bookid = _bookid;
            return f;
        }
        public UidBLL uidBLL = new UidBLL();
        private readonly BBDC.BLL.DCBLL book = new BBDC.BLL.DCBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                book.Delete("'" + model.wordid + "'", bookid);
                uidBLL.Delete("bookid=" + "'" + bookid + "'" + " and wordid=" + "'" + model.wordid + "'", "U" + UserLoginInfo.userid);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据异常", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
