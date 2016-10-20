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
    public partial class frmExpenditureDetails : Form
    {
        bool loaded = false;
        int costID = -1;

        public frmExpenditureDetails()
        {
            InitializeComponent();
        }

        public frmExpenditureDetails(int costID)
        {
            InitializeComponent();
            loaded = true;
            this.costID = costID;

            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader dr;
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            cmd.Connection = cn;

            try
            {
                string q = "SELECT costDesc, totalCost, costDate FROM Cost WHERE costID = " + costID;
                cmd.CommandText = q;
                cn.Open();
                dr = cmd.ExecuteReader();

                string costDesc = "";
                double totalCost = 0.0;
                string costDate = "";

                while (dr.Read())
                {
                    costDesc = dr["costDesc"].ToString();
                    totalCost = double.Parse(dr["totalCost"].ToString());
                    costDate = dr["costDate"].ToString();
                }


                cn.Close();
                dr.Close();

                txtAmount.Text = totalCost.ToString();
                txtDescription.Text = costDesc;
                dtpDate.Value = DateTime.Parse(costDate);
                btnGenerateEmpSalary.Enabled = false;
            }
            catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtAmount.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("One or more fields are left empty. Please fill them up!", "Error");
                return;
            }

            double amount = 0.0;
            bool convertAmount = double.TryParse(txtAmount.Text, out amount);
            
            if (convertAmount == false)
            {
                MessageBox.Show("Please enter numbers in the Amount field!", "Error");
                return;
            }

            amount = Math.Round(amount, 2);
            string date = dtpDate.Value.ToShortDateString();
            string description = txtDescription.Text;

            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            cmd.Connection = cn;

            bool successful = false;
            try
            {
                //If loaded then UPDATE, if not loaded then INSERT
                if (loaded == true)
                {
                    string q = "UPDATE Cost SET costDesc='" + description + "', totalCost=" + amount + ", costDate='" + date + "' WHERE costID=" + costID;

                    cmd.CommandText = q;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                    cn.Close();

                    MessageBox.Show("Record successfully edited! Returning to previous screen!", "Successful");
                    successful = true;
                }
                else
                {
                    string p = "SELECT Max(costID) FROM Cost";
                    cmd.CommandText = p;

                    cn.Open();

                    int maxId = 1;

                    if (cmd.ExecuteScalar() != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(cmd.ExecuteScalar());
                        maxId = maxId + 1;
                    }

                    cn.Close();

                    string q = "INSERT INTO Cost(costID, costDesc, totalCost, costDate)" +
                        " VALUES(" + maxId + ",'" + description + "'," + amount + ",'" + date + "')";

                    cmd.CommandText = q;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                    cn.Close();

                    MessageBox.Show("Record successfully added! Returning to previous screen!", "Successful");
                    successful = true;
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show("Oops... Something went wrong. Please contact the admin to make sure everything's all right!", "Sorry");
            }

            if (successful == true)
            {
                frmExpenditure newForm = new frmExpenditure();
                newForm.Show();
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel? No changes will be saved.", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                frmExpenditure newForm = new frmExpenditure();
                //newForm.clearDataGridView();
                //newForm.loadDataGridView();
                newForm.Show();
                this.Hide();
            }
        }

        private void btnGenerateEmpSalary_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader dr;
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            cmd.Connection = cn;

            try
            {
                double totalSalary = 0.0;
                string q = "SELECT empSalary FROM Employee;";
                cmd.CommandText = q;
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    totalSalary = totalSalary + double.Parse(dr["empSalary"].ToString());
                }

                txtAmount.Text = totalSalary.ToString();
                txtDescription.Text = "Employee Monthly Salary";
                dr.Close();
                cn.Close();
            }
            catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
