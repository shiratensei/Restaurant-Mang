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
    public partial class frmMonthlyReport : Form
    {
        public frmMonthlyReport()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYear.Text) || string.IsNullOrEmpty(cbMonth.Text))
            {
                MessageBox.Show("One or more fields are left empty. Please fill them up!", "Error");
                return;
            }

            int year;
            bool yearValid = Int32.TryParse(txtYear.Text, out year);
            if(yearValid == false || year < 0)
            {
                MessageBox.Show("Please enter a valid year!", "Error");
                return;
            }

            int month = 1;
            if(cbMonth.Text == "February")
            {
                month = 2;
            }
            else if(cbMonth.Text == "March")
            {
                month = 3;
            }
            else if (cbMonth.Text == "April")
            {
                month = 4;
            }
            else if (cbMonth.Text == "May")
            {
                month = 5;
            }
            else if (cbMonth.Text == "June")
            {
                month = 6;
            }
            else if (cbMonth.Text == "July")
            {
                month = 7;
            }
            else if (cbMonth.Text == "August")
            {
                month = 8;
            }
            else if (cbMonth.Text == "September")
            {
                month = 9;
            }
            else if (cbMonth.Text == "October")
            {
                month = 10;
            }
            else if (cbMonth.Text == "November")
            {
                month = 11;
            }
            else if (cbMonth.Text == "December")
            {
                month = 12;
            }

            string dateForMonth = "1/" + month.ToString() + "/" + year.ToString();
            double totalSpent = 0.0;
            double totalEarned = 0.0;

            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader dr;
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            cmd.Connection = cn;

            bool reportFound = false;
            int reportID = -1;
            string q = "SELECT reportID, reportDate FROM Report WHERE reportTitle = 'Monthly';";
            cmd.CommandText = q;
            cn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                reportID = Int32.Parse(dr["reportID"].ToString());
                DateTime dtObtainedDate = DateTime.Parse(dr["reportDate"].ToString());
                string obtainedDate = dtObtainedDate.ToShortDateString();

                if(obtainedDate == dateForMonth)
                {
                    reportFound = true;
                    break;
                }
            }
            dr.Close();
            cn.Close();

            bool generateNewReport = false;
            //If a report was generated previously, ask user if he want to generate a new one or see old one
            if(reportFound == true)
            {
                DialogResult dialogResult = MessageBox.Show("You have previously generated a report for this month and year. Click 'Yes' to generate a new report or 'No' to see the old report. If you generate a new report, the old report will be updated automatically.", "Selection", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    generateNewReport = true;
                }
                else if(dialogResult == DialogResult.No)
                {
                    frmReport newForm = new frmReport(reportID);
                    newForm.Show();
                    this.Hide();
                    return;
                }
            }
            
            if(reportFound == false)
            {
                q = "SELECT totalPrice FROM Bill WHERE Year([billDate]) = " + year + " AND Month([billDate]) = " + month + ";";

                cmd.CommandText = q;
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
                    MessageBox.Show("There are no records for earnings in the chosen month and year! Please select another month or year!", "Empty");
                    return;
                }

                q = "SELECT totalCost FROM Cost WHERE Year([costDate]) = " + year + " AND Month([costDate]) = " + month + ";";
                cmd.CommandText = q;
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
                    MessageBox.Show("There are no records for expenditure in the chosen month and year! Please select another month or year!", "Empty");
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
                    maxId + ", 'Monthly'," + totalSpent + "," + totalEarned + "," + totalProfit + ", ?);";

                cmd.CommandText = q;
                cmd.Parameters.AddWithValue("?", new DateTime(year, month, 1));

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();

                frmReport newForm = new frmReport(maxId);
                newForm.Show();
                this.Hide();
                return;
            }

            if(generateNewReport == true)
            {
                q = "SELECT totalPrice FROM Bill WHERE Year([billDate]) = " + year + " AND Month([billDate]) = " + month + ";";

                cmd.CommandText = q;
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
                    MessageBox.Show("There are no records for earnings in the chosen month and year! Please select another month or year!", "Empty");
                    return;
                }

                q = "SELECT totalCost FROM Cost WHERE Year([costDate]) = " + year + " AND Month([costDate]) = " + month + ";";
                cmd.CommandText = q;
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
                    MessageBox.Show("There are no records for expenditure in the chosen month and year! Please select another month or year!", "Empty");
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmReportMenu newForm = new frmReportMenu();
            newForm.Show();
            this.Hide();
        }

    }
}
