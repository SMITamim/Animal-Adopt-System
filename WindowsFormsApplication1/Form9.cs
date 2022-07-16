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
    public partial class Form9 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form9()
        {
            InitializeComponent();
            BindGridView();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from animal_info";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;


            ///Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[3];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Sclass.ut == "Admin") 
            {
                Form2 f = new Form2();
                f.Show();
            }
            else if (Sclass.ut == "Adopter")
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
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            richTextBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[3].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sclass.rname = textBox1.Text;
            this.Hide();
            Form11 f = new Form11();
            f.Show();
        }
    }
}
