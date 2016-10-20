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
using System.Globalization;

namespace int1
{
    public partial class frmWeeklyReport : Form
    {
        public frmWeeklyReport()
        {
            InitializeComponent();
        }

        private void calDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start.DayOfWeek != DayOfWeek.Sunday)
            {
                MessageBox.Show("Please choose Sundays");
                if(e.Start.DayOfWeek == DayOfWeek.Monday)
                {
                    calDate.SelectionStart = e.Start.AddDays(6);
                }
                if (e.Start.DayOfWeek == DayOfWeek.Tuesday)
                {
                    calDate.SelectionStart = e.Start.AddDays(5);
                }
                if (e.Start.DayOfWeek == DayOfWeek.Wednesday)
                {
                    calDate.SelectionStart = e.Start.AddDays(4);
                }
                if (e.Start.DayOfWeek == DayOfWeek.Thursday)
                {
                    calDate.SelectionStart = e.Start.AddDays(3);
                }
                if (e.Start.DayOfWeek == DayOfWeek.Friday)
                {
                    calDate.SelectionStart = e.Start.AddDays(2);
                }
                if (e.Start.DayOfWeek == DayOfWeek.Saturday)
                {
                    calDate.SelectionStart = e.Start.AddDays(1);
                }
            }
            else
            {
                DateTime chosenDate = calDate.SelectionRange.Start;
                DateTime endDate = chosenDate.AddDays(6);
                lblInfo.Text = "Generate Weekly Report from " + chosenDate.ToShortDateString() + " - " + endDate.ToShortDateString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmReportMenu newForm = new frmReportMenu();
            newForm.Show();
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DateTime chosenDate = calDate.SelectionRange.Start;
            DateTime endDate = chosenDate.AddDays(6);
            if(DateTime.Today < endDate)
            {
                MessageBox.Show("The week you have chosen has not ended. Please choose another Sunday!", "Error");
                return;
            }

            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader dr;
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            cmd.Connection = cn;

            string chosenDateStr = chosenDate.ToShortDateString();
            string endDateStr = endDate.ToShortDateString();

            double totalSpent = 0.0;
            double totalEarned = 0.0;
            bool reportFound = false;
            int reportID = -1;
            string q = "SELECT reportID, reportDate FROM Report WHERE reportTitle = 'Weekly';";
            cmd.CommandText = q;
            cn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                reportID = Int32.Parse(dr["reportID"].ToString());
                DateTime dtObtainedDate = DateTime.Parse(dr["reportDate"].ToString());
                string obtainedDate = dtObtainedDate.ToShortDateString();

                if (obtainedDate == chosenDateStr)
                {
                    reportFound = true;
                    break;
                }
            }
            dr.Close();
            cn.Close();

            bool generateNewReport = false;
            //If a report was generated previously, ask user if he want to generate a new one or see old one
            if (reportFound == true)
            {
                DialogResult dialogResult = MessageBox.Show("You have previously generated a report for the chosen week. Click 'Yes' to generate a new report or 'No' to see the old report. If you generate a new report, the old report will be updated automatically.", "Selection", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    generateNewReport = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    frmReport newForm = new frmReport(reportID);
                    newForm.Show();
                    this.Hide();
                    return;
                }
            }

            if (reportFound == false)
            {
                q = "SELECT [totalPrice] FROM [Bill] WHERE [billDate] BETWEEN ? AND ?;";

                cmd.CommandText = q;
                cmd.Parameters.AddWithValue("?", new DateTime(chosenDate.Year, chosenDate.Month, chosenDate.Day));
                cmd.Parameters.AddWithValue("?", new DateTime(endDate.Year, endDate.Month, endDate.Day));
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    totalEarned = totalEarned + double.Parse(dr["totalPrice"].ToString());
                }

                dr.Close();
                cn.Close();

                if (totalEarned == 0.0)
                {
                    MessageBox.Show("There are no records for earnings for the chosen week! Please select another week!", "Empty");
                    return;
                }

                q = "SELECT totalCost FROM Cost WHERE costDate BETWEEN ? AND ?;";
                cmd.CommandText = q;
                cmd.Parameters.AddWithValue("?", new DateTime(chosenDate.Year, chosenDate.Month, chosenDate.Day));
                cmd.Parameters.AddWithValue("?", new DateTime(endDate.Year, endDate.Month, endDate.Day));

                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    totalSpent = totalSpent + double.Parse(dr["totalCost"].ToString());
                }

                dr.Close();
                cn.Close();

                if (totalEarned == 0.0)
                {
                    MessageBox.Show("There are no records for expenditure for the chosen week! Please select another week!", "Empty");
                    return;
                }

                double totalProfit = totalEarned - totalSpent;

                q = "SELECT Max(reportID) FROM Report";
                cmd.CommandText = q;

                cn.Open();

                int maxId = 1;

                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    maxId = Convert.ToInt32(cmd.ExecuteScalar());
                    maxId = maxId + 1;
                }

                cn.Close();

                q = "INSERT INTO Report(reportID, reportTitle, totalCost, totalSales, totalProfit, reportDate) VALUES(" +
                    maxId + ", 'Weekly'," + totalSpent + "," + totalEarned + "," + totalProfit + ",'" + chosenDateStr + "');";

                cmd.CommandText = q;
                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();

                frmReport newForm = new frmReport(maxId);
                newForm.Show();
                this.Hide();
                return;
            }

            if (generateNewReport == true)
            {
                q = "SELECT [totalPrice] FROM [Bill] WHERE [billDate] BETWEEN ? AND ?;";

                cmd.CommandText = q;
                cmd.Parameters.AddWithValue("?", new DateTime(chosenDate.Year, chosenDate.Month, chosenDate.Day));
                cmd.Parameters.AddWithValue("?", new DateTime(endDate.Year, endDate.Month, endDate.Day));
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    totalEarned = totalEarned + double.Parse(dr["totalPrice"].ToString());
                }

                dr.Close();
                cn.Close();

                if (totalEarned == 0.0)
                {
                    MessageBox.Show("There are no records for earnings for the chosen week! Please select another week!", "Empty");
                    return;
                }

                q = "SELECT totalCost FROM Cost WHERE costDate BETWEEN ? AND ?;";
                cmd.CommandText = q;
                cmd.Parameters.AddWithValue("?", new DateTime(chosenDate.Year, chosenDate.Month, chosenDate.Day));
                cmd.Parameters.AddWithValue("?", new DateTime(endDate.Year, endDate.Month, endDate.Day));

                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    totalSpent = totalSpent + double.Parse(dr["totalCost"].ToString());
                }

                dr.Close();
                cn.Close();

                if (totalEarned == 0.0)
                {
                    MessageBox.Show("There are no records for expenditure for the chosen week! Please select another week!", "Empty");
                    return;
                }

                double totalProfit = totalEarned - totalSpent;

                q = "UPDATE Report SET totalCost=" + totalSpent + ", totalSales=" + totalEarned + ", totalProfit=" +
                    totalProfit + " WHERE reportID=" + reportID;

                cmd.CommandText = q;
                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();

                frmReport newForm = new frmReport(reportID);
                newForm.Show();
                this.Hide();
                return;
            }
        }

        private void frmWeeklyReport_Load(object sender, EventArgs e)
        {

        }
    }
}
