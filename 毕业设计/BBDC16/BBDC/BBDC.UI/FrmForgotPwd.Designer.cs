namespace BBDC.UI
{
    partial class FrmForgotPwd
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
            this.labUserId = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtQRNewPwd = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lblNewPwd = new System.Windows.Forms.Label();
            this.lblQRNewPwd = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labUserId
            // 
            this.labUserId.AutoSize = true;
            this.labUserId.Location = new System.Drawing.Point(36, 32);
            this.labUserId.Name = "labUserId";
            this.labUserId.Size = new System.Drawing.Size(41, 12);
            this.labUserId.TabIndex = 0;
            this.labUserId.Text = "账号：";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(36, 76);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(65, 12);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "密保问题：";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(129, 29);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(100, 21);
            this.txtUserId.TabIndex = 2;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(129, 107);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(100, 21);
            this.txtAnswer.TabIndex = 4;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(129, 150);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(100, 21);
            this.txtNewPwd.TabIndex = 5;
            // 
            // txtQRNewPwd
            // 
            this.txtQRNewPwd.Location = new System.Drawing.Point(129, 190);
            this.txtQRNewPwd.Name = "txtQRNewPwd";
            this.txtQRNewPwd.PasswordChar = '*';
            this.txtQRNewPwd.Size = new System.Drawing.Size(100, 21);
            this.txtQRNewPwd.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(154, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(38, 232);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Location = new System.Drawing.Point(36, 110);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(65, 12);
            this.lblAnswer.TabIndex = 9;
            this.lblAnswer.Text = "密保答案：";
            // 
            // lblNewPwd
            // 
            this.lblNewPwd.AutoSize = true;
            this.lblNewPwd.Location = new System.Drawing.Point(36, 153);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Size = new System.Drawing.Size(65, 12);
            this.lblNewPwd.TabIndex = 10;
            this.lblNewPwd.Text = "新的密码：";
            // 
            // lblQRNewPwd
            // 
            this.lblQRNewPwd.AutoSize = true;
            this.lblQRNewPwd.Location = new System.Drawing.Point(36, 193);
            this.lblQRNewPwd.Name = "lblQRNewPwd";
            this.lblQRNewPwd.Size = new System.Drawing.Size(65, 12);
            this.lblQRNewPwd.TabIndex = 11;
            this.lblQRNewPwd.Text = "确认密码：";
            // 
            // txtQuestion
            // 
            this.txtQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtQuestion.FormattingEnabled = true;
            this.txtQuestion.Items.AddRange(new object[] {
            "爸爸名字",
            "妈妈名字",
            "学校名字"});
            this.txtQuestion.Location = new System.Drawing.Point(129, 67);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(100, 20);
            this.txtQuestion.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 264);
            this.panel1.TabIndex = 13;
            // 
            // FrmForgotPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 288);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.lblQRNewPwd);
            this.Controls.Add(this.lblNewPwd);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtQRNewPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.labUserId);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmForgotPwd";
            this.Text = "重置密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labUserId;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtQRNewPwd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Label lblNewPwd;
        private System.Windows.Forms.Label lblQRNewPwd;
        private System.Windows.Forms.ComboBox txtQuestion;
        private System.Windows.Forms.Panel panel1;
    }
}