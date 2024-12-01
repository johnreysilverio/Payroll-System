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
    public partial class AccountDetailsShowForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        public AccountDetailsShowForm()
        {
            InitializeComponent();
            ShowDetails();
        }

        private void ShowDetails()
        {
            string username = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "username"]?.ToString() ?? string.Empty
                : string.Empty;
            string firstName = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "firstName"]?.ToString() ?? string.Empty
                : string.Empty;
            string lastName = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "lastName"]?.ToString() ?? string.Empty
                : string.Empty;

            string sex = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "sex"]?.ToString() ?? string.Empty
                : string.Empty;

            string staffID = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "staffID"]?.ToString() ?? string.Empty
                : string.Empty;
            DateTime? dOB = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "DOB"] as DateTime?
                : null;
            string formattedDate = dOB?.ToString("MM/dd/yyyy") ?? string.Empty;

            string userID = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "userID"]?.ToString() ?? string.Empty
                : string.Empty;

            string stationNum = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "stationNo"]?.ToString() ?? string.Empty
                : string.Empty;

            string salary = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "salary"]?.ToString() ?? string.Empty
                : string.Empty;

            string allowance = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "allowance"]?.ToString() ?? string.Empty
                : string.Empty;

            string sss = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "SSS"]?.ToString() ?? string.Empty
                : string.Empty;

            string pagibig = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "PagIbig"]?.ToString() ?? string.Empty
                : string.Empty;

            string philhealth = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "PhilHealth"]?.ToString() ?? string.Empty
                : string.Empty;
            txtFullname.Text = firstName + " " + lastName;
            txtUsername.Text = username;
            txtGender.Text = sex;
            txtDOB.Text = formattedDate;
            txtStaffID.Text = staffID;
            txtUserID.Text = userID;
            txtStation.Text = stationNum;
            txtSalary.Text = salary;
            txtAllowance.Text = allowance;
            txtSSS.Text = sss;
            txtPagIbig.Text = pagibig;
            txtPhilHealth.Text = philhealth;
        }
    }
}
