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
    public partial class Userpage : Form
    {
        public String query,s1,s5;
        public Userpage(String str)
        {
            InitializeComponent();
            query = "'" + str + "'";
            s5 = str;
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select name from login where username="+query+"", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s1 = dr.GetString(0).ToString();
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            sperformance3 s3 = new sperformance3(s1,s5);
            s3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test t1 = new Test(s1,s5);
            t1.Show();
            this.Hide();
        }
    }
}
