namespace Payroll_System
{
    partial class EditPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPasswordForm));
            panel1 = new Panel();
            lbNewPass = new Label();
            lbConfNewPass = new Label();
            TxtConfNewPass = new TextBox();
            TxtNewPass = new TextBox();
            label3 = new Label();
            TxtPass = new TextBox();
            label1 = new Label();
            ConfirmButton = new Button();
            TxtOldPass = new TextBox();
            TxtConfOldPass = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(lbNewPass);
            panel1.Controls.Add(lbConfNewPass);
            panel1.Controls.Add(TxtConfNewPass);
            panel1.Controls.Add(TxtNewPass);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(TxtPass);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(ConfirmButton);
            panel1.Controls.Add(TxtOldPass);
            panel1.Controls.Add(TxtConfOldPass);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(368, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(501, 573);
            panel1.TabIndex = 25;
            // 
            // lbNewPass
            // 
            lbNewPass.Anchor = AnchorStyles.None;
            lbNewPass.AutoSize = true;
            lbNewPass.BackColor = SystemColors.Control;
            lbNewPass.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lbNewPass.ForeColor = SystemColors.ActiveBorder;
            lbNewPass.Location = new Point(32, 238);
            lbNewPass.Name = "lbNewPass";
            lbNewPass.Size = new Size(192, 34);
            lbNewPass.TabIndex = 41;
            lbNewPass.Text = "8-16 Characters";
            lbNewPass.Click += lbNewPass_Click;
            // 
            // lbConfNewPass
            // 
            lbConfNewPass.Anchor = AnchorStyles.None;
            lbConfNewPass.AutoSize = true;
            lbConfNewPass.BackColor = SystemColors.Control;
            lbConfNewPass.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lbConfNewPass.ForeColor = SystemColors.ActiveBorder;
            lbConfNewPass.Location = new Point(32, 329);
            lbConfNewPass.Name = "lbConfNewPass";
            lbConfNewPass.Size = new Size(192, 34);
            lbConfNewPass.TabIndex = 40;
            lbConfNewPass.Text = "8-16 Characters";
            lbConfNewPass.Click += lbConfNewPass_Click;
            // 
            // TxtConfNewPass
            // 
            TxtConfNewPass.Anchor = AnchorStyles.None;
            TxtConfNewPass.BackColor = SystemColors.Control;
            TxtConfNewPass.BorderStyle = BorderStyle.FixedSingle;
            TxtConfNewPass.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtConfNewPass.Location = new Point(22, 315);
            TxtConfNewPass.MaxLength = 16;
            TxtConfNewPass.Name = "TxtConfNewPass";
            TxtConfNewPass.Size = new Size(459, 56);
            TxtConfNewPass.TabIndex = 3;
            TxtConfNewPass.UseSystemPasswordChar = true;
            TxtConfNewPass.Enter += TxtConfNewPass_Enter;
            TxtConfNewPass.Leave += TxtConfNewPass_Leave;
            // 
            // TxtNewPass
            // 
            TxtNewPass.Anchor = AnchorStyles.None;
            TxtNewPass.BackColor = SystemColors.Control;
            TxtNewPass.BorderStyle = BorderStyle.FixedSingle;
            TxtNewPass.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtNewPass.Location = new Point(22, 224);
            TxtNewPass.MaxLength = 16;
            TxtNewPass.Name = "TxtNewPass";
            TxtNewPass.Size = new Size(459, 56);
            TxtNewPass.TabIndex = 2;
            TxtNewPass.UseSystemPasswordChar = true;
            TxtNewPass.Enter += TxtNewPass_Enter;
            TxtNewPass.Leave += TxtNewPass_Leave;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Location = new Point(3, 101);
            label3.Name = "label3";
            label3.Size = new Size(230, 29);
            label3.TabIndex = 39;
            label3.Text = "Confirm Old Password:";
            // 
            // TxtPass
            // 
            TxtPass.Anchor = AnchorStyles.None;
            TxtPass.BorderStyle = BorderStyle.FixedSingle;
            TxtPass.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtPass.Location = new Point(172, 720);
            TxtPass.Name = "TxtPass";
            TxtPass.Size = new Size(459, 56);
            TxtPass.TabIndex = 7;
            TxtPass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Location = new Point(153, 688);
            label1.Name = "label1";
            label1.Size = new Size(168, 29);
            label1.TabIndex = 38;
            label1.Text = "Input Password:";
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new Point(3, 506);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(495, 54);
            ConfirmButton.TabIndex = 4;
            ConfirmButton.Text = "CONFIRM";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // TxtOldPass
            // 
            TxtOldPass.Anchor = AnchorStyles.None;
            TxtOldPass.BackColor = SystemColors.Control;
            TxtOldPass.BorderStyle = BorderStyle.FixedSingle;
            TxtOldPass.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtOldPass.Location = new Point(22, 42);
            TxtOldPass.MaxLength = 16;
            TxtOldPass.Name = "TxtOldPass";
            TxtOldPass.Size = new Size(459, 56);
            TxtOldPass.TabIndex = 0;
            TxtOldPass.UseSystemPasswordChar = true;
            // 
            // TxtConfOldPass
            // 
            TxtConfOldPass.Anchor = AnchorStyles.None;
            TxtConfOldPass.BackColor = SystemColors.Control;
            TxtConfOldPass.BorderStyle = BorderStyle.FixedSingle;
            TxtConfOldPass.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtConfOldPass.Location = new Point(22, 133);
            TxtConfOldPass.MaxLength = 16;
            TxtConfOldPass.Name = "TxtConfOldPass";
            TxtConfOldPass.Size = new Size(459, 56);
            TxtConfOldPass.TabIndex = 1;
            TxtConfOldPass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(3, 192);
            label4.Name = "label4";
            label4.Size = new Size(156, 29);
            label4.TabIndex = 35;
            label4.Text = "New Password:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Location = new Point(3, 10);
            label2.Name = "label2";
            label2.Size = new Size(147, 29);
            label2.TabIndex = 27;
            label2.Text = "Old Password:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.BackColor = SystemColors.Control;
            label7.Location = new Point(3, 283);
            label7.Name = "label7";
            label7.Size = new Size(234, 29);
            label7.TabIndex = 29;
            label7.Text = "Confirm New Password";
            // 
            // EditPasswordForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1232, 599);
            Controls.Add(panel1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "EditPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditPasswordForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label3;
        private TextBox TxtPass;
        private Label label1;
        private Button ConfirmButton;
        private TextBox TxtOldPass;
        private TextBox TxtConfOldPass;
        private Label label4;
        private Label label2;
        private Label label7;
        private TextBox TxtConfNewPass;
        private TextBox TxtNewPass;
        private Label lbConfNewPass;
        private Label lbNewPass;
    }
}