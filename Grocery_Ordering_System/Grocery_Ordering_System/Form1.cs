using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grocery_Ordering_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        int startpos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 1;
            progressBar1.Value = startpos;

            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();

                login f=new login();
                f.Show();
                this.Hide();

            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
