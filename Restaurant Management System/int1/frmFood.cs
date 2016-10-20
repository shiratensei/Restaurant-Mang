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
    public partial class frmFood : Form
    {
        private OleDbConnection connect = new OleDbConnection();

        public frmFood()
        {
            InitializeComponent();
            connect.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
        }

        public void clearDataGridView()
        {
            dgvFood.Rows.Clear();
        }

        public void loadBoard()
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader dr;

            cmd.Connection = connect;

            try
            {
                string q = "SELECT foodID,foodName, price FROM Food";
                cmd.CommandText = q;
                connect.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int foodID = int.Parse(dr["foodID"].ToString());
                    string foodName = dr["foodName"].ToString();
                    double foodPrice = double.Parse(dr["price"].ToString());


                    dgvFood.Rows.Add(foodName, foodPrice.ToString("c2"), foodID);
                }

                connect.Close();
                dr.Close();
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frmFoodOperation_Load(object sender, EventArgs e)
        {
            loadBoard();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManagerMenu newForm = new frmManagerMenu();
            newForm.Show();
            this.Hide();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            int rowIndex = dgvFood.CurrentCell.RowIndex;
            int primaryKey = Convert.ToInt32(dgvFood.Rows[rowIndex].Cells[2].Value);
            string name = (dgvFood.Rows[rowIndex].Cells[0].Value).ToString();

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove " + name + " from the database?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    connect.Open();

                    command.Connection = connect;
                    string query = "delete from Food where foodID= " + primaryKey + "";
                    command.CommandText = query;

                    command.ExecuteNonQuery();
                    MessageBox.Show(name + " successfully removed from the system!", "Successful");

                    connect.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error   " + ex);
                }
                clearDataGridView();
                loadBoard();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFoodDetails f2 = new frmFoodDetails();
            f2.Show();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvFood.CurrentCell.RowIndex;
            int primaryKey = Convert.ToInt32(dgvFood.Rows[rowIndex].Cells[2].Value);
            frmFoodDetails f2 = new frmFoodDetails(primaryKey);
            f2.Show();
            this.Hide();
        }
    }
}
