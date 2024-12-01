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
    public partial class InsuraceForm : Form
    {
        DBConn dbConn = new();
        DBQuery dbQuery = new();
        DataTable dtInsurance = new();
        DataTable? retrievedTable = UserDetails.UserDetail;
        decimal sss;
        decimal pagibig;
        decimal philhealth;
        private int userID;
        private string username;
        public InsuraceForm()
        {
            InitializeComponent();
            GetStaffInsurance();
            userID = Convert.ToInt32(retrievedTable.Rows[0]["userID"]);
            username = retrievedTable.Rows[0][columnName: "username"].ToString();
        }

        private void GetStaffInsurance()
        {
            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.GetStaffInsurance(), dbConn.getConnection());
            mscAdapter.SelectCommand = mscSearchAcc;
            mscAdapter.Fill(dtInsurance);

            sss = (decimal)dtInsurance.Rows[0][columnName: "SSS"];
            pagibig = (decimal)dtInsurance.Rows[0][columnName: "PagIbig"];
            philhealth = (decimal)dtInsurance.Rows[0][columnName: "PhilHealth"];

            numericUpDown1.Value = sss;
            textBox1.Text = pagibig.ToString();
            textBox2.Text = philhealth.ToString();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' &&
                sender is System.Windows.Forms.TextBox textBox &&
                textBox.Text != null &&
                textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if ((textBox1.Text.IndexOf('.') > -1) && (textBox1.Text.Substring(textBox1.Text.IndexOf('.') + 1).Length >= 2) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' &&
                sender is System.Windows.Forms.TextBox textBox &&
                textBox.Text != null &&
                textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if ((textBox2.Text.IndexOf('.') > -1) && (textBox2.Text.Substring(textBox2.Text.IndexOf('.') + 1).Length >= 2) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            UpdateStaffInsurance();
        }
        private void UpdateStaffInsurance()
        {
            if (MessageBox.Show("Are you sure you want to Update Insurance Deduction?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (MySqlConnection connection = dbConn.getConnection())
                {
                    connection.Open();

                    using (MySqlCommand mscEventLog = new MySqlCommand(dbQuery.UpdateStaffInsurance(), connection))
                    {
                        mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = numericUpDown1.Value;
                        mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = textBox1.Text;
                        mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = textBox2.Text;

                        mscEventLog.ExecuteNonQuery();
                    }
                    using (MySqlCommand eventLogCommand = new MySqlCommand(dbQuery.EventLog(), connection))
                    {

                        string logMessage = ($"{username.ToLower()} has updated Insurance Deductions:");

                        if (sss != numericUpDown1.Value)
                        {
                            logMessage += ($" SSS from {sss.ToString()}% to {numericUpDown1.Value}%");
                        }

                        if (pagibig != Convert.ToDecimal(textBox1.Text))
                        {
                            logMessage += ($" Pag-Ibig from Php {pagibig} to Php {textBox1.Text}");
                        }

                        if (philhealth != Convert.ToDecimal(textBox2.Text))
                        {
                            logMessage += ($" Philhealth from Php {philhealth} to Php {textBox2.Text}");
                        }
                        
                        eventLogCommand.Parameters.Add("@p0", MySqlDbType.VarChar).Value = logMessage;
                        eventLogCommand.Parameters.Add("@p1", MySqlDbType.VarChar).Value = userID;
                        eventLogCommand.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;

                        
                        eventLogCommand.ExecuteNonQuery();
                    }
                    connection.Clone();
                    this.Close();
                }
            }
        }
    }
}
