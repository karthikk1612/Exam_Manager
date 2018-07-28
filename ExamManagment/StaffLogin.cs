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
    public partial class StaffLogin : Form
    {
        public String query;
        public StaffLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            query = "'"+textBox1.Text+"'";
            SqlCommand cmd = new SqlCommand("select staffpass from login where staffuname="+query+"", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if ((textBox2.Text.ToString() == dr.GetString(0).ToString()))
                {
                    StaffPage s1 = new StaffPage(textBox1.Text.ToString());
                    s1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Form1 f1 = new ExamManagment.Form1();
            f1.Show();
            this.Hide();
        }
    }
}
