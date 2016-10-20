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
    public partial class frmLogIn : Form
    {

        List<string> position = new List<string>();
        List<string> username = new List<string>();
        List<string> password = new List<string>();

        public frmLogIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader dr;
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Restaurant.accdb";
            cmd.Connection = cn;
            string q = "SELECT empPosition, empUsername, empPassword FROM Employee WHERE empUsername IS NOT NULL AND empPassword IS NOT NULL";
            cmd.CommandText = q;
            cn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                position.Add(dr["empPosition"].ToString());
                username.Add(dr["empUsername"].ToString());
                password.Add(dr["empPassword"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string inputUsername = txtUsername.Text;
            string inputPassword = txtPassword.Text;

            int index = 0;
            bool usernameFound = false;
            bool passwordFound = false;
            for(int i = 0; i < username.Count; i++)
            {
                if(inputUsername == username[i])
                {
                    index = i;
                    usernameFound = true;
                    break;
                }
            }

            if(usernameFound == false)
            {
                MessageBox.Show("Wrong username! Please try again!", "Unsuccessful");
                return;
            }

            if(inputPassword == password[index])
            {
                passwordFound = true;
            }

            if(passwordFound == false)
            {
                MessageBox.Show("Wrong password! Please try again!", "Unsuccessful");
                return;
            }

            if(usernameFound == true && passwordFound == true)
            {
                MessageBox.Show("Successful login. Redirecting to " + position[index] + " Menu!", "Successful");
                if(position[index] == "Manager")
                {
                    frmManagerMenu newForm = new frmManagerMenu();
                    newForm.Show();
                    this.Hide();
                }
                else if(position[index] == "Cashier")
                {
                    frmGenerateBill newForm = new frmGenerateBill();
                    newForm.Show();
                    this.Hide();
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
