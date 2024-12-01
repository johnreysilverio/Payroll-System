namespace Payroll_System
{
    partial class TicketsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketsForm));
            btnDTR = new Button();
            panel1 = new Panel();
            MainPanel = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDTR
            // 
            btnDTR.Anchor = AnchorStyles.None;
            btnDTR.BackColor = SystemColors.ButtonFace;
            btnDTR.FlatAppearance.BorderSize = 0;
            btnDTR.FlatStyle = FlatStyle.Flat;
            btnDTR.Location = new Point(0, 12);
            btnDTR.Name = "btnDTR";
            btnDTR.Size = new Size(100, 37);
            btnDTR.TabIndex = 8;
            btnDTR.Text = "DTR";
            btnDTR.UseVisualStyleBackColor = false;
            btnDTR.Click += btnDTR_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(btnDTR);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(12, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1244, 49);
            panel1.TabIndex = 10;
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(12, 49);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1232, 599);
            MainPanel.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(12, 660);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(12, 648);
            panel3.Name = "panel3";
            panel3.Size = new Size(1244, 12);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveBorder;
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1244, 49);
            panel4.Name = "panel4";
            panel4.Size = new Size(12, 599);
            panel4.TabIndex = 1;
            // 
            // TicketsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1256, 660);
            Controls.Add(MainPanel);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "TicketsForm";
            Text = "TicketsForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnDTR;
        private Panel panel1;
        private Panel MainPanel;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}