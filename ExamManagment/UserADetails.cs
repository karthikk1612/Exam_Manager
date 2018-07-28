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
    public partial class UserADetails : Form
    {
        public String str;
        public UserADetails()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select name from login where name IS NOT NULL and name <> ''; ", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            foreach (DataRow name in dt.Rows)
            {
                listBox1.Items.Add(name.Field<String>(0));
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Text.ToString() != null)
            {


                SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
                conn.Open();
                str = "'" + listBox1.Text.ToString() + "'";
                listBox1.Items.Remove(listBox1.SelectedItem);
                SqlCommand cmd = new SqlCommand(@"update login set name=NULL,username=NULL,password=NULL,Age=NULL,address=NULL,phno=NULL,status=NULL where name=" + str + ";", conn);
                cmd.ExecuteNonQuery();
                listBox1.Items.Remove(str);
                conn.Close();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewADetails v1 = new viewADetails(listBox1.Text);
            v1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminPage a1 = new AdminPage();
            a1.Show();
            this.Hide();
        }
    }
}
