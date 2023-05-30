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
    public partial class New_Customer_Reg : Form
    {
        public New_Customer_Reg()
        {
            InitializeComponent();
            dbcon();
         
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

      
       

        void clearall()
        {
            cname.Clear();
            cadd.Clear();
            ctell.Clear();
       
        }

        void refresh()
        {
            New_Customer_Reg cd = new New_Customer_Reg();
            cd.Show();
            this.Hide();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            login frm = new login();
            this.Hide();
            frm.Show();
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

            cid.Text = cusid.ToString();

        }

        private void New_Customer_Reg_Load(object sender, EventArgs e)
        {
            getcusid();
        }

        private void cid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (cname.Text != "" && cadd.Text != "" && ctell.Text != "" )
                {
                    con.Open();
                    string sql = "insert into customer values('" + cid.Text + "','" + cname.Text + "','" + cadd.Text + "','" + ctell.Text + "')";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.ExecuteNonQuery();

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

        private void button1_Click(object sender, EventArgs e)
        {
            clearall();
        }
    }
}
