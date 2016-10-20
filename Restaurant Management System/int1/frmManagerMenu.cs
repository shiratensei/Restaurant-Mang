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
    public partial class frmManagerMenu : Form
    {
        public frmManagerMenu()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLogIn newForm = new frmLogIn();
            newForm.Show();
            this.Hide();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            frmFood newForm = new frmFood();
            newForm.Show();
            this.Hide();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee newForm = new frmEmployee();
            newForm.Show();
            this.Hide();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReportMenu newForm = new frmReportMenu();
            newForm.Show();
            this.Hide();
        }

        private void btnExpenditure_Click(object sender, EventArgs e)
        {
            frmExpenditure newForm = new frmExpenditure();
            newForm.Show();
            this.Hide();
        }
    }
}
