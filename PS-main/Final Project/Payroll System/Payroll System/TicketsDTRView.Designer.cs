namespace Payroll_System
{
    partial class TicketsDTRView
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
            panel1 = new Panel();
            lbStatus = new Label();
            label8 = new Label();
            txtRemarks = new TextBox();
            txtDescription = new TextBox();
            label1 = new Label();
            charCountLabel = new Label();
            checkClockout = new CheckBox();
            checkClockin = new CheckBox();
            lbResolverFirstName = new Label();
            label15 = new Label();
            lbReporterUserID = new Label();
            label13 = new Label();
            lbClockout = new Label();
            label14 = new Label();
            lbClockin = new Label();
            label12 = new Label();
            label10 = new Label();
            lbDateResolved = new Label();
            label9 = new Label();
            lbDateRecieved = new Label();
            label7 = new Label();
            lbDTRID = new Label();
            label6 = new Label();
            btnReslove = new Button();
            label4 = new Label();
            lbDTRDate = new Label();
            lbTicketID = new Label();
            label3 = new Label();
            label2 = new Label();
            btnCancel = new Button();
            btnReject = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(lbStatus);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtRemarks);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(charCountLabel);
            panel1.Controls.Add(checkClockout);
            panel1.Controls.Add(checkClockin);
            panel1.Controls.Add(lbResolverFirstName);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(lbReporterUserID);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(lbClockout);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(lbClockin);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(lbDateResolved);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(lbDateRecieved);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(lbDTRID);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnReslove);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lbDTRDate);
            panel1.Controls.Add(lbTicketID);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnReject);
            panel1.Location = new Point(12, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(625, 777);
            panel1.TabIndex = 1;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Location = new Point(96, 88);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(74, 29);
            lbStatus.TabIndex = 35;
            lbStatus.Text = "status";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 88);
            label8.Name = "label8";
            label8.Size = new Size(80, 29);
            label8.TabIndex = 34;
            label8.Text = "Status:";
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(10, 491);
            txtRemarks.MaxLength = 255;
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(607, 168);
            txtRemarks.TabIndex = 4;
            txtRemarks.TextChanged += txtRemarks_TextChanged;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(10, 288);
            txtDescription.MaxLength = 255;
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(607, 168);
            txtDescription.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 1);
            label1.Name = "label1";
            label1.Size = new Size(97, 29);
            label1.TabIndex = 31;
            label1.Text = "TicketID:";
            // 
            // charCountLabel
            // 
            charCountLabel.AutoSize = true;
            charCountLabel.ForeColor = SystemColors.ControlText;
            charCountLabel.Location = new Point(10, 662);
            charCountLabel.Name = "charCountLabel";
            charCountLabel.Size = new Size(209, 29);
            charCountLabel.TabIndex = 30;
            charCountLabel.Text = "Characters Left: 255";
            // 
            // checkClockout
            // 
            checkClockout.AutoSize = true;
            checkClockout.Location = new Point(334, 694);
            checkClockout.Name = "checkClockout";
            checkClockout.Size = new Size(255, 33);
            checkClockout.TabIndex = 29;
            checkClockout.Text = "Set Clockout to 5:00pm";
            checkClockout.UseVisualStyleBackColor = true;
            // 
            // checkClockin
            // 
            checkClockin.AutoSize = true;
            checkClockin.Location = new Point(74, 694);
            checkClockin.Name = "checkClockin";
            checkClockin.Size = new Size(242, 33);
            checkClockin.TabIndex = 28;
            checkClockin.Text = "Set Clockin to 8:00am";
            checkClockin.UseVisualStyleBackColor = true;
            // 
            // lbResolverFirstName
            // 
            lbResolverFirstName.AutoSize = true;
            lbResolverFirstName.Location = new Point(416, 30);
            lbResolverFirstName.Name = "lbResolverFirstName";
            lbResolverFirstName.Size = new Size(199, 29);
            lbResolverFirstName.TabIndex = 27;
            lbResolverFirstName.Text = "resolver first name";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(306, 30);
            label15.Name = "label15";
            label15.Size = new Size(104, 29);
            label15.TabIndex = 26;
            label15.Text = "Resolver:";
            // 
            // lbReporterUserID
            // 
            lbReporterUserID.AutoSize = true;
            lbReporterUserID.Location = new Point(99, 169);
            lbReporterUserID.Name = "lbReporterUserID";
            lbReporterUserID.Size = new Size(76, 29);
            lbReporterUserID.TabIndex = 25;
            lbReporterUserID.Text = "userid";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(10, 169);
            label13.Name = "label13";
            label13.Size = new Size(83, 29);
            label13.TabIndex = 24;
            label13.Text = "UserID:";
            // 
            // lbClockout
            // 
            lbClockout.AutoSize = true;
            lbClockout.Location = new Point(423, 227);
            lbClockout.Name = "lbClockout";
            lbClockout.Size = new Size(98, 29);
            lbClockout.TabIndex = 23;
            lbClockout.Text = "clockout";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(308, 227);
            label14.Name = "label14";
            label14.Size = new Size(109, 29);
            label14.TabIndex = 22;
            label14.Text = "Clock Out:";
            // 
            // lbClockin
            // 
            lbClockin.AutoSize = true;
            lbClockin.Location = new Point(112, 227);
            lbClockin.Name = "lbClockin";
            lbClockin.Size = new Size(85, 29);
            lbClockin.TabIndex = 21;
            lbClockin.Text = "clockin";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(10, 227);
            label12.Name = "label12";
            label12.Size = new Size(96, 29);
            label12.TabIndex = 20;
            label12.Text = "Clock In:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 459);
            label10.Name = "label10";
            label10.Size = new Size(105, 29);
            label10.TabIndex = 18;
            label10.Text = "Remarks:";
            // 
            // lbDateResolved
            // 
            lbDateResolved.AutoSize = true;
            lbDateResolved.Location = new Point(464, 59);
            lbDateResolved.Name = "lbDateResolved";
            lbDateResolved.Size = new Size(141, 29);
            lbDateResolved.TabIndex = 17;
            lbDateResolved.Text = "dateresolved";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(307, 59);
            label9.Name = "label9";
            label9.Size = new Size(155, 29);
            label9.TabIndex = 16;
            label9.Text = "Date Resolved:";
            // 
            // lbDateRecieved
            // 
            lbDateRecieved.AutoSize = true;
            lbDateRecieved.Location = new Point(172, 59);
            lbDateRecieved.Name = "lbDateRecieved";
            lbDateRecieved.Size = new Size(142, 29);
            lbDateRecieved.TabIndex = 15;
            lbDateRecieved.Text = "daterecieved";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 59);
            label7.Name = "label7";
            label7.Size = new Size(156, 29);
            label7.TabIndex = 14;
            label7.Text = "Date Recieved:";
            // 
            // lbDTRID
            // 
            lbDTRID.AutoSize = true;
            lbDTRID.Location = new Point(95, 198);
            lbDTRID.Name = "lbDTRID";
            lbDTRID.Size = new Size(79, 29);
            lbDTRID.TabIndex = 13;
            lbDTRID.Text = "DTR ID:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 198);
            label6.Name = "label6";
            label6.Size = new Size(79, 29);
            label6.TabIndex = 12;
            label6.Text = "DTR ID:";
            // 
            // btnReslove
            // 
            btnReslove.Location = new Point(184, 733);
            btnReslove.Name = "btnReslove";
            btnReslove.Size = new Size(142, 41);
            btnReslove.TabIndex = 11;
            btnReslove.Text = "Resolve";
            btnReslove.UseVisualStyleBackColor = true;
            btnReslove.Click += btnReslove_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 256);
            label4.Name = "label4";
            label4.Size = new Size(131, 29);
            label4.TabIndex = 8;
            label4.Text = "Description:";
            // 
            // lbDTRDate
            // 
            lbDTRDate.AutoSize = true;
            lbDTRDate.Location = new Point(417, 198);
            lbDTRDate.Name = "lbDTRDate";
            lbDTRDate.Size = new Size(98, 29);
            lbDTRDate.TabIndex = 7;
            lbDTRDate.Text = "DTR Date";
            // 
            // lbTicketID
            // 
            lbTicketID.AutoSize = true;
            lbTicketID.Location = new Point(113, 30);
            lbTicketID.Name = "lbTicketID";
            lbTicketID.Size = new Size(96, 29);
            lbTicketID.TabIndex = 6;
            lbTicketID.Text = "Ticket ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(308, 198);
            label3.Name = "label3";
            label3.Size = new Size(103, 29);
            label3.TabIndex = 5;
            label3.Text = "DTR Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 30);
            label2.Name = "label2";
            label2.Size = new Size(97, 29);
            label2.TabIndex = 4;
            label2.Text = "TicketID:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(480, 733);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(142, 41);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(332, 733);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(142, 41);
            btnReject.TabIndex = 0;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // TicketsDTRView
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(649, 800);
            Controls.Add(panel1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "TicketsDTRView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TicketsDTRView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label lbDTRDate;
        private Label lbTicketID;
        private Label label3;
        private Label label2;
        private Button btnCancel;
        private Button btnReject;
        private Button btnReslove;
        private Label lbDTRID;
        private Label label6;
        private Label label10;
        private Label lbDateResolved;
        private Label label9;
        private Label lbDateRecieved;
        private Label label7;
        private Label lbResolverFirstName;
        private Label label15;
        private Label lbReporterUserID;
        private Label label13;
        private Label lbClockout;
        private Label label14;
        private Label lbClockin;
        private Label label12;
        private CheckBox checkClockout;
        private CheckBox checkClockin;
        private Label charCountLabel;
        private TextBox txtRemarks;
        private TextBox txtDescription;
        private Label label1;
        private Label lbStatus;
        private Label label8;
    }
}