using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_form
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AD2 ad2 = new AD2();
            ad2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AD3 ad3 = new AD3();
            ad3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AD4 ad4 = new AD4();
            ad4.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 a1 = new Form1();
            a1.Visible = true;
            this.Visible = false;
        }
    }
}
