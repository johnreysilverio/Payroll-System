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

namespace Payroll_System
{
    public partial class ViewPayslipForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        DataTable? dtDTR = new();
        DataTable? dtPayslipInfo = new();
        DBConn dbConn = new();
        DBQuery dbQuery = new();
        int? selectedPayslipDetailID = UserDetails.SelectedPayslipDetailID;
        int? selectedPayslipID = UserDetails.SelectedPayslipID;
        private bool formLoaded = false;
        public ViewPayslipForm()
        {
            InitializeComponent();
            formLoaded = true;
            ShowPayslipDTR();
            ShowPayslipInfo();
            foreach (DataGridViewColumn column in dgvDTR.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void ShowPayslipInfo()
        {
            if (!formLoaded)
            {
                return;
            }
            dtPayslipInfo.Rows.Clear();
            string userID = retrievedTable.Rows[0][columnName: "userID"].ToString();
            MySqlDataAdapter? mscAdapter2 = new();

            MySqlCommand? mscGetInfo;
            mscGetInfo = new(dbQuery.GetPayslipInfo(), dbConn.getConnection());
            mscGetInfo.Parameters.AddWithValue("@p0", selectedPayslipDetailID);
            mscAdapter2.SelectCommand = mscGetInfo;
            mscAdapter2.Fill(dtPayslipInfo);

            FillPayslipInfo();
        }

        private void FillPayslipInfo()
        {
            string userID = dtPayslipInfo.Rows[0][columnName: "userID"].ToString();
            string firstname = dtPayslipInfo.Rows[0][columnName: "firstName"].ToString();
            string lastname = dtPayslipInfo.Rows[0][columnName: "lastName"].ToString();
            string position = dtPayslipInfo.Rows[0][columnName: "position"].ToString();
            string salary = dtPayslipInfo.Rows[0][columnName: "salary"].ToString();
            string daily = dtPayslipInfo.Rows[0][columnName: "daily"].ToString();
            string hourly = dtPayslipInfo.Rows[0][columnName: "hourly"].ToString();
            string allowance = dtPayslipInfo.Rows[0][columnName: "allowance"].ToString();
            string stationNo = dtPayslipInfo.Rows[0][columnName: "stationNo"].ToString();
            string sss = dtPayslipInfo.Rows[0][columnName: "SSS"].ToString();
            string pagIbig = dtPayslipInfo.Rows[0][columnName: "PagIbig"].ToString();
            string philHealth = dtPayslipInfo.Rows[0][columnName: "PhilHealth"].ToString();
            DateTime startDate = (DateTime)dtPayslipInfo.Rows[0][columnName: "startDate"];
            DateTime endDate = (DateTime)dtPayslipInfo.Rows[0][columnName: "endDate"];
            string totalHours = dtPayslipInfo.Rows[0][columnName: "totalHours"].ToString();
            string totalEarnings = dtPayslipInfo.Rows[0][columnName: "totalEarnings"].ToString();
            string subtotal = dtPayslipInfo.Rows[0][columnName: "subtotal"].ToString();
            string sssDeduction = dtPayslipInfo.Rows[0][columnName: "SSSDeduction"].ToString();
            string totalDeduction = dtPayslipInfo.Rows[0][columnName: "deduction"].ToString();
            string totalSalary = dtPayslipInfo.Rows[0][columnName: "totalSalary"].ToString();

            string formattedStartDate = startDate.ToString("MMM dd, yyyy");
            string formattedEndDate = endDate.ToString("MMM dd, yyyy");

            txtID.Text = userID;
            txtFullname.Text = firstname + " " + lastname;
            txtWorkPlace.Text = "Mart's Minimart";
            txtPosition.Text = position;
            txtEmploymentStage.Text = "Regular";
            txtPayrollPeriod.Text = formattedStartDate + " - " + formattedEndDate;
            txtPayFrequency.Text = "Weekly";
            txtPaymentType.Text = "Weekly Rated";
            txtWeeklyRate.Text = salary;
            txtDailyRate.Text = daily;
            txtHourlyRate.Text = hourly;

            lbDTRPay.Text = subtotal;
            lbAllowance.Text = allowance;
            lbTotalEarnings.Text = totalEarnings;
            lbSSS.Text = sssDeduction;
            lbPhilHealth.Text = philHealth;
            lbPagIbig.Text = pagIbig;
            lbTotalDeduction.Text = totalDeduction;
            lbTotalEarnings2.Text = totalEarnings;
            lbTotalDeduction2.Text = totalDeduction;
            lbNetPay.Text = totalSalary;

        }

        private void ShowPayslipDTR()
        {
            if (!formLoaded)
            {
                return;
            }
            dtDTR.Rows.Clear();

            string userID = retrievedTable.Rows[0][columnName: "userID"].ToString();
            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscGetDTR;
            mscGetDTR = new(dbQuery.GetPayslipDTR(), dbConn.getConnection());
            mscGetDTR.Parameters.AddWithValue("@p0", userID);
            mscGetDTR.Parameters.AddWithValue("@p1", selectedPayslipID);
            mscAdapter.SelectCommand = mscGetDTR;
            mscAdapter.Fill(dtDTR);

            FilldgvDTR();
        }

        private void FilldgvDTR()
        {
            dgvDTR.DataSource = dtDTR;

            var dtrDateColumn = dgvDTR.Columns["dtrDate"];
            dtrDateColumn.DefaultCellStyle.Format = "MM/dd/yyyy , dddd";
            dtrDateColumn.HeaderText = "Date";
            dtrDateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var dtrClockInColumn = dgvDTR.Columns["totalHour"];
            dtrClockInColumn.HeaderText = "Php";
            dtrClockInColumn.Width = 127;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDTR_SelectionChanged(object sender, EventArgs e)
        {
            dgvDTR.CurrentCell = null;
            this.dgvDTR.ClearSelection();
        }
    }
}
