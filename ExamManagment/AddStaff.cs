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
    public partial class AddStaff : Form
    {
        public AddStaff()
        {
            InitializeComponent();
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

        private void label2_Click(object sender, EventArgs e)
        {

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
            String str= "'"+textBox1.Text.ToString()+"','"+textBox2.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+listBox1.Text.ToString()+"'";
            SqlCommand cmd = new SqlCommand(@"insert into login(staffname,staffuname,staffpass,staffcategory) values("+str+")",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Staff Added Succesfully...!!");
            AdminPage a1 = new AdminPage();
            a1.Show();
            this.Hide();

        }
    }
}
