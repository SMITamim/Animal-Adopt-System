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
    public partial class Form11 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form11()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "* Required");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox3_Leave(object sender, System.EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider2.SetError(this.textBox3, "*Required");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox4_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider3.SetError(this.textBox4, "*Required");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox5_Leave(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider4.SetError(this.textBox5, "*Required");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";

            ofd.Filter = "Image File (All files) *.* | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }
        private byte[] SavePhoto()
        {

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "insert into Apply_adopt values(@NAME,@JOB,@PH,@HA,@EMAIL,@EXP,@NID,@rname,@aname)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NAME", textBox1.Text + textBox2.Text);
            cmd.Parameters.AddWithValue("@JOB", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH", textBox4.Text);
            cmd.Parameters.AddWithValue("@HA", textBox5.Text);
            cmd.Parameters.AddWithValue("@EMAIL", textBox6.Text);
            cmd.Parameters.AddWithValue("@EXP", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@NID", SavePhoto());
            cmd.Parameters.AddWithValue("@rname", Sclass.rname);
            cmd.Parameters.AddWithValue("@aname", Sclass.name);//new

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Inserted Successfully ! ");
                // BindGridView();
                //ResetContro();
                this.Hide();
                Form8 f = new Form8();
                f.Show();
            }
            else
            {
                MessageBox.Show("Data not Inserted ! ");
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Form8 f = new Form8();
            f.Show();
        }
    }
}
