using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class AccountDetailsForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;

        public AccountDetailsForm()
        {
            InitializeComponent();
            ShowAccDetails();
            btnShowDetails.UseVisualStyleBackColor = false;
            btnChangePass.UseVisualStyleBackColor = false;
        }
        public void LoadForm(object? Form)
        {
            if (this.MainPanel.Controls.Count > 0)
                this.MainPanel.Controls.RemoveAt(0);
            if (Form != null)
            {
                Form f = (Form)Form;
                if (f != null)
                {
                    f.TopLevel = false;
                    f.Dock = DockStyle.Fill;
                    this.MainPanel.Controls.Add(f);
                    this.MainPanel.Tag = f;
                    f.Show();
                }
            }
        }

        private void ShowAccDetails()
        {
            btnShowDetails.Enabled = false;
            btnChangePass.Enabled = true;
            btnShowDetails.BackColor = SystemColors.Control;
            btnChangePass.BackColor = Color.FromArgb(178, 190, 195);
            LoadForm(new AccountDetailsShowForm());
        }
        private void ChangePassword()
        {
            btnShowDetails.Enabled = true;
            btnChangePass.Enabled = false;
            btnShowDetails.BackColor = Color.FromArgb(178, 190, 195);
            btnChangePass.BackColor = SystemColors.Control;
            LoadForm(new EditPasswordForm());
        }
        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            ShowAccDetails();
        }
    }
}
