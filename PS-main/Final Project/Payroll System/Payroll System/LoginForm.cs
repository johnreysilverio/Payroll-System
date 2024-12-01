using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class LoginForm : Form
    {
        DataTable? userDataTable = new();
        DataTable? dtServerCheck = new();
        DataTable? table = new();
        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        string? username;
        string? password;
        string? staffID;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void ServerCheck()
        {
            MySqlDataAdapter msdServerCheck = new();

            MySqlCommand mscServerCheck = new(dbQuery.CheckServerStatus(), dbConn.getConnection());

            msdServerCheck.SelectCommand = mscServerCheck;

            if (dtServerCheck != null)
            {
                msdServerCheck.Fill(dtServerCheck);
            }
        }
        private void CheckAccountIfExist()
        {
            username = UsernameTextBox.Text.ToString();
            password = PasswordTextBox.Text.ToString();

            MySqlDataAdapter adapter = new();

            MySqlCommand command = new(dbQuery.LoginQuery(), dbConn.getConnection());

            command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            if (table != null)
            {
                adapter.Fill(table);
            }
        }
        private void GetUserDetails()
        {
            if (table != null)
            {
                staffID = table.Rows[0][columnName: "staffID"].ToString();
                MySqlDataAdapter mscAdapter = new();

                MySqlCommand mscUserDetail = new(dbQuery.UserDetailsQuery(), dbConn.getConnection());

                mscUserDetail.Parameters.Add("@p0", MySqlDbType.Double).Value = staffID;

                mscAdapter.SelectCommand = mscUserDetail;

                if (userDataTable != null)
                {
                    mscAdapter.Fill(userDataTable);
                    UserDetails.UserDetail = userDataTable;
                }
            }
        }
        private void GenerateEventLog()
        {
            if (username != null)
            {
                using (MySqlConnection connection = dbConn.getConnection())
                {
                    connection.Open();

                    using (MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), connection))
                    {
                        mscEventLog.Parameters.AddWithValue("@p0", $"{username.ToLower()} has logged in");
                        mscEventLog.Parameters.AddWithValue("@p1", staffID);
                        mscEventLog.Parameters.AddWithValue("@p2", 1);

                        mscEventLog.ExecuteNonQuery();
                    }
                }
            }
        }
        private void Login()
        {
            ServerCheck();

            if (dtServerCheck != null && dtServerCheck.Rows.Count > 0)
            {
                int status = (int)dtServerCheck.Rows[0][columnName: "status"];

                if (status != 0)
                {
                    CheckAccountIfExist();

                    int rowCheck = 0;

                    if (table != null && table.Rows.Count > rowCheck)
                    {
                        var isEnabled = table.Rows[rowCheck][columnName: "isEnabled"].ToString();

                        if (isEnabled == "1")
                        {
                            var isLoggedIn = table.Rows[rowCheck][columnName: "isLoggedIn"].ToString();
                            if (isLoggedIn != "1")
                            {
                                GetUserDetails();
                                LoginStatus();
                                GenerateEventLog();

                                MessageBox.Show("Succesfuly Logged In", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                new MenuForm().Show();
                            }
                            else
                            {
                                MessageBox.Show("Account is currently Logged In in other Device", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your Account is currently locked, please contact HR for assistance", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Server is currently down, please wait...", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (table != null && dtServerCheck != null)
            {
                table.Rows.Clear();
                dtServerCheck.Rows.Clear();
            }
        }

        private void LoginStatus()
        {
            if (userDataTable != null && userDataTable.Rows.Count > 0)
            {
                string? userID = userDataTable.Rows[0][columnName: "userID"]?.ToString();

                if (userID != null)
                {
                    using (MySqlConnection dbConnection = dbConn.getConnection())
                    {
                        dbConnection.Open();

                        using (MySqlCommand acommand = new MySqlCommand(dbQuery.LoginStatus(), dbConnection))
                        {
                            acommand.Parameters.AddWithValue("@p0", 1);
                            acommand.Parameters.AddWithValue("@p1", userID);

                            acommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text != "" && PasswordTextBox.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("Username and Password should not be empty", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            UsernameTextBox.Clear();
            PasswordTextBox.Clear();
            UsernameTextBox_Leave(sender, e);
            PasswordTextBox_Leave(sender, e);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void UsernameTextBox_Enter(object sender, EventArgs e)
        {
            UsernamePlaceHolderLabel.Hide();
            UsernameTextBox.SelectAll();
        }

        private void UsernameTextBox_Leave(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "")
            {
                UsernamePlaceHolderLabel.Show();
            }
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            PasswordPlaceHolderLabel.Hide();
            PasswordTextBox.SelectAll();
        }

        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "")
            {
                PasswordPlaceHolderLabel.Show();
            }
        }
        private void UsernamePlaceHolderLabel_Click(object sender, EventArgs e)
        {
            UsernameTextBox.Focus();
        }
        private void PasswordPlaceHolderLabel_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
        }
        private void HidePasswordIcon_Click(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = false;
            HidePasswordIcon.Hide();
            ShowPasswordIcon.Show();
        }

        private void ShowPasswordIcon_Click(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
            ShowPasswordIcon.Hide();
            HidePasswordIcon.Show();
        }

        private void LoginButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("If you forgot your password, please contact the HR or your Manager", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
