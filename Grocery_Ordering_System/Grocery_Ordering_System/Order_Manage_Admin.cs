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
    public partial class Order_Manage_Admin : Form
    {
        public Order_Manage_Admin()
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

            string sql = "select  * from orders";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

        }


        private void Order_Manage_Admin_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            o1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            o2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            // dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            o3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            op.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            o4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            o5.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void o2_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from orders where  cus_id like '%" + o2.Text + "%' ";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);

            DataTable dt = new DataTable();

            da.Fill(dt);


            dataGridView1.DataSource = dt;
        }

        void clear()
        {
            o1.Clear();
            o3.Clear();
            o5.Clear();
            o4.Clear();
            op.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            dataview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            string sql = "update orders set quantity ='" + o4.Text + "',total_price ='" + o5.Text + "' where order_no='" + o1.Text + "'";

            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.ExecuteNonQuery();

            dataview();

            MessageBox.Show(" Updated Successfully....");

            clear();


            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "delete from orders where order_no='" + o1.Text + "' ";

            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.ExecuteNonQuery();

            dataview();

            MessageBox.Show("Successfully deleted....");

            clear();

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Sales f = new Admin_Sales();
            f.Show();
            this.Hide();
            //f.cusid.Text = o2.Text;
        }

        private void o4_TextChanged(object sender, EventArgs e)
        {
            if (o4.Text == "")
            {
                o4.Text = "0";
            }

            int p = int.Parse(op.Text);
            int q = int.Parse(o4.Text);
            int total = p * q;

            o5.Text = total.ToString();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin f = new Admin();
            f.Show();
            this.Hide();
        }
    }
}
