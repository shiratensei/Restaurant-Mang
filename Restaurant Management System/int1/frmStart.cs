using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace int1
{
    public partial class frmStart : Form
    {
        frmLogIn newForm = new frmLogIn();
        public frmStart()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(4);
            if (progressBar1.Value == 100)
            {
                //frmLogIn newForm = new frmLogIn();
                timer1.Stop();
                newForm.Show(); 
                this.Hide();
            } 

        }
    }
}
