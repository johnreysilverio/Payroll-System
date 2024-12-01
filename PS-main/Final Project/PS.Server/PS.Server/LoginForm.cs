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

namespace PS.Server
{
    public partial class LoginForm : Form
    {
        DataTable? userDataTable = new();
        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        public LoginForm()
        {
            InitializeComponent();
        }
        private void Login()
        {
            string username = UsernameTextBox.Text.ToString();
            string password = PasswordTextBox.Text.ToString();
            DataTable? table = new();

            MySqlDataAdapter adapter = new();

            MySqlCommand command = new(dbQuery.LoginQuery(), dbConn.getConnection());

            command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            int rowCheck = 0;

            if (table.Rows.Count > rowCheck)
            {
                MessageBox.Show("Succesfuly Logged In", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new ServerForm().Show();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            table.Rows.Clear();
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
    }
}
