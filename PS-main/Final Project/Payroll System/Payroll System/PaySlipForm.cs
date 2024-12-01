using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_System
{
    public partial class PaySlipForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        DataTable? dtPayslip = new();
        DataTable? dtPayslipRange = new();
        DBConn dbConn = new();
        DBQuery dbQuery = new();
        private bool formLoaded = false;
        private string cellValuePayslipID;
        private string cellValuePayslipDetailID;
        private string? accLevel;
        private string payslipID;
        public PaySlipForm()
        {
            InitializeComponent();
            formLoaded = true;
            ShowOwnPayslip();
            foreach (DataGridViewColumn column in dgvPayslip.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (retrievedTable != null && retrievedTable.Rows.Count > 0)
            {
                accLevel = retrievedTable.Rows[0][columnName: "accountLevel"].ToString();
            }

            cbView.SelectedIndex = 0;
            lbRange.Visible = false;
            cbViewPayslips.Visible = false;
            ShowPayslipRange();

            if (accLevel != "1")
            {
                cbView.Enabled = true;
            }
        }
        private void ShowPayslipRange()
        {
            if (!formLoaded)
            {
                return;
            }

            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscShowPayslipRange;
            mscShowPayslipRange = new(dbQuery.ShowPayslipRange(), dbConn.getConnection());
            mscAdapter.SelectCommand = mscShowPayslipRange;
            mscAdapter.Fill(dtPayslipRange);

            if (dtPayslipRange != null)
            {
                cbViewPayslips.Items.Clear();

                foreach (DataRow row in dtPayslipRange.Rows)
                {
                    string valueToAdd = row[1].ToString();
                    cbViewPayslips.Items.Add(valueToAdd);
                }
            }

        }
        private void ShowOwnPayslip()
        {
            if (!formLoaded)
            {
                return;
            }
            dtPayslip.Rows.Clear();

            string userID = retrievedTable.Rows[0][columnName: "userID"].ToString();
            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscGetPayslip;
            mscGetPayslip = new(dbQuery.GetPayslip(), dbConn.getConnection());
            mscGetPayslip.Parameters.Add("@p0", MySqlDbType.VarChar).Value = userID;
            mscAdapter.SelectCommand = mscGetPayslip;
            mscAdapter.Fill(dtPayslip);

            FilldgvPayslip();
        }
        private void ShowPayslip()
        {
            if (!formLoaded)
            {
                return;
            }
            dtPayslip.Rows.Clear();

            string userID = retrievedTable.Rows[0][columnName: "userID"].ToString();
            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscShowPayslip;
            mscShowPayslip = new(dbQuery.ShowPayslips(), dbConn.getConnection());
            mscShowPayslip.Parameters.Add("@p0", MySqlDbType.VarChar).Value = payslipID;
            mscAdapter.SelectCommand = mscShowPayslip;
            mscAdapter.Fill(dtPayslip);

            FilldgvPayslip();
        }
        private void FilldgvPayslip()
        {
            dgvPayslip.DataSource = dtPayslip;

            dgvPayslip.Columns["payslipID"].Visible = false;
            dgvPayslip.Columns["payslipDetailID"].Visible = false;
            dgvPayslip.Columns["userID"].Visible = false;
            dgvPayslip.Columns["subtotal"].Visible = false;
            dgvPayslip.Columns["allowance"].Visible = false;
            dgvPayslip.Columns["deduction"].Visible = false;


            var payslipCombinedColumn = dgvPayslip.Columns["combined_column"];
            payslipCombinedColumn.HeaderText = "Reference Number";
            payslipCombinedColumn.Width = 200;

            var payslipFullnameColumn = dgvPayslip.Columns["fullname"];
            payslipFullnameColumn.HeaderText = "Fullname";
            payslipFullnameColumn.Width = 200;


            var payslipStartDateColumn = dgvPayslip.Columns["startDate"];
            payslipStartDateColumn.DefaultCellStyle.Format = "MM/dd/yyyy";
            payslipStartDateColumn.HeaderText = "Start Date";
            payslipStartDateColumn.Width = 200;

            var payslipEndDateColumn = dgvPayslip.Columns["endDate"];
            payslipEndDateColumn.DefaultCellStyle.Format = "MM/dd/yyyy";
            payslipEndDateColumn.HeaderText = "End Date";
            payslipEndDateColumn.Width = 200;

            var payslipTotalHours = dgvPayslip.Columns["totalHours"];
            payslipTotalHours.HeaderText = "Total Hours";
            payslipTotalHours.DefaultCellStyle.Format = "HH:mm:ss";
            payslipTotalHours.Width = 200;

            var payslipTotalSalary = dgvPayslip.Columns["totalSalary"];
            payslipTotalSalary.HeaderText = "Total Salary in Php";
            payslipTotalSalary.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (cellValuePayslipID != null || cellValuePayslipDetailID != null)
            {
                ViewPayslipForm viewPayslipForm = new ViewPayslipForm();
                viewPayslipForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a row first");
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void UpdateView()
        {
            if (cbView.SelectedIndex == 0)
            {
                lbRange.Visible = false;
                cbViewPayslips.Visible = false;
                ShowOwnPayslip();
                dgvPayslip.Columns["fullname"].Visible = false;
            }
            else
            {
                lbRange.Visible = true;
                cbViewPayslips.Visible = true;
                ShowPayslip();
                cbViewPayslips.SelectedIndex = 0;
                dgvPayslip.Columns["fullname"].Visible = true;
            }
        }

        private void dgvPayslip_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvPayslip.Columns[e.ColumnIndex].Name == "totalHours")
            {
                if (e.Value != null && e.Value is decimal)
                {
                    decimal decimalValue = (decimal)e.Value;
                    int hours = (int)decimalValue;
                    decimal minutesDecimal = (decimalValue - hours) * 60;
                    int minutes = (int)minutesDecimal;
                    int seconds = (int)((minutesDecimal - minutes) * 60);

                    e.Value = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvPayslip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvPayslip.Rows[e.RowIndex];
                cellValuePayslipID = selectedRow.Cells[2].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValuePayslipID) && int.TryParse(cellValuePayslipID, out int selectedPayslipID))
                {
                    UserDetails.SelectedPayslipID = selectedPayslipID;
                }
                else
                {
                    MessageBox.Show("Invalid or empty cell value.", "Error");
                }

                cellValuePayslipDetailID = selectedRow.Cells[5].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValuePayslipDetailID) && int.TryParse(cellValuePayslipDetailID, out int selectedPayslipDetailID))
                {
                    UserDetails.SelectedPayslipDetailID = selectedPayslipDetailID;
                }
                else
                {
                    MessageBox.Show("Invalid or empty cell value.", "Error");
                }
            }
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void ViewPayslips()
        {
            int selectedRow = cbViewPayslips.SelectedIndex;
            payslipID = dtPayslipRange.Rows[selectedRow][columnName: "payslipID"].ToString();

            ShowPayslip();
        }

        private void cbViewPayslips_SelectedValueChanged(object sender, EventArgs e)
        {
            ViewPayslips();
        }
    }
}
