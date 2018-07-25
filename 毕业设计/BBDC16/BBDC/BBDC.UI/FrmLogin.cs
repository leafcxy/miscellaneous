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
    public delegate void EventLoadingInfo();//声明加载填充信息的委托
    public partial class FrmLogin : Form
    {
        public UserBLL userBLL = new UserBLL();
        public FrmLogin()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "vista1.ssk";
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //用户名、密码都不为空
                if (!CheckInputNotEmpty())
                {
                    return;
                }
                //检索用户名、密码是否存在
                bool result = userBLL.Login(this.txtUserId.Text.Trim(), this.txtPwd.Text.Trim());
                if (!result)
                {
                    MessageBox.Show("用户名或密码不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    UserLoginInfo.userid = txtUserId.Text.Trim();
                    //这个对话框窗体只要赋值为OK，那么窗体就会关闭
                    this.DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
}
        

        #region 输入验证
        //用户名、密码的非空验证
        public bool CheckInputNotEmpty()
        {
            //用户名为空

            if (string.IsNullOrEmpty(this.txtUserId.Text.Trim()))
            {
                MessageBox.Show("请输入账号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtUserId.Focus();
                return false;
            }
            //密码为空
            else if (this.txtPwd.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPwd.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegister frmRegister = new FrmRegister();
            frmRegister.RegisterEvent += new EventLoadingInfo(this.RLogin);//订阅注册成功事件
            frmRegister.ShowDialog();
        }
        public void RLogin()
        {
            txtUserId.Text = UserLoginInfo.userid;
            txtPwd.Text = UserLoginInfo.pwd;
        }

        private void btnFgPwd_Click(object sender, EventArgs e)
        {
            FrmForgotPwd frmForgotPwd = new FrmForgotPwd();
            frmForgotPwd.ForgotPwdEvent += new EventLoadingInfo(this.RLogin);//订阅注册成功事件
            frmForgotPwd.ShowDialog();
        }
    }
}
