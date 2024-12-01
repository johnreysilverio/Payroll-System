namespace Payroll_System
{
    partial class ManageAccountEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageAccountEditForm));
            label12 = new Label();
            txtBAllowance = new TextBox();
            label11 = new Label();
            txtBSalary = new TextBox();
            label10 = new Label();
            txtBPosition = new TextBox();
            label9 = new Label();
            cBAccResLVL = new ComboBox();
            label7 = new Label();
            dTPBOD = new DateTimePicker();
            label6 = new Label();
            cBGender = new ComboBox();
            label5 = new Label();
            txtBFirstname = new TextBox();
            txtBLastname = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btnCancel = new Button();
            btnConfirm = new Button();
            label1 = new Label();
            panel1 = new Panel();
            txtPhilHealth = new TextBox();
            label15 = new Label();
            txtPagIbig = new TextBox();
            label8 = new Label();
            txtSSS = new TextBox();
            label13 = new Label();
            txtBStationNo = new TextBox();
            txtBDOB = new TextBox();
            btnResetPassword = new Button();
            cBLockAcc = new ComboBox();
            label4 = new Label();
            TxtPass = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(502, 153);
            label12.Name = "label12";
            label12.Size = new Size(115, 29);
            label12.TabIndex = 63;
            label12.Text = "Station No.";
            // 
            // txtBAllowance
            // 
            txtBAllowance.Location = new Point(18, 475);
            txtBAllowance.Name = "txtBAllowance";
            txtBAllowance.Size = new Size(452, 37);
            txtBAllowance.TabIndex = 8;
            txtBAllowance.TextChanged += txtBAllowance_TextChanged;
            txtBAllowance.KeyPress += txtBAllowance_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(-1, 443);
            label11.Name = "label11";
            label11.Size = new Size(118, 29);
            label11.TabIndex = 60;
            label11.Text = "Allowance:";
            // 
            // txtBSalary
            // 
            txtBSalary.Location = new Point(518, 401);
            txtBSalary.Name = "txtBSalary";
            txtBSalary.Size = new Size(452, 37);
            txtBSalary.TabIndex = 7;
            txtBSalary.TextChanged += txtBSalary_TextChanged;
            txtBSalary.KeyPress += txtBSalary_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(503, 369);
            label10.Name = "label10";
            label10.Size = new Size(80, 29);
            label10.TabIndex = 58;
            label10.Text = "Salary:";
            // 
            // txtBPosition
            // 
            txtBPosition.Location = new Point(519, 257);
            txtBPosition.Name = "txtBPosition";
            txtBPosition.Size = new Size(452, 37);
            txtBPosition.TabIndex = 6;
            txtBPosition.TextChanged += txtBPosition_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(501, 225);
            label9.Name = "label9";
            label9.Size = new Size(97, 29);
            label9.TabIndex = 56;
            label9.Text = "Position:";
            // 
            // cBAccResLVL
            // 
            cBAccResLVL.DropDownStyle = ComboBoxStyle.DropDownList;
            cBAccResLVL.FormattingEnabled = true;
            cBAccResLVL.Items.AddRange(new object[] { "Level 1", "Level 2" });
            cBAccResLVL.Location = new Point(20, 185);
            cBAccResLVL.Name = "cBAccResLVL";
            cBAccResLVL.Size = new Size(452, 37);
            cBAccResLVL.TabIndex = 4;
            cBAccResLVL.SelectedIndexChanged += cBAccResLVL_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 153);
            label7.Name = "label7";
            label7.Size = new Size(265, 29);
            label7.TabIndex = 52;
            label7.Text = "Account Restriction Level:";
            // 
            // dTPBOD
            // 
            dTPBOD.Format = DateTimePickerFormat.Short;
            dTPBOD.Location = new Point(953, 113);
            dTPBOD.Name = "dTPBOD";
            dTPBOD.Size = new Size(18, 37);
            dTPBOD.TabIndex = 3;
            dTPBOD.ValueChanged += dTPBOD_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(502, 81);
            label6.Name = "label6";
            label6.Size = new Size(96, 29);
            label6.TabIndex = 49;
            label6.Text = "Birthday";
            // 
            // cBGender
            // 
            cBGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cBGender.FormattingEnabled = true;
            cBGender.Items.AddRange(new object[] { "Male", "Female", "Other", "Prefer not to say" });
            cBGender.Location = new Point(18, 113);
            cBGender.Name = "cBGender";
            cBGender.Size = new Size(452, 37);
            cBGender.TabIndex = 2;
            cBGender.SelectedIndexChanged += cBGender_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 81);
            label5.Name = "label5";
            label5.Size = new Size(89, 29);
            label5.TabIndex = 46;
            label5.Text = "Gender:";
            // 
            // txtBFirstname
            // 
            txtBFirstname.Location = new Point(18, 41);
            txtBFirstname.Name = "txtBFirstname";
            txtBFirstname.Size = new Size(452, 37);
            txtBFirstname.TabIndex = 0;
            txtBFirstname.TextChanged += txtBFirstname_TextChanged;
            // 
            // txtBLastname
            // 
            txtBLastname.Location = new Point(519, 41);
            txtBLastname.Name = "txtBLastname";
            txtBLastname.Size = new Size(452, 37);
            txtBLastname.TabIndex = 1;
            txtBLastname.TextChanged += txtBLastname_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(502, 9);
            label3.Name = "label3";
            label3.Size = new Size(113, 29);
            label3.TabIndex = 41;
            label3.Text = "Lastname:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(117, 29);
            label2.TabIndex = 39;
            label2.Text = "Firstname:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(501, 619);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(469, 54);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.Lime;
            btnConfirm.Location = new Point(2, 619);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(470, 54);
            btnConfirm.TabIndex = 9;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Location = new Point(777, 954);
            label1.Name = "label1";
            label1.Size = new Size(168, 29);
            label1.TabIndex = 38;
            label1.Text = "Input Password:";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(txtPhilHealth);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(txtPagIbig);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtSSS);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(txtBStationNo);
            panel1.Controls.Add(txtBDOB);
            panel1.Controls.Add(btnResetPassword);
            panel1.Controls.Add(cBLockAcc);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(txtBAllowance);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txtBSalary);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtBPosition);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(cBAccResLVL);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dTPBOD);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cBGender);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtBFirstname);
            panel1.Controls.Add(txtBLastname);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(TxtPass);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnConfirm);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(974, 676);
            panel1.TabIndex = 26;
            // 
            // txtPhilHealth
            // 
            txtPhilHealth.Location = new Point(19, 401);
            txtPhilHealth.Name = "txtPhilHealth";
            txtPhilHealth.Size = new Size(452, 37);
            txtPhilHealth.TabIndex = 73;
            txtPhilHealth.TextChanged += txtPhilHealth_TextChanged;
            txtPhilHealth.KeyPress += txtPhilHealth_KeyPress;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(4, 369);
            label15.Name = "label15";
            label15.Size = new Size(106, 29);
            label15.TabIndex = 75;
            label15.Text = "PillHealth";
            // 
            // txtPagIbig
            // 
            txtPagIbig.Location = new Point(518, 329);
            txtPagIbig.Name = "txtPagIbig";
            txtPagIbig.Size = new Size(452, 37);
            txtPagIbig.TabIndex = 70;
            txtPagIbig.TextChanged += txtPagIbig_TextChanged;
            txtPagIbig.KeyPress += txtPhilHealth_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(499, 297);
            label8.Name = "label8";
            label8.Size = new Size(93, 29);
            label8.TabIndex = 72;
            label8.Text = "Pag-Ibig";
            // 
            // txtSSS
            // 
            txtSSS.Location = new Point(19, 329);
            txtSSS.Name = "txtSSS";
            txtSSS.Size = new Size(452, 37);
            txtSSS.TabIndex = 69;
            txtSSS.TextChanged += txtSSS_TextChanged;
            txtSSS.KeyPress += txtPhilHealth_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(4, 297);
            label13.Name = "label13";
            label13.Size = new Size(54, 29);
            label13.TabIndex = 71;
            label13.Text = "SSS:";
            // 
            // txtBStationNo
            // 
            txtBStationNo.Location = new Point(519, 185);
            txtBStationNo.Name = "txtBStationNo";
            txtBStationNo.Size = new Size(452, 37);
            txtBStationNo.TabIndex = 68;
            txtBStationNo.TextChanged += txtBStationNo_TextChanged;
            // 
            // txtBDOB
            // 
            txtBDOB.Location = new Point(519, 113);
            txtBDOB.Name = "txtBDOB";
            txtBDOB.ReadOnly = true;
            txtBDOB.Size = new Size(434, 37);
            txtBDOB.TabIndex = 67;
            txtBDOB.Click += txtBDOB_Click;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.Red;
            btnResetPassword.Location = new Point(501, 465);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(470, 54);
            btnResetPassword.TabIndex = 66;
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // cBLockAcc
            // 
            cBLockAcc.DropDownStyle = ComboBoxStyle.DropDownList;
            cBLockAcc.FormattingEnabled = true;
            cBLockAcc.Items.AddRange(new object[] { "Yes", "No" });
            cBLockAcc.Location = new Point(20, 257);
            cBLockAcc.Name = "cBLockAcc";
            cBLockAcc.Size = new Size(452, 37);
            cBLockAcc.TabIndex = 64;
            cBLockAcc.SelectedIndexChanged += cBLockAcc_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 225);
            label4.Name = "label4";
            label4.Size = new Size(155, 29);
            label4.TabIndex = 65;
            label4.Text = "Lock Account?";
            // 
            // TxtPass
            // 
            TxtPass.Anchor = AnchorStyles.None;
            TxtPass.BorderStyle = BorderStyle.FixedSingle;
            TxtPass.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtPass.Location = new Point(796, 986);
            TxtPass.Name = "TxtPass";
            TxtPass.Size = new Size(459, 56);
            TxtPass.TabIndex = 7;
            TxtPass.UseSystemPasswordChar = true;
            // 
            // ManageAccountEditForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(998, 700);
            Controls.Add(panel1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "ManageAccountEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManageAccountEditForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label12;
        private TextBox txtBAllowance;
        private Label label11;
        private TextBox txtBSalary;
        private Label label10;
        private TextBox txtBPosition;
        private Label label9;
        private ComboBox cBAccResLVL;
        private Label label7;
        private DateTimePicker dTPBOD;
        private Label label6;
        private ComboBox cBGender;
        private Label label5;
        private TextBox txtBFirstname;
        private TextBox txtBLastname;
        private Label label3;
        private Label label2;
        private Button btnCancel;
        private Button btnConfirm;
        private Label label1;
        private Panel panel1;
        private ComboBox cBLockAcc;
        private Label label4;
        private TextBox TxtPass;
        private Button btnResetPassword;
        private TextBox txtBDOB;
        private TextBox txtBStationNo;
        private TextBox txtPhilHealth;
        private Label label15;
        private TextBox txtPagIbig;
        private Label label8;
        private TextBox txtSSS;
        private Label label13;
    }
}