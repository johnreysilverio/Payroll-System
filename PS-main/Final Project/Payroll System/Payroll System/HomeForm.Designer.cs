namespace Payroll_System
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            btnClockIn = new Button();
            btnClockOut = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnClockIn
            // 
            btnClockIn.BackColor = Color.Lime;
            btnClockIn.ForeColor = SystemColors.ControlText;
            btnClockIn.Location = new Point(768, 12);
            btnClockIn.Name = "btnClockIn";
            btnClockIn.Size = new Size(235, 53);
            btnClockIn.TabIndex = 1;
            btnClockIn.Text = "CLOCK IN";
            btnClockIn.UseVisualStyleBackColor = false;
            btnClockIn.Click += btnClockIn_Click;
            // 
            // btnClockOut
            // 
            btnClockOut.BackColor = Color.Red;
            btnClockOut.ForeColor = SystemColors.ControlText;
            btnClockOut.Location = new Point(1009, 12);
            btnClockOut.Name = "btnClockOut";
            btnClockOut.Size = new Size(235, 53);
            btnClockOut.TabIndex = 2;
            btnClockOut.Text = "CLOCK OUT";
            btnClockOut.UseVisualStyleBackColor = false;
            btnClockOut.Click += btnClockOut_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Payroll_System;
            pictureBox1.Location = new Point(491, 187);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(275, 272);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Brush Script Std", 20.2499981F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(294, 428);
            label1.Name = "label1";
            label1.Size = new Size(693, 31);
            label1.TabIndex = 4;
            label1.Text = "\"Simplify your payroll process and let your business thrive.\"";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(178, 190, 195);
            ClientSize = new Size(1256, 660);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(btnClockOut);
            Controls.Add(btnClockIn);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnClockIn;
        private Button btnClockOut;
        private PictureBox pictureBox1;
        private Label label1;
    }
}