namespace Payroll_System
{
    partial class AccountDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountDetailsForm));
            btnChangePass = new Button();
            panel1 = new Panel();
            btnShowDetails = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            MainPanel = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnChangePass
            // 
            btnChangePass.Anchor = AnchorStyles.None;
            btnChangePass.BackColor = SystemColors.Control;
            btnChangePass.FlatAppearance.BorderSize = 0;
            btnChangePass.FlatStyle = FlatStyle.Flat;
            btnChangePass.Location = new Point(233, 12);
            btnChangePass.Name = "btnChangePass";
            btnChangePass.Size = new Size(221, 37);
            btnChangePass.TabIndex = 11;
            btnChangePass.Text = "Change Password";
            btnChangePass.UseVisualStyleBackColor = false;
            btnChangePass.Click += ChangePasswordButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(178, 190, 195);
            panel1.Controls.Add(btnShowDetails);
            panel1.Controls.Add(btnChangePass);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1256, 49);
            panel1.TabIndex = 46;
            // 
            // btnShowDetails
            // 
            btnShowDetails.Anchor = AnchorStyles.None;
            btnShowDetails.BackColor = SystemColors.Control;
            btnShowDetails.FlatAppearance.BorderSize = 0;
            btnShowDetails.FlatStyle = FlatStyle.Flat;
            btnShowDetails.Location = new Point(12, 12);
            btnShowDetails.Name = "btnShowDetails";
            btnShowDetails.Size = new Size(221, 37);
            btnShowDetails.TabIndex = 12;
            btnShowDetails.Text = "Show Details";
            btnShowDetails.UseVisualStyleBackColor = false;
            btnShowDetails.Click += btnShowDetails_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(178, 190, 195);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(12, 611);
            panel2.TabIndex = 47;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(178, 190, 195);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(12, 648);
            panel3.Name = "panel3";
            panel3.Size = new Size(1244, 12);
            panel3.TabIndex = 48;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(178, 190, 195);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1244, 49);
            panel4.Name = "panel4";
            panel4.Size = new Size(12, 599);
            panel4.TabIndex = 49;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = SystemColors.Control;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(12, 49);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1232, 599);
            MainPanel.TabIndex = 50;
            // 
            // AccountDetailsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1256, 660);
            Controls.Add(MainPanel);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "AccountDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AccountDetailsForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnChangePass;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel MainPanel;
        private Button btnShowDetails;
    }
}