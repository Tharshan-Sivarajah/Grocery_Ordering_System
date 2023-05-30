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
    public partial class Customer_Details : Form
    {
        public Customer_Details()
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

            string sql = "select  * from customer";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            clearall();

        }

        void clearall()
        {
            c1.Clear();
            c2.Clear();
            c3.Clear();
           
            c1.Focus();
           

        }

        void refresh()
        {
            Customer_Details cd = new Customer_Details();
            cd.Show();
            this.Hide();
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

                if (c1.Text != "" && c2.Text != "" && c3.Text != "" && c4.Text != "")
                {
                    con.Open();
                    string sql = "insert into customer values('" + c4.Text + "','" + c1.Text + "','" + c2.Text + "','" + c3.Text + "')";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.ExecuteNonQuery();

                    dataview();

                    MessageBox.Show("Customer Successfully Added....");

                    refresh();
                  
                }
                else
                {
                    MessageBox.Show("Fill the data properly....");
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (c1.Text != "" && c2.Text != "" && c3.Text != "" && c4.Text != "")
                {

                    con.Open();



                    string sql = "update customer set cus_name='" + c1.Text + "',address='" + c2.Text + "',tell_no='" + c3.Text + "' where cus_id='" + c4.Text + "'";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.ExecuteNonQuery();

                    dataview();

                    MessageBox.Show("customer Updated Successfully....");

                    refresh();

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Fill the data properly....");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (c4.Text != "")
                {

                    con.Open();
                    string sql = "delete from customer where cus_id='" + c4.Text + "' ";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.ExecuteNonQuery();

                    dataview();

                    MessageBox.Show("customer deleted successfully.... ", "confirmation");

                    refresh();
                }
                else
                {
                    MessageBox.Show("Fill the data properly....");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void csearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string sql = "select * from customer where cus_id like '%" + csearch.Text + "%' or cus_name like '%" + csearch.Text + "%' ";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);

                DataTable dt = new DataTable();

                da.Fill(dt);


                dataGridView1.DataSource = dt;
                c1.Clear();
                c2.Clear();
                c3.Clear();

                //c1.Focus();
               // clearall();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            c4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            c1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            c2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            c3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


        }


        public void getcusid()
        {
            string cusid;
            string sql = "select cus_id from customer order by cus_id Desc";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                cusid = id.ToString("0000");

            }
            else if (Convert.IsDBNull(dr))
            {
                cusid = ("0001");
            }
            else
            {
                cusid = ("0001");
            }

            con.Close();

            c4.Text = cusid.ToString();

        }


        private void Customer_Details_Load(object sender, EventArgs e)
        {
            dataview();
            getcusid();
        }
    }
}
