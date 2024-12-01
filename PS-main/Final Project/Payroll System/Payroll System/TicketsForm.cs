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
    public partial class TicketsForm : Form
    {
        public TicketsForm()
        {
            InitializeComponent();
            ShowDTRTickets();
        }
        public void LoadForm(object Form)
        {
            if (this.MainPanel.Controls.Count > 0)
                this.MainPanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag = f;
            f.Show();
        }
        private void btnDTR_Click(object sender, EventArgs e)
        {
            ShowDTRTickets();
        }



        private void ShowDTRTickets()
        {
            btnDTR.BackColor = SystemColors.Control;
            LoadForm(new TicketsDTRForm());
        }
    }
}
