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
    public partial class UserLogin : Form
    {
        public String query;
        public UserLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            query = "'" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand("select password,status from login where username="+query+"", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if ((textBox2.Text.ToString() == dr.GetString(0).ToString()))
                {
                
                    if ("Approved" == dr.GetString(1).ToString())
                    {
                        
                        Userpage s1 = new Userpage(textBox1.Text);
                        s1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Verification Pending!");
                    }
                    }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserRegister u1 = new UserRegister();
            u1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}