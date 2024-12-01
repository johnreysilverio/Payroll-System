namespace Payroll_System
{
    partial class InsuraceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsuraceForm));
            panel1 = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnCancel = new Button();
            btnSend = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSend);
            panel1.Location = new Point(12, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(367, 247);
            panel1.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.Control;
            label7.Location = new Point(132, 148);
            label7.Name = "label7";
            label7.Size = new Size(50, 29);
            label7.TabIndex = 11;
            label7.Text = "Php";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Control;
            label6.Location = new Point(132, 105);
            label6.Name = "label6";
            label6.Size = new Size(50, 29);
            label6.TabIndex = 10;
            label6.Text = "Php";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Location = new Point(262, 58);
            label5.Name = "label5";
            label5.Size = new Size(30, 29);
            label5.TabIndex = 9;
            label5.Text = "%";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(188, 145);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(174, 37);
            textBox2.TabIndex = 8;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(188, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 37);
            textBox1.TabIndex = 7;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(188, 56);
            numericUpDown1.Margin = new Padding(5, 6, 5, 6);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(66, 37);
            numericUpDown1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 148);
            label4.Name = "label4";
            label4.Size = new Size(118, 29);
            label4.TabIndex = 5;
            label4.Text = "PhilHealth:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 105);
            label3.Name = "label3";
            label3.Size = new Size(98, 29);
            label3.TabIndex = 4;
            label3.Text = "Pag-Ibig:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 58);
            label2.Name = "label2";
            label2.Size = new Size(54, 29);
            label2.TabIndex = 3;
            label2.Text = "SSS:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(302, 29);
            label1.TabIndex = 2;
            label1.Text = "Update Insurance Deductions";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(188, 198);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(174, 41);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(3, 198);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(174, 41);
            btnSend.TabIndex = 0;
            btnSend.Text = "Update";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // InsuraceForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(391, 270);
            Controls.Add(panel1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "InsuraceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InsuraceForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnCancel;
        private Button btnSend;
        private TextBox textBox2;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
    }
}