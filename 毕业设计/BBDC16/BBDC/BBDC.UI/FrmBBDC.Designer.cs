namespace BBDC.UI
{
    partial class FrmBBDC
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("背单词");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("词库");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("翻译");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("测试");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("游戏");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("设置");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBBDC));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnName = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelbeidanci = new System.Windows.Forms.Panel();
            this.btn6 = new System.Windows.Forms.Button();
            this.cmbVoices = new System.Windows.Forms.ComboBox();
            this.cheBx1 = new System.Windows.Forms.CheckBox();
            this.btn2 = new System.Windows.Forms.Button();
            this.txtBx2 = new System.Windows.Forms.TextBox();
            this.txtBx1 = new System.Windows.Forms.TextBox();
            this.lbl12 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lblnumber = new System.Windows.Forms.Label();
            this.lbltip = new System.Windows.Forms.Label();
            this.lblprogress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bookname = new System.Windows.Forms.Label();
            this.changePlan = new System.Windows.Forms.Button();
            this.panelciku = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelfanyi = new System.Windows.Forms.Panel();
            this.btn_fanyi_clear = new System.Windows.Forms.Button();
            this.btn_fanyi_type = new System.Windows.Forms.Button();
            this.btn_fanyi_star = new System.Windows.Forms.Button();
            this.txt_fanyi_output = new System.Windows.Forms.TextBox();
            this.txt_fanyi_input = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelceshi = new System.Windows.Forms.Panel();
            this.pictureBox_test = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelyouxi = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btngametype1 = new System.Windows.Forms.Button();
            this.btngametype0 = new System.Windows.Forms.Button();
            this.panelshezhi = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelbeidanci.SuspendLayout();
            this.panelciku.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelfanyi.SuspendLayout();
            this.panelceshi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_test)).BeginInit();
            this.panelyouxi.SuspendLayout();
            this.panelshezhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(35, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnName
            // 
            this.btnName.Location = new System.Drawing.Point(35, 99);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(80, 23);
            this.btnName.TabIndex = 1;
            this.btnName.Text = "昵称";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Window;
            this.treeView1.Font = new System.Drawing.Font("宋体", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.FullRowSelect = true;
            this.treeView1.ItemHeight = 40;
            this.treeView1.Location = new System.Drawing.Point(12, 137);
            this.treeView1.Name = "treeView1";
            treeNode1.Checked = true;
            treeNode1.Name = "beidanci";
            treeNode1.Text = "背单词";
            treeNode2.Name = "ciku";
            treeNode2.Text = "词库";
            treeNode3.Name = "fanyi";
            treeNode3.Text = "翻译";
            treeNode4.Name = "ceshi";
            treeNode4.Text = "测试";
            treeNode5.Name = "youxi";
            treeNode5.Text = "游戏";
            treeNode6.Name = "shezhi";
            treeNode6.Text = "设置";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(128, 261);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panelbeidanci
            // 
            this.panelbeidanci.BackColor = System.Drawing.SystemColors.Control;
            this.panelbeidanci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelbeidanci.Controls.Add(this.btn6);
            this.panelbeidanci.Controls.Add(this.cmbVoices);
            this.panelbeidanci.Controls.Add(this.cheBx1);
            this.panelbeidanci.Controls.Add(this.btn2);
            this.panelbeidanci.Controls.Add(this.txtBx2);
            this.panelbeidanci.Controls.Add(this.txtBx1);
            this.panelbeidanci.Controls.Add(this.lbl12);
            this.panelbeidanci.Controls.Add(this.lbl11);
            this.panelbeidanci.Controls.Add(this.lbl10);
            this.panelbeidanci.Controls.Add(this.lbl9);
            this.panelbeidanci.Controls.Add(this.lbl8);
            this.panelbeidanci.Controls.Add(this.lblnumber);
            this.panelbeidanci.Controls.Add(this.lbltip);
            this.panelbeidanci.Controls.Add(this.lblprogress);
            this.panelbeidanci.Controls.Add(this.progressBar1);
            this.panelbeidanci.Controls.Add(this.bookname);
            this.panelbeidanci.Controls.Add(this.changePlan);
            this.panelbeidanci.Location = new System.Drawing.Point(155, 12);
            this.panelbeidanci.Name = "panelbeidanci";
            this.panelbeidanci.Size = new System.Drawing.Size(620, 387);
            this.panelbeidanci.TabIndex = 3;
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(512, 161);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(75, 23);
            this.btn6.TabIndex = 27;
            this.btn6.Text = "例句发音";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // cmbVoices
            // 
            this.cmbVoices.FormattingEnabled = true;
            this.cmbVoices.Location = new System.Drawing.Point(385, 163);
            this.cmbVoices.Name = "cmbVoices";
            this.cmbVoices.Size = new System.Drawing.Size(121, 20);
            this.cmbVoices.TabIndex = 26;
            this.cmbVoices.Visible = false;
            // 
            // cheBx1
            // 
            this.cheBx1.AutoSize = true;
            this.cheBx1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cheBx1.Location = new System.Drawing.Point(337, 321);
            this.cheBx1.Name = "cheBx1";
            this.cheBx1.Size = new System.Drawing.Size(60, 16);
            this.cheBx1.TabIndex = 25;
            this.cheBx1.Text = "错误！";
            this.cheBx1.UseVisualStyleBackColor = true;
            this.cheBx1.Visible = false;
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(512, 132);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 23);
            this.btn2.TabIndex = 24;
            this.btn2.Text = "单词发音";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // txtBx2
            // 
            this.txtBx2.Location = new System.Drawing.Point(231, 319);
            this.txtBx2.Name = "txtBx2";
            this.txtBx2.Size = new System.Drawing.Size(100, 21);
            this.txtBx2.TabIndex = 23;
            this.txtBx2.TextChanged += new System.EventHandler(this.txtBx2_TextChanged);
            // 
            // txtBx1
            // 
            this.txtBx1.Location = new System.Drawing.Point(94, 190);
            this.txtBx1.Multiline = true;
            this.txtBx1.Name = "txtBx1";
            this.txtBx1.ReadOnly = true;
            this.txtBx1.Size = new System.Drawing.Size(493, 115);
            this.txtBx1.TabIndex = 22;
            // 
            // lbl12
            // 
            this.lbl12.AutoSize = true;
            this.lbl12.Location = new System.Drawing.Point(92, 322);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(125, 12);
            this.lbl12.TabIndex = 21;
            this.lbl12.Text = "你还可以临摹下单词：";
            // 
            // lbl11
            // 
            this.lbl11.AutoSize = true;
            this.lbl11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl11.Location = new System.Drawing.Point(32, 190);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(56, 16);
            this.lbl11.TabIndex = 20;
            this.lbl11.Text = "例句：";
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl10.Location = new System.Drawing.Point(94, 161);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(64, 16);
            this.lbl10.TabIndex = 19;
            this.lbl10.Text = "label10";
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl9.Location = new System.Drawing.Point(32, 161);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(56, 16);
            this.lbl9.TabIndex = 18;
            this.lbl9.Text = "释义：";
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl8.Location = new System.Drawing.Point(32, 124);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(67, 25);
            this.lbl8.TabIndex = 17;
            this.lbl8.Text = "label8";
            // 
            // lblnumber
            // 
            this.lblnumber.AutoSize = true;
            this.lblnumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnumber.Location = new System.Drawing.Point(400, 64);
            this.lblnumber.Name = "lblnumber";
            this.lblnumber.Size = new System.Drawing.Size(80, 16);
            this.lblnumber.TabIndex = 5;
            this.lblnumber.Text = "lblnumber";
            // 
            // lbltip
            // 
            this.lbltip.AutoSize = true;
            this.lbltip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltip.Location = new System.Drawing.Point(264, 64);
            this.lbltip.Name = "lbltip";
            this.lbltip.Size = new System.Drawing.Size(56, 16);
            this.lbltip.TabIndex = 4;
            this.lbltip.Text = "label1";
            // 
            // lblprogress
            // 
            this.lblprogress.AutoSize = true;
            this.lblprogress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblprogress.Location = new System.Drawing.Point(32, 64);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(88, 16);
            this.lblprogress.TabIndex = 3;
            this.lblprogress.Text = "背诵进度：";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(126, 60);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(132, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // bookname
            // 
            this.bookname.AutoSize = true;
            this.bookname.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookname.Location = new System.Drawing.Point(32, 22);
            this.bookname.Name = "bookname";
            this.bookname.Size = new System.Drawing.Size(67, 25);
            this.bookname.TabIndex = 1;
            this.bookname.Text = "label1";
            // 
            // changePlan
            // 
            this.changePlan.Location = new System.Drawing.Point(512, 60);
            this.changePlan.Name = "changePlan";
            this.changePlan.Size = new System.Drawing.Size(75, 23);
            this.changePlan.TabIndex = 0;
            this.changePlan.Text = "更改计划";
            this.changePlan.UseVisualStyleBackColor = true;
            this.changePlan.Click += new System.EventHandler(this.changePlan_Click);
            // 
            // panelciku
            // 
            this.panelciku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelciku.Controls.Add(this.button4);
            this.panelciku.Controls.Add(this.button3);
            this.panelciku.Controls.Add(this.button2);
            this.panelciku.Controls.Add(this.button1);
            this.panelciku.Controls.Add(this.comboBox1);
            this.panelciku.Controls.Add(this.dataGridView1);
            this.panelciku.Location = new System.Drawing.Point(155, 12);
            this.panelciku.Name = "panelciku";
            this.panelciku.Size = new System.Drawing.Size(620, 387);
            this.panelciku.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(23, 275);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "修改词条";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 220);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "删除词条";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "添加词条";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "添加词库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 20);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(155, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(463, 385);
            this.dataGridView1.TabIndex = 12;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "wordid";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "word";
            this.Column2.HeaderText = "单词";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "mean";
            this.Column3.HeaderText = "释义";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // panelfanyi
            // 
            this.panelfanyi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelfanyi.Controls.Add(this.btn_fanyi_clear);
            this.panelfanyi.Controls.Add(this.btn_fanyi_type);
            this.panelfanyi.Controls.Add(this.btn_fanyi_star);
            this.panelfanyi.Controls.Add(this.txt_fanyi_output);
            this.panelfanyi.Controls.Add(this.txt_fanyi_input);
            this.panelfanyi.Controls.Add(this.label3);
            this.panelfanyi.Location = new System.Drawing.Point(155, 12);
            this.panelfanyi.Name = "panelfanyi";
            this.panelfanyi.Size = new System.Drawing.Size(620, 387);
            this.panelfanyi.TabIndex = 4;
            // 
            // btn_fanyi_clear
            // 
            this.btn_fanyi_clear.Location = new System.Drawing.Point(237, 302);
            this.btn_fanyi_clear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_fanyi_clear.Name = "btn_fanyi_clear";
            this.btn_fanyi_clear.Size = new System.Drawing.Size(112, 72);
            this.btn_fanyi_clear.TabIndex = 10;
            this.btn_fanyi_clear.Text = "清除";
            this.btn_fanyi_clear.UseVisualStyleBackColor = true;
            this.btn_fanyi_clear.Click += new System.EventHandler(this.btn_fanyi_clear_Click);
            // 
            // btn_fanyi_type
            // 
            this.btn_fanyi_type.Location = new System.Drawing.Point(366, 302);
            this.btn_fanyi_type.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_fanyi_type.Name = "btn_fanyi_type";
            this.btn_fanyi_type.Size = new System.Drawing.Size(115, 73);
            this.btn_fanyi_type.TabIndex = 9;
            this.btn_fanyi_type.Text = "英-汉互译";
            this.btn_fanyi_type.UseVisualStyleBackColor = true;
            this.btn_fanyi_type.Click += new System.EventHandler(this.btn_fanyi_type_Click);
            // 
            // btn_fanyi_star
            // 
            this.btn_fanyi_star.Location = new System.Drawing.Point(494, 302);
            this.btn_fanyi_star.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_fanyi_star.Name = "btn_fanyi_star";
            this.btn_fanyi_star.Size = new System.Drawing.Size(106, 72);
            this.btn_fanyi_star.TabIndex = 8;
            this.btn_fanyi_star.Text = "开始翻译";
            this.btn_fanyi_star.UseVisualStyleBackColor = true;
            this.btn_fanyi_star.Click += new System.EventHandler(this.btn_fanyi_star_Click);
            // 
            // txt_fanyi_output
            // 
            this.txt_fanyi_output.Location = new System.Drawing.Point(17, 161);
            this.txt_fanyi_output.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_fanyi_output.Multiline = true;
            this.txt_fanyi_output.Name = "txt_fanyi_output";
            this.txt_fanyi_output.ReadOnly = true;
            this.txt_fanyi_output.Size = new System.Drawing.Size(584, 127);
            this.txt_fanyi_output.TabIndex = 7;
            // 
            // txt_fanyi_input
            // 
            this.txt_fanyi_input.Location = new System.Drawing.Point(17, 28);
            this.txt_fanyi_input.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_fanyi_input.Multiline = true;
            this.txt_fanyi_input.Name = "txt_fanyi_input";
            this.txt_fanyi_input.Size = new System.Drawing.Size(584, 122);
            this.txt_fanyi_input.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "请输入你要翻译的内容";
            // 
            // panelceshi
            // 
            this.panelceshi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelceshi.Controls.Add(this.label4);
            this.panelceshi.Controls.Add(this.pictureBox_test);
            this.panelceshi.Location = new System.Drawing.Point(155, 12);
            this.panelceshi.Name = "panelceshi";
            this.panelceshi.Size = new System.Drawing.Size(620, 387);
            this.panelceshi.TabIndex = 4;
            // 
            // pictureBox_test
            // 
            this.pictureBox_test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_test.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_test.Image")));
            this.pictureBox_test.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_test.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox_test.Name = "pictureBox_test";
            this.pictureBox_test.Size = new System.Drawing.Size(618, 385);
            this.pictureBox_test.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_test.TabIndex = 6;
            this.pictureBox_test.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // panelyouxi
            // 
            this.panelyouxi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelyouxi.BackgroundImage")));
            this.panelyouxi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelyouxi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelyouxi.Controls.Add(this.btnReset);
            this.panelyouxi.Controls.Add(this.btngametype1);
            this.panelyouxi.Controls.Add(this.btngametype0);
            this.panelyouxi.Location = new System.Drawing.Point(155, 12);
            this.panelyouxi.Name = "panelyouxi";
            this.panelyouxi.Size = new System.Drawing.Size(620, 387);
            this.panelyouxi.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(426, 266);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(140, 30);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "重置单词游戏记录";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btngametype1
            // 
            this.btngametype1.Location = new System.Drawing.Point(237, 266);
            this.btngametype1.Name = "btngametype1";
            this.btngametype1.Size = new System.Drawing.Size(140, 30);
            this.btngametype1.TabIndex = 8;
            this.btngametype1.Text = "无尽模式";
            this.btngametype1.UseVisualStyleBackColor = true;
            this.btngametype1.Click += new System.EventHandler(this.btngametype1_Click);
            // 
            // btngametype0
            // 
            this.btngametype0.Location = new System.Drawing.Point(46, 266);
            this.btngametype0.Name = "btngametype0";
            this.btngametype0.Size = new System.Drawing.Size(140, 30);
            this.btngametype0.TabIndex = 7;
            this.btngametype0.Text = "单词模式";
            this.btngametype0.UseVisualStyleBackColor = true;
            this.btngametype0.Click += new System.EventHandler(this.btngametype0_Click);
            // 
            // panelshezhi
            // 
            this.panelshezhi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelshezhi.Controls.Add(this.pictureBox3);
            this.panelshezhi.Controls.Add(this.pictureBox2);
            this.panelshezhi.Location = new System.Drawing.Point(155, 12);
            this.panelshezhi.Name = "panelshezhi";
            this.panelshezhi.Size = new System.Drawing.Size(620, 387);
            this.panelshezhi.TabIndex = 5;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 103);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(606, 271);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(184, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(252, 87);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 387);
            this.panel1.TabIndex = 6;
            // 
            // FrmBBDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnName);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelceshi);
            this.Controls.Add(this.panelshezhi);
            this.Controls.Add(this.panelciku);
            this.Controls.Add(this.panelbeidanci);
            this.Controls.Add(this.panelfanyi);
            this.Controls.Add(this.panelyouxi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmBBDC";
            this.Text = "背背单词";
            this.Activated += new System.EventHandler(this.FrmBBDC_Activated);
            this.Load += new System.EventHandler(this.FrmBBDC_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBBDC_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelbeidanci.ResumeLayout(false);
            this.panelbeidanci.PerformLayout();
            this.panelciku.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelfanyi.ResumeLayout(false);
            this.panelfanyi.PerformLayout();
            this.panelceshi.ResumeLayout(false);
            this.panelceshi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_test)).EndInit();
            this.panelyouxi.ResumeLayout(false);
            this.panelshezhi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panelbeidanci;
        private System.Windows.Forms.Panel panelciku;
        private System.Windows.Forms.Panel panelfanyi;
        private System.Windows.Forms.Panel panelceshi;
        private System.Windows.Forms.Panel panelyouxi;
        private System.Windows.Forms.Panel panelshezhi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btngametype1;
        private System.Windows.Forms.Button btngametype0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button changePlan;
        private System.Windows.Forms.Label lbltip;
        private System.Windows.Forms.Label lblprogress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label bookname;
        private System.Windows.Forms.Label lblnumber;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.ComboBox cmbVoices;
        private System.Windows.Forms.CheckBox cheBx1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.TextBox txtBx2;
        private System.Windows.Forms.TextBox txtBx1;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Button btn_fanyi_clear;
        private System.Windows.Forms.Button btn_fanyi_type;
        private System.Windows.Forms.Button btn_fanyi_star;
        private System.Windows.Forms.TextBox txt_fanyi_output;
        private System.Windows.Forms.TextBox txt_fanyi_input;
        private System.Windows.Forms.PictureBox pictureBox_test;
    }
}

