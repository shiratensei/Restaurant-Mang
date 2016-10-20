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
    public partial class frmExpenditure : Form
    {
        public frmExpenditure()
        {
            InitializeComponent();
        }

        public void loadDataGridView()
        {
            dgvExpenditure.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader dr;
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            cmd.Connection = cn;

            try
            {
                string q = "SELECT costID, costDesc, totalCost, costDate FROM Cost;";
                cmd.CommandText = q;
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string costID = dr["costID"].ToString();
                    string costDesc = dr["costDesc"].ToString();
                    double totalCost = double.Parse(dr["totalCost"].ToString());
                    DateTime costDate = DateTime.Parse(dr["costDate"].ToString());

                    dgvExpenditure.Rows.Add(totalCost.ToString("c2"), costDate, costDesc, costID);
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
            dgvExpenditure.Rows.Clear();
        }

        private void frmExpenditure_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(dgvExpenditure.RowCount > 0)
            {
                int rowIndex = dgvExpenditure.CurrentCell.RowIndex;
                int primaryKey = Convert.ToInt32(dgvExpenditure.Rows[rowIndex].Cells[3].Value);
                string description = (dgvExpenditure.Rows[rowIndex].Cells[2].Value).ToString();

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove the expenditure with description '" + description + "' from the database?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    OleDbConnection cn = new OleDbConnection();
                    cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
                    cmd.Connection = cn;

                    try
                    {
                        string q = "DELETE * FROM Cost WHERE costID = " + primaryKey;
                        cmd.CommandText = q;
                        cn.Open();

                        cmd.ExecuteNonQuery();

                        cn.Close();
                        MessageBox.Show("'" + description + "' successfully removed from the system!", "Successful");
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
            frmExpenditureDetails newForm = new frmExpenditureDetails();
            newForm.Show();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvExpenditure.RowCount > 0)
            {
                int rowIndex = dgvExpenditure.CurrentCell.RowIndex;
                int primaryKey = Convert.ToInt32(dgvExpenditure.Rows[rowIndex].Cells[3].Value);
                frmExpenditureDetails newForm = new frmExpenditureDetails(primaryKey);
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
