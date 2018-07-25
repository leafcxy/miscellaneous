namespace BBDC.UI
{
    partial class FrmGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGame));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.级别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入门ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.初等ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中等ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大师ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.总共个ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.第个ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单词ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 360);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.暂停ToolStripMenuItem,
            this.级别ToolStripMenuItem,
            this.退出ToolStripMenuItem,
            this.总共个ToolStripMenuItem,
            this.第个ToolStripMenuItem,
            this.中文ToolStripMenuItem,
            this.单词ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 36);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Enabled = false;
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(44, 32);
            this.开始ToolStripMenuItem.Text = "开始";
            this.开始ToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
            // 
            // 暂停ToolStripMenuItem
            // 
            this.暂停ToolStripMenuItem.Name = "暂停ToolStripMenuItem";
            this.暂停ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Space)));
            this.暂停ToolStripMenuItem.Size = new System.Drawing.Size(44, 32);
            this.暂停ToolStripMenuItem.Text = "暂停";
            this.暂停ToolStripMenuItem.Click += new System.EventHandler(this.暂停ToolStripMenuItem_Click);
            // 
            // 级别ToolStripMenuItem
            // 
            this.级别ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.入门ToolStripMenuItem,
            this.初等ToolStripMenuItem,
            this.中等ToolStripMenuItem,
            this.高级ToolStripMenuItem,
            this.大师ToolStripMenuItem});
            this.级别ToolStripMenuItem.Name = "级别ToolStripMenuItem";
            this.级别ToolStripMenuItem.Size = new System.Drawing.Size(44, 32);
            this.级别ToolStripMenuItem.Text = "级别";
            // 
            // 入门ToolStripMenuItem
            // 
            this.入门ToolStripMenuItem.Name = "入门ToolStripMenuItem";
            this.入门ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.入门ToolStripMenuItem.Text = "入门";
            this.入门ToolStripMenuItem.Click += new System.EventHandler(this.入门ToolStripMenuItem_Click);
            // 
            // 初等ToolStripMenuItem
            // 
            this.初等ToolStripMenuItem.Name = "初等ToolStripMenuItem";
            this.初等ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.初等ToolStripMenuItem.Text = "初级";
            this.初等ToolStripMenuItem.Click += new System.EventHandler(this.初等ToolStripMenuItem_Click);
            // 
            // 中等ToolStripMenuItem
            // 
            this.中等ToolStripMenuItem.Name = "中等ToolStripMenuItem";
            this.中等ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.中等ToolStripMenuItem.Text = "中级";
            this.中等ToolStripMenuItem.Click += new System.EventHandler(this.中等ToolStripMenuItem_Click);
            // 
            // 高级ToolStripMenuItem
            // 
            this.高级ToolStripMenuItem.Name = "高级ToolStripMenuItem";
            this.高级ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.高级ToolStripMenuItem.Text = "高级";
            this.高级ToolStripMenuItem.Click += new System.EventHandler(this.高级ToolStripMenuItem_Click);
            // 
            // 大师ToolStripMenuItem
            // 
            this.大师ToolStripMenuItem.Name = "大师ToolStripMenuItem";
            this.大师ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.大师ToolStripMenuItem.Text = "大师";
            this.大师ToolStripMenuItem.Click += new System.EventHandler(this.大师ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 32);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 总共个ToolStripMenuItem
            // 
            this.总共个ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.总共个ToolStripMenuItem.Enabled = false;
            this.总共个ToolStripMenuItem.Name = "总共个ToolStripMenuItem";
            this.总共个ToolStripMenuItem.Size = new System.Drawing.Size(56, 32);
            this.总共个ToolStripMenuItem.Text = "总共个";
            // 
            // 第个ToolStripMenuItem
            // 
            this.第个ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.第个ToolStripMenuItem.Enabled = false;
            this.第个ToolStripMenuItem.Name = "第个ToolStripMenuItem";
            this.第个ToolStripMenuItem.Size = new System.Drawing.Size(44, 32);
            this.第个ToolStripMenuItem.Text = "第个";
            // 
            // 中文ToolStripMenuItem
            // 
            this.中文ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.中文ToolStripMenuItem.Enabled = false;
            this.中文ToolStripMenuItem.Name = "中文ToolStripMenuItem";
            this.中文ToolStripMenuItem.Size = new System.Drawing.Size(56, 32);
            this.中文ToolStripMenuItem.Text = "中文：";
            // 
            // 单词ToolStripMenuItem
            // 
            this.单词ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.单词ToolStripMenuItem.Enabled = false;
            this.单词ToolStripMenuItem.Name = "单词ToolStripMenuItem";
            this.单词ToolStripMenuItem.Size = new System.Drawing.Size(56, 32);
            this.单词ToolStripMenuItem.Text = "单词：";
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmGame";
            this.Text = "游戏";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGame_FormClosed);
            this.Load += new System.EventHandler(this.FrmGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGame_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂停ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单词ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 第个ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 总共个ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 级别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 入门ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 初等ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中等ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 大师ToolStripMenuItem;
    }
}