using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient; 

namespace WindowsFormsApplication1
{
    public partial class Form17 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form17()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment successful", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Form8 f = new Form8();
            f.Show();
        }
    }
}
