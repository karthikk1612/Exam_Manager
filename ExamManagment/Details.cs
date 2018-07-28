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
    public partial class Details : Form
    {
        public String query;
        
        public Details(String str)
        {
            InitializeComponent();
            label5.Text = str;
            query = "'"+label5.Text+"'";
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select staffuname,staffpass,staffcategory from login where staffname="+query+"", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                label6.Text = dr.GetString(0).ToString();
                label7.Text = dr.GetString(1).ToString();
                label8.Text = dr.GetString(2).ToString();
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaffDetails s1 = new StaffDetails();
            s1.Show();
            this.Hide();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
