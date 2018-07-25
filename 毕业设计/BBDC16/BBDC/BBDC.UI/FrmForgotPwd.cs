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
    public partial class FrmForgotPwd : Form
    {
        UserBLL userBLL = new UserBLL();
        UserInfo userInfo1 = new UserInfo();
        UserInfo userInfo2 = new UserInfo();
        public event EventLoadingInfo ForgotPwdEvent;//声明修改成功事件
        public FrmForgotPwd()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //填写信息都不为空
                if (!CheckInputNotEmpty())
                {
                    return;
                }
                userInfo1 = userBLL.GetModel(txtUserId.Text.Trim());//取得填写id的用户模型
                if (userInfo1 != null)//判断用户是否存在
                {
                    if(userInfo1.answer == txtAnswer.Text.Trim()&&userInfo1.question==txtQuestion.Text.Trim())
                    {
                        userInfo2 = userInfo1;
                        userInfo2.pwd = txtNewPwd.Text.Trim();
                        int result = userBLL.Update(userInfo2);
                        if (result > 0)
                        {
                            UserLoginInfo.userid = txtUserId.Text.Trim();
                            UserLoginInfo.pwd = txtNewPwd.Text.Trim();
                            if (ForgotPwdEvent != null)
                            {
                                ForgotPwdEvent();//如果有订阅对象，调用所有订阅对象的方法
                            }
                            MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK);
                            this.Close();//关闭修改窗口
                        }
                        else
                        {
                            MessageBox.Show("修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("密保答案错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtAnswer.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("账号不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 输入验证
        //信息非空验证
        public bool CheckInputNotEmpty()
        {
            if (string.IsNullOrEmpty(this.txtUserId.Text.Trim()))
            {
                MessageBox.Show("请输入账号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtUserId.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtQuestion.Text.Trim()))
            {
                MessageBox.Show("请输入密保问题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtQuestion.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtAnswer.Text.Trim()))
            {
                MessageBox.Show("请输入密保答案", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAnswer.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtNewPwd.Text.Trim()))
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNewPwd.Focus();
                return false;
            }
            else if (!(this.txtNewPwd.Text.Trim().Equals(this.txtQRNewPwd.Text.Trim())))
            {
                MessageBox.Show("密码不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNewPwd.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
