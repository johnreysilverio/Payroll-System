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

namespace Payroll_System
{
    public partial class TicketsDTRForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        int? selectedStaffID = UserDetails.SelectedStaffID;
        DataTable? allAccDet = new DataTable();
        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        private string cellValue;
        private string views;
        public TicketsDTRForm()
        {
            InitializeComponent();
            string acclevel = retrievedTable.Rows[0][columnName: "accountLevel"].ToString();
            string userID = retrievedTable.Rows[0][columnName: "userID"].ToString();
            if (acclevel == "1")
            {
                views = acclevel;
            }
            else
            {
                views = "";
            }
            cbList.SelectedIndex = 0;
            ShowDTRTickets();

        }
        private void ShowDTRTickets()
        {
            int selectedIndex = cbList.SelectedIndex;
            string viewNum = "";

            switch (selectedIndex)
            {
                case 0:
                    viewNum = "";
                    break;
                case 1:
                    viewNum = "1";
                    break;
                case 2:
                    viewNum = "2";
                    break;
                case 3:
                    viewNum = "3";
                    break;
            }


            allAccDet.Rows.Clear();

            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.ShowDTRTickets(), dbConn.getConnection());
            mscSearchAcc.Parameters.AddWithValue("@p0", viewNum);
            mscSearchAcc.Parameters.AddWithValue("@p1", views);

            mscAdapter.SelectCommand = mscSearchAcc;
            mscAdapter.Fill(allAccDet);

            FillDGV();
        }
        private void FillDGV()
        {
            dgvDTRTickets.DataSource = allAccDet;

            dgvDTRTickets.Columns["dtrTicketID"].Visible = false;
            dgvDTRTickets.Columns["dtrID"].Visible = false;

            var descriptionColumn = dgvDTRTickets.Columns["dtrTicketDescription"];
            descriptionColumn.HeaderText = "Description";
            descriptionColumn.Width = 300;

            var remarksColumn = dgvDTRTickets.Columns["dtrTicketRemarks"];
            remarksColumn.HeaderText = "Remarks";
            remarksColumn.Width = 300;

            var statusColumn = dgvDTRTickets.Columns["dtrTicketStatus"];
            statusColumn.HeaderText = "Status";
            statusColumn.Width = 100;

            var recievedColumn = dgvDTRTickets.Columns["dtrTicketDateRecieved"];
            recievedColumn.HeaderText = "Date Recieved";
            recievedColumn.DefaultCellStyle.Format = "MMM dd, yyyy";
            recievedColumn.Width = 150;

            var resolvedColumn = dgvDTRTickets.Columns["dtrTicketDateResolved"];
            resolvedColumn.HeaderText = "Date Reviewed";
            resolvedColumn.DefaultCellStyle.Format = "MMM dd, yyyy";
            resolvedColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowDTRTickets();
        }

        private void cbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDTRTickets();
        }

        private void dgvDTRTickets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string targetColumnName = "dtrTicketStatus";

                if (dgvDTRTickets.Columns[e.ColumnIndex].Name == targetColumnName && e.Value != null)
                {
                    if (int.TryParse(e.Value.ToString(), out int cellValue))
                    {
                        switch (cellValue)
                        {
                            case 1:
                                e.Value = "Unresolved";
                                break;
                            case 2:
                                e.Value = "Resolved";
                                break;
                            default:
                                e.Value = "Rejected";
                                break;
                        }

                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void dgvDTRTickets_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            string targetColumnName = "dtrTicketStatus";
            int columnIndex = dgvDTRTickets.Columns[targetColumnName].Index;

            if (e.RowIndex >= 0 && dgvDTRTickets.Rows[e.RowIndex].Cells[columnIndex].Value != null)
            {
                if (int.TryParse(dgvDTRTickets.Rows[e.RowIndex].Cells[columnIndex].Value.ToString(), out int cellValue))
                {
                    DataGridViewRow row = dgvDTRTickets.Rows[e.RowIndex];

                    switch (cellValue)
                    {
                        case 1:
                            row.DefaultCellStyle.BackColor = Color.White;
                            break;
                        case 2:
                            row.DefaultCellStyle.BackColor = Color.Green;
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.Red;
                            break;
                    }
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (cellValue != null)
            {
                TicketsDTRView ticketsDTRView = new TicketsDTRView();
                ticketsDTRView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a row first");
            }
        }

        private void dgvDTRTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDTRTickets.Rows[e.RowIndex];
                cellValue = selectedRow.Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValue) && int.TryParse(cellValue, out int selectedDTRTicketID))
                {
                    UserDetails.SelectedDTRTicketID = selectedDTRTicketID;
                }
                else
                {
                    MessageBox.Show("Invalid or empty cell value.", "Error");
                }
            }
        }
    }
}
