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
    public partial class MP4 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["aprtmentdb"].ConnectionString;

        public MP4()
        {
            InitializeComponent();
            BindGridGrive();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            manager w = new manager();
            w.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MP4_Load(object sender, EventArgs e)
        {

        }
        void BindGridGrive( string query = "select * from bill_details")
        {
            SqlConnection con = new SqlConnection(cs);
           
            SqlDataAdapter sda = new SqlDataAdapter(query, con);



            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;



          



            //Autosize column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image row hight
            dataGridView1.RowTemplate.Height = 50;



        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ApartmentNocomboBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
          txt1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txt2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //pictureBox1.Image = GetImage((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            double hv = 0;
           // double rv = 0;
            string total = this.txt1.Text;
            var T = Convert.ToDouble(total);
            string advance = this.txt5.Text;
            var A = Convert.ToDouble(advance);
           // string npay = this.txtNPaid.Text;
           // var N = Convert.ToDouble(npay);
            hv = T - A;
           // rv = N - hv;
            txt4.Text = Convert.ToString(hv);
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UniversalSearch_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from bill_details where apartment_no like '" + this.UniversalSearch.Text + "%' ";
            this.BindGridGrive(query);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 100, y = 100; 
            int width = 80, height = 50;
          
           
         
            y += height + 30; //bottom padding

            var header = new Font("Calibri", 21, FontStyle.Bold);
            int hdy = (int)header.GetHeight(e.Graphics); //30; //line height 

            var fnt = new Font("Times new Roman", 14, FontStyle.Bold);
            int dy = (int)fnt.GetHeight(e.Graphics); //20; //line height spacing

            e.Graphics.DrawString("E-housing system", header, Brushes.Black, new PointF(x, y)); y += hdy + hdy + hdy;
            e.Graphics.DrawString("Apartment Number : " + ApartmentNocomboBox.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("Bill No : " + txt2.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("Total Amount : " + txt3.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("Advance Paid : " + txt5.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("Extra Cost : " + textBox5.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("Have to Pay : " + txt4.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            
        }
    }
}
