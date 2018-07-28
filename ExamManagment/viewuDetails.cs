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
    public partial class viewuDetails : Form
    {
        public String s2,query;
        public viewuDetails(String str,String s5)
        {
            InitializeComponent();
            s2 = str;
            query = "'" + s5 + "'";
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select username,password,name,Age,address,phno from login where name="+query+"", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label7.Text = dr.GetString(0).ToString();
                label8.Text = dr.GetString(1).ToString();
                label9.Text = dr.GetString(2).ToString();
                label10.Text = dr.GetInt32(3).ToString();
                label11.Text = dr.GetString(4).ToString();
                label12.Text = dr.GetString(5).ToString();
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDetails u1 = new UserDetails(s2,"");
            u1.Show();
            this.Hide();
        }
    }
}
