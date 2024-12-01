using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_System
{
    public partial class HomeForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        DateTime currentTime = DateTime.Now;
        private int userID;
        private string? username;
        public HomeForm()
        {
            InitializeComponent();
            if (retrievedTable != null && retrievedTable.Rows.Count > 0)
            {
                userID = Convert.ToInt32(retrievedTable.Rows[0]["userID"]);
                username = retrievedTable.Rows[0][columnName: "username"].ToString();
            }
            SetHomeForm();
        }

        private void SetHomeForm()
        {
            string? clockedIn = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "clockedIn"]?.ToString()
                : null;
            string? clockedOut = retrievedTable != null && retrievedTable.Rows.Count > 0
                ? retrievedTable.Rows[0][columnName: "clockedOut"]?.ToString()
                : null;

            DateTime clockIn = DateTime.Today.AddHours(6);
            DateTime clockOut = DateTime.Today.AddHours(18);


            if (clockIn < currentTime && clockedIn == "0" || clockIn > currentTime)
            {
                ClockedOut();
            }
            else if (clockedIn == "0" && clockedOut == "0")
            {
                ClockDefault();
            }
            else
            {
                if (clockedIn == "1" && clockedOut == "0")
                {
                    ClockedIn();
                }
                else
                {
                    ClockedOut();
                }
            }
        }
        private void ClockDefault()
        {
            btnClockIn.BackColor = System.Drawing.Color.Lime;
            btnClockOut.BackColor = System.Drawing.Color.Gray;
            btnClockIn.Enabled = true;
            btnClockOut.Enabled = false;
        }
        private void ClockedIn()
        {
            btnClockIn.BackColor = System.Drawing.Color.Gray;
            btnClockOut.BackColor = System.Drawing.Color.Red;
            btnClockIn.Enabled = false;
            btnClockOut.Enabled = true;
        }
        private void ClockedOut()
        {
            btnClockIn.BackColor = System.Drawing.Color.Gray;
            btnClockOut.BackColor = System.Drawing.Color.Gray;
            btnClockIn.Enabled = false;
            btnClockOut.Enabled = false;
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            if (UserDetails.UserDetail != null && UserDetails.UserDetail.Rows.Count > 0)
            {

                UserDetails.UserDetail.Rows[0]["clockintime"] = DateTime.Now;
                UserDetails.UserDetail.Rows[0]["clockedIn"] = 1;
            }

            if (username != null)
            {
                dbConn.openConnection();

                MySqlCommand mscClockIn = new(dbQuery.ClockInOut(), dbConn.getConnection());
                mscClockIn.Parameters.Add("@p0", MySqlDbType.Int32).Value = userID;
                mscClockIn.Parameters.Add("@p1", MySqlDbType.DateTime).Value = DateTime.Now;
                mscClockIn.Parameters.Add("@p2", MySqlDbType.Int32).Value = 1;
                mscClockIn.Parameters.Add("@p3", MySqlDbType.DateTime).Value = null;
                mscClockIn.Parameters.Add("@p4", MySqlDbType.Int32).Value = 0;
                mscClockIn.ExecuteNonQuery();

                MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
                mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = username.ToLower() + " has clocked in";
                mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = userID;
                mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                mscEventLog.ExecuteNonQuery();


                dbConn.closeConnection();
            }
            ClockedIn();
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            if (username != null)
            {
                DateTime clockOutTime = DateTime.Today.AddHours(17);

                if (currentTime < clockOutTime)
                {
                    string currentTimeString = currentTime.ToString("h:mm tt");
                    string message = $"Are you sure you want to Clock Out? It's still {currentTimeString}";
                    DialogResult result = MessageBox.Show(message, "Clock Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ClockOut();
                        ClockedOut();
                    }
                }
                else
                {
                    ClockOut();
                    ClockedOut();
                }
                dbConn.openConnection();
                MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
                mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = username.ToLower() + " has clocked out";
                mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = userID;
                mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                mscEventLog.ExecuteNonQuery();
                dbConn.closeConnection();
            }

        }
        private void ClockOut()
        {
            if (UserDetails.UserDetail != null && UserDetails.UserDetail.Rows.Count > 0)
            {
                DateTime clockInTime = Convert.ToDateTime(UserDetails.UserDetail.Rows[0]["clockintime"]);
                UserDetails.UserDetail.Rows[0]["clockouttime"] = DateTime.Now;
                UserDetails.UserDetail.Rows[0]["clockedOut"] = 1;

                dbConn.openConnection();

                MySqlCommand mscClockOut = new(dbQuery.ClockInOut(), dbConn.getConnection());
                mscClockOut.Parameters.Add("@p0", MySqlDbType.Int32).Value = userID;
                mscClockOut.Parameters.Add("@p1", MySqlDbType.DateTime).Value = clockInTime;
                mscClockOut.Parameters.Add("@p2", MySqlDbType.Int32).Value = 1;
                mscClockOut.Parameters.Add("@p3", MySqlDbType.DateTime).Value = DateTime.Now;
                mscClockOut.Parameters.Add("@p4", MySqlDbType.Int32).Value = 1;
                mscClockOut.ExecuteNonQuery();

                dbConn.closeConnection();
            }
        }
    }
}
