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
using System.Drawing.Drawing2D;
using System.IO;
using SpeechLib;

namespace BBDC.UI
{
    public partial class FrmBBDC : Form
    {
        public UserBLL userBLL = new UserBLL();
        public UserInfo userInfo = new UserInfo();
        public UidBLL uidBLL = new UidBLL();
        private readonly BBDC.BLL.DictBLL dict = new BBDC.BLL.DictBLL();
        private readonly BBDC.BLL.DCBLL book = new BBDC.BLL.DCBLL();
        private readonly BBDC.BLL.DetailBLL detail = new BBDC.BLL.DetailBLL();
        List<DictInfo> list;
        List<DCInfo> dlist;
        List<UidInfo> ulist;
        string uid = UserLoginInfo.userid;
        UserInfo userinfo;
        int index;
        int num;
        public FanyiBLL fy = new FanyiBLL();
        public FrmBBDC()
        {
            InitializeComponent();
            // 创建SpVoice对象    
            m_spVoice = new SpVoice();
            // 枚举出系统中已经安装的语音，并将其填充到Combo Box控件中
            foreach (ISpeechObjectToken Token in m_spVoice.GetVoices(string.Empty, string.Empty))
            {
                this.cmbVoices.Items.Add(Token.GetDescription(49));
            }
            // 默认选中第一个语音
            cmbVoices.SelectedIndex = 0;
        }
        // SpVoice对象，我们将使用这个对象来朗读文本
        private SpVoice m_spVoice;
        private void FrmBBDC_Load(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();//pictureBox改为圆形
            gp.AddEllipse(pictureBox1.ClientRectangle);
            Region region = new Region(gp);
            pictureBox1.Region = region;
            gp.Dispose();
            region.Dispose();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            LoadingInfo();

            list = dict.GetModelList("");
            comboBox1.ValueMember = "bookid";
            comboBox1.DisplayMember = "describe";
            comboBox1.DataSource = list;

        }
        private void loadWords()
        {
            try
            {
                userinfo = userBLL.GetModel(uid);
                dlist = book.GetModelList("", userinfo.bookid);
                ulist = uidBLL.GetModelList("bookid = " + @"'" + userinfo.bookid + @"'", "U" + uid);
                index = Convert.ToInt32(userBLL.GetModel(uid).wordid);
                if (index == 0)
                {
                    index = ulist.Count();
                    if (ulist.Count == dlist.Count)
                    {
                        //MessageBox.Show("已经背完这本书");
                        index = ulist.Count() - 1;
                    }
                }
                this.lblnumber.Text = "每次背" + userinfo.number.ToString() + "个";
                this.bookname.Text = dict.GetModel(userinfo.bookid).describe;
                if (dlist.Count == 0)
                {
                    lbl8.Text = "";
                    lbl10.Text = "";
                    string a = "";
                    txtBx1.Text = a;
                    //this.progressBar1.Maximum = 0;
                    //this.progressBar1.Minimum = 0;
                    this.progressBar1.Value = 0;
                    lbltip.Text = "0/0";
                }
                else
                {
                    this.progressBar1.Maximum = book.GetRecordCount("", userinfo.bookid);
                    this.progressBar1.Minimum = 0;
                    this.progressBar1.Value = ulist.Count;
                    lbltip.Text = this.progressBar1.Value.ToString() + "/" + this.progressBar1.Maximum.ToString();
                    lbl8.Text = dlist[index].word;
                    lbl10.Text = dlist[index].mean;
                    string a = detail.findDetail(dlist[index].word).exam;
                    if (a != null && a.IndexOf("<br>") != -1)
                    {
                        a = a.Replace("<br>", "\r\n\r\n");
                    }
                    txtBx1.Text = a;
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(),"已经背完这本书");
            }

        }
        private void LoadingInfo()//加载头像和昵称
        {
            try
            {
                userInfo = userBLL.GetModel(UserLoginInfo.userid);
                btnName.Text = userInfo.name;
                byte[] pic = userInfo.image;
                MemoryStream ms = new MemoryStream(pic);//将字节数组存入到二进制内存流中
                pictureBox1.Image = Image.FromStream(ms);//二进制流在image控件中显示
            }
            catch (Exception ex)
            {
                //pictureBox1.Image = null;
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmBBDC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.SmoothingMode = SmoothingMode.HighQuality; // 去锯齿
            Pen p = new Pen(Color.Gray, 5);
            g.DrawEllipse(p, 0, 0, 80, 80);
        }
        public void PanelVisible()
        {
            panelbeidanci.Visible = false;
            panelciku.Visible = false;
            panelfanyi.Visible = false;
            panelceshi.Visible = false;
            panelyouxi.Visible = false;
            panelshezhi.Visible = false;
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PanelVisible();
            switch (e.Node.Name)
            {
                case "beidanci": panelbeidanci.Visible = true; break;
                case "ciku": panelciku.Visible = true; break;
                case "fanyi": panelfanyi.Visible = true; break;
                case "ceshi": panelceshi.Visible = true;
                    FrmTest frmtest = new FrmTest(); frmtest.ShowDialog(); break;
                case "youxi": panelyouxi.Visible = true; break;
                case "shezhi": panelshezhi.Visible = true; break;
                default: ; break;
            }
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            FrmUserInfo frmUserInfo = new FrmUserInfo();
            frmUserInfo.UserInfoEvent += new EventLoadingInfo(this.LoadingInfo);
            frmUserInfo.Show();
        }
        private void FrmBBDC_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (list != null)
            //{
            //    foreach (dict d in list)
            //    {
            //        if (File.Exists(Application.StartupPath + "\\Words" + d.bookid + ".txt"))
            //        {
            //            File.Delete(Application.StartupPath + "\\Words" + d.bookid + ".txt");
            //        }
            //    }
            //}


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedValue.ToString();
            dataGridView1.DataSource = book.GetModelList("", s);
        }
        FrmDelete frmDelete;
        private void button3_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    DialogResult dr = MessageBox.Show("删除记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (dr == DialogResult.Yes)
            //    {
            //        DCInfo model = new DCInfo();
            //        model = book.GetModelByCxy(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), comboBox1.SelectedValue.ToString());
            //        book.Delete("'" + model.wordid + "'", comboBox1.SelectedValue.ToString());
            //        uidBLL.Delete("bookid=" + "'" + comboBox1.SelectedValue.ToString() + "'" + " and wordid=" + "'" + model.wordid + "'","U" + uid);
            //        string s = comboBox1.SelectedValue.ToString();
            //        dataGridView1.DataSource = book.GetModelList("", s);
            //    }
            //}
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DCInfo model = new DCInfo();
                model = book.GetModelByCxy(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), comboBox1.SelectedValue.ToString());
                frmDelete = FrmDelete.GetSington(model, comboBox1.SelectedValue.ToString());
                frmDelete.ShowDialog();
            }
        }
        FrmDict frmDict;
        private void button2_Click(object sender, EventArgs e)
        {
            frmDict = FrmDict.GetSington(null, true, comboBox1.SelectedValue.ToString());
            frmDict.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DCInfo model = new DCInfo();
                model = book.GetModelByCxy(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), comboBox1.SelectedValue.ToString());
                frmDict = FrmDict.GetSington(model, false, comboBox1.SelectedValue.ToString());
                frmDict.ShowDialog();
            }
        }

        private void FrmBBDC_Activated(object sender, EventArgs e)
        {
            loadWords();

            string s = comboBox1.SelectedValue.ToString();
            dataGridView1.DataSource = book.GetModelList("", s);
        }
        FrmDictPlus frmDictPlus;
        private void button1_Click(object sender, EventArgs e)
        {
            frmDictPlus = FrmDictPlus.GetSington();
            frmDictPlus.ShowDialog();
            comboBox1.DataSource = dict.GetModelList("");
        }

        private void btngametype0_Click(object sender, EventArgs e)
        {
            FrmGame frmgame0 = new FrmGame();
            frmgame0.gametype = 0;
            frmgame0.ShowDialog();
        }

        private void btngametype1_Click(object sender, EventArgs e)
        {
            FrmGame frmgame1 = new FrmGame();
            frmgame1.gametype = 1;
            frmgame1.ShowDialog();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                int result = uidBLL.UpdateGame(userInfo.usertable);
                MessageBox.Show("重置成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changePlan_Click(object sender, EventArgs e)
        {
            new FrmPlan().ShowDialog();
        }

        private void txtBx2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (num > userinfo.number)
                {
                    MessageBox.Show("已经背了" + this.lblnumber.Text);
                    return;
                }
                if (txtBx2.Text == lbl8.Text)
                {
                    cheBx1.Checked = true;
                    cheBx1.Text = "正确！";
                    uidBLL.Add(new UidInfo()
                    {
                        bookid = userinfo.bookid,
                        wordid = dlist[index].wordid,
                        review = 0,
                        game = 0,
                        error = 0
                    }, "U" + uid);
                    if (index < dlist.Count - 1)
                    {
                        index++;
                        this.txtBx2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("最后一个","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }
                    userBLL.Updatewordid(new UserInfo()
                    {
                        userid = uid,
                        wordid = index.ToString()
                    });
                    loadWords();
                    num++;
                }
                else
                {
                    cheBx1.Checked = false;
                    cheBx1.Text = "错误！";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("已经背完这背书", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            //this.btn2.Enabled = false;
            // 获取用户在Combo Box中选择的语音索引
            int nVoiceIndex = this.cmbVoices.SelectedIndex;
            // 根据语音索引指定SpVoice的Voice属性，也就是指定使用何种语音 
            m_spVoice.Voice = m_spVoice.GetVoices(string.Empty, string.Empty).Item(nVoiceIndex);
            // 使用SpVoice的Speak()方法阅读Text Box中文本 
            m_spVoice.Speak(this.lbl8.Text, SpeechVoiceSpeakFlags.SVSFDefault);
            //this.btn2.Enabled = true;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            //this.btn6.Enabled = false;
            // 获取用户在Combo Box中选择的语音索引
            int nVoiceIndex = this.cmbVoices.SelectedIndex;
            // 根据语音索引指定SpVoice的Voice属性，也就是指定使用何种语音 
            m_spVoice.Voice = m_spVoice.GetVoices(string.Empty, string.Empty).Item(nVoiceIndex);
            // 使用SpVoice的Speak()方法阅读Text Box中文本 
            m_spVoice.Speak(this.txtBx1.Text, SpeechVoiceSpeakFlags.SVSFDefault);
            //this.btn6.Enabled = true;
        }

        private void btn_fanyi_star_Click(object sender, EventArgs e)
        {
            if (txt_fanyi_input.Text == "")
            {
                MessageBox.Show("不能为空");
            }
            else
            {
                string inputtext = txt_fanyi_input.Text;
                if (btn_fanyi_type.Text == "英-汉互译")
                {
                    txt_fanyi_output.Text = fy.GetWord(inputtext, 1);
                }
                else
                {
                    txt_fanyi_output.Text = fy.GetWord(inputtext, 2);
                }
            }
        }

        private void btn_fanyi_type_Click(object sender, EventArgs e)
        {
            if (btn_fanyi_type.Text == "英-汉互译")
            {
                btn_fanyi_type.Text = "汉-英互译";
            }
            else
            {
                btn_fanyi_type.Text = "英-汉互译";
            }
        }

        private void btn_fanyi_clear_Click(object sender, EventArgs e)
        {
            txt_fanyi_input.Text = "";
            txt_fanyi_output.Text = "";
        }
    }
}
