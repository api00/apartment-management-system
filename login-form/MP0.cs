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
    public partial class MP0 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["aprtmentdb"].ConnectionString;
        public MP0()
        {
            InitializeComponent();
            BindGridGrive();
        }

        private void btnShow_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void BindGridGrive( string query = "select * from apartment_details")
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
            dataGridView1.RowTemplate.Height = 80;



        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            manager s = new manager();
            s.Show();
            this.Hide();
        }

        private void UniversalSearch_TextChanged(object sender, EventArgs e)
        {


            string query = "select * from apartment_details where apartment_name like '" + this.UniversalSearch.Text + "%' ";
            this.BindGridGrive(query);
           
              
        }

        private void MP0_Load(object sender, EventArgs e)
        {

        }



        
    
            
            
        

       

    }
}
