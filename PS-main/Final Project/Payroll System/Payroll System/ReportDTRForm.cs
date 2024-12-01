using Google.Protobuf.Collections;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_System
{
    public partial class ReportDTRForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        DataTable? dtDTR = new();
        DataTable? dtDTRInfo = new();
        DBConn dbConn = new();
        DBQuery dbQuery = new();
        int? selectedDTRID = UserDetails.SelectedDTRID;
        private bool formLoaded = false;
        private int userID;
        private string username;
        public ReportDTRForm()
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Vertical;
            formLoaded = true;
            GetSpecificDTR();
            btnSend.Enabled = false;
            userID = Convert.ToInt32(retrievedTable.Rows[0]["userID"]);
            username = retrievedTable.Rows[0][columnName: "username"].ToString();
        }
        private void GetSpecificDTR()
        {
            if (!formLoaded)
            {
                return;
            }
            dtDTRInfo.Rows.Clear();
            MySqlDataAdapter? mscAdapter2 = new();

            MySqlCommand? mscGetInfo;
            mscGetInfo = new(dbQuery.GetSpecificDTR(), dbConn.getConnection());
            mscGetInfo.Parameters.AddWithValue("@p0", selectedDTRID);
            mscAdapter2.SelectCommand = mscGetInfo;
            mscAdapter2.Fill(dtDTRInfo);

            FillDTRInfo();
        }

        private void FillDTRInfo()
        {
            string dtrID = dtDTRInfo.Rows[0][columnName: "dtrID"].ToString();
            DateTime dtrDate = (DateTime)dtDTRInfo.Rows[0][columnName: "dtrDate"];

            string formattedDTRDate = dtrDate.ToString("MMM dd, yyyy");

            lbDTRId.Text = dtrID;
            lbDTRDate.Text = formattedDTRDate;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int maxLength = 255;
            int remainingChars = maxLength - textBox1.Text.Length;

            if (textBox1.Text != "")
            {
                btnSend.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
            }

            if (remainingChars < 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, maxLength);
                remainingChars = 0;
            }

            charCountLabel.Text = "Characters Left: " + remainingChars;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Submit a Ticket?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DTRTicketSend();
                dbConn.openConnection();
                MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
                mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = username.ToLower() + " has submitted a ticket";
                mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = userID;
                mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                mscEventLog.ExecuteNonQuery();
                dbConn.closeConnection();
                this.Close();
            }
        }
        private void DTRTicketSend()
        {

            string staffID = retrievedTable.Rows[0][columnName: "staffID"].ToString();
            string dtrID = dtDTRInfo.Rows[0][columnName: "dtrID"].ToString();
            string description = textBox1.Text;

            using (MySqlConnection dbConnection = dbConn.getConnection())
            {
                dbConnection.Open();

                using (MySqlCommand acommand = new MySqlCommand(dbQuery.GenerateDTRTicket(), dbConnection))
                {
                    acommand.Parameters.AddWithValue("@p0", dtrID);
                    acommand.Parameters.AddWithValue("@p1", staffID);
                    acommand.Parameters.AddWithValue("@p2", description);

                    int rowsAffected = acommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Ticket Submitted.", "DTR Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ticket Submittion Failed.", "DTR Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
