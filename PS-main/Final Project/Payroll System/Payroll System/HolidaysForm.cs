using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_System
{
    public partial class HolidaysForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        DataTable? dtDate = new DataTable();
        DataTable? dtUserID = new();
        DateTime date;
        private bool formLoaded = false;
        private string cellValue;
        private bool updateDTRHolidayIsSuccessful = false;
        private bool showDatesIsSuccessful = false;
        private bool getAllUserIDIsSuccessful = false;
        private bool fillPayrollDetailIsSuccessful = false;
        private string sqlFormattedDate;
        private string? userID;
        private string? username;
        public HolidaysForm()
        {
            InitializeComponent();
            formLoaded = true;
            ShowDates();
            foreach (DataGridViewColumn column in dgvDates.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            string acclevel = retrievedTable.Rows[0][columnName: "accountLevel"].ToString();
            if (acclevel == "1")
            {
                btnModify.Enabled = false;
                rb0.Enabled = false;
                rb1.Enabled = false;
                rb2.Enabled = false;
                rb3.Enabled = false;
            }
            username = retrievedTable != null && retrievedTable.Rows.Count > 0
               ? retrievedTable.Rows[0][columnName: "username"]?.ToString() ?? string.Empty
               : string.Empty;
            userID = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "userID"]?.ToString() ?? string.Empty
                : string.Empty;
        }

        private void ShowDates()
        {
            if (!formLoaded)
            {
                return;
            }
            dtDate.Rows.Clear();

            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.GetDates(), dbConn.getConnection());
            mscAdapter.SelectCommand = mscSearchAcc;
            mscAdapter.Fill(dtDate);
            FillDGV();
        }
        private void FillDGV()
        {
            dgvDates.DataSource = dtDate;

            var holidayColumn = dgvDates.Columns["holiday"];
            holidayColumn.HeaderText = "Number of Holidays";
            holidayColumn.Width = 300;

            var dtrDateColumn = dgvDates.Columns["dtrDate"];
            dtrDateColumn.DefaultCellStyle.Format = "MMM/dd/yyyy , dddd";
            dtrDateColumn.HeaderText = "Date";
            dtrDateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDates.RowPrePaint += dgvDates_RowPrePaint;
            showDatesIsSuccessful = true;
        }

        private void UpdateDTRHoliday()
        {
            int selectedValue = 0;

            if (rb0.Checked)
            {
                selectedValue = 0;
            }
            else if (rb1.Checked)
            {
                selectedValue = 1;
            }
            else if (rb2.Checked)
            {
                selectedValue = 2;
            }
            else if (rb3.Checked)
            {
                selectedValue = 3;
            }
            using (MySqlConnection dbConnection = dbConn.getConnection())
            {
                dbConnection.Open();

                using (MySqlCommand acommand = new MySqlCommand(dbQuery.UpdateDTRHoliday(), dbConnection))
                {
                    acommand.Parameters.AddWithValue("@p0", selectedValue);
                    acommand.Parameters.AddWithValue("@p1", sqlFormattedDate);

                    int rowsAffected = acommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        updateDTRHolidayIsSuccessful = true;
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (cellValue != null)
            {
                if (MessageBox.Show("Are you sure you want to Update the Holiday?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    UpdateDTRHoliday();
                    if (updateDTRHolidayIsSuccessful == true)
                    {
                        GetAllUserID();
                        if (getAllUserIDIsSuccessful == true)
                        {
                            FillPayrollDetail();
                            if (fillPayrollDetailIsSuccessful == true)
                            {
                                ShowDates();
                                if (username != null)
                                {
                                    dbConn.openConnection();
                                    MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
                                    mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = username.ToLower() + " has changed password";
                                    mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = userID;
                                    mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                                    mscEventLog.ExecuteNonQuery();
                                    dbConn.closeConnection();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Fill Payroll Detail Failed");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Get all userID Failed");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Update DTR Holiday Failed");
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a row first");
            }
        }
        private void GetAllUserID()
        {
            dtUserID.Rows.Clear();

            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.GetAllUserID(), dbConn.getConnection());
            mscAdapter.SelectCommand = mscSearchAcc;
            mscAdapter.Fill(dtUserID);

            getAllUserIDIsSuccessful = true;
        }
        private void FillPayrollDetail()
        {
            string formattedDate = date.ToString("yyyy/MM/dd");
            try
            {
                dbConn.openConnection();

                foreach (DataRow row in dtUserID.Rows)
                {
                    int userID = Convert.ToInt32(row["userID"]);
                    MySqlCommand mscGeneratePayslipDet = new MySqlCommand(dbQuery.FillPayrollDetail(), dbConn.getConnection());
                    mscGeneratePayslipDet.Parameters.Clear();
                    mscGeneratePayslipDet.Parameters.AddWithValue("@p0", userID);
                    mscGeneratePayslipDet.Parameters.AddWithValue("@p1", formattedDate);

                    int rowsAffected = mscGeneratePayslipDet.ExecuteNonQuery();

                    fillPayrollDetailIsSuccessful = true;
                }
            }
            catch (MySqlException ex)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                dbConn.closeConnection();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowDates();
        }

        private void dgvDates_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDates.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDates.SelectedRows[0];
                cellValue = selectedRow.Cells[1].Value?.ToString();

                date = (DateTime)dgvDates.SelectedRows[0].Cells["dtrDate"].Value;
                string formattedDate = date.ToString("MMM/dd/yyyy, dddd");
                sqlFormattedDate = date.ToString("yyyy/MM/dd");
                textBox1.Text = $"{formattedDate}";
                int radioButtonValue = Convert.ToInt32(dgvDates.SelectedRows[0].Cells["holiday"].Value);

                switch (radioButtonValue)
                {
                    case 0:
                        rb0.Checked = true;
                        break;
                    case 1:
                        rb1.Checked = true;
                        break;
                    case 2:
                        rb2.Checked = true;
                        break;
                    case 3:
                        rb3.Checked = true;
                        break;
                }
            }
        }

        private void dgvDates_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDates.Rows[e.RowIndex];
                if (row.Cells["dtrDate"].Value != null && row.Cells["dtrDate"].Value is DateTime date)
                {
                    if (date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = dgvDates.DefaultCellStyle.BackColor;
                    }
                }
            }
        }
    }
}
