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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from login where adminusername='admin' ", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if ((textBox1.Text.ToString() == dr.GetString(0).ToString()) && (textBox2.Text.ToString() == dr.GetString(1).ToString()))
                {
                    AdminPage a1 = new AdminPage();
                    a1.Show();
                    this.Hide();
                }

            }
            conn.Close();
        }
    }
    }

