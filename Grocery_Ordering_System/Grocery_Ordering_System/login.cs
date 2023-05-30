using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Grocery_Ordering_System
{
    public partial class login : Form
    {
        MySqlConnection con;

        void dbcon()
        {
            try
            {
                con = new MySqlConnection("server=localhost;user=root;pwd=;database=grocery");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public login()
        {
            InitializeComponent();
            dbcon();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
         

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Are you a 'CUSTOMER' or 'ADMIN' ?");
            }
            else
            {


                        if (comboBox1.SelectedItem == "Admin")
                        {


                            string sql = "select * from admin_user where user_id = '" + textBox1.Text + "' and password ='" + textBox2.Text + "' ";

                            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                                    if ((dt.Rows.Count) != 0)
                                    {
                                        Admin f3 = new Admin();
                                        this.Hide();
                                        f3.Show();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Wrong UserID or Password....");
                                    }

                        }

                        else
                        {
                            string sql = "select * from customer where cus_id = '" + textBox1.Text + "' ";

                            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                                    if ((dt.Rows.Count) != 0)
                                    {
                                        sales_customer f3 = new sales_customer();
                                        this.Hide();
                                        f3.Show();
                                       
                                        f3.cusid.Text = textBox1.Text;  //text parse

                                    }
                                    else
                                    {
                                        MessageBox.Show("Wrong UserID....");
                                    }
                        }

            }

           
          
        }

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            New_Customer_Reg f4 = new New_Customer_Reg();

            this.Hide();
            f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = string.Empty;
            textBox1.Clear();
            textBox2.Clear();
            checkBox1.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
          if (MessageBox.Show("Do you want to Exit ???", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {
                Application.Exit();
           }
              
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Customer")
            {
                textBox2.Visible = false;
                label4.Visible = false;
                checkBox1.Visible = false;
            }
            else
            {
                textBox2.Visible = true;
                label4.Visible = true;
                checkBox1.Visible = true;
            }
        }
    }
}
