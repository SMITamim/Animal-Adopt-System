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
    public partial class Form7 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form7()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into COMPLAINS values(@uname,@name,@email,@sub)";
            SqlCommand cmd = new SqlCommand(query, con);
           
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@uname", textBox2.Text);
            cmd.Parameters.AddWithValue("@email", textBox3.Text);
            cmd.Parameters.AddWithValue("@sub", richTextBox1.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Inserted Successfully ! ");

            }
            else
            {
                MessageBox.Show("Data not Inserted ! ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Sclass.ut == "Adopter")
            {
                Form8 f = new Form8();
                f.Show();
            }
            else if (Sclass.ut == "Rescuer")
            {
                Form6 f = new Form6();
                f.Show();
            }

        }
    }
}
