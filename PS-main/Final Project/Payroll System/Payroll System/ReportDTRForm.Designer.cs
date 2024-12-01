namespace Payroll_System
{
    partial class ReportDTRForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDTRForm));
            panel1 = new Panel();
            charCountLabel = new Label();
            label4 = new Label();
            lbDTRDate = new Label();
            lbDTRId = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            btnCancel = new Button();
            btnSend = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(charCountLabel);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lbDTRDate);
            panel1.Controls.Add(lbDTRId);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSend);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(625, 441);
            panel1.TabIndex = 0;
            // 
            // charCountLabel
            // 
            charCountLabel.AutoSize = true;
            charCountLabel.ForeColor = SystemColors.ControlText;
            charCountLabel.Location = new Point(3, 394);
            charCountLabel.Name = "charCountLabel";
            charCountLabel.Size = new Size(209, 29);
            charCountLabel.TabIndex = 10;
            charCountLabel.Text = "Characters Left: 255";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 88);
            label4.Name = "label4";
            label4.Size = new Size(131, 29);
            label4.TabIndex = 8;
            label4.Text = "Description:";
            // 
            // lbDTRDate
            // 
            lbDTRDate.AutoSize = true;
            lbDTRDate.Location = new Point(72, 59);
            lbDTRDate.Name = "lbDTRDate";
            lbDTRDate.Size = new Size(98, 29);
            lbDTRDate.TabIndex = 7;
            lbDTRDate.Text = "DTR Date";
            // 
            // lbDTRId
            // 
            lbDTRId.AutoSize = true;
            lbDTRId.Location = new Point(72, 30);
            lbDTRId.Name = "lbDTRId";
            lbDTRId.Size = new Size(79, 29);
            lbDTRId.TabIndex = 6;
            lbDTRId.Text = "DTR ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 59);
            label3.Name = "label3";
            label3.Size = new Size(63, 29);
            label3.TabIndex = 5;
            label3.Text = "DATE:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(79, 29);
            label2.TabIndex = 4;
            label2.Text = "DTR ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 1);
            label1.Name = "label1";
            label1.Size = new Size(119, 29);
            label1.TabIndex = 3;
            label1.Text = "Report DTR";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 120);
            textBox1.MaxLength = 255;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(619, 268);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(480, 394);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(142, 41);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(332, 394);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(142, 41);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // ReportDTRForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(649, 463);
            Controls.Add(panel1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "ReportDTRForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReportDTRForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnCancel;
        private Button btnSend;
        private TextBox textBox1;
        private Label label1;
        private Label lbDTRDate;
        private Label lbDTRId;
        private Label label3;
        private Label label2;
        private Label charCountLabel;
        private Label label4;
    }
}