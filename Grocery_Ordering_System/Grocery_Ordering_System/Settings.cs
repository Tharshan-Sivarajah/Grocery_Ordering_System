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
    public partial class Settings : Form
    {
        public Settings()
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

            string sql = "select  * from admin_user";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

        }

        void clearall()
        {
            s1.Clear();
            s2.Clear();
            s3.Clear();
            search.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin frm = new Admin();
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql = "insert into admin_user values('" + s1.Text + "','" + s2.Text + "','" + s3.Text + "')";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin Successfully Added");
              dataview();
              clearall();

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
                con.Open();

                // foreignkey how to update(studep)

                string sql = "update admin_user set password='" + s2.Text + "',Name='" + s3.Text + "' where user_id='" + s1.Text + "'";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Admin Updated Successfully");

                dataview();
                clearall();
                
                con.Close();

          }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }
            con.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            s1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            s2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            s3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql = "delete from admin_user where user_id='" + s1.Text + "' ";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully deleted", "confirmation");
                dataview();
                clearall();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }

            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            clearall();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = "select * from admin_user where user_id like '%" + search.Text + "%' or Name like '%" + search.Text + "%'  or password like '%" + search.Text + "%' ";

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

        private void search_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string sql = "select * from admin_user where user_id like '%" + search.Text + "%' or Name like '%" + search.Text + "%' ";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);

                DataTable dt = new DataTable();

                da.Fill(dt);


                dataGridView1.DataSource = dt;
               // c1.Clear();
                //c2.Clear();
                //c3.Clear();

                //c1.Focus();
                // clearall();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
    }
}
