namespace Handling_Erroneous_Invoices
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCalculatingMachine = new System.Windows.Forms.RadioButton();
            this.rbCode = new System.Windows.Forms.RadioButton();
            this.rbNoCode = new System.Windows.Forms.RadioButton();
            this.btnPathChoose = new System.Windows.Forms.Button();
            this.txtPathPublish = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbNoSign = new System.Windows.Forms.RadioButton();
            this.rbHSM = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tệp xử lý";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(88, 49);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(317, 20);
            this.txtItemName.TabIndex = 2;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(88, 23);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(317, 20);
            this.txtItemCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hàng hoá";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPathChoose);
            this.groupBox1.Controls.Add(this.txtPathPublish);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtItemCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hàng hoá cần sửa";
            // 
            // rbCalculatingMachine
            // 
            this.rbCalculatingMachine.AutoSize = true;
            this.rbCalculatingMachine.Checked = true;
            this.rbCalculatingMachine.Location = new System.Drawing.Point(184, 19);
            this.rbCalculatingMachine.Name = "rbCalculatingMachine";
            this.rbCalculatingMachine.Size = new System.Drawing.Size(67, 17);
            this.rbCalculatingMachine.TabIndex = 7;
            this.rbCalculatingMachine.TabStop = true;
            this.rbCalculatingMachine.Text = "HĐ MTT";
            this.rbCalculatingMachine.UseVisualStyleBackColor = true;
            this.rbCalculatingMachine.CheckedChanged += new System.EventHandler(this.rbCalculatingMachine_CheckedChanged);
            // 
            // rbCode
            // 
            this.rbCode.AutoSize = true;
            this.rbCode.Location = new System.Drawing.Point(105, 19);
            this.rbCode.Name = "rbCode";
            this.rbCode.Size = new System.Drawing.Size(73, 17);
            this.rbCode.TabIndex = 6;
            this.rbCode.Text = "HĐ có mã";
            this.rbCode.UseVisualStyleBackColor = true;
            // 
            // rbNoCode
            // 
            this.rbNoCode.AutoSize = true;
            this.rbNoCode.Location = new System.Drawing.Point(8, 19);
            this.rbNoCode.Name = "rbNoCode";
            this.rbNoCode.Size = new System.Drawing.Size(91, 17);
            this.rbNoCode.TabIndex = 5;
            this.rbNoCode.Text = "HĐ không mã";
            this.rbNoCode.UseVisualStyleBackColor = true;
            // 
            // btnPathChoose
            // 
            this.btnPathChoose.Location = new System.Drawing.Point(411, 73);
            this.btnPathChoose.Name = "btnPathChoose";
            this.btnPathChoose.Size = new System.Drawing.Size(75, 23);
            this.btnPathChoose.TabIndex = 4;
            this.btnPathChoose.Text = "Chọn tệp";
            this.btnPathChoose.UseVisualStyleBackColor = true;
            this.btnPathChoose.Click += new System.EventHandler(this.btnPathChoose_Click);
            // 
            // txtPathPublish
            // 
            this.txtPathPublish.Location = new System.Drawing.Point(88, 75);
            this.txtPathPublish.Name = "txtPathPublish";
            this.txtPathPublish.Size = new System.Drawing.Size(317, 20);
            this.txtPathPublish.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên hàng hoá";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(420, 329);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "Xử lý";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(339, 329);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbCalculatingMachine);
            this.groupBox2.Controls.Add(this.rbNoCode);
            this.groupBox2.Controls.Add(this.rbCode);
            this.groupBox2.Location = new System.Drawing.Point(9, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 47);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loại hoá đơn";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbNoSign);
            this.groupBox3.Controls.Add(this.rbHSM);
            this.groupBox3.Location = new System.Drawing.Point(9, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 47);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hình thức ký số";
            // 
            // rbNoSign
            // 
            this.rbNoSign.AutoSize = true;
            this.rbNoSign.Checked = true;
            this.rbNoSign.Location = new System.Drawing.Point(63, 19);
            this.rbNoSign.Name = "rbNoSign";
            this.rbNoSign.Size = new System.Drawing.Size(70, 17);
            this.rbNoSign.TabIndex = 7;
            this.rbNoSign.TabStop = true;
            this.rbNoSign.Text = "Không ký";
            this.rbNoSign.UseVisualStyleBackColor = true;
            // 
            // rbHSM
            // 
            this.rbHSM.AutoSize = true;
            this.rbHSM.Location = new System.Drawing.Point(8, 19);
            this.rbHSM.Name = "rbHSM";
            this.rbHSM.Size = new System.Drawing.Size(49, 17);
            this.rbHSM.TabIndex = 6;
            this.rbHSM.Text = "HSM";
            this.rbHSM.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool lập hoá đơn thay thế";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPathPublish;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPathChoose;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.RadioButton rbCalculatingMachine;
        private System.Windows.Forms.RadioButton rbCode;
        private System.Windows.Forms.RadioButton rbNoCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbNoSign;
        private System.Windows.Forms.RadioButton rbHSM;
    }
}

