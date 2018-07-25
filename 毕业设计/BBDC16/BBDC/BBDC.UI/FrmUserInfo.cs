using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBDC.BLL;
using BBDC.Model;

namespace BBDC.UI
{
    public partial class FrmUserInfo : Form
    {
        UserBLL userBLL = new UserBLL();
        UserInfo userInfo1 = new UserInfo();
        UserInfo userInfo2 = new UserInfo();
        public event EventLoadingInfo UserInfoEvent;//声明保存信息成功事件
        byte[] imgBytes;
        public FrmUserInfo()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "vista1.ssk";
        }

        private void FrmUserInfo_Load(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();//pictureBox改为圆形
            gp.AddEllipse(pictureBox1.ClientRectangle);
            Region region = new Region(gp);
            pictureBox1.Region = region;
            gp.Dispose();
            region.Dispose();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                userInfo1 = userBLL.GetModel(UserLoginInfo.userid);
                txtNmae.Text = userInfo1.name;
                txtPwd.Text = userInfo1.pwd;
                txtQRPwd.Text = userInfo1.pwd;
                txtQuestion.Text = userInfo1.question;
                txtAnswer.Text = userInfo1.answer;

                imgBytes = userInfo1.image;
                MemoryStream ms = new MemoryStream(imgBytes);//将字节数组存入到二进制内存流中
                pictureBox1.Image = Image.FromStream(ms);//二进制流在image控件中显示
            }
            catch (Exception ex)
            {
                //pictureBox1.Image = null;
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSelectFile_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.SmoothingMode = SmoothingMode.HighQuality; // 去锯齿
            Pen p = new Pen(Color.Gray, 5);
            g.DrawEllipse(p, 0, 0, 80, 80);
        }
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfPhoto = new OpenFileDialog();
            opfPhoto.Filter = @"jpg格式图片|*.jpg|png格式图片|*.png";
            if (opfPhoto.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Image img = Image.FromFile(@"g:\Users\lsjz\Desktop\123.jpg");
                    Image img = Image.FromFile(opfPhoto.FileName);
                    pictureBox1.Image = img;
                    string fileName = opfPhoto.FileName.ToString();//记录图片位置
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);//将图片以文件流的形式进行保存
                    BinaryReader br = new BinaryReader(fs);
                    imgBytes = br.ReadBytes((int)fs.Length);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pictureBox1.Image = null;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //注册信息都不为空
                if (!CheckInputNotEmpty())
                {
                    return;
                }
                userInfo2 = userInfo1;
                userInfo2.name = txtNmae.Text.Trim();
                userInfo2.pwd = txtPwd.Text.Trim();
                userInfo2.question = txtQuestion.Text.Trim();
                userInfo2.answer = txtAnswer.Text.Trim();
                userInfo2.image = imgBytes;
                int result = userBLL.Update(userInfo2);
                if (result != -1)//如果id没找到，则i赋值为1，退出循环，否则继续随机取id,进入则注册成功
                {
                    if (UserInfoEvent != null)
                    {
                        UserInfoEvent();//如果有订阅对象，调用所有订阅对象的方法
                    }
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();//关闭注册窗口
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrEmpty(this.txtNmae.Text.Trim()))
            {
                MessageBox.Show("请输入昵称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNmae.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtPwd.Text.Trim()))
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPwd.Focus();
                return false;
            }
            else if (!(this.txtPwd.Text.Trim().Equals(this.txtQRPwd.Text.Trim())))
            {
                MessageBox.Show("密码不一致", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPwd.Focus();
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
            else if (this.pictureBox1.Image == null)
            {
                MessageBox.Show("请上传头像", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
