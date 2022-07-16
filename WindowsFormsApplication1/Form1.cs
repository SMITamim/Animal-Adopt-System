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
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = false;
                    break;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "*Username Required");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "*Password Required");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection c = new SqlConnection(cs);
                string query = "select * from login_tbl where username= @user and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, c);
                cmd.Parameters.AddWithValue("@User", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                c.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("login successful!", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("login failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                c.Close();

            }
            else
            {
                MessageBox.Show("Fill both fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (comboBox1.Text == "Admin")
            {
                Sclass.name = textBox1.Text;
                Sclass.ut = "Admin";
                this.Hide();
                Form2 f = new Form2();
                f.Show();

            }
            else if (comboBox1.Text == "Rescuer")
            {
                Sclass.ut = "Rescuer";
                Sclass.name = textBox1.Text;
                this.Hide();
                Form6 f = new Form6();
                f.Show();

            }
            else if (comboBox1.Text == "Adopter")
            {
                Sclass.ut = "Adopter";
                Sclass.name = textBox1.Text;
                this.Hide();
                Form8 f = new Form8();
                f.Show();

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f = new Form3();
            f.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form21 f = new Form21();
            f.Show();
        }

    }
    static class Sclass
    {
        public static string name;
        public static string rname;
        public static string ut;
    }
}
