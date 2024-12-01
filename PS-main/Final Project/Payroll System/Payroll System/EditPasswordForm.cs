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
    public partial class EditPasswordForm : Form
    {

        DBConn dbConn = new();

        DBQuery dbQuery = new DBQuery();
        DataTable? retrievedTable = UserDetails.UserDetail;
        private string? oldPass;
        private string? userID;
        private string? username;
        public EditPasswordForm()
        {
            InitializeComponent();
            oldPass = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "password"]?.ToString() ?? string.Empty
                : string.Empty;
            username = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "username"]?.ToString() ?? string.Empty
                : string.Empty;
            userID = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "userID"]?.ToString() ?? string.Empty
                : string.Empty;
        }
        private void ChangePassword()
        {

            string staffID = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "staffID"]?.ToString() ?? string.Empty
                : string.Empty;
            string? txtNewPass = TxtNewPass.Text;
            using (MySqlConnection dbConnection = dbConn.getConnection())
            {
                dbConnection.Open();

                using (MySqlCommand acommand = new MySqlCommand(dbQuery.UpdateAccountPassword(), dbConnection))
                {
                    acommand.Parameters.Add("@p0", MySqlDbType.VarChar).Value = txtNewPass;
                    acommand.Parameters.Add("@p1", MySqlDbType.VarChar).Value = staffID;

                    int rowsAffected = acommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        if (retrievedTable != null && txtNewPass != null)
                        {
                            retrievedTable.Rows[0][columnName: "password"] = txtNewPass;
                        }
                        MessageBox.Show("Successfully changed Password", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TxtOldPass.Text = "";
                        TxtConfOldPass.Text = "";
                        TxtNewPass.Text = "";
                        TxtConfNewPass.Text = "";

                        if (retrievedTable != null)
                        {

                            oldPass = retrievedTable.Rows[0][columnName: "password"].ToString();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Failed to update the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtOldPass.Text) || string.IsNullOrWhiteSpace(TxtConfOldPass.Text))
            {
                MessageBox.Show("No Empty Fields Allowed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(TxtNewPass.Text) || string.IsNullOrWhiteSpace(TxtConfNewPass.Text))
            {
                MessageBox.Show("No Empty Fields Allowed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (oldPass != TxtOldPass.Text)
            {
                MessageBox.Show("Wrong Old Password", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TxtOldPass.Text != TxtConfOldPass.Text)
            {
                MessageBox.Show("Old Password Didn't Match", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TxtNewPass.Text != TxtConfNewPass.Text)
            {
                MessageBox.Show("New Password Didn't Match", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TxtNewPass.Text.Length < 8)
            {
                MessageBox.Show("New Password should be 8 - 16 characters", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TxtOldPass.Text == TxtNewPass.Text)
            {
                MessageBox.Show("Old and New password cannot be the same", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show("Are you sure you want to Change Password?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ChangePassword();
                if(username != null)
                {
                    using (MySqlConnection connection = dbConn.getConnection())
                    {
                        connection.Open();

                        using (MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), connection))
                        {
                            mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = $"{username.ToLower()} has changed password";
                            mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = userID;
                            mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;

                            mscEventLog.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void TxtNewPass_Enter(object sender, EventArgs e)
        {
            lbNewPass.Hide();
            TxtNewPass.SelectAll();
        }

        private void TxtNewPass_Leave(object sender, EventArgs e)
        {
            if (TxtNewPass.Text == "")
            {
                lbNewPass.Show();
            }
        }

        private void TxtConfNewPass_Enter(object sender, EventArgs e)
        {
            lbConfNewPass.Hide();
            TxtConfNewPass.SelectAll();
        }

        private void TxtConfNewPass_Leave(object sender, EventArgs e)
        {
            if (TxtConfNewPass.Text == "")
            {
                lbConfNewPass.Show();
            }
        }

        private void lbNewPass_Click(object sender, EventArgs e)
        {
            TxtNewPass.Focus();
        }

        private void lbConfNewPass_Click(object sender, EventArgs e)
        {
            TxtConfNewPass.Focus();
        }
    }
}
