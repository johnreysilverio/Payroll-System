namespace Payroll_System
{
    partial class HolidaysForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HolidaysForm));
            btnModify = new Button();
            dgvDates = new DataGridView();
            btnRefresh = new Button();
            textBox1 = new TextBox();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            label1 = new Label();
            label2 = new Label();
            rb0 = new RadioButton();
            rb2 = new RadioButton();
            rb1 = new RadioButton();
            rb3 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvDates).BeginInit();
            SuspendLayout();
            // 
            // btnModify
            // 
            btnModify.Anchor = AnchorStyles.None;
            btnModify.Location = new Point(937, 611);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(307, 37);
            btnModify.TabIndex = 6;
            btnModify.Text = "Modify";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // dgvDates
            // 
            dgvDates.AllowUserToAddRows = false;
            dgvDates.AllowUserToDeleteRows = false;
            dgvDates.AllowUserToResizeColumns = false;
            dgvDates.AllowUserToResizeRows = false;
            dgvDates.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDates.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDates.Location = new Point(12, 12);
            dgvDates.MultiSelect = false;
            dgvDates.Name = "dgvDates";
            dgvDates.ReadOnly = true;
            dgvDates.RowHeadersVisible = false;
            dgvDates.RowTemplate.Height = 25;
            dgvDates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDates.Size = new Size(608, 636);
            dgvDates.TabIndex = 7;
            dgvDates.RowPrePaint += dgvDates_RowPrePaint;
            dgvDates.SelectionChanged += dgvDates_SelectionChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.None;
            btnRefresh.Location = new Point(626, 611);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(307, 37);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(626, 40);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(618, 32);
            textBox1.TabIndex = 9;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(626, 12);
            label1.Name = "label1";
            label1.Size = new Size(53, 25);
            label1.TabIndex = 10;
            label1.Text = "Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(626, 75);
            label2.Name = "label2";
            label2.Size = new Size(168, 25);
            label2.TabIndex = 12;
            label2.Text = "Number of Holidays";
            // 
            // rb0
            // 
            rb0.AutoSize = true;
            rb0.Location = new Point(749, 103);
            rb0.Name = "rb0";
            rb0.Size = new Size(71, 29);
            rb0.TabIndex = 13;
            rb0.TabStop = true;
            rb0.Text = "None";
            rb0.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            rb2.AutoSize = true;
            rb2.Location = new Point(749, 138);
            rb2.Name = "rb2";
            rb2.Size = new Size(79, 29);
            rb2.TabIndex = 14;
            rb2.TabStop = true;
            rb2.Text = "Two, 2";
            rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            rb1.AutoSize = true;
            rb1.Location = new Point(965, 103);
            rb1.Name = "rb1";
            rb1.Size = new Size(76, 29);
            rb1.TabIndex = 15;
            rb1.TabStop = true;
            rb1.Text = "One, 1";
            rb1.UseVisualStyleBackColor = true;
            // 
            // rb3
            // 
            rb3.AutoSize = true;
            rb3.Location = new Point(966, 138);
            rb3.Name = "rb3";
            rb3.Size = new Size(94, 29);
            rb3.TabIndex = 16;
            rb3.TabStop = true;
            rb3.Text = "Three, 3";
            rb3.UseVisualStyleBackColor = true;
            // 
            // HolidaysForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(178, 190, 195);
            ClientSize = new Size(1256, 660);
            Controls.Add(rb3);
            Controls.Add(rb1);
            Controls.Add(rb2);
            Controls.Add(rb0);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(btnRefresh);
            Controls.Add(dgvDates);
            Controls.Add(btnModify);
            Font = new Font("Impact", 15F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "HolidaysForm";
            Text = "HolidaysForm";
            ((System.ComponentModel.ISupportInitialize)dgvDates).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnModify;
        private DataGridView dgvDates;
        private Button btnRefresh;
        private TextBox textBox1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private Label label1;
        private Label label2;
        private RadioButton rb0;
        private RadioButton rb2;
        private RadioButton rb1;
        private RadioButton rb3;
    }
}