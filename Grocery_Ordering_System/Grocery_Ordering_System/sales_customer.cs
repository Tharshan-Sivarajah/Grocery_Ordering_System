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
    public partial class sales_customer : Form
    {
        public sales_customer()
        {
            InitializeComponent();
            dbcon();
            dataview();
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

        void dataview()
        {

            string sql = "select  * from item";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

        }
       
        private void sales_customer_Load(object sender, EventArgs e)
        {
            

            string order_no;
            string sql = "select order_no from orders order by order_no Desc";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                order_no = id.ToString("0000");

            }
            else if (Convert.IsDBNull(dr))
            {
                order_no = ("0001");
            }
            else
            {
                order_no = ("0001");
            }

            con.Close();

            orderNo.Text = order_no.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            nm.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            pr.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void qua_TextChanged(object sender, EventArgs e)
        {
            if (qua.Text == "")
            {
                qua.Text = "0";
            }

            int p = int.Parse(pr.Text);
            int q = int.Parse(qua.Text);
            int total = p*q;

            tot.Text = total.ToString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nm.Clear();
            pr.Text="0";
            qua.Text="0";
            tot.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login f = new login();
            this.Hide();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (qua.Text != "" && nm.Text!="" )
                {
                    con.Open();
                    string sql = "insert into orders values('" + orderNo.Text + "','" + cusid.Text + "','" + dateTimePicker1.Text + "','" + nm.Text + "','" + pr.Text + "','" + qua.Text + "','" + tot.Text + "')";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.ExecuteNonQuery();

                    

                    MessageBox.Show("Order Successfully Added....");

                    sales_customer f = new sales_customer();
                    this.Hide();
                        f.Show();
                        f.cusid.Text = cusid.Text;  //text parse

                    
                }
                else
                {
                    MessageBox.Show("Select the Item and Enter the Quantity....");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void cusid_TextChanged(object sender, EventArgs e)
        {

        }

        private void pr_TextChanged(object sender, EventArgs e)
        {
            if (pr.Text == "")
            {
                pr.Text = "0";
            }
        }

        private void tot_TextChanged(object sender, EventArgs e)
        {
            if (tot.Text == "")
            {
                tot.Text = "0";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Order_Management f = new Order_Management();
            f.Show();
            this.Hide();
            f.o2.Text = cusid.Text;
        }
    }
}