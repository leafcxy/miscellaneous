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
    public partial class FrmRegister : Form
    {
        public UserInfo userInfo = new UserInfo();
        public UserBLL userBLL = new UserBLL();
        public event EventLoadingInfo RegisterEvent;//声明注册成功事件
        public byte[] imgBytes;//存储头像字节数组
        public FrmRegister()
        {
            InitializeComponent();
        }
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();//pictureBox改为圆形
            gp.AddEllipse(pictureBox1.ClientRectangle);
            Region region = new Region(gp);
            pictureBox1.Region = region;
            gp.Dispose();
            region.Dispose();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //Image img = Image.FromFile(@"g:\Users\lsjz\Desktop\123.jpg");
            //pictureBox1.Image = img;
        }
        private void FrmRegister_Paint(object sender, PaintEventArgs e)
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
            if(opfPhoto.ShowDialog() == DialogResult.OK)
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
                    MessageBox.Show(ex.Message,"失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pictureBox1.Image = null;
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //注册信息都不为空
                if (!CheckInputNotEmpty())
                {
                    return;
                }
                int i = 0;
                userInfo.pwd = txtPwd.Text.Trim();
                userInfo.name = txtNmae.Text.Trim();
                userInfo.question = txtQuestion.Text.Trim();
                userInfo.answer = txtAnswer.Text.Trim();
                userInfo.image = imgBytes;
                userInfo.wordid = "1";
                userInfo.bookid = "c1";
                userInfo.number = 50;
                do
                {
                    Random rd = new Random();
                    int r = rd.Next(1, 1000);
                    string id = String.Format("{0:D3}", r);
                    userInfo.userid = id;
                    userInfo.usertable = "U" + id;
                    //检索id是否存在
                    int result = userBLL.Add(userInfo);
                    if (result != -1)//如果id没找到，则i赋值为1，退出循环，否则继续随机取id,进入则注册成功
                    {
                        i = 1;
                        UserLoginInfo.userid = id;
                        UserLoginInfo.pwd = txtPwd.Text.Trim();
                        if (RegisterEvent != null)
                        {
                            RegisterEvent();//如果有订阅对象，调用所有订阅对象的方法
                        }
                        MessageBox.Show("注册成功，账号id为：" + id, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();//关闭注册窗口
                    }
                } while (i == 0);
  
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
            else if (this.pictureBox1.Image==null)
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
