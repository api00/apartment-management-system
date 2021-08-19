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

    public partial class AD3 : Form
    {
        string s = ConfigurationManager.ConnectionStrings["aprtmentdb"].ConnectionString;
        public AD3()
        {
            InitializeComponent();
            BindGridGrive();
        }

        private void btnAddS_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(s);
            String query = "Insert into staff_details values (@staff_id,@staff_name,@phone,@address,@joining,@nid,@post,@salary)";
            SqlCommand sqc = new SqlCommand(query, sc);
            sqc.Parameters.AddWithValue("@staff_id", txtSID.Text);
            sqc.Parameters.AddWithValue("@staff_name", textBox4.Text);
            sqc.Parameters.AddWithValue("@phone", textBox2.Text);
            sqc.Parameters.AddWithValue("@address", textBox1.Text);
            sqc.Parameters.AddWithValue("@joining", dtpSjoining.Text);
            sqc.Parameters.AddWithValue("@nid", textBox3.Text);
            sqc.Parameters.AddWithValue("@post", cmbPost.Text);
            sqc.Parameters.AddWithValue("@salary", cmbSsalary.Text);

            sc.Open();
            int a = sqc.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Sccessfully Added!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                resetcontrol();
                BindGridGrive();
            }
            else
            {
                MessageBox.Show("Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            sc.Close();
        }

        private void resetcontrol()
        {
            txtSID.Clear();
            textBox4.Clear();
            textBox2.Clear();
            textBox1.Clear();
            textBox3.Clear();
            dtpSjoining.ResetText();
            cmbSsalary.ResetText();
            cmbPost.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection sc = new SqlConnection(s);
            //String query = "update staff_details set staff_name=@staff_name,phone=@phn,address=@address,joining=@joining,nid=@nid,post=@post,salary=@salary where staff_id=@staff_id";
            //SqlCommand sqc = new SqlCommand(query, sc);
            //sqc.Parameters.AddWithValue("@staff_id", txtSID.Text);
            //sqc.Parameters.AddWithValue("@staff_name", textBox4.Text);
            //sqc.Parameters.AddWithValue("@phone", textBox2.Text);
            //sqc.Parameters.AddWithValue("@address", textBox1.Text);
            //sqc.Parameters.AddWithValue("@joining", dtpSjoining.Text);
            //sqc.Parameters.AddWithValue("@nid", textBox3.Text);
            //sqc.Parameters.AddWithValue("@post", cmbPost.Text);
            //sqc.Parameters.AddWithValue("@salary", cmbSsalary.Text);

            //sc.Open();
            //int a = sqc.ExecuteNonQuery();
            //if (a > 0)
            //{
            //    MessageBox.Show("Sccessfully updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    resetcontrol();
            //    BindGridGrive();
            //}
            //else
            //{
            //    MessageBox.Show("Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //sc.Close();
        }

        public void BindGridGrive(string query = "Select * from staff_details")
        {
            SqlConnection sc = new SqlConnection(s);
          
            SqlDataAdapter sda = new SqlDataAdapter(query, s);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 65;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //txtSID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //textBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //dtpSjoining.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            //textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //cmbPost.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            //cmbSsalary.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            //txtSID.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void AD3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            txtSID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            dtpSjoining.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            cmbPost.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            cmbSsalary.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            txtSID.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(s);
            String query = "update staff_details set staff_name=@staff_name,phone=@phone,address=@address,joining=@joining,nid=@nid,post=@post,salary=@salary where staff_id=@staff_id";
            SqlCommand sqc = new SqlCommand(query, sc);
            sqc.Parameters.AddWithValue("@staff_id", txtSID.Text);
            sqc.Parameters.AddWithValue("@staff_name", textBox4.Text);
            sqc.Parameters.AddWithValue("@phone", textBox2.Text);
            sqc.Parameters.AddWithValue("@address", textBox1.Text);
            sqc.Parameters.AddWithValue("@joining", dtpSjoining.Text);
            sqc.Parameters.AddWithValue("@nid", textBox3.Text);
            sqc.Parameters.AddWithValue("@post", cmbPost.Text);
            sqc.Parameters.AddWithValue("@salary", cmbSsalary.Text);

            sc.Open();
            int a = sqc.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Sccessfully updated!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                resetcontrol();
                BindGridGrive();
            }
            else
            {
                MessageBox.Show("Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            sc.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(s);
            String query = "Delete from staff_details where staff_id=@staff_id";
            SqlCommand sqc = new SqlCommand(query, sc);
            sqc.Parameters.AddWithValue("@staff_id", txtSID.Text);

            sc.Open();
            int a = sqc.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Sccessfully Removed!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                resetcontrol();
                BindGridGrive();
            }
            else
            {
                MessageBox.Show("Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            sc.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin m = new admin();
            m.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select * from staff_Details where post like '" + this.comboBox1.Text + "%' ";
            this.BindGridGrive(query);
        }
    }
}
