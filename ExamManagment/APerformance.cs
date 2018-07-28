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
    public partial class APerformance : Form
    {
        public String str,query;
        public APerformance(String d)
        {
            InitializeComponent();
            str = "'" + d + "'";
            label2.Text = "0";
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select ctgr from login where uname =" + str + "", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            foreach (DataRow name in dt.Rows)
            {
                listBox1.Items.Add(name.Field<String>(0));
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage a1 = new AdminPage();
            a1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            query = "'" + listBox1.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(@"select score from login where uname=" + str + "and ctgr=" + query + "", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                label2.Text = dr.GetString(0).ToString();

            }
            conn.Close();
        }
    }
}
