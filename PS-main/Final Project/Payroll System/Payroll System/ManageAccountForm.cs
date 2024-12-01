using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_System
{
    public partial class ManageAccountForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        int? selectedStaffID = UserDetails.SelectedStaffID;
        DataTable? allAccDet = new DataTable();
        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        private string cellValue;
        private int userID;
        private string username;
        private string cellUsername;

        public ManageAccountForm()
        {
            InitializeComponent();
            ShowAccounts();
            userID = Convert.ToInt32(retrievedTable.Rows[0]["userID"]);
            username = retrievedTable.Rows[0][columnName: "username"].ToString();
        }

        private void ShowAccounts()
        {
            allAccDet.Rows.Clear();

            string search = txtBoxSearch.Text;
            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.GetUserAcc(), dbConn.getConnection());
            mscSearchAcc.Parameters.Add("@p0", MySqlDbType.VarChar).Value = search;
            mscAdapter.SelectCommand = mscSearchAcc;
            mscAdapter.Fill(allAccDet);
            FillDGV();
        }
        private void FillDGV()
        {
            userDatasGrid.DataSource = allAccDet;
            var dgvStaffIDColum = userDatasGrid.Columns["Staff_ID"];
            dgvStaffIDColum.HeaderText = "Staff ID";
            dgvStaffIDColum.Width = 75;
            userDatasGrid.Columns["Locked"].Width = 75;
            userDatasGrid.Columns["Username"].Width = 400;
            userDatasGrid.Columns["Firstname"].Width = 150;
            userDatasGrid.Columns["Lastname"].Width = 150;
            userDatasGrid.Columns["Position"].Width = 150;
            var dgvStationNoColum = userDatasGrid.Columns["Station_No"];
            dgvStationNoColum.HeaderText = "Station No";
            dgvStationNoColum.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ShowAccounts();
        }

        private void userDatasGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = userDatasGrid.Rows[e.RowIndex];
                cellValue = selectedRow.Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValue) && int.TryParse(cellValue, out int selectedStaffID))
                {
                    UserDetails.SelectedStaffID = selectedStaffID;
                }
                else
                {
                    MessageBox.Show("Invalid or empty cell value.", "Error");
                }

                cellUsername = selectedRow.Cells[3].Value?.ToString();

                if (string.IsNullOrEmpty(cellUsername))
                {
                    MessageBox.Show("Invalid or empty cell value.", "Error");
                }
            }
        }
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (cellValue != null)
            {
                ManageAccountEditForm manageAccountEditForm = new ManageAccountEditForm();
                manageAccountEditForm.Success += Success;
                manageAccountEditForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a row first");
            }
        }
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            AccountRegisterForm accountRegisterForm = new AccountRegisterForm();
            accountRegisterForm.Success += Success;
            accountRegisterForm.ShowDialog();
        }
        private void Success(object sender, EventArgs e)
        {
            ShowAccounts();
        }

        private void userDatasGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string targetColumnName = "Locked";

                if (userDatasGrid.Columns[e.ColumnIndex].Name == targetColumnName)
                {
                    if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue) && cellValue == 0)
                    {
                        e.Value = "Yes";
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        e.Value = "No";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Text = "";
            searchPlaceholder.Show();
        }

        private void txtBoxSearch_Enter(object sender, EventArgs e)
        {
            searchPlaceholder.Hide();
            txtBoxSearch.SelectAll();
        }

        private void txtBoxSearch_Leave(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == "")
            {
                searchPlaceholder.Show();
            }
        }

        private void searchPlaceholder_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete the Account?\nOnce deleted, it can no longer be restored", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (MessageBox.Show("Are you really sure you want to Delete the Account?\nOnce deleted, it can no longer be restored", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    if (cellValue != null)
                    {
                        using (MySqlConnection connection = dbConn.getConnection())
                        {
                            connection.Open();

                            using (MySqlCommand mscDeleteUser = new MySqlCommand(dbQuery.DeleteUser(), connection))
                            {
                                mscDeleteUser.Parameters.Add("@p0", MySqlDbType.Int32).Value = cellValue;
                                mscDeleteUser.ExecuteNonQuery();
                            }
                            using (MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), connection))
                            {
                                mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = $"{username.ToLower()} has deleted {cellUsername}";
                                mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = userID;
                                mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;

                                mscEventLog.ExecuteNonQuery();
                            }

                        }

                        ShowAccounts();
                    }
                    else
                    {
                        MessageBox.Show("Select a row first");
                    }
                }
            }
        }

        private void btnDeduction_Click(object sender, EventArgs e)
        {
            InsuraceForm insuraceFrom = new InsuraceForm();
            insuraceFrom.ShowDialog();
        }
    }
}
