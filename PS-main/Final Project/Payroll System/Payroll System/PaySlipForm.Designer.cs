namespace Payroll_System
{
    partial class PaySlipForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaySlipForm));
            dgvPayslip = new DataGridView();
            btnRefresh = new Button();
            btnView = new Button();
            cbView = new ComboBox();
            label1 = new Label();
            cbViewPayslips = new ComboBox();
            lbRange = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPayslip).BeginInit();
            SuspendLayout();
            // 
            // dgvPayslip
            // 
            dgvPayslip.AllowUserToAddRows = false;
            dgvPayslip.AllowUserToDeleteRows = false;
            dgvPayslip.AllowUserToResizeColumns = false;
            dgvPayslip.AllowUserToResizeRows = false;
            dgvPayslip.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPayslip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPayslip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPayslip.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPayslip.Location = new Point(12, 49);
            dgvPayslip.Name = "dgvPayslip";
            dgvPayslip.ReadOnly = true;
            dgvPayslip.RowHeadersVisible = false;
            dgvPayslip.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPayslip.RowTemplate.Height = 25;
            dgvPayslip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayslip.Size = new Size(1232, 556);
            dgvPayslip.TabIndex = 0;
            dgvPayslip.CellClick += dgvPayslip_CellClick;
            dgvPayslip.CellFormatting += dgvPayslip_CellFormatting;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.None;
            btnRefresh.Location = new Point(1024, 611);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(220, 37);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnView
            // 
            btnView.Anchor = AnchorStyles.None;
            btnView.Location = new Point(798, 611);
            btnView.Name = "btnView";
            btnView.Size = new Size(220, 37);
            btnView.TabIndex = 6;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // cbView
            // 
            cbView.DropDownStyle = ComboBoxStyle.DropDownList;
            cbView.Enabled = false;
            cbView.FormattingEnabled = true;
            cbView.Items.AddRange(new object[] { "Own", "All" });
            cbView.Location = new Point(88, 6);
            cbView.Name = "cbView";
            cbView.Size = new Size(261, 37);
            cbView.TabIndex = 9;
            cbView.SelectedIndexChanged += cbView_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(70, 29);
            label1.TabIndex = 8;
            label1.Text = "Show:";
            // 
            // cbViewPayslips
            // 
            cbViewPayslips.DropDownStyle = ComboBoxStyle.DropDownList;
            cbViewPayslips.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point);
            cbViewPayslips.FormattingEnabled = true;
            cbViewPayslips.Items.AddRange(new object[] { "Own", "All" });
            cbViewPayslips.Location = new Point(441, 6);
            cbViewPayslips.Name = "cbViewPayslips";
            cbViewPayslips.Size = new Size(399, 37);
            cbViewPayslips.TabIndex = 10;
            cbViewPayslips.SelectedValueChanged += cbViewPayslips_SelectedValueChanged;
            // 
            // lbRange
            // 
            lbRange.AutoSize = true;
            lbRange.Location = new Point(355, 9);
            lbRange.Name = "lbRange";
            lbRange.Size = new Size(80, 29);
            lbRange.TabIndex = 11;
            lbRange.Text = "Range:";
            // 
            // PaySlipForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(178, 190, 195);
            ClientSize = new Size(1256, 660);
            Controls.Add(lbRange);
            Controls.Add(cbViewPayslips);
            Controls.Add(cbView);
            Controls.Add(label1);
            Controls.Add(btnView);
            Controls.Add(btnRefresh);
            Controls.Add(dgvPayslip);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "PaySlipForm";
            Text = "PaySlipForm";
            ((System.ComponentModel.ISupportInitialize)dgvPayslip).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPayslip;
        private Button btnRefresh;
        private Button btnView;
        private ComboBox cbView;
        private Label label1;
        private ComboBox cbViewPayslips;
        private Label lbRange;
    }
}