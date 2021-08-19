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
    public partial class AD2 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["aprtmentdb"].ConnectionString;

        public AD2()
        {
            InitializeComponent();
            BindGridGrive();
        }

        private void dtpMjoining_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dGVman_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AD2_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            admin mn = new admin();
            mn.Show();
            this.Hide();
        }

        private void btnAddS_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlConnection cons = new SqlConnection(cs);
            string query = "insert into manager_details (manager_id,manager_name,address,phone_no,joining_date,nid,salary) values(@manager_id,@manager_name,@address,@phone_no,@joining_date,@nid,@salary) ";
          //  string query1 = "insert into bill_details (apartment_no,apartment_price) values (@apartment_no,@apartment_price)";
            SqlCommand cmd = new SqlCommand(query, con);
         //   int x = Convert.ToInt32(dtpMjoining.tex)
          //  SqlCommand cmda = new SqlCommand(query1, cons);
            cmd.Parameters.AddWithValue("@manager_id",txtID.Text);
            cmd.Parameters.AddWithValue("@manager_name",txtMName.Text);
            cmd.Parameters.AddWithValue("@address",txtMAdd.Text);
            cmd.Parameters.AddWithValue("@phone_no",txtMPhone.Text);
            cmd.Parameters.AddWithValue("@joining_date",dtpMjoining.Text);
            cmd.Parameters.AddWithValue("@nid",txtMnid.Text);
            cmd.Parameters.AddWithValue("@salary",txtMsalary.Text);
            //cmd.Parameters.AddWithValue("@apartment_picture", SavePhoto());

           // cmda.Parameters.AddWithValue("@apartment_no", txt2.Text);
            //cmda.Parameters.AddWithValue("@apartment_price", txt4.Text);

            con.Open();
           // cons.Open();
            int a = cmd.ExecuteNonQuery();
           // int b = cmda.ExecuteNonQuery();
            //SqlDataReader dr = cmd.ExecuteReader();
            if (a > 0)
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

        void BindGridGrive(string query = "select * from manager_details")
        {
            SqlConnection con = new SqlConnection(cs);
            
            SqlDataAdapter sda = new SqlDataAdapter(query, con);



            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;



            //image column
            //DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            //dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            //dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;



            //Autosize column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image row hight
            dataGridView1.RowTemplate.Height = 50;



        }
        void Reset()
        {
            txtID.Clear();
            txtMName.Clear();
            txtMAdd.Clear();
            txtMPhone.Clear();
           // dtpMjoining.Clear();
            txtMnid.Clear();
            txtMsalary.Clear();
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtMName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtMAdd.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtMPhone.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            dtpMjoining.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtMnid.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtMsalary.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from manager_details where manager_id=@manager_id";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@manager_id", txtID.Text);

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

        private void btnMShow_Click(object sender, EventArgs e)
        {

        }

        private void txtMIDsearch_TextChanged(object sender, EventArgs e)
        {
            
            string query = "select * from manager_details where manager_name like '" + this.txtMIDsearch.Text + "%' ";
            this.BindGridGrive(query);
        }

       
    }
}
