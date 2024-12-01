namespace Payroll_System
{
    partial class DTRForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DTRForm));
            btnRefresh = new Button();
            btnReport = new Button();
            dgvDTR = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDTR).BeginInit();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.None;
            btnRefresh.Location = new Point(798, 611);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(220, 37);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnReport
            // 
            btnReport.Anchor = AnchorStyles.None;
            btnReport.Location = new Point(1024, 611);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(220, 37);
            btnReport.TabIndex = 5;
            btnReport.Text = "Report";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // dgvDTR
            // 
            dgvDTR.AllowUserToAddRows = false;
            dgvDTR.AllowUserToDeleteRows = false;
            dgvDTR.AllowUserToResizeColumns = false;
            dgvDTR.AllowUserToResizeRows = false;
            dgvDTR.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDTR.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDTR.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDTR.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDTR.Location = new Point(12, 12);
            dgvDTR.MultiSelect = false;
            dgvDTR.Name = "dgvDTR";
            dgvDTR.ReadOnly = true;
            dgvDTR.RowHeadersVisible = false;
            dgvDTR.RowTemplate.Height = 25;
            dgvDTR.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDTR.Size = new Size(1232, 593);
            dgvDTR.TabIndex = 6;
            dgvDTR.TabStop = false;
            dgvDTR.CellClick += dgvDTR_CellClick;
            dgvDTR.CellFormatting += dgvDTR_CellFormatting;
            dgvDTR.RowPrePaint += dgvDTR_RowPrePaint;
            // 
            // DTRForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(178, 190, 195);
            ClientSize = new Size(1256, 660);
            Controls.Add(dgvDTR);
            Controls.Add(btnReport);
            Controls.Add(btnRefresh);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "DTRForm";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "DTRForm";
            ((System.ComponentModel.ISupportInitialize)dgvDTR).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnRefresh;
        private Button btnReport;
        private DataGridView dgvDTR;
    }
}