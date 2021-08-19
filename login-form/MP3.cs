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
    public partial class MP3 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["aprtmentdb"].ConnectionString;
        public MP3()
        {
            InitializeComponent();
            BindGridGrive();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            manager mn = new manager();
            mn.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlConnection cons = new SqlConnection(cs);
            SqlConnection conx = new SqlConnection(cs);
            string query = "insert into customer_details values (@customer_id,@customer_name,@apartment_no,@phone,@nid,@customer_picture)";
            string query2 = "update apartment_details set customer_id=@customer_id,status='Booked' where apartment_no=@apartment_no";
            string query3 = "update  bill_details set bill_no=@bill_no,advance_paid=@advance_paid,total_bill=@total_bill,customer_name=@customer_name where @apartment_no=apartment_no ";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlCommand cmda = new SqlCommand(query2, cons);
            SqlCommand cmdb = new SqlCommand(query3, conx);

            cmd.Parameters.AddWithValue("@customer_id",IDcomboBox.Text.ToString());
            cmd.Parameters.AddWithValue("@customer_name",textBox3.Text);
            cmd.Parameters.AddWithValue("@apartment_no", textBox4.Text);
            cmd.Parameters.AddWithValue("@phone", textBox5.Text);
            cmd.Parameters.AddWithValue("@nid",numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@customer_picture", SavePhoto());

            cmda.Parameters.AddWithValue("@apartment_no", textBox4.Text);
            cmda.Parameters.AddWithValue("@customer_id", IDcomboBox.Text);

            cmdb.Parameters.AddWithValue("@bill_no", textBox1.Text);
            cmdb.Parameters.AddWithValue("@advance_paid", textBox2.Text);
            cmdb.Parameters.AddWithValue("@total_bill", textBox6.Text);
            cmdb.Parameters.AddWithValue("@apartment_no", textBox4.Text);
            cmdb.Parameters.AddWithValue("@customer_name", textBox3.Text);

            con.Open();
            cons.Open();
            conx.Open();
            int a = cmd.ExecuteNonQuery();
            int B = cmda.ExecuteNonQuery();
            int c = cmdb.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show("Data inserted successfully!");
                BindGridGrive();

             
               // cons.Open();
               
                //if (B > 0)
                //{
                //}


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
        void BindGridGrive(string query = "select * from customer_details")
        {
            SqlConnection con = new SqlConnection(cs);
          
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
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
           // numericUpDown1.Clear();
            pictureBox1.Image = Properties.Resources.download__1_;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private Image GetImage(byte[] image)
        {
            MemoryStream ms = new MemoryStream(image);
            return Image.FromStream(ms);
        }

        private void MP3_Load(object sender, EventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

          
            SqlConnection cons = new SqlConnection(cs);

            string query2 = "update customer_details set customer_name=@customer_name,apartment_no=@apartment_no,phone=@phone,nid=@nid where customer_id=@customer_id ";

            SqlCommand cmd = new SqlCommand(query2, cons);
          

            cmd.Parameters.AddWithValue("@customer_id",IDcomboBox.Text.ToString());
            cmd.Parameters.AddWithValue("@customer_name",textBox3.Text);
            cmd.Parameters.AddWithValue("@apartment_no", textBox4.Text);
            cmd.Parameters.AddWithValue("@phone", textBox5.Text);
            cmd.Parameters.AddWithValue("@nid",numericUpDown1.Value);
           // cmd.Parameters.AddWithValue("@customer_picture", SavePhoto());



            cons.Open();
            
            int a = cmd.ExecuteNonQuery();
         
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
            {
                MessageBox.Show("Data updated successfully!");
                BindGridGrive();

             
               // cons.Open();
               
                //if (B > 0)
                //{
                //}


                Reset();




            }
            else
            {
                MessageBox.Show("data not insert");
            }
            cons.Close();
        
          
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            IDcomboBox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            numericUpDown1.Maximum = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value);
            //pictureBox1.Image = GetImage((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
           // pictureBox1.Image = GetImage((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from customer_details where customer_id=@customer_id";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@customer_id", IDcomboBox.Text.ToString());

            con.Open();
            int a = cmd.ExecuteNonQuery();
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

        private void UniversalSearch_TextChanged(object sender, EventArgs e)
        {
              string query = "select * from customer_details where customer_name like '" + this.UniversalSearch.Text + "%' ";
            this.BindGridGrive(query);
        }

      

    }
}
