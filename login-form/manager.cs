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
    public partial class manager : Form
    {
        public manager()
        {
            InitializeComponent();
        }

        private void Manager_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MP2 mp2 = new MP2();
            mp2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MP3 mp3 = new MP3();
            mp3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MP4 mp4 = new MP4();
            mp4.Show();
            this.Hide();
        }

        private void manager_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 a1 = new Form1();
            a1.Visible = true;
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MP0 m = new MP0();
            m.Show();
            this.Hide();
        }
    }
}
