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
    public partial class Form12 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form12()
        {
            InitializeComponent();
            BindGridView();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Apply_adopt where R_NAME='"+Sclass.name+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            ///Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Hide();
                Form6 f = new Form6();
                f.Show();
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //richTextBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[6].Value);
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();//new
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "insert into ACCEPT values(@NAME,@JOB,@PH,@HA,@EMAIL,@EXP,@NID,@rname,@aname)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NAME", textBox1.Text + textBox2.Text);
            cmd.Parameters.AddWithValue("@JOB", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH", textBox4.Text);
            cmd.Parameters.AddWithValue("@HA", textBox5.Text);
            cmd.Parameters.AddWithValue("@EMAIL", textBox6.Text);
            cmd.Parameters.AddWithValue("@EXP", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@NID", SavePhoto());
            cmd.Parameters.AddWithValue("@rname", Sclass.name);
            cmd.Parameters.AddWithValue("@aname", textBox7.Text);//new

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
        }
        private byte[] SavePhoto()
        {

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into REJECT values(@NAME,@JOB,@PH,@HA,@EMAIL,@EXP,@NID,@rname,@aname)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NAME", textBox1.Text + textBox2.Text);
            cmd.Parameters.AddWithValue("@JOB", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH", textBox4.Text);
            cmd.Parameters.AddWithValue("@HA", textBox5.Text);
            cmd.Parameters.AddWithValue("@EMAIL", textBox6.Text);
            cmd.Parameters.AddWithValue("@EXP", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@NID", SavePhoto());
            cmd.Parameters.AddWithValue("@rname", Sclass.name);
            cmd.Parameters.AddWithValue("@aname", textBox7.Text);//new

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
        }
    }
}
