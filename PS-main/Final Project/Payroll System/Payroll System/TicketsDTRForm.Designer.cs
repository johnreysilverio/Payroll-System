namespace Payroll_System
{
    partial class TicketsDTRForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketsDTRForm));
            btnRefresh = new Button();
            dgvDTRTickets = new DataGridView();
            label1 = new Label();
            btnView = new Button();
            cbList = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvDTRTickets).BeginInit();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1102, 607);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(142, 41);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvDTRTickets
            // 
            dgvDTRTickets.AllowUserToAddRows = false;
            dgvDTRTickets.AllowUserToDeleteRows = false;
            dgvDTRTickets.AllowUserToResizeColumns = false;
            dgvDTRTickets.AllowUserToResizeRows = false;
            dgvDTRTickets.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDTRTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDTRTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDTRTickets.Location = new Point(12, 55);
            dgvDTRTickets.MultiSelect = false;
            dgvDTRTickets.Name = "dgvDTRTickets";
            dgvDTRTickets.ReadOnly = true;
            dgvDTRTickets.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dgvDTRTickets.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvDTRTickets.RowTemplate.Height = 25;
            dgvDTRTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDTRTickets.Size = new Size(1232, 546);
            dgvDTRTickets.TabIndex = 3;
            dgvDTRTickets.CellClick += dgvDTRTickets_CellClick;
            dgvDTRTickets.CellFormatting += dgvDTRTickets_CellFormatting;
            dgvDTRTickets.RowPrePaint += dgvDTRTickets_RowPrePaint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(70, 29);
            label1.TabIndex = 5;
            label1.Text = "Show:";
            // 
            // btnView
            // 
            btnView.Location = new Point(954, 607);
            btnView.Name = "btnView";
            btnView.Size = new Size(142, 41);
            btnView.TabIndex = 6;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // cbList
            // 
            cbList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbList.FormattingEnabled = true;
            cbList.Items.AddRange(new object[] { "All", "Unresolved", "Resolved", "Rejected" });
            cbList.Location = new Point(88, 12);
            cbList.Name = "cbList";
            cbList.Size = new Size(261, 37);
            cbList.TabIndex = 7;
            cbList.SelectedIndexChanged += cbList_SelectedIndexChanged;
            // 
            // TicketsDTRForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(178, 190, 195);
            ClientSize = new Size(1256, 660);
            Controls.Add(cbList);
            Controls.Add(btnView);
            Controls.Add(label1);
            Controls.Add(dgvDTRTickets);
            Controls.Add(btnRefresh);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "TicketsDTRForm";
            Text = "TicketsDTRForm";
            ((System.ComponentModel.ISupportInitialize)dgvDTRTickets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRefresh;
        private DataGridView dgvDTRTickets;
        private Label label1;
        private Button btnView;
        private ComboBox cbList;
    }
}