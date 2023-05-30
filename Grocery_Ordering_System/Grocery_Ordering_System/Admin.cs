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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Item_Details frm = new Item_Details();
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item_Details frm = new Item_Details();
            this.Hide();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Customer_Details frm = new Customer_Details();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Details frm = new Customer_Details();
            this.Hide();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Order_Details frm = new Order_Details();
           
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order_Details frm = new Order_Details();

            this.Hide();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Settings  frm = new Settings  ();
            this.Hide();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Settings frm = new Settings();
            this.Hide();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            login frm = new login();
            this.Hide();
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
      

        private void button12_Click_1(object sender, EventArgs e)
        {
            
            Admin_Sales f=new Admin_Sales();
            this.Hide();
            f.Show();

            


        }

        private void button11_Click(object sender, EventArgs e)
        {
            Admin_Sales f = new Admin_Sales();
            this.Hide();
            f.Show();
        }
    }
}
