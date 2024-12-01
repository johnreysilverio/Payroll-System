using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_System
{
    public partial class TicketsDTRView : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        DataTable? dtDTR = new();
        DataTable? dtDTRTicketInfo = new();
        DBConn dbConn = new();
        DBQuery dbQuery = new();
        int? selectedDTRTickedID = UserDetails.SelectedDTRTicketID;
        private bool formLoaded = false;
        private string dtrID;
        private string reporterUserID;
        private string sqlFormatDTRDate;
        private string status;
        private string dtrTicketID;
        private string username;
        private int userID;
        public TicketsDTRView()
        {
            InitializeComponent();
            formLoaded = true;
            GetSpecificDTR();
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtRemarks.ScrollBars = ScrollBars.Vertical;
            btnReslove.Enabled = false;
            btnReject.Enabled = false;

            string acclevel = retrievedTable.Rows[0][columnName: "accountLevel"].ToString();
            userID = Convert.ToInt32(retrievedTable.Rows[0]["userID"]);
            username = retrievedTable.Rows[0][columnName: "username"].ToString();
            if (acclevel == "1")
            {
                txtRemarks.ReadOnly = true;
                charCountLabel.Visible = false;
                checkClockin.Visible = false;
                checkClockout.Visible = false;
                btnReject.Visible = false;
                btnReslove.Visible = false;
                btnCancel.Text = "Close";
            }
        }
        private void GetSpecificDTR()
        {
            if (!formLoaded)
            {
                return;
            }
            dtDTRTicketInfo.Rows.Clear();
            MySqlDataAdapter? mscAdapter2 = new();

            MySqlCommand? mscGetInfo;
            mscGetInfo = new(dbQuery.GetDTRFromDTRTickets(), dbConn.getConnection());
            mscGetInfo.Parameters.AddWithValue("@p0", selectedDTRTickedID);
            mscAdapter2.SelectCommand = mscGetInfo;
            mscAdapter2.Fill(dtDTRTicketInfo);

            FillDTRTicketInfo();
        }

        private void FillDTRTicketInfo()
        {
            dtrID = dtDTRTicketInfo.Rows[0][columnName: "dtrID"].ToString();
            reporterUserID = dtDTRTicketInfo.Rows[0][columnName: "userID"].ToString();
            DateTime clockinTime = dtDTRTicketInfo.Rows[0]["clockintime"] != DBNull.Value
                ? (DateTime)dtDTRTicketInfo.Rows[0]["clockintime"]
                : DateTime.MinValue;
            DateTime clockoutTime = dtDTRTicketInfo.Rows[0]["clockouttime"] != DBNull.Value
                ? (DateTime)dtDTRTicketInfo.Rows[0]["clockouttime"]
                : DateTime.MinValue;
            DateTime dtrDate = (DateTime)dtDTRTicketInfo.Rows[0][columnName: "dtrDate"];
            dtrTicketID = dtDTRTicketInfo.Rows[0][columnName: "dtrTicketID"].ToString();
            string resolverName = dtDTRTicketInfo.Rows[0][columnName: "resolverName"].ToString();
            string dtrTicketDescription = dtDTRTicketInfo.Rows[0][columnName: "dtrTicketDescription"].ToString();
            string dtrTicketRemarks = dtDTRTicketInfo.Rows[0][columnName: "dtrTicketRemarks"].ToString();
            int dtrTicketStatus = (int)dtDTRTicketInfo.Rows[0][columnName: "dtrTicketStatus"];
            DateTime dtrTicketDateRecieved = (DateTime)dtDTRTicketInfo.Rows[0][columnName: "dtrTicketDateRecieved"];
            DateTime dtrTicketDateResolved = dtDTRTicketInfo.Rows[0]["dtrTicketDateResolved"] != DBNull.Value
                ? (DateTime)dtDTRTicketInfo.Rows[0]["dtrTicketDateResolved"]
                : DateTime.MinValue;
            string formattedDTRDate = dtrDate.ToString("MM, dd, yyyy");
            sqlFormatDTRDate = dtrDate.ToString("yyyy/MM/dd");
            string formattedClockinTime = clockinTime != DateTime.MinValue
                ? clockinTime.ToString("hh:mm:ss tt")
                : string.Empty;
            string formattedClockoutTime = clockoutTime != DateTime.MinValue
                ? clockoutTime.ToString("hh:mm:ss tt")
                : string.Empty;
            string formattedDTRDateRecieved = dtrTicketDateRecieved.ToString("MM, dd, yyyy");
            string formattedDTRDateResolved = (dtrTicketDateResolved != DateTime.MinValue)
                ? dtrTicketDateResolved.ToString("MM, dd, yyyy")
                : string.Empty;

            string statusString = "";

            switch (dtrTicketStatus)
            {
                case 0:
                    statusString = "Unresolved";
                    break;
                case 1:
                    statusString = "Resolved";
                    break;
                case 2:
                    statusString = "Rejected";
                    break;
                default:
                    statusString = "Unknown";
                    break;
            }

            lbTicketID.Text = dtrTicketID;
            lbResolverFirstName.Text = resolverName;
            lbDateRecieved.Text = formattedDTRDateRecieved;
            lbDateResolved.Text = formattedDTRDateResolved;
            lbStatus.Text = statusString;
            lbReporterUserID.Text = reporterUserID;
            lbDTRID.Text = dtrID;
            lbDTRDate.Text = formattedDTRDate;
            lbClockin.Text = formattedClockinTime;
            lbClockout.Text = formattedClockoutTime;
            txtDescription.Text = dtrTicketDescription;
            txtRemarks.Text = dtrTicketRemarks;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            int maxLength = 255;
            int remainingChars = maxLength - txtRemarks.Text.Length;

            if (txtRemarks.Text != "")
            {
                btnReslove.Enabled = true;
                btnReject.Enabled = true;
            }
            else
            {
                btnReslove.Enabled = false;
                btnReject.Enabled = false;
            }

            if (remainingChars < 0)
            {
                txtRemarks.Text = txtRemarks.Text.Substring(0, maxLength);
                remainingChars = 0;
            }

            charCountLabel.Text = "Characters Left: " + remainingChars;
        }
        private void ResetDTRClockIn()
        {
            using (MySqlConnection dbConnection = dbConn.getConnection())
            {
                dbConnection.Open();

                using (MySqlCommand acommand = new MySqlCommand(dbQuery.ResetDTRClockIn(), dbConnection))
                {
                    acommand.Parameters.AddWithValue("@p0", dtrID);

                    int rowsAffected = acommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ResetDTRClockOut()
        {
            using (MySqlConnection dbConnection = dbConn.getConnection())
            {
                dbConnection.Open();

                using (MySqlCommand acommand = new MySqlCommand(dbQuery.ResetDTRClockOut(), dbConnection))
                {
                    acommand.Parameters.AddWithValue("@p0", dtrID);

                    int rowsAffected = acommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void FillPayrollDetail()
        {
            try
            {
                dbConn.openConnection();
                MySqlCommand mscGeneratePayslipDet = new MySqlCommand(dbQuery.FillPayrollDetail(), dbConn.getConnection());
                mscGeneratePayslipDet.Parameters.Clear();
                mscGeneratePayslipDet.Parameters.AddWithValue("@p0", reporterUserID);
                mscGeneratePayslipDet.Parameters.AddWithValue("@p1", sqlFormatDTRDate);

                int rowsAffected = mscGeneratePayslipDet.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                dbConn.closeConnection();
            }
        }
        private void UpdateDTRTickets()
        {
            string firstName = retrievedTable.Rows[0][columnName: "firstName"].ToString();
            try
            {
                dbConn.openConnection();
                MySqlCommand mscGeneratePayslipDet = new MySqlCommand(dbQuery.UpdateDTRTickets(), dbConn.getConnection());
                mscGeneratePayslipDet.Parameters.Clear();
                mscGeneratePayslipDet.Parameters.AddWithValue("@p0", firstName);
                mscGeneratePayslipDet.Parameters.AddWithValue("@p1", txtRemarks.Text);
                mscGeneratePayslipDet.Parameters.AddWithValue("@p2", status);
                mscGeneratePayslipDet.Parameters.AddWithValue("@p3", dtrTicketID);

                int rowsAffected = mscGeneratePayslipDet.ExecuteNonQuery();
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

        private void btnReslove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Resolve Ticket?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                status = "2";
                UpdateDTRTickets();
                if (checkClockin.Checked == true)
                {
                    ResetDTRClockIn();
                }
                if (checkClockout.Checked == true)
                {
                    ResetDTRClockOut();
                }
                FillPayrollDetail();
                dbConn.openConnection();
                MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
                mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = username.ToLower() + " has resolved a ticket number " + dtrTicketID;
                mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = userID;
                mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                mscEventLog.ExecuteNonQuery();
                dbConn.closeConnection();
                this.Close();
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Reject Ticket?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                status = "3";
                UpdateDTRTickets();
                dbConn.openConnection();
                MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
                mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = username.ToLower() + " has rejected ticket number " + dtrTicketID;
                mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = userID;
                mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                mscEventLog.ExecuteNonQuery();
                dbConn.closeConnection();
                this.Close();
            }
        }
    }
}
