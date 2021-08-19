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
    public partial class AD4 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["aprtmentdb"].ConnectionString;

        public AD4()
        {
            InitializeComponent();
            BindGridGrive();
            BindGridGrived1();
            BindGridGrived2();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            admin mn = new admin();
            mn.Show();
            this.Hide();
        }

        private void AD4_Load(object sender, EventArgs e)
        {

        }
        void BindGridGrive(string query = "select * from bill_details")
        {
            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter sda = new SqlDataAdapter(query, con);



            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView2.DataSource = data;



            //image column
            //DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            //dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            //dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //Autosize column
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  
        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
            
        }

        void BindGridGrived1()
        {
            SqlConnection con = new SqlConnection(cs);
            
            string query = "select sum(apartment_price) as TOTAL_ASSET from bill_details";
           
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
           



            DataTable data = new DataTable();
           
            sda.Fill(data);
           
            dataGridView1.DataSource = data;
           
            //Autosize column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image row hight
            dataGridView2.RowTemplate.Height = 30;



        }
        void BindGridGrived2()
        {
            SqlConnection con = new SqlConnection(cs);
           
           
            string query1 = "select (sum(apartment_price) - sum(advance_paid)) as DUE from bill_details";
            SqlDataAdapter sdab = new SqlDataAdapter(query1, con);



            DataTable data = new DataTable();
            sdab.Fill(data);
            dataGridView3.DataSource = data;
      
            //Autosize column
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image row hight
            dataGridView3.RowTemplate.Height = 30;



        }

      



        //void BindGridGrive(string query = "select * from bill_details")
        //{
        //    SqlConnection con = new SqlConnection(cs);

        //    SqlDataAdapter sda = new SqlDataAdapter(query, con);



        //    DataTable data = new DataTable();
        //    sda.Fill(data);
        //    dataGridView1.DataSource = data;



        //    //image column
        //    //DataGridViewImageColumn dgv = new DataGridViewImageColumn();
        //    //dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
        //    //dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

        //    //Autosize column
        //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //}
    }
}
