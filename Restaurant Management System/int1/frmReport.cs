using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace int1
{
    public partial class frmReport : Form
    {
        public frmReport(int id)
        {
            InitializeComponent();

            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader dr;
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            cmd.Connection = cn;

            string q = "SELECT totalCost, totalSales, totalProfit, reportDate FROM Report WHERE reportID = " + id + ";";

            cmd.CommandText = q;
            cn.Open();
            dr = cmd.ExecuteReader();

            DateTime date = System.DateTime.Now;
            double cost = 0.0;
            double revenue = 0.0;
            double profit = 0.0;

            while (dr.Read())
            {
                date = DateTime.Parse(dr["reportDate"].ToString());
                cost = double.Parse(dr["totalCost"].ToString());
                revenue = double.Parse(dr["totalSales"].ToString());
                profit = double.Parse(dr["totalProfit"].ToString());
            }

            dr.Close();
            cn.Close();

            txtDate.Text = date.ToString("dd/MM/yyyy");
            txtExpenditure.Text = cost.ToString("#.##");
            txtRevenue.Text = revenue.ToString("#.##");
            txtProfit.Text = profit.ToString("#.##");
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Returning to Manager Menu. Press 'Yes' to proceed.", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                frmManagerMenu newForm = new frmManagerMenu();
                newForm.Show();
                this.Hide();
            }
        }
    }
}
