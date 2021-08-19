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



namespace login_form
{
    public partial class MP2 : Form

    {
                string cs = ConfigurationManager.ConnectionStrings["aprtmentdb"].ConnectionString;

        public MP2()
        {
            InitializeComponent();
            BindGridGrive();
           
        }

        private void dGVman_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            manager mn = new manager();
            mn.Show();
            this.Hide();
        }

        private void MP2_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlConnection cons = new SqlConnection(cs);
            string query = "insert into apartment_details (apartment_name,apartment_no,apartment_size,apartment_price,apartment_location,apartment_picture) values (@apartment_name,@apartment_no,@apartment_size,@apartment_price,@apartment_location,@apartment_picture)";
            string query1 = "insert into bill_details (apartment_no,apartment_price) values (@apartment_no,@apartment_price)";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmda = new SqlCommand(query1, cons);
            cmd.Parameters.AddWithValue("@apartment_name", txt1.Text);
            cmd.Parameters.AddWithValue("@apartment_no", txt2.Text);
            cmd.Parameters.AddWithValue("@apartment_size", txt3.Text);
            cmd.Parameters.AddWithValue("@apartment_price", txt4.Text);
            cmd.Parameters.AddWithValue("@apartment_location",txt5.Text);
            cmd.Parameters.AddWithValue("@apartment_picture",SavePhoto());

            cmda.Parameters.AddWithValue("@apartment_no", txt2.Text);
            cmda.Parameters.AddWithValue("@apartment_price", txt4.Text);

            con.Open();
            cons.Open();
            int a = cmd.ExecuteNonQuery();
            int b = cmda.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (b > 0)
            {
                MessageBox.Show("Data inserted successfully!");
               BindGridGrive();
               Reset();




            }
            else
            {
                MessageBox.Show("data not insert");
            }
            con.Close();
        }

        private byte[] SavePhoto()
        {
            //  throw new NotImplementedException();
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            // pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select image";
            ofd.Filter = "All image file *.*) | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);



            }
        }
        void BindGridGrive()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from apartment_details";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);



            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;



            //image column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;



            //Autosize column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image row hight
            dataGridView1.RowTemplate.Height = 50;



        }
        void Reset()
        {
            txt1.Clear();
            txt2.Clear();
            txt3.Clear();
            txt4.Clear();
            txt5.Clear();
            pictureBox1.Image = Properties.Resources.img2;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            txt1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            pictureBox1.Image = GetImage((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
        }

        private Image GetImage(byte[] image)
        {
            MemoryStream ms = new MemoryStream(image);
            return Image.FromStream(ms);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update apartment_details set apartment_name=@apartment_name,apartment_no=@apartment_no,apartment_size=@apartment_size,apartment_price=@apartment_price,apartment_location=@apartment_location,apartment_picture=@apartment_picture where apartment_no=@apartment_no";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@apartment_name", txt1.Text);
            cmd.Parameters.AddWithValue("@apartment_no", txt2.Text);
            cmd.Parameters.AddWithValue("@apartment_size", txt3.Text);
            cmd.Parameters.AddWithValue("@apartment_price", txt4.Text);
            cmd.Parameters.AddWithValue("@apartment_location", txt5.Text);
            cmd.Parameters.AddWithValue("@apartment_picture", SavePhoto());
            con.Open();
            int b = cmd.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (b > 0)
            {
                MessageBox.Show("Data Updated successfully!");
                BindGridGrive();
                Reset();




            }
            else
            {
                MessageBox.Show("data not updated");
            }
            con.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from apartment_details where apartment_no=@apartment_no";
            string query1 = "delete from bill_details where apartment_no=@apartment_no";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmdb = new SqlCommand(query1, con);
            
            cmd.Parameters.AddWithValue("@apartment_no", txt2.Text);
            cmdb.Parameters.AddWithValue("@apartment_no", txt2.Text);
        
            con.Open();
            int a = cmd.ExecuteNonQuery();
            int b = cmdb.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show(" Deleted successfully!");
                BindGridGrive();
                Reset();




            }
            else
            {
                MessageBox.Show("data not deleted");
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMShow_Click(object sender, EventArgs e)
        {
           
        }

      
    }
}
