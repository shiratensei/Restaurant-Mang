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
    public partial class frmFoodDetails : Form
    {
        private OleDbConnection connect = new OleDbConnection();
        private OleDbDataReader dr;
        private int food;
        private int choice;

        public frmFoodDetails()
        {
            choice = 1;
            InitializeComponent();
            connect.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
        }

        public frmFoodDetails(int fID)
        {
            InitializeComponent();
            this.food = fID;
            connect.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            choice = 2;

            try
            {

                connect.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connect;
                command.CommandText = "SELECT foodID, foodName, price FROM Food WHERE foodID = " + fID;
                dr = command.ExecuteReader();

                string fname = "";
                double fprice = 0.0;

                while (dr.Read())
                {

                    fname = dr["foodName"].ToString();
                    fprice = double.Parse(dr["price"].ToString());

                }
                txtFoodName.Text = fname;
                txtFoodPrice.Text = fprice.ToString();

                connect.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }

        private void confirmButton(int choice)
        {
            double price = 0.0;
            bool convertPrice = double.TryParse(txtFoodPrice.Text, out price);

            if(convertPrice == false || price < 0)
            {
                MessageBox.Show("Please enter positive numbers in the Price field!", "Error");
                return;
            }
            else if(String.IsNullOrWhiteSpace(txtFoodName.Text))
            {
                MessageBox.Show("Please enter data in the Food Name field!", "Error");
                return;
            }

            price = Math.Round(price, 2);
            try
            {

                connect.Open();
                string p = "SELECT Max(foodID) FROM Food";

                int maxId = 1;
                OleDbCommand command = new OleDbCommand();
                using (OleDbCommand command1 = new OleDbCommand(p, connect))
                {
                    if (command1.ExecuteScalar() != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(command1.ExecuteScalar());
                        maxId = maxId + 1;
                    }
                }

                command.Connection = connect;
                if (choice == 1)
                {
                    command.CommandText = "insert into Food (foodID, foodName, price) values  ('" + maxId + "','" + txtFoodName.Text + "'," + price + ")";
                }
                else if (choice == 2)
                {
                    command.CommandText = "UPDATE Food SET foodName='" + txtFoodName.Text + "', price=" + price + " WHERE foodID = " + food + ";";
                }

                command.ExecuteNonQuery();
                if (choice == 1)
                {
                    MessageBox.Show("Food record successfully added! Returning to previous screen!", "Successful");
                }
                else if (choice == 2)
                {
                    MessageBox.Show("Food record successfully edited! Returning to previous screen!", "Successful");
                }

                connect.Close();
                frmFood f1 = new frmFood();
                f1.Show();
                this.Hide();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmButton(choice);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel? No changes will be saved.", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                frmFood newForm = new frmFood();
                //newForm.clearDataGridView();
                //newForm.loadDataGridView();
                newForm.Show();
                this.Hide();
            }
        }
    }
}
