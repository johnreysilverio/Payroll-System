namespace Payroll_System
{
    partial class ManageAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageAccountForm));
            userDatasGrid = new DataGridView();
            ButtonEdit = new Button();
            ButtonRegister = new Button();
            txtBoxSearch = new TextBox();
            btnClear = new Button();
            searchPlaceholder = new Label();
            btnDelete = new Button();
            btnDeduction = new Button();
            ((System.ComponentModel.ISupportInitialize)userDatasGrid).BeginInit();
            SuspendLayout();
            // 
            // userDatasGrid
            // 
            userDatasGrid.AllowUserToAddRows = false;
            userDatasGrid.AllowUserToDeleteRows = false;
            userDatasGrid.AllowUserToResizeColumns = false;
            userDatasGrid.AllowUserToResizeRows = false;
            userDatasGrid.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            userDatasGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            userDatasGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            userDatasGrid.DefaultCellStyle = dataGridViewCellStyle2;
            userDatasGrid.Location = new Point(12, 55);
            userDatasGrid.MultiSelect = false;
            userDatasGrid.Name = "userDatasGrid";
            userDatasGrid.ReadOnly = true;
            userDatasGrid.RowHeadersVisible = false;
            userDatasGrid.RowTemplate.Height = 25;
            userDatasGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            userDatasGrid.Size = new Size(1232, 550);
            userDatasGrid.TabIndex = 2;
            userDatasGrid.CellClick += userDatasGrid_CellClick;
            userDatasGrid.CellFormatting += userDatasGrid_CellFormatting;
            // 
            // ButtonEdit
            // 
            ButtonEdit.Anchor = AnchorStyles.None;
            ButtonEdit.BackColor = Color.Yellow;
            ButtonEdit.Location = new Point(798, 611);
            ButtonEdit.Name = "ButtonEdit";
            ButtonEdit.Size = new Size(220, 37);
            ButtonEdit.TabIndex = 3;
            ButtonEdit.Text = "Modify";
            ButtonEdit.UseVisualStyleBackColor = false;
            ButtonEdit.Click += ButtonEdit_Click;
            // 
            // ButtonRegister
            // 
            ButtonRegister.Anchor = AnchorStyles.None;
            ButtonRegister.BackColor = Color.Lime;
            ButtonRegister.Location = new Point(572, 611);
            ButtonRegister.Name = "ButtonRegister";
            ButtonRegister.Size = new Size(220, 37);
            ButtonRegister.TabIndex = 4;
            ButtonRegister.Text = "Register";
            ButtonRegister.UseVisualStyleBackColor = false;
            ButtonRegister.Click += ButtonRegister_Click;
            // 
            // txtBoxSearch
            // 
            txtBoxSearch.Location = new Point(12, 12);
            txtBoxSearch.Name = "txtBoxSearch";
            txtBoxSearch.Size = new Size(446, 37);
            txtBoxSearch.TabIndex = 5;
            txtBoxSearch.TextChanged += txtBoxSearch_TextChanged;
            txtBoxSearch.Enter += txtBoxSearch_Enter;
            txtBoxSearch.Leave += txtBoxSearch_Leave;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.None;
            btnClear.Location = new Point(464, 12);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(220, 37);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // searchPlaceholder
            // 
            searchPlaceholder.AutoSize = true;
            searchPlaceholder.BackColor = SystemColors.Window;
            searchPlaceholder.ForeColor = SystemColors.ActiveBorder;
            searchPlaceholder.Location = new Point(15, 16);
            searchPlaceholder.Name = "searchPlaceholder";
            searchPlaceholder.Size = new Size(366, 29);
            searchPlaceholder.TabIndex = 7;
            searchPlaceholder.Text = "Username or Firstname or Lastname";
            searchPlaceholder.Click += searchPlaceholder_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.BackColor = Color.Red;
            btnDelete.Location = new Point(1024, 611);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(220, 37);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnDeduction
            // 
            btnDeduction.Anchor = AnchorStyles.None;
            btnDeduction.BackColor = Color.Yellow;
            btnDeduction.Location = new Point(12, 611);
            btnDeduction.Name = "btnDeduction";
            btnDeduction.Size = new Size(220, 37);
            btnDeduction.TabIndex = 9;
            btnDeduction.Text = "Insurances";
            btnDeduction.UseVisualStyleBackColor = false;
            btnDeduction.Click += btnDeduction_Click;
            // 
            // ManageAccountForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(178, 190, 195);
            ClientSize = new Size(1256, 660);
            Controls.Add(btnDeduction);
            Controls.Add(btnDelete);
            Controls.Add(searchPlaceholder);
            Controls.Add(btnClear);
            Controls.Add(txtBoxSearch);
            Controls.Add(ButtonRegister);
            Controls.Add(ButtonEdit);
            Controls.Add(userDatasGrid);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "ManageAccountForm";
            Text = "ManageAccountForm";
            ((System.ComponentModel.ISupportInitialize)userDatasGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView userDatasGrid;
        private Button ButtonEdit;
        private Button ButtonRegister;
        private TextBox txtBoxSearch;
        private Button btnClear;
        private Label searchPlaceholder;
        private Button btnDelete;
        private Button btnDeduction;
    }
}