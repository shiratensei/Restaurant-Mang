using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace int1
{
    public partial class frmReportMenu : Form
    {
        public frmReportMenu()
        {
            InitializeComponent();
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            frmWeeklyReport newForm = new frmWeeklyReport();
            newForm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManagerMenu newForm = new frmManagerMenu();
            newForm.Show();
            this.Hide();
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            frmMonthlyReport newForm = new frmMonthlyReport();
            newForm.Show();
            this.Hide();
        }
    }
}
