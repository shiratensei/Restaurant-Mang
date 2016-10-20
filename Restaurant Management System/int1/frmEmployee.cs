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
    public partial class frmEmployee : Form
    {
        public void loadDataGridView()
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader dr;
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            cmd.Connection = cn;

            try
            {
                string q = "SELECT empID, empName, empContact, empSalary, empAddress, empPostcode, empCity, empState, empPosition FROM Employee";
                cmd.CommandText = q;
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string empID = dr["empID"].ToString();
                    string empName = dr["empName"].ToString();
                    string empContact = dr["empContact"].ToString();
                    double empSalary = double.Parse(dr["empSalary"].ToString());
                    string empAddress = dr["empAddress"].ToString();
                    string empPostcode = dr["empPostcode"].ToString();
                    string empCity = dr["empCity"].ToString();
                    string empState = dr["empState"].ToString();
                    string empPosition = dr["empPosition"].ToString();

                    dgvEmployee.Rows.Add(empName, empContact, empAddress + ", " + empPostcode + " " + empCity + ", " + empState, empSalary.ToString("c2"), empPosition, empID);
                }

                cn.Close();
                dr.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void clearDataGridView()
        {
            dgvEmployee.Rows.Clear();
        }

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployeeOperation_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(dgvEmployee.RowCount > 0)
            {
                int rowIndex = dgvEmployee.CurrentCell.RowIndex;
                int primaryKey = Convert.ToInt32(dgvEmployee.Rows[rowIndex].Cells[5].Value);
                string name = (dgvEmployee.Rows[rowIndex].Cells[0].Value).ToString();

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove " + name + " from the database?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    OleDbConnection cn = new OleDbConnection();
                    cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
                    cmd.Connection = cn;

                    try
                    {
                        string q = "DELETE * FROM Employee WHERE empID = " + primaryKey;
                        cmd.CommandText = q;
                        cn.Open();

                        cmd.ExecuteNonQuery();

                        cn.Close();
                        MessageBox.Show(name + " successfully removed from the system!", "Successful");
                    }
                    catch (Exception ex)
                    {
                        cn.Close();
                        MessageBox.Show(ex.Message.ToString());
                    }

                    clearDataGridView();
                    loadDataGridView();
                }
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmployeeDetails newForm = new frmEmployeeDetails();
            newForm.Show();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.RowCount > 0)
            {
                int rowIndex = dgvEmployee.CurrentCell.RowIndex;
                int primaryKey = Convert.ToInt32(dgvEmployee.Rows[rowIndex].Cells[5].Value);
                frmEmployeeDetails newForm = new frmEmployeeDetails(primaryKey);
                newForm.Show();
                this.Hide();
            }    
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManagerMenu newForm = new frmManagerMenu();
            newForm.Show();
            this.Hide();
        }
    }
}
