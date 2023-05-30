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
    public partial class Item_Details : Form
    {
        public Item_Details()
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

        void clearall()
        {
            i1.Clear();
            i2.Clear();
            i3.Clear();
            i5.Clear();
            isearch.Clear();

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

                if (i1.Text != "" && i2.Text != "" && i3.Text != "" && i5.Text != "")
                {
                    con.Open();
                    string sql = "insert into item values('" + i1.Text + "','" + i2.Text + "','" + i3.Text + "','" + i5.Text + "')";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.ExecuteNonQuery();

                    dataview();

                    MessageBox.Show("Item Successfully Added....");

                    clearall();
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
                if (i1.Text != "" || i2.Text != "" || i3.Text != "" || i5.Text != "")

                {

                con.Open();



                string sql = "update item set item_name='" + i1.Text + "',price='" + i3.Text + "',per='" + i5.Text + "' where item_id='" + i2.Text + "'";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.ExecuteNonQuery();

                dataview();

                MessageBox.Show("Item Updated Successfully....");
               
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
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            i1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            i2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            i3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            i5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (i1.Text != "" || i2.Text != "" || i3.Text != "" || i5.Text != "")
                {

                    con.Open();
                    string sql = "delete from item where item_id='" + i2.Text + "' ";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.ExecuteNonQuery();

                    dataview();

                    MessageBox.Show("Item deleted successfully.... ", "confirmation");

                    clearall();
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

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i1.Clear();
            i2.Clear();
            i3.Clear();
            i5.Clear();
            isearch.Clear();

            i1.Focus();
        }

        private void isearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string sql = "select * from item where item_name like '%" + isearch.Text + "%' or item_id like '%" + isearch.Text + "%' ";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
