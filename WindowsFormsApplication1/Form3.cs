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
    public partial class Form3 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form3()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into USERS_ACC values(@id,@fname,@lname,@uname,@email,@pass)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@fname", textBox2.Text);
            cmd.Parameters.AddWithValue("@lname", textBox3.Text);
            cmd.Parameters.AddWithValue("@uname", textBox4.Text);
            cmd.Parameters.AddWithValue("@email", textBox6.Text);
            cmd.Parameters.AddWithValue("@pass", textBox5.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Inserted Successfully ! ");
                //BindGridView();

                // ResetContro();
            }
            else
            {
                MessageBox.Show("Data not Inserted ! ");
            }

            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
