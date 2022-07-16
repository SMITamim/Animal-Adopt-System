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
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form10 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form10()
        {
            InitializeComponent();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) == true)
            {
                comboBox1.Focus();
                errorProvider1.SetError(this.comboBox1, "* Required");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text) == true)
            {
                richTextBox1.Focus();
                errorProvider2.SetError(this.richTextBox1, "*Required");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void richTextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox2.Text) == true)
            {
                richTextBox2.Focus();
                errorProvider3.SetError(this.richTextBox2, "*Required");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";

            ofd.Filter = "Image File (All files) *.* | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into animal_info values(@TP,@AD,@RS,@img,@rname)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TP", comboBox1.Text);
            cmd.Parameters.AddWithValue("@AD", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@RS", richTextBox2.Text);
            cmd.Parameters.AddWithValue("@img", SavePhoto());
            cmd.Parameters.AddWithValue("@rname", Sclass.name);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Inserted Successfully ! ");
                // BindGridView();
                //ResetContro();
            }
            else
            {
                MessageBox.Show("Data not Inserted ! ");
            }
            this.Hide();
            Form9 f = new Form9();
            f.Show();
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f = new Form6();
            f.Show();
        }
    }
}
