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
    public partial class Form16 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form16()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please set your card number");
            }
            else if (textBox2.Text == "")
            {
                errorProvider2.SetError(textBox2, "Please set your expiration date");
            }
            else if (textBox3.Text == "")
            {
                errorProvider3.SetError(textBox3, "Please set your amount");
            }
            else if (textBox4.Text == "")
            {
                errorProvider4.SetError(textBox4, "Please set your CVV");
            }
            else if (textBox5.Text == "")
            {
                errorProvider5.SetError(textBox5, "Please insert PIN");
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into VISA values (@Card_no,@Ex_Date,@amount,@CVV,@PIN)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Card_no", textBox1.Text);
                cmd.Parameters.AddWithValue("@Ex_date", textBox2.Text);
                cmd.Parameters.AddWithValue("@amount", textBox3.Text);
                cmd.Parameters.AddWithValue("@CVV", textBox4.Text);
                cmd.Parameters.AddWithValue("@PIN", textBox5.Text);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Payment successful", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.Hide();
            Form8 f = new Form8();
            f.Show();
        }
    }
}
