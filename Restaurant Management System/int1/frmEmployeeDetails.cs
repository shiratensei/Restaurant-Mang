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
    public partial class frmEmployeeDetails : Form
    {

        private bool loaded = false;
        private int empID = -1;

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        bool IsCharOnly(string str)
        {
            foreach (char c in str)
            {
                if (c >= '0' && c <= '9')
                    return false;
            }

            return true;
        }

        public frmEmployeeDetails()
        {
            InitializeComponent();
        }

        public frmEmployeeDetails(int empID)
        {
            InitializeComponent();
            loaded = true;
            this.empID = empID;

            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader dr;
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb; Persist Security Info=False;";
            cmd.Connection = cn;

            try
            {
                string q = "SELECT empName, empContact, empSalary, empAddress, empPostcode, empCity, empState, empPosition FROM Employee WHERE empID = " + empID;
                cmd.CommandText = q;
                cn.Open();
                dr = cmd.ExecuteReader();

                string empName = "";
                string empContact = "";
                double empSalary = 0.0;
                string empAddress = "";
                string empPostcode = "";
                string empCity = "";
                string empState = "";
                string empPosition = "";

                while (dr.Read())
                {
                    empName = dr["empName"].ToString();
                    empContact = dr["empContact"].ToString();
                    empSalary = double.Parse(dr["empSalary"].ToString());
                    empAddress = dr["empAddress"].ToString();
                    empPostcode = dr["empPostcode"].ToString();
                    empCity = dr["empCity"].ToString();
                    empState = dr["empState"].ToString();
                    empPosition = dr["empPosition"].ToString();
                }
                

                cn.Close();
                dr.Close();

                txtEmpName.Text = empName;
                txtEmpContact.Text = empContact;
                txtEmpSalary.Text = empSalary.ToString("#.##");
                txtEmpAddress.Text = empAddress;
                txtEmpPostcode.Text = empPostcode;
                txtEmpCity.Text = empCity;
                cbEmpState.Text = empState;
                txtPosition.Text = empPosition;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel? No changes will be saved.", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                frmEmployee newForm = new frmEmployee();
                //newForm.clearDataGridView();
                //newForm.loadDataGridView();
                newForm.Show();
                this.Hide();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool convertContact = IsDigitsOnly(txtEmpContact.Text);
            bool convertPostCode = IsDigitsOnly(txtEmpPostcode.Text);
            bool convertName = IsCharOnly(txtEmpName.Text);

            double salary = 0.0;
            bool convertSalary = double.TryParse(txtEmpSalary.Text, out salary);

            if(convertContact == false)
            {
                MessageBox.Show("Please enter only numbers (no special characters) in the Contact field!", "Error");
                return;
            }
            else if(convertSalary == false || salary < 0)
            {
                MessageBox.Show("Please enter positive numbers in the Salary field!", "Error");
                return;
            }
            else if(convertPostCode == false || txtEmpPostcode.Text.Length != 5)
            {
                MessageBox.Show("Please enter 5 positive numbers in the Postcode field!", "Error");
                return;
            }
            else if (String.IsNullOrWhiteSpace(txtEmpName.Text))
            {
                MessageBox.Show("Please enter data in the Name field!", "Error");
                return;
            }
            else if(convertName == false)
            {
                MessageBox.Show("Please enter characters in the Name field!", "Error");
                return;
            }

            salary = Math.Round(salary, 2);
            string name = txtEmpName.Text;
            string contact = txtEmpContact.Text;
            string address = txtEmpAddress.Text;
            string postcode = txtEmpPostcode.Text;
            string city = txtEmpCity.Text;
            string state = cbEmpState.GetItemText(cbEmpState.SelectedItem);
            string position = txtPosition.Text;

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
                    string q = "UPDATE Employee SET empName='" + name + "', empContact='" + contact + 
                        "', empSalary=" + salary + ", empAddress='" + address + "', empPostcode='" + postcode +
                        "', empCity='" + city + "', empState='" + state + "', empPosition='" + position + "' WHERE empID = " + empID + ";";

                    cmd.CommandText = q;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                    cn.Close();

                    MessageBox.Show("Record successfully edited! Returning to previous screen!", "Successful");
                    successful = true;
                }
                else
                {
                    string p = "SELECT Max(empID) FROM Employee";
                    cmd.CommandText = p;
               
                    cn.Open();

                    int maxId = 1;

                    if (cmd.ExecuteScalar() != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(cmd.ExecuteScalar());
                        maxId = maxId + 1;
                    }

                    cn.Close();

                    string q = "INSERT INTO Employee(empID, empName, empContact, empSalary, empAddress, empPostcode, empCity, empState, empPosition)" + 
                        " VALUES(" + maxId + ",'" + name + "','" + contact + "'," + salary + ",'" + address + "','"
                        + postcode + "','" + city + "','" + state + "','" + position + "');";
                    
                    cmd.CommandText = q;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                    cn.Close();

                    MessageBox.Show("Record successfully added! Returning to previous screen!", "Successful");
                    successful = true;
                }
            }
            catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Oops... Something went wrong. Please contact the admin to make sure everything's all right!", "Sorry");
            }

            if (successful == true)
            {
                frmEmployee newForm = new frmEmployee();
                newForm.Show();
                this.Hide();
            }
        }

        private void frmEmployeeDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
