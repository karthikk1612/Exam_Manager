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
    public partial class Test : Form
    {
        public String x1,x2;
        public Test(String str,String e)
        {
            InitializeComponent();
            x1 = str;
            x2 = e;
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select questioncategory from login where questioncategory IS NOT NULL and questioncategory <> ''; ", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            foreach (DataRow questioncategory in dt.Rows)
            {
                listBox1.Items.Add(questioncategory.Field<String>(0));
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QA q1 = new QA(listBox1.Text,x1);
            q1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Userpage u1 = new Userpage(x2);
            u1.Show();
            this.Hide();
        }
    }
}
