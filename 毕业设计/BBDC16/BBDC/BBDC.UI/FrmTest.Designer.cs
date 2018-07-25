namespace BBDC.UI
{
    partial class FrmTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_test_bookshow = new System.Windows.Forms.Label();
            this.txt_test_show = new System.Windows.Forms.TextBox();
            this.lbl_test_type = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_test_time = new System.Windows.Forms.Label();
            this.panel_star = new System.Windows.Forms.Panel();
            this.btn_test_star = new System.Windows.Forms.Button();
            this.btn_test_exit = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel_test = new System.Windows.Forms.Panel();
            this.btn_test_submit = new System.Windows.Forms.Button();
            this.label9_jieguo = new System.Windows.Forms.Label();
            this.textBox4_input = new System.Windows.Forms.TextBox();
            this.textBox3_output = new System.Windows.Forms.TextBox();
            this.label2_show = new System.Windows.Forms.Label();
            this.label1_show = new System.Windows.Forms.Label();
            this.timer_1 = new System.Windows.Forms.Timer(this.components);
            this.panel_star.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_test.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_test_bookshow
            // 
            this.lbl_test_bookshow.AutoSize = true;
            this.lbl_test_bookshow.Location = new System.Drawing.Point(10, 10);
            this.lbl_test_bookshow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_test_bookshow.Name = "lbl_test_bookshow";
            this.lbl_test_bookshow.Size = new System.Drawing.Size(89, 12);
            this.lbl_test_bookshow.TabIndex = 0;
            this.lbl_test_bookshow.Text = "你要测试的书本";
            // 
            // txt_test_show
            // 
            this.txt_test_show.Location = new System.Drawing.Point(98, 8);
            this.txt_test_show.Margin = new System.Windows.Forms.Padding(2);
            this.txt_test_show.Name = "txt_test_show";
            this.txt_test_show.ReadOnly = true;
            this.txt_test_show.Size = new System.Drawing.Size(167, 21);
            this.txt_test_show.TabIndex = 1;
            // 
            // lbl_test_type
            // 
            this.lbl_test_type.AutoSize = true;
            this.lbl_test_type.Location = new System.Drawing.Point(279, 10);
            this.lbl_test_type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_test_type.Name = "lbl_test_type";
            this.lbl_test_type.Size = new System.Drawing.Size(53, 12);
            this.lbl_test_type.TabIndex = 2;
            this.lbl_test_type.Text = "测试种类";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(344, 8);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(91, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "中----英测试";
            // 
            // lbl_test_time
            // 
            this.lbl_test_time.AutoSize = true;
            this.lbl_test_time.Location = new System.Drawing.Point(463, 10);
            this.lbl_test_time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_test_time.Name = "lbl_test_time";
            this.lbl_test_time.Size = new System.Drawing.Size(29, 12);
            this.lbl_test_time.TabIndex = 4;
            this.lbl_test_time.Text = "时间";
            // 
            // panel_star
            // 
            this.panel_star.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_star.Controls.Add(this.dataGridView1);
            this.panel_star.Location = new System.Drawing.Point(11, 40);
            this.panel_star.Margin = new System.Windows.Forms.Padding(2);
            this.panel_star.Name = "panel_star";
            this.panel_star.Size = new System.Drawing.Size(500, 350);
            this.panel_star.TabIndex = 5;
            // 
            // btn_test_star
            // 
            this.btn_test_star.Location = new System.Drawing.Point(333, 326);
            this.btn_test_star.Margin = new System.Windows.Forms.Padding(2);
            this.btn_test_star.Name = "btn_test_star";
            this.btn_test_star.Size = new System.Drawing.Size(127, 53);
            this.btn_test_star.TabIndex = 6;
            this.btn_test_star.Text = "开始测试";
            this.btn_test_star.UseVisualStyleBackColor = true;
            this.btn_test_star.Click += new System.EventHandler(this.btn_test_star_Click);
            // 
            // btn_test_exit
            // 
            this.btn_test_exit.Location = new System.Drawing.Point(51, 326);
            this.btn_test_exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_test_exit.Name = "btn_test_exit";
            this.btn_test_exit.Size = new System.Drawing.Size(124, 53);
            this.btn_test_exit.TabIndex = 7;
            this.btn_test_exit.Text = "退出测试";
            this.btn_test_exit.UseVisualStyleBackColor = true;
            this.btn_test_exit.Click += new System.EventHandler(this.btn_test_exit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 12);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(409, 254);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel_test
            // 
            this.panel_test.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_test.Controls.Add(this.btn_test_submit);
            this.panel_test.Controls.Add(this.label9_jieguo);
            this.panel_test.Controls.Add(this.textBox4_input);
            this.panel_test.Controls.Add(this.textBox3_output);
            this.panel_test.Controls.Add(this.label2_show);
            this.panel_test.Controls.Add(this.label1_show);
            this.panel_test.Location = new System.Drawing.Point(12, 40);
            this.panel_test.Margin = new System.Windows.Forms.Padding(2);
            this.panel_test.Name = "panel_test";
            this.panel_test.Size = new System.Drawing.Size(500, 350);
            this.panel_test.TabIndex = 1;
            // 
            // btn_test_submit
            // 
            this.btn_test_submit.Location = new System.Drawing.Point(340, 206);
            this.btn_test_submit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_test_submit.Name = "btn_test_submit";
            this.btn_test_submit.Size = new System.Drawing.Size(107, 54);
            this.btn_test_submit.TabIndex = 5;
            this.btn_test_submit.Text = "提交";
            this.btn_test_submit.UseVisualStyleBackColor = true;
            this.btn_test_submit.Click += new System.EventHandler(this.btn_test_submit_Click);
            // 
            // label9_jieguo
            // 
            this.label9_jieguo.AutoSize = true;
            this.label9_jieguo.Location = new System.Drawing.Point(98, 248);
            this.label9_jieguo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9_jieguo.Name = "label9_jieguo";
            this.label9_jieguo.Size = new System.Drawing.Size(0, 12);
            this.label9_jieguo.TabIndex = 4;
            // 
            // textBox4_input
            // 
            this.textBox4_input.Location = new System.Drawing.Point(156, 170);
            this.textBox4_input.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4_input.Name = "textBox4_input";
            this.textBox4_input.Size = new System.Drawing.Size(188, 21);
            this.textBox4_input.TabIndex = 3;
            // 
            // textBox3_output
            // 
            this.textBox3_output.Location = new System.Drawing.Point(156, 71);
            this.textBox3_output.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3_output.Name = "textBox3_output";
            this.textBox3_output.ReadOnly = true;
            this.textBox3_output.Size = new System.Drawing.Size(188, 21);
            this.textBox3_output.TabIndex = 2;
            // 
            // label2_show
            // 
            this.label2_show.AutoSize = true;
            this.label2_show.Location = new System.Drawing.Point(100, 178);
            this.label2_show.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2_show.Name = "label2_show";
            this.label2_show.Size = new System.Drawing.Size(29, 12);
            this.label2_show.TabIndex = 1;
            this.label2_show.Text = "英文";
            // 
            // label1_show
            // 
            this.label1_show.AutoSize = true;
            this.label1_show.Location = new System.Drawing.Point(98, 74);
            this.label1_show.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1_show.Name = "label1_show";
            this.label1_show.Size = new System.Drawing.Size(29, 12);
            this.label1_show.TabIndex = 0;
            this.label1_show.Text = "中文";
            // 
            // timer_1
            // 
            this.timer_1.Interval = 1000;
            this.timer_1.Tick += new System.EventHandler(this.timer_1_Tick);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 401);
            this.Controls.Add(this.btn_test_exit);
            this.Controls.Add(this.btn_test_star);
            this.Controls.Add(this.lbl_test_time);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_test_type);
            this.Controls.Add(this.txt_test_show);
            this.Controls.Add(this.lbl_test_bookshow);
            this.Controls.Add(this.panel_star);
            this.Controls.Add(this.panel_test);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmTest";
            this.Text = "测试";
            this.Load += new System.EventHandler(this.FrmTest_Load);
            this.panel_star.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_test.ResumeLayout(false);
            this.panel_test.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_test_bookshow;
        private System.Windows.Forms.TextBox txt_test_show;
        private System.Windows.Forms.Label lbl_test_type;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_test_time;
        private System.Windows.Forms.Panel panel_star;
        private System.Windows.Forms.Panel panel_test;
        private System.Windows.Forms.Label label9_jieguo;
        private System.Windows.Forms.TextBox textBox4_input;
        private System.Windows.Forms.TextBox textBox3_output;
        private System.Windows.Forms.Label label2_show;
        private System.Windows.Forms.Label label1_show;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_test_star;
        private System.Windows.Forms.Button btn_test_exit;
        private System.Windows.Forms.Button btn_test_submit;
        private System.Windows.Forms.Timer timer_1;
    }
}