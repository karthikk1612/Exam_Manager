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
    public partial class AddQuestions : Form
    {
        public int count;
        
        public AddQuestions()
        {
            InitializeComponent();
            listBox2.Hide();
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select questioncategory from login where questioncategory IS NOT NULL and questioncategory <> ''; ", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            foreach(DataRow questioncategory in dt.Rows)
            {
                listBox1.Items.Add(questioncategory.Field<String>(0));
            }
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            count = counts();
            String str = "'" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','"+listBox1.Text.ToString()+"',"+count+"";
            SqlCommand cmd = new SqlCommand(@"insert into login(question,option1,option2,option3,option4,answer,category,Qno) values(" + str + ");", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Question Added");
            clear();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPage a1 = new AdminPage();
            a1.Show();
            this.Hide();
        }
        public int counts()
        {
            int a = 1;
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database= ExamManager;Integrated Security =true");
            conn.Open();
            String query = "'" + listBox1.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand("select Qno from login where category="+query+"", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            foreach (DataRow Qno in dt.Rows)
            {
                listBox2.Items.Add(Qno.Field<Int32>(0));
                a = listBox2.Items.Count;
                a++;
            }
            
            return a;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
