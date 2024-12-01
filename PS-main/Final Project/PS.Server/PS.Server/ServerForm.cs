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
    public partial class ServerForm : Form
    {
        private readonly DBConn dbConn = new DBConn();
        private readonly DBQuery dbQuery = new DBQuery();
        private readonly DataTable dtServerStatus = new DataTable();
        private readonly DataTable dtEventLogs = new DataTable();
        private readonly System.Timers.Timer serverTimer = new System.Timers.Timer(10000);
        private readonly System.Timers.Timer loadingTimer = new System.Timers.Timer(10000);
        private int storedTotalLog = 0;
        private int newTotalLog = 1;
        private bool isServerTerminated = false;
        private bool formLoaded = false;
        public ServerForm()
        {
            InitializeComponent();
            this.Load += ServerForm_Load;
            InitializeTimers();

            MySqlDataAdapter? mscAdapter = new();
            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.CheckServerStatus(), dbConn.getConnection());
            mscAdapter.SelectCommand = mscSearchAcc;
            mscAdapter.Fill(dtServerStatus);
        }
        private void InitializeTimers()
        {
            serverTimer.Elapsed += ServerTimerElapsed;
            serverTimer.AutoReset = true;

            loadingTimer.Elapsed += LoadingTimerElapsed;
            loadingTimer.Start();
        }
        private void ServerForm_Load(object? sender, EventArgs e)
        {
            formLoaded = true;
            GetTotalNumberOfLogs();
        }
        private void ServerTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            PayslipGenerator();
            GetTotalNumberOfLogs();
            if (newTotalLog > storedTotalLog)
            {
                EventLog();
                storedTotalLog = newTotalLog;
            }
        }
        private void LoadingTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (dtServerStatus != null)
            {
                int serverStatus = (int)dtServerStatus.Rows[0][columnName: "status"];
                this.Invoke(new Action(() => UpdateServerStatus(serverStatus)));

                PayslipGenerator();
                GetTotalNumberOfLogs();

                if (newTotalLog > storedTotalLog)
                {
                    EventLog();
                    storedTotalLog = newTotalLog;
                }
                serverTimer.Start();
                loadingTimer.Stop();
            }            
        }

        private void UpdateServerStatus(int serverStatus)
        {
            if (serverStatus == 1)
            {
                ServerStarted();
            }
            else
            {
                ServerTerminated();
            }
        }

        private void PayslipGenerator()
        {
            using (MySqlConnection connection = dbConn.getConnection())
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (MySqlCommand mscPayslipGenerator = new MySqlCommand(dbQuery.PayslipGenerator(), connection))
                    {
                        mscPayslipGenerator.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    LogException(ex, connection);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void LogEvent(string log, MySqlConnection connection)
        {
            int retryCount = 3;
            int currentRetry = 0;
            while (currentRetry < retryCount)
            {
                try
                {
                    using (MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), connection))
                    {
                        mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = log;
                        mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = 0;
                        mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                        mscEventLog.ExecuteNonQuery();
                    }
                    break;
                }
                catch (Exception ex)
                {
                    LogException(ex, connection);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        private void LogException(Exception ex, MySqlConnection connection)
        {
            int retryCount = 3;
            int currentRetry = 0;
            while (currentRetry < retryCount)
            {
                try
                {
                    using (MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), connection))
                    {
                        mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = ex.ToString();
                        mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = 0;
                        mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                        mscEventLog.ExecuteNonQuery();
                    }
                    break;
                }
                catch (Exception exd)
                {
                    LogException(exd, connection);
                }
                finally
                {
                    connection.Close();
                    currentRetry++;
                    Thread.Sleep(1000);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Run the Server?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                serverTimer.Stop();

                StartServer();
                ServerStarted();
                GetTotalNumberOfLogs();
                storedTotalLog = newTotalLog;
                ScrollToBottom();

                serverTimer.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Terminate the Server?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                serverTimer.Stop();

                TerminateServer();
                ServerTerminated();
                GetTotalNumberOfLogs();
                storedTotalLog = newTotalLog;
                ScrollToBottom();

                serverTimer.Start();
            }
        }
        private void StartServer()
        {
            using (MySqlConnection connection = dbConn.getConnection())
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (MySqlCommand mscChangeServerStats = new MySqlCommand(dbQuery.ChangeServerStatus(), connection))
                {
                    mscChangeServerStats.Parameters.Add("@p0", MySqlDbType.Int32).Value = 1;
                    mscChangeServerStats.ExecuteNonQuery();
                }

                string log = "Server Started";
                LogEvent(log, connection);

                connection.Close();
            }
            EventLog();
        }
        private void ServerStarted()
        {
            txtStatus.ForeColor = System.Drawing.Color.Lime;
            btnStart.BackColor = System.Drawing.Color.Gray;
            btnStop.BackColor = System.Drawing.Color.Red;
            btnExit.BackColor = System.Drawing.Color.Gray;
            btnLogoffAll.BackColor = System.Drawing.Color.Red;
            txtStatus.Text = "RUNNING";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnExit.Enabled = false;
            btnLogoffAll.Enabled = true;
        }
        private void TerminateServer()
        {
            using (MySqlConnection connection = dbConn.getConnection())
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (MySqlCommand mscChangeServerStats = new MySqlCommand(dbQuery.ChangeServerStatus(), connection))
                {
                    mscChangeServerStats.Parameters.Add("@p0", MySqlDbType.Int32).Value = 0;
                    mscChangeServerStats.ExecuteNonQuery();
                }

                string log = "Server Terminated";
                LogEvent(log, connection);

                connection.Close();

            }
            EventLog();
        }
        private void ServerTerminated()
        {
            txtStatus.ForeColor = System.Drawing.Color.Red;
            btnStart.BackColor = System.Drawing.Color.Lime;
            btnStop.BackColor = System.Drawing.Color.Gray;
            btnExit.BackColor = System.Drawing.Color.Red;
            btnLogoffAll.BackColor = System.Drawing.Color.Gray;
            txtStatus.Text = "TERMINATED";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnExit.Enabled = true;
            btnLogoffAll.Enabled = false;
        }
        private void GetTotalNumberOfLogs()
        {
            using (MySqlConnection connection = dbConn.getConnection())
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (MySqlCommand command = new MySqlCommand(dbQuery.GetTotalNumberOfLogs(), connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int newTotalLogValue))
                        {
                            newTotalLog = newTotalLogValue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogException(ex, connection);
                }
                finally
                {
                    connection.Close();
                }
            }
            
        }
        private void EventLog()
        {
            if (!formLoaded)
            {
                return;
            }

            int maxRetries = 3;
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                if (dtEventLogs != null)
                {
                    dtEventLogs.Rows.Clear();

                    MySqlDataAdapter? msdEventLog = new();
                    MySqlCommand? mscEventLog = new();

                    using (MySqlConnection connection = dbConn.getConnection())
                    {
                        try
                        {
                            connection.Open();

                            using (mscEventLog = new(dbQuery.CallEventLogs(), connection))
                            {
                                msdEventLog.SelectCommand = mscEventLog;
                                msdEventLog.Fill(dtEventLogs);
                            }

                            richTextBox1.Invoke((MethodInvoker)delegate
                            {
                                richTextBox1.Clear();
                                foreach (DataRow row in dtEventLogs.Rows)
                                {
                                    string? dateTime = Convert.ToString(row["eventDateTime"]);
                                    if (DateTime.TryParse(dateTime, out DateTime parsedDateTime))
                                    {
                                        string formattedDate = parsedDateTime.ToString("MMM. dd, hh:mm:ss tt");
                                        string? eventDescription = Convert.ToString(row["eventDescription"]);
                                        richTextBox1.AppendText($"PS Server> {formattedDate}>> {eventDescription}" + Environment.NewLine);
                                    }
                                }
                            });

                            break;
                        }
                        catch (Exception ex)
                        {
                            LogException(ex, connection);
                            retryCount++;
                            Thread.Sleep(1000);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
            if (retryCount == maxRetries)
            {
                MessageBox.Show("All retry attempts failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            ScrollToBottom();
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit the Server?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                serverTimer.Stop();
                isServerTerminated = true;
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (isServerTerminated)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnLogoffAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout all users?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                serverTimer.Stop();

                using (MySqlConnection connection = dbConn.getConnection())
                {
                    connection.Open();

                    using (MySqlCommand mscClockIn = new MySqlCommand(dbQuery.LogoutAll(), connection))
                    {
                        mscClockIn.ExecuteNonQuery();
                    }

                    string log = "Logging out all users";
                    LogEvent(log, connection);

                    connection.Close();
                }

                EventLog();
                GetTotalNumberOfLogs();
                storedTotalLog = newTotalLog;
                ScrollToBottom();

                serverTimer.Start();
            }


        }
        private void ScrollToBottom()
        {
            richTextBox1.ScrollToCaret();
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }
    }
}