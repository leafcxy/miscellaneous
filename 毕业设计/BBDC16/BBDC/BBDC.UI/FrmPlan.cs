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
    public partial class FrmPlan : Form
    {
        public FrmPlan()
        {
            InitializeComponent();
        }
        private readonly BBDC.BLL.DictBLL dict = new BBDC.BLL.DictBLL();
        private readonly BBDC.BLL.UserBLL user = new BBDC.BLL.UserBLL();
        List<DictInfo> dictlist;
        UserInfo usermodel;
        string uid = UserLoginInfo.userid;
        private void FrmPlan_Load(object sender, EventArgs e)
        {
            dictlist = dict.GetModelList("");
            usermodel = user.GetModel(uid);
            this.listView1.BeginUpdate();
            foreach (DictInfo i in dictlist)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = 0;
                lvi.Text = i.describe;
                lvi.Tag = i.bookid;
                this.listView1.Items.Add(lvi);
            }
            this.listView1.EndUpdate();
            int f = 0;
            foreach (ListViewItem i in listView1.Items)
            {
                
                if (i.Tag.ToString() == usermodel.bookid)
                {
                    listView1.Items[f].Selected = true;
                }
                f++;
            }
            this.textBox1.Text = usermodel.number.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && textBox1.Text.Trim() != "")
            {
                try
                {
                    user.Updatenumber(new UserInfo()
                    {
                        userid = uid,
                        bookid = listView1.SelectedItems[0].Tag.ToString(),
                        number = Convert.ToInt32(textBox1.Text),
                        wordid = "0"
                    });
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("listview和textbox不能为空！");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
