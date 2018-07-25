namespace BBDC.UI
{
    partial class FrmRegister
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lblQRPwd = new System.Windows.Forms.Label();
            this.txtNmae = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtQRPwd = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.labImage = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtQuestion = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(34, 121);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "昵称：";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(34, 164);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(41, 12);
            this.lblPwd.TabIndex = 1;
            this.lblPwd.Text = "密码：";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(34, 207);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(65, 12);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "密保问题：";
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Location = new System.Drawing.Point(267, 210);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(65, 12);
            this.lblAnswer.TabIndex = 3;
            this.lblAnswer.Text = "密保答案：";
            // 
            // lblQRPwd
            // 
            this.lblQRPwd.AutoSize = true;
            this.lblQRPwd.Location = new System.Drawing.Point(267, 164);
            this.lblQRPwd.Name = "lblQRPwd";
            this.lblQRPwd.Size = new System.Drawing.Size(65, 12);
            this.lblQRPwd.TabIndex = 4;
            this.lblQRPwd.Text = "确认密码：";
            // 
            // txtNmae
            // 
            this.txtNmae.Location = new System.Drawing.Point(126, 118);
            this.txtNmae.Name = "txtNmae";
            this.txtNmae.Size = new System.Drawing.Size(100, 21);
            this.txtNmae.TabIndex = 5;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(126, 161);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 6;
            // 
            // txtQRPwd
            // 
            this.txtQRPwd.Location = new System.Drawing.Point(359, 164);
            this.txtQRPwd.Name = "txtQRPwd";
            this.txtQRPwd.PasswordChar = '*';
            this.txtQRPwd.Size = new System.Drawing.Size(100, 21);
            this.txtQRPwd.TabIndex = 7;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(359, 207);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(100, 21);
            this.txtAnswer.TabIndex = 9;
            // 
            // labImage
            // 
            this.labImage.AutoSize = true;
            this.labImage.Location = new System.Drawing.Point(267, 118);
            this.labImage.Name = "labImage";
            this.labImage.Size = new System.Drawing.Size(41, 12);
            this.labImage.TabIndex = 10;
            this.labImage.Text = "头像：";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(359, 113);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 11;
            this.btnSelectFile.Text = "选择文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(210, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(151, 257);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 13;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(269, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtQuestion
            // 
            this.txtQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtQuestion.FormattingEnabled = true;
            this.txtQuestion.Items.AddRange(new object[] {
            "爸爸名字",
            "妈妈名字",
            "学校名字"});
            this.txtQuestion.Location = new System.Drawing.Point(126, 204);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(100, 20);
            this.txtQuestion.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 298);
            this.panel1.TabIndex = 16;
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 322);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtNmae);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblQRPwd);
            this.Controls.Add(this.labImage);
            this.Controls.Add(this.txtQRPwd);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRegister";
            this.Text = "注册";
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmRegister_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Label lblQRPwd;
        private System.Windows.Forms.TextBox txtNmae;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtQRPwd;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label labImage;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox txtQuestion;
        private System.Windows.Forms.Panel panel1;
    }
}