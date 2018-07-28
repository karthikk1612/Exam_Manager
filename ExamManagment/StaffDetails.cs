using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExamManagment
{

    public partial class StaffDetails : Form
             
    {
        public String str="";
        public StaffDetails()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select staffname from login where staffname IS NOT NULL and staffname <> ''; ", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            foreach (DataRow staffname in dt.Rows)
            {
                listBox1.Items.Add(staffname.Field<String>(0));
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminPage a1 = new AdminPage();
            a1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Text.ToString() != null)
            {


                SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
                conn.Open();
                String str = "'" + listBox1.Text.ToString() + "'";
                listBox1.Items.Remove(listBox1.SelectedItem);
                SqlCommand cmd = new SqlCommand(@"update login set staffname=NULL,staffusername=NULL,staffpass=NULL,staffcategory=NULL where staffname=" + str + ";", conn);
                cmd.ExecuteNonQuery();
                listBox1.Items.Remove(str);
                conn.Close();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Details d1 = new Details(listBox1.Text);
            
            d1.Show();
            this.Hide();
        }
    }
}
