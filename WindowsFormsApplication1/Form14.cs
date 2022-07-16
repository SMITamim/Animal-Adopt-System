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
    public partial class Form14 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form14()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please set your name");
            }
            else if (textBox2.Text == "")
            {
                errorProvider2.SetError(textBox2, "Please set your number");
            }
            else if (textBox3.Text == "")
            {
                errorProvider3.SetError(textBox3, "Please set donation amount");
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into ROCKET values (@name,@number,@amount,@massage)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@number", textBox2.Text);
                cmd.Parameters.AddWithValue("@amount", textBox3.Text);
                cmd.Parameters.AddWithValue("@massage", textBox4.Text);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    new Form17().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please check your information again", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            this.Hide();
            Form8 f = new Form8();
            f.Show();
        }
    }
}
