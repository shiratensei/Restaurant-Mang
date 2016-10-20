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
    public partial class frmGenerateBill : Form
    {
        private List<string> foodName = new List<string>();
        private List<double> foodPrice = new List<double>();
        private List<int> foodID = new List<int>();

        private List<double> orderFoodPrice = new List<double>();
        private List<int> orderFoodID = new List<int>();
        private double totalPrice = 0.0;

        public frmGenerateBill()
        {
            InitializeComponent();
        }

        private void lstFood_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lstFood.SelectedItems != null)
            {
                lstOrder.Items.Add(lstFood.SelectedItems[0].SubItems[0].Text);
                int index = lstFood.SelectedIndices[0];
                orderFoodID.Add(foodID[index]);
                orderFoodPrice.Add(foodPrice[index]);
                totalPrice = totalPrice + foodPrice[index];
                txtTotal.Text = totalPrice.ToString("c2");
            }
        }

        private void frmGenerateBill_Load(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            cmd.Connection = cn;

            string p = "SELECT Max(billID) FROM Bill;";
            cmd.CommandText = p;

            cn.Open();

            int maxId = 1;

            if (cmd.ExecuteScalar() != DBNull.Value)
            {
                maxId = Convert.ToInt32(cmd.ExecuteScalar());
                maxId = maxId + 1;
            }

            cn.Close();
            txtOrderNumber.Text = maxId.ToString();

            OleDbDataReader dr;
            p = "SELECT foodID, foodName, price FROM Food;";
            cmd.CommandText = p;

            cn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int id = Int32.Parse(dr["foodID"].ToString());
                string name = dr["foodName"].ToString();
                double price = double.Parse(dr["price"].ToString());
                foodID.Add(id);
                foodName.Add(name);
                foodPrice.Add(price);
                lstFood.Items.Add(name + " - " + price.ToString("c2"));
            }

            dr.Close();
            cn.Close();
        }

        private void lstOrder_DoubleClick(object sender, EventArgs e)
        {
            if(lstOrder.SelectedItems != null)
            {
                int index = lstOrder.SelectedIndices[0];
                orderFoodID.RemoveAt(index);
                orderFoodPrice.RemoveAt(index);
                totalPrice = 0.0;
                for(int i = 0; i < orderFoodPrice.Count; i++)
                {
                    totalPrice = totalPrice + orderFoodPrice[i];
                }
                txtTotal.Text = totalPrice.ToString("c2");
                lstOrder.Items[index].Remove();
            }
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            if(orderFoodID.Count == 0)
            {
                MessageBox.Show("Please input some food data before generating bill!", "Error");
                return;
            }

            string date = DateTime.Today.ToShortDateString();
            int id = Int32.Parse(txtOrderNumber.Text);
            double price = totalPrice;

            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            cmd.Connection = cn;

            string p = "INSERT INTO Bill(billID, totalPrice, billDate) VALUES (" + id + "," + price + ",'" + date + "');";
            cmd.CommandText = p;

            cn.Open();

            cmd.ExecuteNonQuery();

            cn.Close();
          
            foreach (int i in orderFoodID)
            {
                string q = "INSERT INTO [Order](foodID, billID) VALUES(" + i + ", " + id + ")";
                cmd.CommandText = q;

                cn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                cn.Close();
            }

            orderFoodPrice.Clear();

            p = "SELECT Max(billID) FROM Bill;";
            cmd.CommandText = p;

            cn.Open();

            int maxId = 1;

            if (cmd.ExecuteScalar() != DBNull.Value)
            {
                maxId = Convert.ToInt32(cmd.ExecuteScalar());
                maxId = maxId + 1;
            }

            cn.Close();
            txtOrderNumber.Text = maxId.ToString();
            lstOrder.Items.Clear();
            orderFoodPrice.Clear();
            orderFoodID.Clear();
            totalPrice = 0.0;
            txtTotal.Text = "";

            MessageBox.Show("Receipt successfully generated! Ready to accept next order!", "Successful!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to return? Make sure you have saved the data before returning!", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                frmLogIn newForm = new frmLogIn();
                newForm.Show();
                this.Hide();
            }
        }
    }
}
