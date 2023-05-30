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
    public partial class Order_Details : Form
    {
        public Order_Details()
        {
            InitializeComponent();
            dbcon();
            dataviewcustomer();
            datavieworder();
        }


        MySqlConnection con;

        void dbcon()
        {
            try
            {
                con = new MySqlConnection("server=localhost;user=root;pwd=;database=grocery");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void dataviewcustomer()
        {

            string sql = "select  * from customer";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView2.DataSource = dt;

        }

        void datavieworder()
        {

            string sql = "select  * from orders";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

        }

        void clearall()
        {
            o1.Clear();
            o2.Clear();
           
            osearch.Clear();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Admin frm = new Admin();
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (o1.Text != "" && o2.Text != "" )
                {

                    con.Open();
                    string sql = "insert into ordertbl values('" + o1.Text + "','" + o2.Text + "')";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.ExecuteNonQuery();
                    datavieworder();

                    MessageBox.Show("Order Added Successfully.... ");
                   
                    clearall();
                }
                
                 else
                {
                    MessageBox.Show("Fill the data properly....");

                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (o1.Text != "" || o2.Text != ""  )
                {
                    con.Open();



                    string sql = "update orders set cus_id='" + o2.Text + "' where order_no='" + o1.Text + "'";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.ExecuteNonQuery();

                    datavieworder();

                    MessageBox.Show(" Updated Successfully....");
                   
                    clearall();

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Fill the data properly....");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }
            con.Close();
        }

        private void o2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string sql = "select * from customer where cus_id like '%" + o2.Text + "%' ";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);

                DataTable dt = new DataTable();

                da.Fill(dt);


                dataGridView2.DataSource = dt;

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (o1.Text != "" || o2.Text != "" )
                {

                    con.Open();
                    string sql = "delete from orders where order_no='" + o1.Text + "' ";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.ExecuteNonQuery();

                    datavieworder();

                    MessageBox.Show("Successfully deleted....");
                   
                    clearall();
                }
                else
                {
                    MessageBox.Show("Fill the data properly....");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            o1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            o2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void osearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string sql = "select * from orders where  Date like '%"+ osearch.Text +"%' ";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);

                DataTable dt = new DataTable();

                da.Fill(dt);


                dataGridView1.DataSource = dt;

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void Order_Details_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            try
            {

                string sql = "select * from orders where  cus_id like '%" + textBox2.Text + "%' ";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);

                DataTable dt = new DataTable();

                da.Fill(dt);


                dataGridView1.DataSource = dt;

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


                 try
            {

                string sql = "select * from orders where  Order_no like '%" + textBox1.Text + "%' ";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);

                DataTable dt = new DataTable();

                da.Fill(dt);


                dataGridView1.DataSource = dt;

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }
    }
}
